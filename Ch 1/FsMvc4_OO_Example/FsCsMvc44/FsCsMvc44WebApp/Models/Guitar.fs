//namespace FsWeb.Models

//open System.ComponentModel.DataAnnotations
//
//type GuitarType = 
//  | Accoustic
//  | Electric
//  | AccousticElectric
//  | Steel
//  | Bass

//type Guitar = { Name : string}
//

namespace FsWeb.Models

open System
open Microsoft.FSharp.Core
open System.ComponentModel.DataAnnotations

type Guitar() = 
    let mutable id = Guid.NewGuid()
    let mutable name = ""
    [<Key>]
    member x.Id with get() = id and set v = id <- v
    [<Required>] member x.Name with get () = name and set v = name <- v

type Guitar2() = 
    [<Required>] member val Name  = "" with get, set
