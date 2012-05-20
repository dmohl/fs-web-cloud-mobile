namespace FsWeb.Controllers

open System.Web
open System.Web.Mvc
open Microsoft.IdentityModel.Claims
open System.Threading

[<HandleError>]
type HomeController() =
    inherit Controller()
    member this.Index () =
        let claimsIdentity = Thread.CurrentPrincipal.Identity :?> ClaimsIdentity
        claimsIdentity.Claims
        |> Seq.filter(fun c -> c.ClaimType = ClaimTypes.Email)
        |> Seq.map(fun c -> c.Value)
        |> Seq.head
        |> function 
           | v when v.Contains("@gmail.com") ->
               this.ViewData.["Claims"] <-
                   claimsIdentity.Claims 
                   |> Seq.fold(
                          fun acc c -> acc + 
                                       sprintf "Type: %s - Value: %s\r\n" 
                                           c.ClaimType c.Value) "" 
           | _ -> ()
        this.View() :> ActionResult
