namespace PitTodo

open Pit
open Pit.Dom
open Pit.JavaScript
open Pit.JavaScript.JQuery
open Pit.JavaScript.JQuery.UI

module mainModule = 
    [<JsObject>]
    type dragType = { draggable : DomElement }
    
    [<Js>]
    let populateTaskList (el:DomElement) tasksList =
        tasksList
        |> List.iter( fun (task:string) ->            
            tag "div" [|
                "class"@="ui-widget-content draggable"
                "innerHtml"@=task|]
            |> Html.make
            |> el.AppendChild )

    [<Js>]
    let populateTasks () =
        let tasksToDo = 
            [ "Persist the tasks to a data store."
              "Add new tasks."
              "Remove a task." ]
        let tasksDone = 
            [ "Allow tasks to be moved to done."
              "Add dynamic population of tasks." ]
        let tasksNotStartedEl = document.QuerySelector ".tasksNotStarted"         
        let tasksDoneEl = document.QuerySelector ".tasksDone"         
        populateTaskList tasksNotStartedEl tasksToDo
        populateTaskList tasksDoneEl tasksDone

    [<Js>]
    let initDragAndDrop () = 
        jQueryUI(".draggable")
            .draggable(
                [ "revert" => "invalid"
                  "cursor" => "move"
                  "helper" => "clone" ] )
            .ignore()

        jQueryUI(".droppable")
            .droppable(
                [ "hoverClass" => "ui-state-active"
                  "accept" => ".draggable"
                  "drop" => fun (event, ui:dragType) -> 
                      jQuery("this").append(ui.draggable).ignore() ] )
            .ignore()

    [<DomEntryPoint>]
    [<Js>]
    let main() =
        populateTasks()
        initDragAndDrop()