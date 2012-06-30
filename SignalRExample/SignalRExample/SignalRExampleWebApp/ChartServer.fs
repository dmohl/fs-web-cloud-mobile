module SignalRExample

open System
open SignalR
open Newtonsoft.Json

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

type ChartServer() =
    inherit PersistentConnection()

    override x.OnReceivedAsync(request, connectionId, data) = 
        votesAgent.PostAndReply(fun reply -> Message.Vote(data, reply))   
        |> Seq.map(fun v -> { language = fst v; count = snd v } )
        |> JsonConvert.SerializeObject 
        |> base.Connection.Broadcast

