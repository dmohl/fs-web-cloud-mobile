namespace FsWeb.Controllers

open System
open System.Web.Http
open FsWeb.Models
open FsWeb.Commands
open Microsoft.ApplicationServer.Caching
open Fog.Caching

type OrdersController() =
    inherit ApiController()
    member x.Post (order:HackySackOrder) =  
       [1..order.Quantity]
       |> Seq.iter(
            fun i -> 
                async {
                    { RowKey = Guid.NewGuid().ToString()
                      PartitionKey = "Orders"
                      PlacementDateTime = DateTime.Now 
                      Quantity = order.Quantity 
                      Instance = i }
                    |> Fog.ServiceBus.Publish "Orders"
                } |> Async.Start )
