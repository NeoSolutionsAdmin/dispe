<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="C1.aspx.cs" Inherits="Christoc.Modules.Turnero.C1" %>
<%@ Import Namespace="ConnectionDispensario.Modelos" %>
<%@ Import Namespace="ConnectionDispensario.Utils" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="/Resources/libraries/jQuery/01_09_01/jquery.js?cdv=63" type="text/javascript"></script>
    <script src="/Resources/libraries/jQuery-UI/01_11_03/jquery-ui.js?cdv=63" type="text/javascript"></script>
    <script src="/DesktopModules/Turnero/xepOnline.jqPlugin.js"></script>
    <style>
        table {
            border-collapse:collapse;
        }
        table, th, td {
    border: 1px solid black;
}
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div id="MasterDiv">
            <div>
                C1 - INFORME DIARIO DE CONSULTAS MEDICAS
            </div>
            <div>
                APELLIDO Y NOMBRE MEDICO: <asp:Label ID="NombreMedico" runat="server"></asp:Label>
            </div>
            <div>
                ESTABLECIMIENTO/DISPENSARIO: <asp:Label ID="Establecimiento" runat="server"></asp:Label>
            </div>
            <div>
                SERVICIO: <asp:Label ID="Servicio" runat="server"></asp:Label>
            </div>
            <div>
                DEPENDENCIA ADMINISTRATIVA Nº: <asp:Label ID="IndependenciaNro" runat="server"></asp:Label>
                DEPARTAMENTO: <asp:Label ID="Departamento" runat="server"></asp:Label>
                MES: <asp:Label ID="Mes" runat="server"></asp:Label>
                AÑO: <asp:Label ID="Año" runat="server"></asp:Label>
            </div>
            <div>

                <table style="font-size:14px">
                    <tbody>
                        <tr>
                            <td colspan="2" rowspan="3"><b>Apellido y Nombre</b></td>
                            
                            <td rowspan="3">  <b>Residencia habitual </b><br />
                                
                                <small><b>(Dpto/Localidad/Paraje/Barrio)</b></small>
                            </td>
                            <td colspan="2"><b>Esta asociado a:</b></td>
                            
                            <td colspan="14"><b>Grupo de edad y sexo</b></td>
                            
                            <td colspan="4" rowspan="3"> <b> Diagnostico, Control</b></td>

                            <td rowspan="3"><b>COD CIE</b></td>
                            <td rowspan="3"><b>Ctrl. Emb.</b></td>
                            
                        </tr>
                        <tr>
                            
                            <td rowspan="2"><b>Obra Social</b></td>
                            <td rowspan="2"><b>Ninguno</b></td>
                            <td colspan="2"><b>Menor 1</b></td>
                            <td colspan="2"><b>1 año</b></td>
                            <td colspan="2"><b>2 a 4</b></td>
                            <td colspan="2"><b>5 a 9</b></td>
                            <td colspan="2"><b>10 a 14</b></td>
                            <td colspan="2"><b>15 a 49</b></td>
                            <td colspan="2"><b>50 y +</b></td>
                        </tr>
                        <tr>
                            <td><b>M</b></td>
                            <td><b>F</b></td>
                            <td><b>M</b></td>
                            <td><b>F</b></td>
                            <td><b>M</b></td>
                            <td><b>F</b></td>
                            <td><b>M</b></td>
                            <td><b>F</b></td>
                            <td><b>M</b></td>
                            <td><b>F</b></td>
                            <td><b>M</b></td>
                            <td><b>F</b></td>
                            <td><b>M</b></td>
                            <td><b>F</b></td>
                        </tr>
                        <%
                           
                            if (Session["result"] != null) 
                            {
                                List<Turno> LT = (List<Turno>)Session["result"];

                                int CountObras = 0;
                                int CountNoObras = 0;
                                int M0 = 0;
                                int F0 = 0;
                                int M1 = 0;
                                int F1 = 0;
                                int M2 = 0;
                                int F2 = 0;
                                int M5 = 0;
                                int F5 = 0;
                                int M10 = 0;
                                int F10 = 0;
                                int M15 = 0;
                                int F15 = 0;
                                int M50 = 0;
                                int F50 = 0;
                                int CountControlEmbarazo=0;
                                
                                for (int a = 0; a < LT.Count; a++) 
                                {
                                    Response.Write("<tr>");
                                    Response.Write("<td>" + (a+1).ToString() + "</td>");
                                        Response.Write("<td>" + LT[a].Pac.APELLIDO + " " + LT[a].Pac.NOMBRE + "</td>");
                                        Response.Write("<td>" + LT[a].Pac.LOCALIDAD + "/" + LT[a].Pac.DOMICILIO + "</td>");
                                        if (LT[a].Pac.IDOBRASOCIAL != 0)
                                        {
                                            ObraSocial OS = ObraSocial.GetObraSocial(LT[a].Pac.IDOBRASOCIAL);
                                            Response.Write("<td>" + OS.NOMBRE + "</td><td></td>");
                                            CountObras++;

                                        }
                                        else 
                                        {
                                            CountNoObras++;
                                            Response.Write("<td></td>" + "<td>X</td>");
                                        }
                                        int categoriaedad = 0;
                                    int Edad = Conversiones.getAge(  LT[a].Pac.FECHA_NACIMIENTO);
                                    if (Edad == 0) categoriaedad = 0;
                                    if (Edad == 1) categoriaedad = 1;
                                    if (Edad > 1 && Edad<5) categoriaedad = 2;
                                    if (Edad > 4 && Edad < 10) categoriaedad = 3;
                                    if (Edad > 9 && Edad < 15) categoriaedad = 4;
                                    if (Edad > 14 && Edad < 50) categoriaedad = 5;
                                    if (Edad >=50) categoriaedad = 6;

                                    
                                    
                                        for (int b = 0; b < 7; b++) 
                                        {
                                            if (b == categoriaedad)
                                            {
                                                if (LT[a].Pac.SEXO == "Masculino")
                                                {
                                                    if (categoriaedad == 0) M0++;
                                                    if (categoriaedad == 1) M1++;
                                                    if (categoriaedad == 2) M2++;
                                                    if (categoriaedad == 3) M5++;
                                                    if (categoriaedad == 4) M10++;
                                                    if (categoriaedad == 5) M15++;
                                                    if (categoriaedad == 6) M50++;
                                                    Response.Write("<td>X</td><td></td>");
                                                }
                                                else
                                                {
                                                    if (categoriaedad == 0) F0++;
                                                    if (categoriaedad == 1) F1++;
                                                    if (categoriaedad == 2) F2++;
                                                    if (categoriaedad == 3) F5++;
                                                    if (categoriaedad == 4) F10++;
                                                    if (categoriaedad == 5) F15++;
                                                    if (categoriaedad == 6) F50++;
                                                    Response.Write("<td></td><td>X</td>");
                                                }
                                            }
                                            else 
                                            {
                                                Response.Write("<td></td><td></td>");
                                            }
                                            
                                        }
                                    
                                    
                                       
                                        if (LT[a].CIE10 != 0)
                                        {
                                            CIE C10 = CIE.get_CIE(LT[a].CIE10);
                                            {
                                                if (C10.ETIQUETA.Length > 25)
                                                {
                                                    C10.ETIQUETA = C10.ETIQUETA.Substring(0, 25);
                                                }
                                                Response.Write("<td colspan='4'>" + C10.ETIQUETA + "</td>" + "<td>" + C10.CODIGO + "</td>");
                                            }
                                        }
                                        else 
                                        {
                                            if (LT[a].DiagnosticoFinal!=null && LT[a].DiagnosticoFinal.Length > 25)
                                            {
                                                LT[a].DiagnosticoFinal = LT[a].DiagnosticoFinal.Substring(0, 25);
                                            }

                                            if (LT[a].DiagnosticoFinal != null)
                                            {
                                                Response.Write("<td colspan='4'>" + LT[a].DiagnosticoFinal + "</td>" + "<td></td>");
                                            }
                                            else
                                            {
                                                Response.Write("<td colspan='4'>" + "</td>" + "<td></td>");
                                            }
                                            
                                            
                                        }

                                        if (LT[a].ControlEmbarazo == false)
                                        {
                                            Response.Write("<td></td>");
                                        }
                                        else 
                                        {
                                            CountControlEmbarazo++;
                                            Response.Write("<td>X</td>");
                                        }
                                    
                                    Response.Write("</tr>");
                                }
                                Response.Write("<tr>");
                                Response.Write("<td colspan='3'></td>");
                                Response.Write("<td>" + CountObras.ToString() + "</td>");
                                Response.Write("<td>" + CountNoObras.ToString() + "</td>");
                                Response.Write("<td>" + M0.ToString() + "</td>");
                                Response.Write("<td>" + F0.ToString() + "</td>");
                                Response.Write("<td>" + M1.ToString() + "</td>");
                                Response.Write("<td>" + F1.ToString() + "</td>");
                                Response.Write("<td>" + M2.ToString() + "</td>");
                                Response.Write("<td>" + F2.ToString() + "</td>");
                                Response.Write("<td>" + M5.ToString() + "</td>");
                                Response.Write("<td>" + F5.ToString() + "</td>");
                                Response.Write("<td>" + M10.ToString() + "</td>");
                                Response.Write("<td>" + F10.ToString() + "</td>");
                                Response.Write("<td>" + M15.ToString() + "</td>");
                                Response.Write("<td>" + F15.ToString() + "</td>");
                                Response.Write("<td>" + M50.ToString() + "</td>");
                                Response.Write("<td>" + F50.ToString() + "</td>");
                                Response.Write("<td rowspan='2'><b>Total Gral. de </br> Consultas</b></td>");
                                Response.Write("<td><b>M</b></td>");
                                Response.Write("<td><b>F</b></td>");
                                Response.Write("<td><b>Total</b></td>");
                                Response.Write("<td rowspan='2'></td>");
                                Response.Write("<td rowspan='2'>" + CountControlEmbarazo.ToString() +  "</td>");
                                //Response.Write("<td>" +(M0+M1+M2+M5+M10+M15+M50) + "</td>");
                                Response.Write("</tr>");
                                Response.Write("<tr>");
                                Response.Write("<td colspan='5'></td>");
                                Response.Write("<td colspan='2'>" +(M0+F0).ToString() + "</td>");
                                Response.Write("<td colspan='2'>" + (M1 + F1).ToString() + "</td>");
                                Response.Write("<td colspan='2'>" + (M2 + F2).ToString() + "</td>");
                                Response.Write("<td colspan='2'>" + (M5 + F5).ToString() + "</td>");
                                Response.Write("<td colspan='2'>" + (M10 + F10).ToString() + "</td>");
                                Response.Write("<td colspan='2'>" + (M15 + F15).ToString() + "</td>");
                                Response.Write("<td colspan='2'>" + (M50 + F50).ToString() + "</td>");
                                Response.Write("<td>" + (M0 + M1 + M2 + M5 + M10 + M15 + M50).ToString() + "</td>");
                                Response.Write("<td>" + (F0 + F1 + F2 + F5 + F10 + F15 + F50).ToString() + "</td>");
                                Response.Write("<td>" + (M0 + M1 + M2 + M5 + M10 + M15 + M50 + F0 + F1 + F2 + F5 + F10 + F15 + F50).ToString() + "</td>");
                                Response.Write("</tr>");
                            }
                            
                             %>
                    </tbody>
                </table>
                
            </div>


            <div style="height:30px; vertical-align:bottom; padding-top:30px">

                Responsable Llenado: _____________________________________________ Fecha: <% Response.Write(DateTime.Now.ToLongDateString()); %>

        </div>

        </div>
        

    </form>
    <style>
        * {
            margin: 0px;
            padding: 0px;
        }

        body {
            width: 8in;
            height: 11in;
            padding-top: 20px;
            padding-left: 20px;
            /* margin:0px 0px 0px 0px;*/
            -ms-transform: rotate(90deg);
            /* IE 9 */
            -webkit-transform: rotate(90deg);
            /* Chrome, Safari, Opera */
            transform: rotate(90deg);
            transform-origin: left top;
            position: absolute;
            top: 0;
            left: 100%;
            white-space: nowrap;
            /*font-size: 48px;      */
        }
    </style>

    <script>

        function PrintMe() {
            $("#MasterDiv").css({ 'display': 'block', 'height:': '100%', 'width': '100%' });

            xepOnline.Formatter.Format('MasterDiv',
            {
                pageWidth: '216mm',
                pageHeight: '279mm',
                render: 'embed'
            });
        }

    </script>

</body>
</html>
