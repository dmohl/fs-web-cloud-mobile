open System
open System.Net.Http

let client = new HttpClient()

async {
    let! res = Async.AwaitTask 
                <| client.GetAsync("http://localhost:9191/api/values/3")
    let! content = Async.AwaitTask <| res.Content.ReadAsStringAsync()
    printfn "%s" content
} |> Async.Start

printfn "Please Wait..."
Console.ReadKey() |> ignore