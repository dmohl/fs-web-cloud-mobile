namespace FsWeb.Controllers

open System
open System.Web.Mvc
open FsWeb.Models
open FsWeb.Repositories
open Repository
open Utils
open PublishMonad

[<HandleError>]
type GuitarsController(context:IDisposable, ?repository) =    
    inherit Controller()    

    let fromRepository =
        match repository with 
        | Some v -> v 
        | _ -> (context :?> FsMvcAppEntities).Guitars 
               |> Repository.Get

    new() = new GuitarsController(new FsMvcAppEntities())

    member this.Index () =
        GetAll() |> fromRepository <| WithCacheKeyOf("AllGuitars")
        |> this.View 

    [<HttpGet>] 
    member this.Create () =
        this.View() 
    
    [<HttpPost>] 
    member this.Create (guitar : Guitar) =
        match base.ModelState.IsValid  with
        | false -> guitar |> this.View |> asActionResult
        | true -> 
            publish {
                do! SendMessageWith("sample_queue", 
                     {Messages.CreateGuitarCommand.Name = guitar.Name})
            }             
            base.RedirectToAction("Index") |> asActionResult
    
    override x.Dispose disposing =
        context.Dispose()
        base.Dispose disposing


//let isNameValid = Utils.NullCheck(guitar.Name).IsSome && not (guitar.Name.Contains("broken"))
//match base.ModelState.IsValid, isNameValid with
//| false, false | true, false | false, true -> 
//	upcast this.View guitar
//| _ -> upcast base.RedirectToAction("Index") 

//module test = 
//    #r "System.Data.Services.Client"
//    #r "FSharp.Data.TypeProviders.dll"
// 
//    open Microsoft.FSharp.Data.TypeProviders
//    open System
//    open System.ComponentModel.DataAnnotations
//
//    type Guitar() = 
//        member val Id = Guid.NewGuid() with get, set
//        member val Name = "" with get, set
//
//    type DbConnection = 
//        SqlDataConnection<ConnectionString="Data Source=.\SQL2K8;Initial Catalog=FsMvcAppExample;Integrated Security=SSPI;"> 
//
//    type GuitarsRepository2() =
//        member x.GetAll () = 
//            use context = DbConnection.GetDataContext()
//            query { for g in context.Guitars do
//                    select (Guitar(Id = g.Id, Name = g.Name)) }
//            |> Seq.toList 
//
//    let repo = new GuitarsRepository2()
//
//    repo.GetAll() |> Seq.iter (fun g -> printfn "%s" g.Name)