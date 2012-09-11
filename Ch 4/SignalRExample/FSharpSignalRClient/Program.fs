module SignalRExample

open System
open SignalR.Client

let connection = 
    Connection "http://localhost:2920/chartserver"

connection.Start().Wait()

connection.Send "F#" 
|> Async.AwaitIAsyncResult 
|> Async.Ignore 
|> ignore

connection.Stop() |> ignore

printfn "Vote cast for F#"
Console.ReadLine() |> ignore

