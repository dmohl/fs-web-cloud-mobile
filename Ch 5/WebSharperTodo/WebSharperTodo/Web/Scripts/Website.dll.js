(function()
{
 var Global=this,Runtime=this.IntelliFactory.Runtime,Website,Pagelets,WebSharper,Html,Default,Seq,List;
 Runtime.Define(Global,{
  Website:{
   IndexControl:Runtime.Class({
    get_Body:function()
    {
     return Pagelets.main(this.Tasks);
    }
   }),
   Pagelets:{
    main:function(tasks)
    {
     return Default.Div(Seq.toList(Seq.delay(function()
     {
      return Seq.append([Default.Attr().Class("tasks droppable")],Seq.delay(function()
      {
       return Seq.map(function(task)
       {
        return Default.Div(List.ofArray([Default.Attr().Class("ui-widget-content draggable"),Default.Text(task)]));
       },tasks);
      }));
     })));
    }
   }
  }
 });
 Runtime.OnInit(function()
 {
  Website=Runtime.Safe(Global.Website);
  Pagelets=Runtime.Safe(Website.Pagelets);
  WebSharper=Runtime.Safe(Global.IntelliFactory.WebSharper);
  Html=Runtime.Safe(WebSharper.Html);
  Default=Runtime.Safe(Html.Default);
  Seq=Runtime.Safe(WebSharper.Seq);
  return List=Runtime.Safe(WebSharper.List);
 });
 Runtime.OnLoad(function()
 {
 });
}());
