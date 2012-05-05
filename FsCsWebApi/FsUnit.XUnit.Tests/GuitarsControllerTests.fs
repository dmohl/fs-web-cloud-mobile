module ``When getting all guitars``

open System
open System.Linq
open FsWeb.Controllers
open FsWeb.Models
open FsUnit.Xunit
open Xunit

type Guitar = dbContext.ServiceTypes.Guitars

let expectedGuitar = Guitar(Id = Guid.NewGuid(), Name = "test1")

let fakeRepository =
    [| expectedGuitar
       Guitar(Id = Guid.NewGuid(), Name = "test2")
       Guitar(Id = Guid.NewGuid(), Name = "test3") |]
    |> Queryable.AsQueryable
    |> Repository.Get

let context = { new Object() 
                    interface IDisposable with 
                        member x.Dispose() = () }

let controller = new GuitarsController(context, fakeRepository)
let result = controller.Get()

[<Fact>]
let ``it should have a count of three``() =
    result |> Seq.length |> should equal 3

[<Fact>]
let ``it should contain a specific guitar record``() =
    result |> should contain expectedGuitar
