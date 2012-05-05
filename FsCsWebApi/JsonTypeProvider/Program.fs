open System
open System.Net.Http
open FSharpx

type itunesApi = StructuredJSON<FileName="itunesSample.json">

let client = new HttpClient()

async {
    let! res = Async.AwaitTask 
                <| client.GetAsync(
                       "http://itunes.apple.com/search?term=guitar&limit=5")
    let! content = Async.AwaitTask <| res.Content.ReadAsStringAsync()
    let root = itunesApi().Root
    printfn "%i results were found." root.ResultCount

    root.GetResultsElements() 
    |> Seq.iter(fun x -> 
           printfn "Artist Name is '%s' and Colletion Name is '%s'" 
               x.ArtistName x.CollectionName)
} |> Async.Start

printfn "Please Wait..."
Console.ReadKey() |> ignore