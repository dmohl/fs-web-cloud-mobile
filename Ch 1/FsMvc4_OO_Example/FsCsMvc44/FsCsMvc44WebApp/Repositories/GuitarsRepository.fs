namespace FsWeb.Repositories

open Microsoft.FSharp.Linq.Query

type GuitarsRepository() =
    member x.GetAll () = 
        let context = new FsMvcAppEntities() 
        query <@ seq { for g in context.Guitars do yield g } @> 
