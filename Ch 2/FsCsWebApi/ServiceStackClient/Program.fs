open System
open ServiceStack.ServiceClient.Web

type ValueResponse = { mutable Result : string }

let client = new JsonServiceClient("http://localhost:9090")
client.GetAsync<ValueResponse>("/api/values/1",
    (fun r -> printfn "Result is %s" r.Result),
    (fun r ex -> raise ex) )

printfn "Please Wait..."
Console.Read() |> ignore