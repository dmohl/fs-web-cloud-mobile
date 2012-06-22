module WebSocketServer

open System
open System.Web
open System.Collections.Generic
open Microsoft.Web.WebSockets
open Newtonsoft.Json

let mutable clients = WebSocketCollection()

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

type WebSocketChartHandler() =
    inherit WebSocketHandler()
    
    override x.OnOpen() = clients.Add x            
    override x.OnMessage(language:string) =  
        let v = votesAgent.PostAndReply(fun reply -> Message.Vote(language, reply))   
        v |> Seq.map(fun v -> { language = fst v; count = snd v } )
        |> JsonConvert.SerializeObject 
        |> clients.Broadcast
    override x.OnClose() =
        clients.Remove x |> ignore
