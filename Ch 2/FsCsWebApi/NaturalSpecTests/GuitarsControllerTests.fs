module GuitarsControllerTests

open System
open System.Linq
open FsWeb.Controllers
open NaturalSpec

type Guitar = dbContext.ServiceTypes.Guitars

let expectedGuitar = Guitar(Id = Guid.NewGuid(), Name = "test1")

let fakeRepository =
    [| expectedGuitar
       Guitar(Id = Guid.NewGuid(), Name = "test2")
       Guitar(Id = Guid.NewGuid(), Name = "test3") |]
    |> Queryable.AsQueryable
    |> Repository.get

let context = { new Object() 
                    interface IDisposable with 
                        member x.Dispose() = () }

let a_GuitarController = new GuitarsController(context, fakeRepository)

let getting_all_guitars (c:GuitarsController) = c.Get() 

[<Scenario>]
let ``When getting all the guitars from the repository``() =
  Given a_GuitarController
    |> When getting_all_guitars        
    |> It should have (length 3)     
    |> It should contain expectedGuitar          
    |> Verify                  
    
//[<Scenario>]
//let ``When removing an element from a list it should not contain the element``() =
//  Given [1;2;3;4;5]                 // "Arrange" test context
//    |> When removing 3              // "Act"
//    |> It shouldn't contain 3       // "Assert"
//    |> It should contain 4          // another assertion
//    |> Verify            