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
    let rec loop votes =
        async {
            let! message = inbox.Receive()
            match message with
            | Vote(language, replyChannel) -> 
                let newVotes = language::votes 
                newVotes
                |> Seq.countBy(fun lang -> lang)
                |> replyChannel.Reply 
                do! loop(newVotes) 
            do! loop votes 
        }
    loop List.empty)

type WebSocketChartHandler() =
    inherit WebSocketHandler()
    
    override x.OnOpen() = clients.Add x            
    override x.OnMessage(language:string) =  
        votesAgent.PostAndReply(fun reply -> Message.Vote(language, reply))   
        |> Seq.map(fun v -> { language = fst v; count = snd v } )
        |> JsonConvert.SerializeObject 
        |> clients.Broadcast
    override x.OnClose() =
        clients.Remove x |> ignore
