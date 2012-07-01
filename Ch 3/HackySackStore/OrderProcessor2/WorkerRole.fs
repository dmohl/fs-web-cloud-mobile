namespace OrderProcessor2

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

type WorkerRole() =
    inherit RoleEntryPoint() 

    let log message kind = Trace.WriteLine(message, kind)

    override wr.Run() =
        log "OrderProcessor2 entry point called" "Information"
        try
            Fog.ServiceBus.Subscribe "Orders" "OrderProcessor"
                <| fun m -> 
                     let entity = m.GetBody<PlaceOrderCommand>()
                     Fog.Storage.Table.CreateEntity "HackySackOrders" entity
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
