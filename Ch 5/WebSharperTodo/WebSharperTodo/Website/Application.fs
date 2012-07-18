namespace Website.Helpers

open System.Web.Mvc

type DataBoundViewPage() =
    inherit ViewPage()

    override this.OnLoad e =
        base.OnLoad e
        this.DataBind()
        
namespace Website

open System
open System.Web
open System.Web.Mvc
open System.Web.Routing
open IntelliFactory.WebSharper

type DataBoundViewPage() =
    inherit ViewPage()

    override this.OnLoad e =
        base.OnLoad e
        this.DataBind()

type RouteInformation =
    {
        controller: string
        action: string
    }

type Application() =
    inherit HttpApplication()

    static member RegisterRoutes(routes : RouteCollection) =
        routes.IgnoreRoute("{resource}.axd/{*pathInfo}")

        routes.MapRoute(
            "Default", // Route name
            "{controller}/{action}", // URL with parameters
            { controller = "Home"; action = "Index"} // Parameter defaults
            )

    member this.Start() = 
        Application.RegisterRoutes(RouteTable.Routes) |> ignore
