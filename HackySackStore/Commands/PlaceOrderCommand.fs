namespace FsWeb.Commands

open System
open System.ServiceModel
open System.Runtime.Serialization
open System.Data.Services.Common
open System.ComponentModel.DataAnnotations

[<DataContract>]
[<DataServiceKey("PartitionKey", "RowKey")>]
type PlaceOrderCommand = 
    { [<DataMember>] mutable PartitionKey : string
      [<DataMember>] [<Key>] mutable RowKey : string
      [<DataMember>] mutable PlacementDateTime : DateTime
      [<DataMember>] mutable Quantity : int
      [<DataMember>] mutable Instance : int }
