module ``Given a GuitarsController``

open System
open System.Linq
open FsWeb.Controllers
open FsWeb.Models
open Swensen.Unquote
open Xunit

type Guitar = dbContext.ServiceTypes.Guitars

let fakeRepository =
    [| Guitar(Id = Guid.NewGuid(), Name = "test1")
       Guitar(Id = Guid.NewGuid(), Name = "test2")
       Guitar(Id = Guid.NewGuid(), Name = "test3") |]
    |> Queryable.AsQueryable
    |> Repository.Get

let context = { new Object() 
                    interface IDisposable with 
                        member x.Dispose() = () }

let controller = new GuitarsController(context, fakeRepository)

[<Fact>]
let ``When getting the guitars from the repo it should have a count of three``() =
    test <@ controller.Get() |> Seq.length = 3 @>


