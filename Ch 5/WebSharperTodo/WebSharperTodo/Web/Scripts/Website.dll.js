(function()
{
 var Global=this,Runtime=this.IntelliFactory.Runtime,Website,Todo,WebSharper,JQueryUI,DraggableConfiguration,Draggable,DroppableConfiguration,Droppable,jQuery,Html,Operators,Default,List,Seq;
 Runtime.Define(Global,{
  Website:{
   IndexControl:Runtime.Class({
    get_Body:function()
    {
     return Todo.main(this.Tasks);
    }
   }),
   Todo:{
    initDrag:function(element)
    {
     var config,returnVal;
     config=(returnVal=[DraggableConfiguration.New()],(null,returnVal[0].cursor="move",returnVal[0].helper="clone",returnVal[0].cancel="invalid",returnVal[0]));
     return Draggable.New1(element,config);
    },
    initDrop:function(element)
    {
     var config,returnVal,dropZone;
     config=(returnVal=[DroppableConfiguration.New()],(null,returnVal[0].hoverClass="ui-state-active",returnVal[0].accept=".draggable",returnVal[0]));
     dropZone=Droppable.New1(element,config);
     dropZone.OnDrop(function()
     {
      return function(el)
      {
       return jQuery(element.Body).append(el.draggable);
      };
     });
     return dropZone;
    },
    main:function(tasks)
    {
     var x,f1;
     x=Operators.add(Default.Div(List.ofArray([Default.Attr().Class("droppable")])),Seq.toList(Seq.delay(function()
     {
      return Seq.map(function(task)
      {
       var x1,f;
       x1=Default.Div(List.ofArray([Default.Attr().Class("ui-widget-content draggable"),Default.Text(task)]));
       f=function(element)
       {
        return Todo.initDrag(element);
       };
       return f(x1);
      },tasks);
     })));
     f1=function(element)
     {
      return Todo.initDrop(element);
     };
     return f1(x);
    },
    moveDroppedItem:function(item,dropZone)
    {
     return item.appendTo(dropZone);
    }
   }
  }
 });
 Runtime.OnInit(function()
 {
  Website=Runtime.Safe(Global.Website);
  Todo=Runtime.Safe(Website.Todo);
  WebSharper=Runtime.Safe(Global.IntelliFactory.WebSharper);
  JQueryUI=Runtime.Safe(WebSharper.JQueryUI);
  DraggableConfiguration=Runtime.Safe(JQueryUI.DraggableConfiguration);
  Draggable=Runtime.Safe(JQueryUI.Draggable);
  DroppableConfiguration=Runtime.Safe(JQueryUI.DroppableConfiguration);
  Droppable=Runtime.Safe(JQueryUI.Droppable);
  jQuery=Runtime.Safe(Global.jQuery);
  Html=Runtime.Safe(WebSharper.Html);
  Operators=Runtime.Safe(Html.Operators);
  Default=Runtime.Safe(Html.Default);
  List=Runtime.Safe(WebSharper.List);
  return Seq=Runtime.Safe(WebSharper.Seq);
 });
 Runtime.OnLoad(function()
 {
 });
}());
