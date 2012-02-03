<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="JobRunnerWebConsole.Default" %>
<%@ Import Namespace="System.Threading" %>
<%@ Import Namespace="System.Threading.Tasks" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Job Runner Web Console</title>
    <script type="text/javascript">

        var timer = setTimeout("window.location.href=window.location.href", 1000);
    </script>
</head>
<body>
    <form id="form1" runat="server">
    
    <div>
        <h1>
            Job Runner Web Console</h1>
        <div>
            <p><%=DateTime.Now %></p>
            <h3>Registered Jobs</h3>
            <%
                foreach (var job in Jobs)
                {
            %>
            <ul>
            <li>
                <%=job.Name%> | <%=job.State%> | <%=job.Period%> | <%=job.NextExecution %> | <a href="#">Logs...</a>
            </li>
            </ul>
            <%
            }
            %>
        </div>
    </div>
    
    <div>
        <%foreach (var log in Logs)
          {
              %>
              <%=log %> <br/>
              <%
          } %>
    </div>
    </form>
</body>
</html>
