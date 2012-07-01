module SignalRExample

open System
open SignalR
open SignalR.Hosting.Self
open Newtonsoft.Json
open SignalR.Hubs
open ImpromptuInterface
open ImpromptuInterface.FSharp
open System.Diagnostics

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

type ChartHub() =
    inherit Hub()
    member x.Send (data:string) = 
       let result = 
           votesAgent.PostAndReply(fun reply -> Message.Vote(data, reply))   
           |> Seq.map(fun v -> { language = fst v; count = snd v } )
       try
           base.Clients?updateChart(result)
       with
       | ex -> 
           printfn "%s" ex.Message

let server = Server "http://*:8181/"
server.MapHubs() |> ignore

server.Start()

printfn "Now listening on port 8181"
Console.ReadLine() |> ignore
