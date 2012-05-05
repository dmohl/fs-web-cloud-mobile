namespace FsWeb.Repositories

open System
open System.Linq

module Repository =
    let WithCacheKeyOf key = Some key 

    let DoNotUseCache = None 

    let Get (source:IQueryable<_>) queryFn cacheKey = 
        let cacheResult = 
            match cacheKey with
            | Some key -> CacheAgent.Get<'a list> key
            | None -> None

        match cacheResult, cacheKey with
        | Some result, _ -> result 
        | None, Some cacheKey -> 
                let result = queryFn source |> Seq.toList 
                CacheAgent.Set cacheKey result
                result           
        | _, _ -> queryFn source |> Seq.toList 

    let GetAll () =
        fun s -> query { for x in s do
                         select x }
    
    let Find filterPredFn =
        filterPredFn
        |> fun fn s -> query { for x in s do
                               where (fn()) }
    
    let GetTop rowCount =
        rowCount
        |> fun cnt s -> query { for x in s do
                                take cnt }     
        