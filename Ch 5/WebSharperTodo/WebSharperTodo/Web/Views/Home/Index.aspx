<%@ Page Title="" Language="C#" Inherits="Website.Helpers.DataBoundViewPage" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
      "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
  <head runat="server">
    <title>WebSharper Application</title>
    <WebSharper:ScriptManager runat="server" />
    <link type="text/css" href="<%= Url.Content("~/Styles/ui-darkness/jquery-ui-1.8.21.custom.css") %>" rel="stylesheet" />
    <link rel="stylesheet" href="<%= Url.Content("~/Styles/Site.css") %>">
    <link rel="stylesheet" href="<%= Url.Content("~/Styles/bootstrap-responsive.min.css") %>">
    <link rel="stylesheet" href="<%= Url.Content("~/Styles/bootstrap.min.css") %>">

  </head>
  <body>
      <div role="main">
          <div class="container todoList">
              <h1>My To Do List</h1>
              <div class="detail row-fluid">
                  <div class="span6 taskContainer well">
                      <div class="column-header">
                          <h3>Not Started</h3>
                      </div>
                      <ws:IndexControl ID="IndexControl3" runat="server" Tasks="<%# ((Website.Controllers.Tasks)Model).TasksToDo %>" />
                  </div>
                  <div class="span6 taskContainer well">
                      <div class="column-header">
                          <h3>Done</h3>
                      </div>
                      <ws:IndexControl ID="IndexControl4" runat="server" Tasks="<%# ((Website.Controllers.Tasks)Model).TasksCompleted %>" />
                  </div>
              </div>
          </div>
      </div>
  </body>
</html> 
