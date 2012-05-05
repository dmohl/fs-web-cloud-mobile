module PublishMonad

// Define the SendMessageWith Discriminated Union
type SendMessageWith<'a> = SendMessageWith of string * 'a

// Define the PublishBuilder builder type
type PublishBuilder() =
    member x.Bind(SendMessageWith(q, msg):SendMessageWith<_>, fn) =
        // Note: This is for illustration purposes
        //       A "real" trace would log to a file, DB, event log, etc.
        printfn "A message was sent to queue %s" q        
        SimpleBus.Publish q msg
    member x.Return(_) = true

// Create the builder-name   
let publish = new PublishBuilder()


