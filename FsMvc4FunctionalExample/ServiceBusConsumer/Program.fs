open Messages
open System

printfn "Waiting for a message"

let queueToDispose = 
    SimpleBus.Subscribe<CreateGuitarCommand> "sample_queue" 
        (fun cmd -> 
            printfn "A message for a new guitar named %s was consumed" cmd.Name)
        (fun (ex:Exception) o -> 
            printfn "An exception occurred with message %s" ex.Message)     
    
printfn "Press any key to quite\r\n"
Console.ReadLine() |> ignore
queueToDispose.Dispose()

