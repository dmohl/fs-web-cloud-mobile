registerNamespace("PitTodo.mainModule");
PitTodo.mainModule.populateTaskList = function (el) {
    return (function (tasksList) {
        return Pit.FSharp.Core.Operators.op_PipeRight(tasksList)((function (list) {
            return Pit.FSharp.Collections.ListModule.Iterate((function (task) {
                return Pit.FSharp.Core.Operators.op_PipeRight(Pit.FSharp.Core.Operators.op_PipeRight(Pit.Dom.Html.tag("div")([Pit.Dom.Html.op_AtEquals("class")("ui-widget-content draggable"), Pit.Dom.Html.op_AtEquals("innerHtml")(task)]))((function (tag) {
                    return Pit.Dom.Html.make(tag);
                })))((function (arg00) {
                    return el.appendChild(arg00);
                }));
            }))(list);
        }));
    });
};
PitTodo.mainModule.moveDroppedItem = function (item) {
    return (function (dropZone) {
        return dropZone.append(item);
    });
};
PitTodo.mainModule.populateTasks = function () {
    var tasksToDo = Pit.FSharp.Collections.ListModule.OfArray(["Persist the tasks to a data store.", "Add new tasks.", "Remove a task."]);
    var tasksDone = Pit.FSharp.Collections.ListModule.OfArray(["Allow tasks to be moved to done.", "Add dynamic population of tasks."]);
    var tasksNotStartedEl = document.querySelector(".tasksNotStarted");
    var tasksDoneEl = document.querySelector(".tasksDone");
    PitTodo.mainModule.populateTaskList(tasksNotStartedEl)(tasksToDo);
    return PitTodo.mainModule.populateTaskList(tasksDoneEl)(tasksDone);
};
PitTodo.mainModule.initDragAndDrop = function () {
    $(".draggable").draggable({
        revert: "invalid",
        cursor: "move",
        helper: "clone"
    });
    return $(".droppable").droppable({
        hoverClass: "ui-state-active",
        accept: ".draggable",
        drop: function (event, ui) {
            return PitTodo.mainModule.moveDroppedItem(ui.draggable)($(this));
        }
    });
};
DOM.domReady(function () {
    PitTodo.mainModule.populateTasks();
    return PitTodo.mainModule.initDragAndDrop();
});