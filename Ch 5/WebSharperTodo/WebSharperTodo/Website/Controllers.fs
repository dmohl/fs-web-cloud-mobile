namespace Website.Controllers

open System
open System.Web.Mvc

type Tasks = { TasksToDo : string list; TasksCompleted : string list }

[<HandleError>]
type HomeController() =
    inherit Controller()

    member this.Index() =
        { TasksToDo = 
            [ "Persist the tasks to a data store."
              "Add new tasks."
              "Remove a task." ]
          TasksCompleted = 
            [ "Allow tasks to be moved to done."
              "Add dynamic population of tasks." ] } |> this.View
