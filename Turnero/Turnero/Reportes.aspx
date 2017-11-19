<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Reportes.aspx.cs" Inherits="Christoc.Modules.Turnero.Reportes" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:ScriptManager runat="server" ID="MyScriptManager"></asp:ScriptManager>
       <rsweb:ReportViewer runat="server" Id="RV" Width="100%" Height="100%" AsyncRendering="False"></rsweb:ReportViewer>
    </div>
    </form>
</body>
</html>
