<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TurnoMedico.aspx.cs" Inherits="Christoc.Modules.Turnero.TurnoMedico" %>
<%@ Import Namespace="ConnectionDispensario.Modelos" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <style>
        @font-face {
  font-family: "Open Sans";
  font-style: normal;
  font-weight:normal;
  src: local("Open Sans Bold"), local("OpenSans-Bold"), url("http://fonts.gstatic.com/s/opensans/v10/k3k702ZOKiLJc3WVjuplzOgdm0LZdjqr5-oayXSOefg.woff2") format("woff2"), url("http://fonts.gstatic.com/s/opensans/v10/k3k702ZOKiLJc3WVjuplzHhCUOGz7vYGh680lGh-uXM.woff") format("woff");
}
        body {
            font-family:"Open Sans";
            font-size:10px;
        }
        table tbody tr {
            border-bottom:solid;
            border-bottom-width:1px;
            
            border-bottom-color:#808080;
            
        }
         table tbody tr th {
            background-color:#a4a3a3;
            font-weight:bolder;
            
        }
         table {
             width:100%;
             border-collapse: collapse;
         }
    </style>
</head>
<body>
   
    <form id="form1" runat="server">
        <div>
            
        </div>
    <div>
    <%
        if (Request["UIP"] != null) 
        {
            int IDP = int.Parse(Request["UIP"].ToString());
            List<Turno> MyTurnos = Turno.GetTurnosByUser(IDP);
            if (MyTurnos != null) 
            {
                Response.Write("<Table>");
                Response.Write("<tbody>");
                Response.Write("<tr>");
                Response.Write("<th> Nro. Turno.  </th>");
                Response.Write("<th> Apellido y Nombre </th>");
                Response.Write("<th> Estado </th>");
                Response.Write("</tr>");
                for (int a = 0; a < MyTurnos.Count; a++) 
                {
                    
                    Response.Write("<tr>");
                    Response.Write("<td>" + MyTurnos[a].IDT + "</td>");
                    Response.Write("<td>" + MyTurnos[a].Pac.APELLIDO + " " + MyTurnos[a].Pac.NOMBRE + "</td>");
                    Response.Write("<td>" + MyTurnos[a].Esstado +  "</td>");
                    Response.Write("</tr>");
                }
                    
                Response.Write("</tbody>");
                Response.Write("</Table>");
            }
        }
        
         %>
    </div>
    </form>
    <script>
        setInterval(function ()
        {
            location.reload();
        }, 5000)

    </script>
</body>
</html>
