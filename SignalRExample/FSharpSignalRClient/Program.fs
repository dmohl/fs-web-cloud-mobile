module SignalRExample

open System
open SignalR.Client

let connection = 
    Connection "http://localhost:2920/chartserver"

connection.Start().Wait()

async { return connection.Send "F#" }
|> Async.Ignore 
|> Async.RunSynchronously

connection.Stop() |> ignore

printfn "Vote cast for F#"
Console.ReadLine() |> ignore

