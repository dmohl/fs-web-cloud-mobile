module SignalRExample

open System
open SignalR.Client
open System.Threading.Tasks

let connection = 
    Connection "http://localhost:8081/chartserver"

connection.Start().Wait()

async { return connection.Send "F#" }
|> Async.Ignore 
|> Async.RunSynchronously

connection.Stop() |> ignore

printfn "Vote cast for F#"
Console.ReadLine() |> ignore

