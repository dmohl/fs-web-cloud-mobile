(function(){
  (function($){
    var populateTaskList;
    populateTaskList = function($el, taskList){
      return prelude.each(function(t){
        return $("<div class='ui-widget-content draggable'>" + t + "</div>").appendTo($el);
      })(
      taskList);
    };
    (function(){
      var tasksToDo, tasksDone;
      tasksToDo = ["Persist the tasks to a data store.", "Add new tasks.", "Remove a task."];
      tasksDone = ["Allow tasks to be moved to done.", "Add dynamic population of tasks."];
      populateTaskList($(".tasksNotStarted"), tasksToDo);
      return populateTaskList($(".tasksDone"), tasksDone);
    })();
    $(".draggable").draggable({
      revert: "invalid",
      cursor: "move",
      helper: "clone"
    });
    $(".droppable").droppable({
      hoverClass: "ui-state-active",
      accept: ".draggable",
      drop: function(event, ui){
        return ui.draggable.appendTo($(this));
      }
    });
  }.call(this, jQuery));
}).call(this);
