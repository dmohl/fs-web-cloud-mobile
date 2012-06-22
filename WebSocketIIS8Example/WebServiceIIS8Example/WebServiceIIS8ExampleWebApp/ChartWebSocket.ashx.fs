namespace FsWeb

open System
open System.Web
open Microsoft.Web.WebSockets
open WebSocketServer

type ChartWebSocket() =
    interface IHttpHandler with 
        member x.ProcessRequest context =
            if context.IsWebSocketRequest then
                context.AcceptWebSocketRequest(new WebSocketChartHandler())
        member x.IsReusable = true

