module SimpleBus

open System
open System.Messaging

let private createQueueIfMissing (queueName:string) =
    if not (MessageQueue.Exists queueName) then
        MessageQueue.Create queueName |> ignore

let private parseQueueName (queueName:string) =             
    let fullName = match queueName.Contains("@") with
                   | true when queueName.Split('@').[1] <> "localhost" -> 
                       queueName.Split('@').[1] + "\\private$\\" + 
                           queueName.Split('@').[0]
                   | _ -> ".\\private$\\" + queueName
    createQueueIfMissing fullName
    fullName

let Subscribe<'a> queueName success failure =     
    let queue = new MessageQueue(parseQueueName queueName)

    queue.ReceiveCompleted.Add( 
        fun (args) ->     
            try        
                args.Message.Formatter <- new BinaryMessageFormatter() 
                args.Message.Body :?> 'a |> success
            with
            | ex -> failure ex args.Message.Body
            queue.BeginReceive() |> ignore)

    queue.BeginReceive() |> ignore
    queue

let Publish queueName message =     
    use queue = new MessageQueue(parseQueueName queueName)
    new Message(message, new BinaryMessageFormatter())
    |> queue.Send
