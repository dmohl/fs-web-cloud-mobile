namespace FsWeb.Models

open System.ComponentModel.DataAnnotations

[<CLIMutable>]
type Contact = {
    [<Required>] FirstName : string
    [<Required>] LastName : string
    [<Required>] Phone : string
}
