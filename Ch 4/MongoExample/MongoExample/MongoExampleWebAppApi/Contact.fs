namespace FsWeb.Models

open MongoDB.Bson
open System.ComponentModel.DataAnnotations

[<CLIMutable>]
type Contact = {
    _id : ObjectId
    [<Required>] FirstName : string
    [<Required>] LastName : string
    [<Required>] Phone : string
}
