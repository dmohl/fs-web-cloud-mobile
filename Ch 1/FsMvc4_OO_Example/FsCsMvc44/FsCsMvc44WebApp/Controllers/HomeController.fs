namespace FsWeb.Controllers

open System.Web
open System.Web.Mvc

[<HandleError>]
type HomeController() =
    inherit Controller()
    member this.Index () : ActionResult =
        upcast this.View()
