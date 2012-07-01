namespace FsWeb.Repositories

open Microsoft.WindowsAzure.ServiceRuntime
open System.Data.Entity
open FsWeb.Commands

type HackySackStoreEntities() = 
    inherit DbContext(
        RoleEnvironment.GetConfigurationSettingValue 
        <| "HackySackStoreConnectionString")

    do Database.SetInitializer(
        CreateDatabaseIfNotExists<HackySackStoreEntities>())

    [<DefaultValue(true)>] val mutable orderCommands : DbSet<PlaceOrderCommand>
    member x.OrderCommands 
        with get() = x.orderCommands and set v = x.orderCommands <- v