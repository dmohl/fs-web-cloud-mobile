namespace FsWeb

open System
open System.Web
open System.Web.Mvc
open System.Web.Routing
open System.Web.Http
open System.Data.Entity
open System.Web.Optimization

type Route = { controller : string
               action : string
               id : UrlParameter }

type MapHttpRouteSettings = { id : obj }

type Global() =
    inherit System.Web.HttpApplication() 

    static member RegisterGlobalFilters(filters:GlobalFilterCollection) =
        filters.Add(new HandleErrorAttribute())

    static member RegisterRoutes(routes:RouteCollection) =
        routes.IgnoreRoute("{resource}.axd/{*pathInfo}")

        routes.MapHttpRoute("DefaultApi", "api/{controller}/{id}", 
            {id = RouteParameter.Optional}) |> ignore

        routes.MapRoute("Default", 
                        "{controller}/{action}/{id}", 
                        { controller = "Home"; action = "Index"
                          id = UrlParameter.Optional } )

    member this.Start() =
        AreaRegistration.RegisterAllAreas()

//        // Use LocalDB for Entity Framework by default
//        Database.DefaultConnectionFactory = new SqlConnectionFactory("Data Source=(localdb)\v11.0; Integrated Security=True; MultipleActiveResultSets=True");
//
        Global.RegisterGlobalFilters(GlobalFilters.Filters)
        Global.RegisterRoutes(RouteTable.Routes) |> ignore

        BundleTable.Bundles.RegisterTemplateBundles();
