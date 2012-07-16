namespace PitTodo

module mainModule = 

    open Pit
    open Pit.Dom
    open Pit.JavaScript.JQuery.UI

    // DomAttribute, @= and createEl are based on code from https://github.com/fsharp/pitfw/blob/master/demos/samples/CalculatorApp/CalculatorApp/App.fs
    type DomAttribute = { Name:string; Value:obj }

    [<Js>]
    let (@=) name (value:'a) = { Name=name; Value=box value }

    [<Js>]
    let createEl name (attributes:DomAttribute list) =
        let el = document.CreateElement name
        for a in attributes do el.SetAttribute(a.Name, a.Value.ToString())
        el
    
    [<Js>]
    let addInnerHtml html (el:DomElement) =
        el.InnerHTML <- html
        el

    [<Js>]
    let populateTaskList (el:DomElement) taskList = 
        taskList
        |> Seq.iter( fun taskText ->
            createEl "div" ["class"@="ui-widget-content draggable"]
            |> addInnerHtml taskText
            |> el.AppendChild )

    [<Js>]
    let moveDroppedItem (item:DomElement) (dropZone:DomElement) = 
        item |> dropZone.AppendChild

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
    let initDragAndDrop () = ()
//        @"$( '.draggable' ).draggable({ 
//            revert: 'invalid',
//            cursor: 'move',
//            helper: 'clone'
//        })
//    
//        $( '.droppable' ).droppable({
//            hoverClass: 'ui-state-active',
//            accept: '.draggable',
//            drop: function ( event, ui ) {
//                moveDroppedItem( ui.draggable, $( this ) );
//            });
//        });"
        
    [<DomEntryPoint>]
    [<Js>]
    let main() =
        populateTasks()
        initDragAndDrop()
        
