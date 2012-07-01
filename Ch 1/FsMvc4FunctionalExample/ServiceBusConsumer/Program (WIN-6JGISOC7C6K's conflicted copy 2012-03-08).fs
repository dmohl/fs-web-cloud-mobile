open Messages
open System

printfn "Waiting for a message"

let queueToDispose = 
    SimpleBus.Subscribe<CreateGuitarCommand> "sample_queue" 
        (fun cmd -> 
            printfn "A request for a new Guitar with name %s was consumed" cmd.Name) 
    
printfn "Press any key to quite\r\n"
Console.ReadLine() |> ignore
queueToDispose.Dispose()

