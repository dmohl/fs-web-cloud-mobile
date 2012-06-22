module FsFleckServer

open System
open System.Collections.Generic
open Fleck
open Newtonsoft.Json

type VoteCounts = { language : string; count : int }  
     
type Message = 
    | Vote of string * AsyncReplyChannel<seq<string*int>>

let votesAgent = MailboxProcessor.Start(fun inbox ->
    let rec loop(votes:List<string>) =
        async {
            let! message = inbox.Receive()
            match message with
            | Vote(language, replyChannel) -> 
                votes.Add language
                votes 
                |> Seq.countBy(fun v -> v)
                |> replyChannel.Reply 
                do! loop(votes) 
            do! loop votes
        }
    loop (new List<string>()))

let main() = 
    FleckLog.Level <- LogLevel.Debug
    let clients = List<IWebSocketConnection>()
    use server = new WebSocketServer "ws://localhost:8181"

    let socketOnOpen socket = clients.Add socket

    let socketOnClose socket = clients.Remove socket |> ignore

    let socketOnMessage language = 
        let results = 
            votesAgent.PostAndReply(fun reply -> Message.Vote(language, reply))   
            |> Seq.map(fun v -> { language = fst v; count = snd v } )
            |> JsonConvert.SerializeObject 
        clients |> Seq.iter(fun c -> c.Send results)

    server.Start(fun socket ->
                    socket.OnOpen <- fun () -> socketOnOpen socket
                    socket.OnClose <- fun () -> socketOnClose socket
                    socket.OnMessage <- fun message -> socketOnMessage message)
    
    Console.ReadLine() |> ignore

main()
