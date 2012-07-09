namespace FsWeb.Controllers

open System.Linq
open System.Web
open System.Web.Mvc
open FsWeb.Models

[<HandleError>]
type HomeController() =
    inherit Controller()

    let contacts = 
        createLocalMongoServer()
        |> getMongoDatabase "contactDb"
        |> getMongoCollection "contacts"

    member this.Index () =
        contacts.FindAll().ToList() |> this.View

    [<HttpGet>] 
    member this.Create () =
        this.View() 
    
    [<HttpPost>]      
    member this.Create (contact:Contact) =     
        if base.ModelState.IsValid then   
            contact |> contacts.Insert |> ignore
            this.RedirectToAction("Index") :> ActionResult
        else
            this.View() :> ActionResult
