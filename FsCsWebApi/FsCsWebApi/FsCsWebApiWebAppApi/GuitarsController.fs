namespace FsWeb.Controllers

open System
open System.Web.Http
open Microsoft.FSharp.Data.TypeProviders
open FsWeb.Models
open Repository 

type dbContext = SqlDataConnection<ConfigFile="Web.config", 
                                   ConnectionStringName="FsMvcAppExample">

type DataContext = dbContext.ServiceTypes.SimpleDataContextTypes.FsMvcAppExample

type GuitarsController(context:IDisposable, ?repository) =    
    inherit ApiController()

    let fromRepository =
        match repository with 
        | Some v -> v 
        | _ -> (context :?> DataContext).Guitars |> Get

    new() = new GuitarsController(dbContext.GetDataContext())

    // GET /api/guitars
    member x.Get() = 
        GetAll() |> fromRepository |> List.toSeq

    override x.Dispose disposing =
        context.Dispose()
        base.Dispose disposing
