registerNamespace("PitTodo.mainModule");
registerNamespace("PitTodo");
PitTodo.mainModule.DomAttribute = (function () {
    function DomAttribute(name, value) {
        this.Name = name;
        this.Value = value;
    }
    DomAttribute.prototype.get_Name = function () {
        return this.Name;
    };
    DomAttribute.prototype.get_Value = function () {
        return this.Value;
    };
    return DomAttribute;
})();
PitTodo.mainModule.op_AtEquals = function (name) {
    return function (value) {
        return new PitTodo.mainModule.DomAttribute(name, value);
    };
};
PitTodo.mainModule.createEl = function (name) {
    return function (attributes) {
        var el = document.createElement(name);
        var enumerator = attributes.IEnumerable1_GetEnumerator();
        (function (thisObject) {
            try {
                while (enumerator.IEnumerator_MoveNext()) {
                    var a = enumerator.IEnumerator1_get_Current();
                    el.setAttribute(a.get_Name(), a.get_Value().ToString());
                }
            } finally {
                (function (thisObject) {
                    if (enumerator.containsInterface("__getIDisposable")) {
                        return enumerator.IDisposable_Dispose();
                    } else {
                        return null;
                    }
                })(thisObject)
            }
        })(this);
        return el;
    };
};
PitTodo.mainModule.addInnerHtml = function (html) {
    return function (el) {
        el.innerHTML = html;
        return el;
    };
};
PitTodo.mainModule.populateTaskList = function (el) {
    return function (taskList) {
        return Pit.FSharp.Core.Operators.op_PipeRight(taskList)(function (source) {
            return Pit.FSharp.Collections.SeqModule.Iterate(function (taskText) {
                return Pit.FSharp.Core.Operators.op_PipeRight(Pit.FSharp.Core.Operators.op_PipeRight(PitTodo.mainModule.createEl("div")(new Pit.FSharp.Collections.FSharpList1.Cons(PitTodo.mainModule.op_AtEquals("class")("ui-widget-content draggable"), new Pit.FSharp.Collections.FSharpList1.Empty())))(function (el1) {
                    return PitTodo.mainModule.addInnerHtml(taskText)(el1);
                }))(function (arg00) {
                    return el.appendChild(arg00);
                });
            })(source);
        });
    };
};
PitTodo.mainModule.moveDroppedItem = function (item) {
    return function (dropZone) {
        return Pit.FSharp.Core.Operators.op_PipeRight(item)(function (arg00) {
            return dropZone.appendChild(arg00);
        });
    };
};
PitTodo.mainModule.populateTasks = function () {
    var tasksToDo = new Pit.FSharp.Collections.FSharpList1.Cons("Persist the tasks to a data store.", new Pit.FSharp.Collections.FSharpList1.Cons("Add new tasks.", new Pit.FSharp.Collections.FSharpList1.Cons("Remove a task.", new Pit.FSharp.Collections.FSharpList1.Empty())));
    var tasksDone = new Pit.FSharp.Collections.FSharpList1.Cons("Allow tasks to be moved to done.", new Pit.FSharp.Collections.FSharpList1.Cons("Add dynamic population of tasks.", new Pit.FSharp.Collections.FSharpList1.Empty()));
    var tasksNotStartedEl = document.querySelector(".tasksNotStarted");
    var tasksDoneEl = document.querySelector(".tasksDone");
    PitTodo.mainModule.populateTaskList(tasksNotStartedEl)(tasksToDo);
    return PitTodo.mainModule.populateTaskList(tasksDoneEl)(tasksDone);
};
PitTodo.mainModule.initDragAndDrop = function () {
    return null;
};
DOM.domReady(function () {
    PitTodo.mainModule.populateTasks();
    return PitTodo.mainModule.initDragAndDrop();
});