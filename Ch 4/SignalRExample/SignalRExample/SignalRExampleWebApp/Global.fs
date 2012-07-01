namespace FsWeb

open System
open System.Web
open System.Web.Mvc
open System.Web.Routing
open SignalR
open SignalRExample

type Route = { controller : string
               action : string
               id : UrlParameter }

type Global() =
    inherit System.Web.HttpApplication() 

    static member RegisterRoutes(routes:RouteCollection) =
        routes.IgnoreRoute("{resource}.axd/{*pathInfo}")
        routes.MapRoute("Default", 
                        "{controller}/{action}/{id}", 
                        { controller = "Home"; action = "Index"
                          id = UrlParameter.Optional } )

    member this.Start() =
        // Used for the Persistent Connection example 
        RouteTable.Routes
            .MapConnection<ChartServer>("chartserver", "chartserver/{*operation}") |> ignore
        // Used for the Persistent Connection example
        AreaRegistration.RegisterAllAreas()
        Global.RegisterRoutes(RouteTable.Routes)