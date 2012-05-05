module Repository 

open System
open System.Linq

let Get (source:IQueryable<_>) queryFn = 
    queryFn source |> Seq.toList 

let GetAll () =
    fun s -> query { for x in s do
                     select x }
        