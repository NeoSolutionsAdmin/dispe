<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="View.ascx.cs" Inherits="Christoc.Modules.Turnero.View" %>
<%@ Import Namespace="ConnectionDispensario.Modelos" %>
<div>
    <span>Dia Comienzo:</span>
    <asp:DropDownList runat="server" ID="DiaStart">
        <asp:ListItem Text="1"></asp:ListItem>
        <asp:ListItem Text="2"></asp:ListItem>
        <asp:ListItem Text="3"></asp:ListItem>
        <asp:ListItem Text="4"></asp:ListItem>
        <asp:ListItem Text="5"></asp:ListItem>
        <asp:ListItem Text="6"></asp:ListItem>
        <asp:ListItem Text="7"></asp:ListItem>
        <asp:ListItem Text="8"></asp:ListItem>
        <asp:ListItem Text="9"></asp:ListItem>
        <asp:ListItem Text="10"></asp:ListItem>
        <asp:ListItem Text="11"></asp:ListItem>
        <asp:ListItem Text="12"></asp:ListItem>
        <asp:ListItem Text="13"></asp:ListItem>
        <asp:ListItem Text="14"></asp:ListItem>
        <asp:ListItem Text="15"></asp:ListItem>
        <asp:ListItem Text="16"></asp:ListItem>
        <asp:ListItem Text="17"></asp:ListItem>
        <asp:ListItem Text="18"></asp:ListItem>
        <asp:ListItem Text="19"></asp:ListItem>
        <asp:ListItem Text="20"></asp:ListItem>
        <asp:ListItem Text="21"></asp:ListItem>
        <asp:ListItem Text="22"></asp:ListItem>
        <asp:ListItem Text="23"></asp:ListItem>
        <asp:ListItem Text="24"></asp:ListItem>
        <asp:ListItem Text="25"></asp:ListItem>
        <asp:ListItem Text="26"></asp:ListItem>
        <asp:ListItem Text="27"></asp:ListItem>
        <asp:ListItem Text="28"></asp:ListItem>
        <asp:ListItem Text="29"></asp:ListItem>
        <asp:ListItem Text="30"></asp:ListItem>
        <asp:ListItem Text="31"></asp:ListItem>
    </asp:DropDownList>
    <span>Dia Finalizacion:</span>
    <asp:DropDownList runat="server" ID="DiaEnd">
        <asp:ListItem Text="1"></asp:ListItem>
        <asp:ListItem Text="2"></asp:ListItem>
        <asp:ListItem Text="3"></asp:ListItem>
        <asp:ListItem Text="4"></asp:ListItem>
        <asp:ListItem Text="5"></asp:ListItem>
        <asp:ListItem Text="6"></asp:ListItem>
        <asp:ListItem Text="7"></asp:ListItem>
        <asp:ListItem Text="8"></asp:ListItem>
        <asp:ListItem Text="9"></asp:ListItem>
        <asp:ListItem Text="10"></asp:ListItem>
        <asp:ListItem Text="11"></asp:ListItem>
        <asp:ListItem Text="12"></asp:ListItem>
        <asp:ListItem Text="13"></asp:ListItem>
        <asp:ListItem Text="14"></asp:ListItem>
        <asp:ListItem Text="15"></asp:ListItem>
        <asp:ListItem Text="16"></asp:ListItem>
        <asp:ListItem Text="17"></asp:ListItem>
        <asp:ListItem Text="18"></asp:ListItem>
        <asp:ListItem Text="19"></asp:ListItem>
        <asp:ListItem Text="20"></asp:ListItem>
        <asp:ListItem Text="21"></asp:ListItem>
        <asp:ListItem Text="22"></asp:ListItem>
        <asp:ListItem Text="23"></asp:ListItem>
        <asp:ListItem Text="24"></asp:ListItem>
        <asp:ListItem Text="25"></asp:ListItem>
        <asp:ListItem Text="26"></asp:ListItem>
        <asp:ListItem Text="27"></asp:ListItem>
        <asp:ListItem Text="28"></asp:ListItem>
        <asp:ListItem Text="29"></asp:ListItem>
        <asp:ListItem Text="30"></asp:ListItem>
        <asp:ListItem Text="31"></asp:ListItem>
    </asp:DropDownList>
    <span>Mes:</span>
    <asp:DropDownList runat="server" ID="Mes">
        <asp:ListItem Text="1"></asp:ListItem>
        <asp:ListItem Text="2"></asp:ListItem>
        <asp:ListItem Text="3"></asp:ListItem>
        <asp:ListItem Text="4"></asp:ListItem>
        <asp:ListItem Text="5"></asp:ListItem>
        <asp:ListItem Text="6"></asp:ListItem>
        <asp:ListItem Text="7"></asp:ListItem>
        <asp:ListItem Text="8"></asp:ListItem>
        <asp:ListItem Text="9"></asp:ListItem>
        <asp:ListItem Text="10"></asp:ListItem>
        <asp:ListItem Text="11"></asp:ListItem>
        <asp:ListItem Text="12"></asp:ListItem>
    </asp:DropDownList>
    <span> Año </span>
    <asp:DropDownList runat="server" ID="Año">
        <asp:ListItem Text="2017"></asp:ListItem>
        <asp:ListItem Text="2018"></asp:ListItem>
        <asp:ListItem Text="2019"></asp:ListItem>
    </asp:DropDownList>
    <span>Hora Comienzo:</span>
    <asp:DropDownList runat="server" ID="HoraStart">
        <asp:ListItem Text="0"></asp:ListItem>
        <asp:ListItem Text="1"></asp:ListItem>
        <asp:ListItem Text="2"></asp:ListItem>
        <asp:ListItem Text="3"></asp:ListItem>
        <asp:ListItem Text="4"></asp:ListItem>
        <asp:ListItem Text="5"></asp:ListItem>
        <asp:ListItem Text="6"></asp:ListItem>
        <asp:ListItem Text="7"></asp:ListItem>
        <asp:ListItem Text="8"></asp:ListItem>
        <asp:ListItem Text="9"></asp:ListItem>
        <asp:ListItem Text="10"></asp:ListItem>
        <asp:ListItem Text="11"></asp:ListItem>
        <asp:ListItem Text="12"></asp:ListItem>
        <asp:ListItem Text="13"></asp:ListItem>
        <asp:ListItem Text="14"></asp:ListItem>
        <asp:ListItem Text="15"></asp:ListItem>
        <asp:ListItem Text="16"></asp:ListItem>
        <asp:ListItem Text="17"></asp:ListItem>
        <asp:ListItem Text="18"></asp:ListItem>
        <asp:ListItem Text="19"></asp:ListItem>
        <asp:ListItem Text="20"></asp:ListItem>
        <asp:ListItem Text="21"></asp:ListItem>
        <asp:ListItem Text="22"></asp:ListItem>
        <asp:ListItem Text="23"></asp:ListItem>
    </asp:DropDownList>
        <span>Hora Finalizacion:</span>
    <asp:DropDownList runat="server" ID="HoraEnd">
        <asp:ListItem Text="0"></asp:ListItem>
        <asp:ListItem Text="1"></asp:ListItem>
        <asp:ListItem Text="2"></asp:ListItem>
        <asp:ListItem Text="3"></asp:ListItem>
        <asp:ListItem Text="4"></asp:ListItem>
        <asp:ListItem Text="5"></asp:ListItem>
        <asp:ListItem Text="6"></asp:ListItem>
        <asp:ListItem Text="7"></asp:ListItem>
        <asp:ListItem Text="8"></asp:ListItem>
        <asp:ListItem Text="9"></asp:ListItem>
        <asp:ListItem Text="10"></asp:ListItem>
        <asp:ListItem Text="11"></asp:ListItem>
        <asp:ListItem Text="12"></asp:ListItem>
        <asp:ListItem Text="13"></asp:ListItem>
        <asp:ListItem Text="14"></asp:ListItem>
        <asp:ListItem Text="15"></asp:ListItem>
        <asp:ListItem Text="16"></asp:ListItem>
        <asp:ListItem Text="17"></asp:ListItem>
        <asp:ListItem Text="18"></asp:ListItem>
        <asp:ListItem Text="19"></asp:ListItem>
        <asp:ListItem Text="20"></asp:ListItem>
        <asp:ListItem Text="21"></asp:ListItem>
        <asp:ListItem Text="22"></asp:ListItem>
        <asp:ListItem Text="23"></asp:ListItem>
    </asp:DropDownList>
    <asp:Button ID="ImprimirC1" runat="server" Text="Imprimir C1" OnClick="ImprimirC1_Click" /> 
