namespace Website

open IntelliFactory.WebSharper
open IntelliFactory.WebSharper.Html

open Website

module Pagelets =
    [<JavaScript>]
    let main tasks = 
        Div [ yield Attr.Class "tasks droppable";  
            for task in tasks do
                yield Div [ 
                    Attr.Class "ui-widget-content draggable"; 
                    Text task] :> IPagelet
        ]    

type IndexControl() =
    inherit Web.Control()

    [<DefaultValue>]
    val mutable Tasks : string list

    [<JavaScript>]
    override x.Body =
        upcast Pagelets.main x.Tasks