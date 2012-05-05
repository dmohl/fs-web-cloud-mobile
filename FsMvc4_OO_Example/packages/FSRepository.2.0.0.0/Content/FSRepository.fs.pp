namespace $rootnamespace$.Repositories

open System
open System.Collections.Generic
open System.Data.Entity

type ASample() =
    let mutable id = 0
    let mutable createdBy = ""
    let mutable created = DateTime.Now
    member x.Id with get() = id and set(v) = id <- v
    member x.CreatedBy with get() = createdBy and set(v) = createdBy <- v
    member x.Created with get() = created and set(v) = created <- v

type MyApplicationEntities() = 
    // replace "MyApplicationName" with whatever you want the database name to be
    inherit DbContext("MyApplicationName")

    // If you want Entity Framework to drop and regenerate your database automatically whenever you change
    // your model schema, add the following line to the Application_Start() method in Global.asax.cs:
    //do DbDatabase.SetInitializer(new DropCreateDatabaseIfModelChanges<MyApplicationEntities>());

    [<DefaultValue(true)>] val mutable samples : DbSet<ASample>
    member x.Samples with get() = x.samples and set(v) = x.samples <- v
    // Add a new DbSet for each entity that should be persisted to the data store 

type SampleRepository() =
    let context = new MyApplicationEntities()
    member x.GetAll() = context.Samples |> Seq.cast
    member x.GetById id = context.Samples.Find(id)
    member x.Add item = 
        context.Samples.Add item |> ignore
    member x.Delete id =
        context.Samples.Find(id)
        |> context.Samples.Remove 
        |> ignore
    member x.Save() = context.SaveChanges() |> ignore
    interface IDisposable with
        member x.Dispose() = context.Dispose()