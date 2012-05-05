namespace FsWeb.Repositories

open System.Data.Entity
open FsWeb.Models

type FsMvcAppEntities() = 
    inherit DbContext("FsMvcAppExample")

    do Database.SetInitializer(new CreateDatabaseIfNotExists<FsMvcAppEntities>())

    [<DefaultValue(true)>] val mutable guitars : DbSet<Guitar>
    member x.Guitars with get() = x.guitars and set v = x.guitars <- v
