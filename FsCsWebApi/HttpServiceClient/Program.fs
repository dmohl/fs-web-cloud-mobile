open System
open System.Net.Http
open Newtonsoft.Json

type Response() =  
    member val Results : string[] = [||] with get, set

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
               <| client.GetAsync("http://localhost:1232/api/values/3")
    res.EnsureSuccessStatusCode() |> ignore
    return! Async.AwaitTask <| res.Content.ReadAsStringAsync() 
} 

Async.StartWithContinuations(
    task, 
    (fun r ->       
        seq { yield "The returned values are:" }
        |> Seq.append <| JsonConvert.DeserializeObject<seq<string>>(r)
        |> Seq.reduce (fun acc v -> sprintf "%s %s" acc v)
        |> printfn "%s"),
    (fun err -> 
        printfn "The request was NOT successful with error %s" err.Message),
    (fun canc -> printfn "The request was cancelled")) 

printfn "Please Wait..."
Console.ReadKey() |> ignore