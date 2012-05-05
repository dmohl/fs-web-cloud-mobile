namespace FSharpWcfServiceApplicationTemplate.Contracts

open System.Runtime.Serialization
open System.ServiceModel

[<ServiceContract>]
type IService1 =
    [<OperationContract>]
    //abstract GetData: value:int -> string
    abstract GetData: v:int -> string
    [<OperationContract>]
    abstract GetDataUsingDataContract: c:CompositeType -> CompositeType

