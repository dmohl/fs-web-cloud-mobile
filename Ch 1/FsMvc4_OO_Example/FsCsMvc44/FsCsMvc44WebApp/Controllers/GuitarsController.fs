namespace FsWeb.Controllers

open System.Web.Mvc
open FsWeb.Models
open FsWeb.Repositories

[<HandleError>]
type GuitarsController(repository : GuitarsRepository) =
    inherit Controller()
    new() = new GuitarsController(GuitarsRepository())
    member this.Index () =
        repository.GetAll()
        |> this.View :> ActionResult    
    [<HttpGet>] 
    member this.Create () =
        this.View() :> ActionResult
    [<HttpPost>] 
    member this.Create (guitar : Guitar) : ActionResult =
        // Do something with the newly guitar
        match base.ModelState.IsValid with
        | false -> upcast this.View guitar 
        | true -> upcast base.RedirectToAction("Index") 

//
//namespace FsWeb.Controllers
//
//open System.Web
//open System.Web.Mvc
//open FsWeb.Models
//
//[<HandleError>]
//type GuitarsController() =
//    inherit Controller()
//    member this.Index () =
//        // While this is hardcoded for the current example, it will ultimately 
//        // be modified to 
////        seq { yield {Name="Gibson Les Paul"}
////              yield {Name="Martin D28"} }
//        seq { yield Guitar(Name="Gibson Les Paul")
//              yield Guitar(Name="Martin D-28") }
//        |> this.View :> ActionResult    
//    [<HttpGet>] 
//    member this.Create () =
//        this.View() :> ActionResult
//    [<HttpPost>] 
//    member this.Create (guitar : Guitar) : ActionResult =
//        // Do something with the newly guitar
//        match base.ModelState.IsValid with
//        | false -> upcast this.View guitar 
//        | true -> upcast base.RedirectToAction("Index") 
