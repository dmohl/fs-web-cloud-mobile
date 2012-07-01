namespace FsWeb.Models

open System
open System.ComponentModel.DataAnnotations

type Guitar() = 
    [<Key>] member val Id = Guid.NewGuid() with get, set
    [<Required>] member val Name = "" with get, set

