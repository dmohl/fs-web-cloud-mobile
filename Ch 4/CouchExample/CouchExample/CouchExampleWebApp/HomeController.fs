namespace FsWeb.Controllers

open System.Linq
open System.Web
open System.Web.Mvc
open FsWeb.Models
open FSharpCouch

[<HandleError>]
type HomeController() =
    inherit Controller()

    let couchUrl = "http://localhost:5984"
    let dbName = "people"

    member this.Index () =
        getAllDocuments<Contact> couchUrl dbName
        |> Seq.map(fun c -> c.body)
        |> this.View
        
    [<HttpGet>] 
    member this.Create () =
        this.View() 
    
    [<HttpPost>]      
    member this.Create (contact:Contact) =     
        if base.ModelState.IsValid then               
            contact |> createDocument couchUrl dbName |> ignore
            this.RedirectToAction("Index") :> ActionResult
        else
            this.View() :> ActionResult
