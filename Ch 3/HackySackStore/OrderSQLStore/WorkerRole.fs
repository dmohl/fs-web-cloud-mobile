namespace OrderSQLStore

open System
open System.Collections.Generic
open System.Diagnostics
open System.Linq
open System.Net
open System.Threading
open Microsoft.WindowsAzure
open Microsoft.WindowsAzure.ServiceRuntime
open Microsoft.WindowsAzure.StorageClient
open FsWeb.Commands
open FsWeb.Repositories

type WorkerRole() =
    inherit RoleEntryPoint() 

    let log message kind = Trace.WriteLine(message, kind)
    
    let handleNewOrderCommand entity = 
       try
           use context = new HackySackStoreEntities()
           context.OrderCommands.Add entity |> ignore
           context.SaveChanges() |> ignore
       with
       | ex -> 
           log ex.Message "Error"
           raise ex 

    override wr.Run() =
        log "OrderSQLStore entry point called" "Information"
        try
            Fog.ServiceBus.Subscribe "Orders" "OrderSQLStore"
                <| fun m ->                 
                     m.GetBody<PlaceOrderCommand>()
                     |> handleNewOrderCommand
                <| fun ex m -> log ex.Message "Error"
        with
        | ex -> 
            log ex.Message "Error"

        while(true) do 
            Thread.Sleep(10000)

    override wr.OnStart() = 
        // Set the maximum number of concurrent connections 
        ServicePointManager.DefaultConnectionLimit <- 12       
        // For information on handling configuration changes
        // see the MSDN topic at http://go.microsoft.com/fwlink/?LinkId=166357.
        base.OnStart()
