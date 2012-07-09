namespace FsWeb.Models

open MongoDB.Bson
open System.ComponentModel.DataAnnotations

type Contact() =
    member val _id = ObjectId.Empty with get, set
    [<Required>] member val FirstName = "" with get, set
    [<Required>] member val LastName = "" with get, set
    [<Required>] member val Phone = "" with get, set
