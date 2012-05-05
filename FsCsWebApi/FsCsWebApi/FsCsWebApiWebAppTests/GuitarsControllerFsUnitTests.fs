module ``Given a GuitarsController``

open System
open System.Linq
open Microsoft.VisualStudio.TestTools.UnitTesting
open FsWeb.Controllers
open FsWeb.Models
open FsUnit.MsTest

type Guitar = dbContext.ServiceTypes.Guitars

[<TestClass>]
type ``When getting all the guitars from the repository``() = 

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

    [<TestMethod>]
    member x.``it should have a count of three``() =
        result |> Seq.length |> should equal 3

    [<TestMethod>]
    member x.``it should contain a specific guitar record``() =
        result |> should contain expectedGuitar
