module WebAppTests.Tests

open System
open FsWeb.Models
open FsWeb.Controllers
open FsWeb.Repositories
open System.Linq
open System.Web.Mvc
open Microsoft.VisualStudio.TestTools.UnitTesting

let BuildFakeRepository () =
    let data = 
        [| Guitar(Id = Guid.NewGuid(), Name="test1"); Guitar(Id=Guid.NewGuid(), Name="test") |]
        |> Queryable.AsQueryable

    data |> Repository.Get

[<TestClass>]
type TestClass() = 
    [<TestMethod>]
    member x.``Given a guitar controller with a "mock" repository it should not throw an errors`` () =
        let context = { new Object() 
                            interface IDisposable with 
                                member x.Dispose() = x.Dispose() }
        let controller = new GuitarsController(context, BuildFakeRepository())
        let model = (controller.Index() :?> ViewResult).Model :?> seq<Guitar>
        (2, model.Count()) |> Assert.AreEqual