</div>
<table class="TablaTurnos">
    <tbody>
        <%
            string SessionTurnos = "SessionTurnos";
            if (Session[SessionTurnos] != null)
            {

                List<Turno> CT = (List<Turno>)Session[SessionTurnos];
                if (CT.Count != 0)
                {

                    
                    Response.Write("<tr>");
                    
                    Response.Write("<th>Nro.</th>");
                    Response.Write("<th>Nombre</th>");
                    Response.Write("<th>Estado</th>");
                    Response.Write("<th>Recepcion</th>");
                    Response.Write("<th>Consulta</th>");
                    Response.Write("<th>Finalizado</th>");
                    Response.Write("<th>Accion</th>");
                    Response.Write("</tr>");


                    for (int a = CT.Count - 1; a > -1; a--)
                    {

                        string Class = CT[a].Esstado;
                        Response.Write("<tr class=' CLS" + Class + "'>");


                        Response.Write("<td>" + CT[a].IDT.ToString() + "</td>");
                        if (CT[a].Pac != null)
                        {
                            Response.Write("<td>" + CT[a].Pac.APELLIDO + " " + CT[a].Pac.NOMBRE + "</td>");
                        }
                        else 
                        {
                            Response.Write("<td style=\"color:red;font-weight:bolder\"> Paciente inexistente en la base de datos </td>");
                        }
                        Response.Write("<td>" + CT[a].Esstado + "</td>");
                        Response.Write("<td>" + CT[a].FechaRecepcion.ToString() + "</td>");
                        if (CT[a].Esstado == "Progreso" || CT[a].Esstado == "Finalizado")
                        {
                            Response.Write("<td>" + CT[a].FechaComienzo.ToString() + "</td>");
                        }
                        else
                        {
                            Response.Write("<td><div class='NonDataCell'></div></td>");
                        }


                        if (CT[a].Esstado == "Finalizado")
                        {
                            Response.Write("<td>" + CT[a].FechaFinal.ToString() + "</td>");
                        }
                        else
                        {
                            Response.Write("<td><div class='NonDataCell'></div></td>");
                        }



                        Response.Write("<td>");
                        switch (CT[a].Esstado)
                        {
                            case "Espera": Response.Write("<input type='button' value='Ingresar' onclick='Ingresar(" + CT[a].IDT + ")'/>");
                                Response.Write("<input type='button' value='Cancelar' onclick='Cancelar(" + CT[a].IDT + ")'/>");
                                break;
                            case "Progreso":
                                Response.Write("<input type='button' value='Finalizar' onclick='Finalizar(" + CT[a].IDT + ")'/>");
                                break;

                            case "Finalizado":
                                if (CT[a].DiagnosticoFinal == null)
                                {
                                    Response.Write("<input type='button' value='Ins. Diagnostico' onclick='InsertarDiagnosticoFinal(" + CT[a].IDT + ",\"" + CT[a].Pac.NOMBRE + " " + CT[a].Pac.APELLIDO + "\")'/>");
                                }
                                else
                                {
                                    Response.Write("<b>" + CT[a].DiagnosticoFinal + "</b>");
                                }
                                /*Response.Write("<input type='button' value='Derivar'/>");
                                */
                                break;
                        }

                        Response.Write("</td>");
                        Response.Write("</tr>");
                    }
                }
                else
                {

                }


            }
            else
            {

            }
        %>
    </tbody>
