open System
open Nancy
open Nancy.Hosting.Self

let GetNancyParam prms key = (prms :> DynamicDictionary).[key]

type System.String with
    static member toNancyResponse (s:string) = Response.op_Implicit s

type ValuesModule() =
    inherit NancyModule()
    let getResponse v = v |> sprintf "The response is %A" 
                        |> String.toNancyResponse
    do base.Get.["/api/values"] <- 
        fun _ -> ["value1", "value2"] |> getResponse 
    do base.Get.["/api/values/{id}"] <- 
        fun prms -> GetNancyParam (unbox prms) "id" |> getResponse 

let host = NancyHost( Uri "http://localhost:9191" ) 
host.Start()

printfn "The service is running on port 9191..."
Console.ReadKey() |> ignore

host.Stop()

