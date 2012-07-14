namespace FsWeb.Controllers

open System.Linq
open System.Web
open System.Web.Mvc
open FsWeb.Models
open Raven.Client.Document

[<HandleError>]
type HomeController() =
    inherit Controller()

    let ravenUrl = "http://localhost:8080/"

    let executeRavenAction action = 
        use store = new DocumentStore()
        store.Url <- ravenUrl
        store.Initialize() |> ignore
        use session = store.OpenSession()
        action session        

    member this.Index () =
        executeRavenAction
        <| fun session -> session.Query<Contact>().ToList()
        |> this.View

    [<HttpGet>] 
    member this.Create () =
        this.View() 
    
    [<HttpPost>]      
    member this.Create (contact:Contact) =     
        if base.ModelState.IsValid then   
            executeRavenAction
            <| fun session -> 
                 session.Store contact
                 session.SaveChanges()
            this.RedirectToAction("Index") :> ActionResult
        else
            this.View() :> ActionResult
