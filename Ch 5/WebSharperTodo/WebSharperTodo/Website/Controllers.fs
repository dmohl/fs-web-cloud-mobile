namespace Website.Controllers

open System
open System.Web.Mvc

type Tasks = { TasksToDo : string list; TasksCompleted : string list }

[<HandleError>]
type HomeController() =
    inherit Controller()

    member this.Index() =
        { TasksToDo = ["Task1"; "Task2"; "Task3"]; TasksCompleted = ["Test"] }
        |> this.View
