open System
open ServiceStack.ServiceHost
open ServiceStack.WebHost.Endpoints
open ServiceStack.ServiceInterface

[<RestService("/api/values/{Id}")>]
type ValueRequest = { mutable Id : int }

type ValueResponse = { mutable Result : string }

type ValuesService() =
    inherit RestServiceBase<ValueRequest>()
    override x.OnGet request = 
        { Result = sprintf "The value is %i" request.Id } |> box
 
type AppHost() =
    inherit AppHostHttpListenerBase("ValuesService", 
                                    typeof<ValuesService>.Assembly)
    override this.Configure container = ()

module ServiceHost =
    let Main args =
        use appHost = new AppHost()
        appHost.Init()
        appHost.Start "http://localhost:9090/"
        printfn "The service has started on port 9090"
        Console.ReadLine() |> ignore

    Main ()

