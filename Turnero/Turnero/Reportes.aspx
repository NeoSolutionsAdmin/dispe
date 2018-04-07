<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Reportes.aspx.cs" Inherits="Christoc.Modules.Turnero.Reportes" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=14.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script src="/Resources/libraries/jQuery/01_09_01/jquery.js?cdv=50" type="text/javascript"></script>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:ScriptManager runat="server" ID="MyScriptManager"></asp:ScriptManager>
       <rsweb:ReportViewer runat="server" Id="RV" Width="100%" Height="100%" AsyncRendering="true"></rsweb:ReportViewer>
    </div>
        <input type="hidden" id="filenamefield" runat="server" value="">
    </form>
    <script>    
        archivo = $("#filenamefield").val()
        window.location.href = "/Portals/0/" + archivo;
    </script>
</body>
</html>