</table>
<div Title="" id="frmDiagnostico">
    <div>
    <b>Diagnostico paciente:</b><asp:TextBox ClientIDMode="Static" id="txtDiagnostico" runat="server" style="width:400px" />
        </div>
    <div>
        <asp:CheckBox runat="server" ClientIDMode="Static" ID="chkControlEmbarazo" Text="Control de Embarazo"  />

    </div>
    <div>
        <asp:Button runat="server" ClientIDMode="Static" id="btnGuardarDiagnostico" OnClick="btnGuardarDiagnostico_Click" Text="Guardar" />
        <asp:Button runat="server" ClientIDMode="Static" id="btnCancelarDiagnostico" OnClick="btnCancelarDiagnostico_Click" Text="Cancelar" />
        
    </div>
</div>
<asp:HiddenField ID="HF_IDT" runat="server" ClientIDMode="Static"/>
<script>
    //http://192.168.1.100/DesktopModules/Turnero/C1.aspx?IDU=5&IDP=0&Y=2017&M=3&DS=1&DE=26&HS=1&HE=23&P=0
    var dlg = $('#frmDiagnostico').dialog(
        {
            dialogClass:'dnnFormPopup',
            autoOpen: false,
            draggable: false,
            width:'450px',
            resizable: false,
            modal: true,
            minWidth:'450px'

        });
    

    function InsertarDiagnosticoFinal(IDT,NP)
    {
        $('#HF_IDT').val(IDT);
        $('#frmDiagnostico').dialog('option', 'title', NP);
        $('#frmDiagnostico').dialog("open");
        $('#txtDiagnostico').val("");
        dlg.parent().appendTo(jQuery("form:first"));
    }

    function Ingresar(IDT)
    {
        window.location.href = "/Turnos?com=I&IDT=" + IDT;
    }
    function Cancelar(IDT)
    {
        window.location.href = "/Turnos?com=C&IDT=" + IDT;
    }
    function Finalizar(IDT)
    {
        window.location.href = "/Turnos?com=F&IDT=" + IDT;
    }

    

</script>