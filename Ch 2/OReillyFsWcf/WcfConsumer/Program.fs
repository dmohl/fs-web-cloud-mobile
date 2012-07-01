open System.ServiceModel
open Microsoft.FSharp.Data.TypeProviders

type webService = WsdlService<"http://localhost:1555/Service1.svc?wsdl">

// This would be moved to a config file
let serviceUri = "http://localhost:1555/Service1.svc"

let client = new EndpointAddress(serviceUri) 
             |> webService.GetBasicHttpBinding_IService1

seq {1 .. 20}
|> Seq.map (fun i ->
    async {
        let! result = Async.AwaitTask <| client.GetDataAsync i
        do printfn "The result was %s" result
    })
|> Async.Parallel 
|> Async.Ignore
|> Async.RunSynchronously

let obj = new webService.ServiceTypes.FSharpWcfServiceApplicationTemplate.Contracts.CompositeType(BoolValue=true, StringValue="test")

try
  printfn "The result was %O" <| (client.GetDataUsingDataContract obj).StringValue
with
| ex -> printfn "%s" ex.InnerException.Message

open FSharpWcfServiceApplicationTemplate.Contracts

// This would be moved to a config file
let serviceUri2 = "http://localhost:1555/Service1.svc"

let address = new EndpointAddress(serviceUri2)
let binding = new BasicHttpBinding()
let factory = new ChannelFactory<IService1>(binding, address)
let channel = factory.CreateChannel()
let clientChannel = channel :?> IClientChannel

let executeOperation action = 
    try
        let enableLogging = true
        try
            action()
            clientChannel.Close()
        with
        | :? FaultException as fexl when enableLogging -> printfn "Fault: %s" fexl.Message
        | :? FaultException as fex -> printfn "Fault: %s" fex.Message
        | ex -> printfn "Error: %s" ex.Message
    finally
        if clientChannel.State <> CommunicationState.Closed then
            clientChannel.Abort()
        clientChannel.Dispose()

executeOperation (fun () -> printfn "The result was %s" 
                            <| channel.GetData 100)
