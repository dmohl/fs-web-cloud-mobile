module Utils

open System.Web.Mvc

let NullCheck = function 
                | v when v <> null -> Some v
                | _ -> None

let asActionResult result = result :> ActionResult
