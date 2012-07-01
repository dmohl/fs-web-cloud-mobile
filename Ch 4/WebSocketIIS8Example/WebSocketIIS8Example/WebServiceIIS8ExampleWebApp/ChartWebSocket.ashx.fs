namespace FsWeb

open System
open System.Web
open Microsoft.Web.WebSockets
open WebSocketServer

type ChartWebSocket() =
    interface IHttpHandler with 
        member x.ProcessRequest context = 
//          Note: Comment out if not using the IIS8 example with web socket support enabled.
            if context.IsWebSocketRequest then
                context.AcceptWebSocketRequest(new WebSocketChartHandler())
        member x.IsReusable = true

