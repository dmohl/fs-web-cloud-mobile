open System
open System.Net
open System.Net.Http
open System.Web.Http
open System.Web.Http.SelfHost
open Frank

let values request =
    respond HttpStatusCode.OK 
        <| new StringContent(["values1"; "values2"].ToString()) 
        <| ignore
    |> async.Return

let value request = 
    let id = getParam request "id" 
    respond HttpStatusCode.OK 
        <| new StringContent(sprintf "The value is %s" id) 
        <| ignore
    |> async.Return 

let delValue request = 
    new HttpResponseMessage() |> async.Return

let app = merge [ route "/api/values" <| get values 
                  route "/api/values/{id}" <| (get value <|> delete delValue)] 
          |> Middleware.log

module HostServer = 
    let Main args =
        let baseUri = "http://localhost:9393"
        use config = new HttpSelfHostConfiguration(baseUri)
        config.Register app

        use server = new HttpSelfHostServer(config)
        server.OpenAsync().Wait()

        printfn "The service is running at %s..." baseUri
        Console.ReadKey() |> ignore
        server.CloseAsync().Wait()

    Main () 
        