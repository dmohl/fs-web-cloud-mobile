module ``Given a Guitars Controller``

open System
open System.Linq
open Microsoft.VisualStudio.TestTools.UnitTesting
open FsWeb.Controllers

type Guitar = dbContext.ServiceTypes.Guitars

[<TestClass>]
type ``When getting all the guitars from the repository``() = 

    let fakeRepository =
        [| Guitar(Id = Guid.NewGuid(), Name = "test1")
           Guitar(Id = Guid.NewGuid(), Name = "test2")
           Guitar(Id = Guid.NewGuid(), Name = "test3") |]
        |> Queryable.AsQueryable
        |> Repository.get

    let context = { new Object() 
                        interface IDisposable with 
                            member x.Dispose() = x.Dispose() }

    let controller = new GuitarsController(context, fakeRepository)
    let result = controller.Get()

    [<TestMethod>]
    member x.``it should have a count of three``() =
        Assert.AreEqual(3, result |> Seq.length)
