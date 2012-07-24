let $ = jQuery
    populateTaskList = ( $el, taskList ) ->
        taskList
        |> prelude.each ( (t) ->
            $ "<div class='ui-widget-content draggable'>#{t}</div>"
            .appendTo $el )

    do ->
        tasksToDo = [ "Persist the tasks to a data store."
            "Add new tasks."
            "Remove a task." ]
        tasksDone = [ "Allow tasks to be moved to done."
            "Add dynamic population of tasks." ]

        populateTaskList $( ".tasksNotStarted" ), tasksToDo
        populateTaskList $( ".tasksDone" ), tasksDone

    $ ".draggable" .draggable (
        revert: "invalid"
        cursor: "move"
        helper: "clone"
    )

    $ ".droppable" .droppable (
        hoverClass: "ui-state-active"
        accept: ".draggable"
        drop: ( event, ui ) -> ui.draggable.appendTo $ @
    )
