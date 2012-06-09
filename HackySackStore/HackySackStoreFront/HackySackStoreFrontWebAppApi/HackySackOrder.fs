namespace FsWeb.Models

type HackySackOrder() =
    let mutable quantity = 0
    member x.Quantity with get() = quantity and set v = quantity <- v

