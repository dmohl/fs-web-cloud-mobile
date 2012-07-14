namespace FsWeb.Models

open System.ComponentModel.DataAnnotations

[<CLIMutable>]
type Contact = {
    Id : string
    [<Required>] FirstName : string
    [<Required>] LastName : string
    [<Required>] Phone : string
}
