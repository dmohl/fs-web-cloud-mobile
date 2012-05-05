open System
open System.Net.Http
open System.Json

let client = new HttpClient()

//async {
//    try
//        let! res = Async.AwaitTask 
//                   <| client.GetAsync("http://localhost:5551/api/values/3")
//        res.EnsureSuccessStatusCode() |> ignore
//        let! content = Async.AwaitTask <| res.Content.ReadAsStringAsync()
//        printfn "The result is %s" content
//    with
//    | ex -> printfn "%s" ex.Message
//} |> Async.Start


let task = async {
    let! res = Async.AwaitTask 
               <| client.GetAsync("http://localhost:5551/api/values/3")
    res.EnsureSuccessStatusCode() |> ignore
    return! Async.AwaitTask <| res.Content.ReadAsAsync<JsonValue>()
} 

Async.StartWithContinuations(
    task, 
    (fun v -> printfn "The returned value is %s" <| v.ToString()), 
    (fun err -> 
        printfn "The request was NOT successful with error %s" err.Message),
    (fun canc -> printfn "The request was cancelled")) 

printfn "Please Wait..."
Console.ReadKey() |> ignore