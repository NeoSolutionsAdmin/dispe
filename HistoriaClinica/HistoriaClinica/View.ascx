<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="View.ascx.cs" Inherits="Christoc.Modules.HistoriaClinica.View" %>
<%@ Import Namespace="System.IO" %>
<%@ Import Namespace="ConnectionDispensario.Modelos" %>

<div>

<asp:Button CssClass="DispensarioButton DispensarioIconBuscarPaciente" Text="Buscar Paciente" ID="btnBuscarPaciente" runat="server" ClientIDMode="Static" OnClientClick="ShowDialog();return false;" />
    </div>

<div id="DialogPacienteSearch" title="Busqueda de pacientes">
    <asp:TextBox ID="StringSearch" runat="server" CssClass="DispensarioTextBox" ClientIDMode="Static"></asp:TextBox>
    <asp:Button ID="Buscar" runat="server" OnClick="Buscar_Click" CssClass="DispensarioButton DispensarioIconBuscarPaciente" Text="BUSCAR" />
    <asp:RadioButtonList ID="SearchForm" runat="server" >
        <asp:ListItem Text="Buscar Por DNI" Value="DNI" Selected="true"></asp:ListItem>
        <asp:ListItem Text="Buscar Por Apellido" Value="APELLIDO"></asp:ListItem>
    </asp:RadioButtonList>


    <br />
    <table class="DispensarioTable">
        <tbody>
            <tr class="DispensarioTableHeader">
                <th>Apellido</th>
                <th>Nombre</th>
                <th>Telefono</th>
                <th>Nro. Doc.</th>
                
            </tr>
        </tbody>
    </table>
    
    <div class="DispensarioScrollBox">
        <table class="DispensarioTable">

            <tbody>
                <%
                
                    if (Session[Christoc.Modules.HistoriaClinica.View.key_pacientes] != null)
                    {
                        List<ConnectionDispensario.Modelos.Paciente> resultados = Session["KeyListaPacientes"] as List<ConnectionDispensario.Modelos.Paciente>;
                        foreach (ConnectionDispensario.Modelos.Paciente P in resultados)
                        {
                            Response.Write("<tr class=\"DispensarioTableContentRow\" onclick=\"ShowHistorial('" + P.GUID + "')\">");
                            Response.Write("<td>" + P.APELLIDO + "</td>");
                            Response.Write("<td>" + P.NOMBRE + "</td>");
                            Response.Write("<td>" + P.TELEFONO + "</td>");
                            Response.Write("<td>" + P.NRODOCUMENTO + "</td>");
                            
                            Response.Write("</tr>");

                        }
                        Session.Remove("KeyListaPacientes");
                        show_search.Value = "1";
                    }
                    else
                    {
                        Response.Write("No hay resultados");
                        show_search.Value = "0";
                    }
    
                %>
                <asp:HiddenField runat="server" ID="show_search" />
            </tbody>
        </table>
    </div>
</div>


<!-- Editor de historial -->
<div class="DispensarioContainer">
    
    <%  if (Session["Paciente"] != null)
        {
            ConnectionDispensario.Modelos.Paciente P = Session["Paciente"] as ConnectionDispensario.Modelos.Paciente;
            String ObraSocial = "(Ninguna)";
            String NumeroObraSocial = "(Ninguno)";
            if (P.IDOBRASOCIAL != 0) 
            {
                ConnectionDispensario.Modelos.ObraSocial OS = ConnectionDispensario.Modelos.ObraSocial.GetObraSocial(P.IDOBRASOCIAL);
                if (OS != null) 
                {
                    ObraSocial = OS.NOMBRE;
                    NumeroObraSocial = P.NROOBRASOCIAL;
                }
            }
            Response.Write("<div class=\"EncabezadoHistorial\">" + 
                "<img src='/DesktopModules/HistoriaClinica/images/iconhistory.png' style='width:32px;height:32px' />"
                + "Historial del paciente <b> "
                + P.NOMBRE + " "
                + P.APELLIDO +
                "</b> </br> Edad: <b>" + ConnectionDispensario.Utils.Conversiones.getAge(P.FECHA_NACIMIENTO) + "</b></br>" +
                "DNI: <b>" + P.NRODOCUMENTO + "</b></br>" +
                "Obra Social:<b>" + ObraSocial + "</b></br>" +
                "Nro. Obra Social:<b>" + NumeroObraSocial + "</b></br>" +
                "</div>");
        }   
        
    %>
</div>



<div class="DispensarioContainer" id="Gallery" runat="server">
    <div style="font-size: 18px">
        <b><u>Documentación digitalizada</u></b>
    </div>
    <%
        
        if (Session["Paciente"] != null)
        {
            ConnectionDispensario.Modelos.Paciente t_p = Session["Paciente"] as ConnectionDispensario.Modelos.Paciente;
            string idpaciente = t_p.ID.ToString();
            string path = Server.MapPath("/DesktopModules/Pacientes") + "\\ArchivosPacientes\\Paciente" + idpaciente;
            //Response.Write(path);

            if (System.IO.Directory.Exists(path) == true)
            {
                string[] files = Directory.GetFiles(path);
                for (int a = 0; a < files.Length; a++)
                {
                    string filename = Path.GetFileName(files[a]);
                    string extension = Path.GetFileName(files[a]);
                    if (filename.Contains("THMB") == true)
                    {
                        string fullpathbigfile = "/DesktopModules/Pacientes/ArchivosPacientes/Paciente" + idpaciente + "/" + filename.Remove(0, 4);
                        Response.Write("<div class=\"DispensarioThumb\" style=\"background-image:url('/DesktopModules/Pacientes/ArchivosPacientes/Paciente" + idpaciente + "/" + filename + "')\" onclick=\"OpenWindow('" + fullpathbigfile + "')\">");
                        Response.Write("<div class=\"InfoThumb\">");
                        Response.Write(File.GetCreationTime(files[a]).ToShortDateString());
                        Response.Write("</div>");
                        Response.Write("</div>");
                    }


                }
            }
        }
      
    %>
</div>

<div class="DispensarioContainer DispensarioContainerAlert" id="ContainerAlergias" runat="server">
    <img src="/DesktopModules/HistoriaClinica/images/iconallergy.png" style="width:32px;height:32px" />
    <b>Antecendentes Alérgicos:</b>
    <div>
        <% 
            if (Session["Paciente"] != null)
            {
                Paciente P = Session["Paciente"] as Paciente;
                List<Alergia> tempAl = Alergia.GetAlergiasByIdPaciente(P.ID);
                if (tempAl != null)
                {
                    for (int a = 0; a < tempAl.Count; a++)
                    {
                        Response.Write("- " + tempAl[a].NameAlergia + "<br/>");
                    }
                }
            }
           
            %>
        <asp:TextBox ID="txtAlergia" runat="server" ></asp:TextBox>
        <asp:Button runat="server" ID="btnGuardarAlergia" Text="+" OnClick="btnGuardarAlergia_Click" />
    </div>
</div>



<div class="DispensarioContainer DispensarioContainerMed" id="ContainerMedicacion" runat="server">
    <img src="/DesktopModules/HistoriaClinica/images/iconmed.png" style="width:32px;height:32px" />
    <b>Medicacion Habitual:</b>
    <div>
        <% 
            if (Session["Paciente"] != null)
            {
                Paciente P = Session["Paciente"] as Paciente;
                List<Medicacion> tempAl = Medicacion.GetMedicacionByIdPaciente(P.ID);
                if (tempAl != null)
                {
                    for (int a = 0; a < tempAl.Count; a++)
                    {
                        string button = "<input type=\"button\" value=\"-\" onclick=\"DelMed('" + tempAl[a].ID + "')\" /> ";
                        Response.Write("- " + tempAl[a].NameMedicacion + button  + "<br/>");
                    }
                }
            }
           
            %>
        <asp:TextBox ID="txtMedicacion" runat="server" ></asp:TextBox>
        <asp:Button runat="server" ID="btnGuardarMedicacion" Text="+" OnClick="btnGuardarMedicacion_Click" />
    </div>
</div>





<div class="DispensarioContainer" id="ContainerPatologiasPersonales" runat="server">
    <img src="/DesktopModules/HistoriaClinica/images/iconpp.png" style="width:32px;height:32px" />
   <b> Antecendentes Patologicos Personales:</b>
    <div>
        <% 
            if (Session["Paciente"] != null) 
            {
                Paciente P = Session["Paciente"] as Paciente;
                List<APP> tempAl = APP.GetAntecedentesByIdPaciente(P.ID);
                if (tempAl != null) 
                {
                    for (int a = 0; a < tempAl.Count; a++) 
                    {
                        Response.Write("- " + tempAl[a].Patologia + "<br/>");
                    }
                }
            }
            %>
        <asp:TextBox ID="txtPatologiasPersonales" runat="server" ></asp:TextBox>
        <asp:Button runat="server" ID="btnGuardarPatologiaPeronal" Text="+" OnClick="btnGuardarPatologiaPeronal_Click" />
    </div>
</div>

<div class="DispensarioContainer" id="ContainerPatologiasFamiliares" runat="server">
    <img src="/DesktopModules/HistoriaClinica/images/iconfp.png" style="width:32px;height:32px" />
    <b>Antecendentes Patologicos Familiares:</b>
    <div>
        <% 
            if (Session["Paciente"] != null) 
            {
                Paciente P = Session["Paciente"] as Paciente;
                List<APF> tempAl = APF.GetAntecedentesByIdPaciente(P.ID);
                if (tempAl != null) 
                {
                    for (int a = 0; a < tempAl.Count; a++) 
                    {
                        Response.Write("- " + tempAl[a].Patologia + "<br/>");
                    }
                }
            }
            %>
        <asp:TextBox ID="txtPatologiasFamiliares" runat="server" ></asp:TextBox>
        <asp:Button runat="server" ID="btnGuardarPatologiaFamiliar" Text="+" OnClick="btnGuardarPatologiaFamiliar_Click"     />
    </div>
</div>

<div class="DispensarioContainer" id="ContainerCirugias" runat="server">
    <img src="/DesktopModules/HistoriaClinica/images/iconcirugy.png" style="width:32px;height:32px" />
    <b>Antecendentes Quirurgicos:</b>
    <div>
         <% 
            if (Session["Paciente"] != null) 
            {
                Paciente P = Session["Paciente"] as Paciente;
                List<Cirugia> tempAl = Cirugia.GetCirugiasByIdPaciente(P.ID);
                if (tempAl != null) 
                {
                    for (int a = 0; a < tempAl.Count; a++) 
                    {
                        Response.Write("- " + tempAl[a].NameCirugia + "<br/>");
                    }
                }
            }
            %>
        <asp:TextBox ID="txtCirugia" runat="server" ></asp:TextBox>
        <asp:Button runat="server" ID="btnGuardarCirugia"  Text="+" OnClick="btnGuardarCirugia_Click"   />
    </div>
</div>

<div style="float:left;visibility:hidden">
    <div style="float:left;color:blue;background-color:#bab9b9;height:10px;width:10px;font-size:10px; vertical-align:middle; text-align:center; line-height:10px">X</div>
    <div style="float:left;color:blue;background-color:#bab9b9;height:10px;width:10px;font-size:10px; vertical-align:middle; text-align:center; line-height:10px">O</div>
    <div style="float:left;color:red;background-color:#bab9b9;height:10px;width:10px;font-size:10px; vertical-align:middle; text-align:center; line-height:10px">X</div>
    <div style="float:left;color:red;background-color:#bab9b9;height:10px;width:10px;font-size:10px; vertical-align:middle; text-align:center; line-height:10px">O</div>
<div style="width: 40px; height: 40px;visibility:hidden" id="diente">
    <svg viewBox="0 0 40 40" preserveAspectRatio="xMaxyMax">
        <polygon id="T" fill="white" stroke="black" stroke-width="1px" points="0,0 40,0 32,10 8,10" onclick="changeState(this)"></polygon>
        <polygon id="B" fill="white" stroke="black" stroke-width="1px" points="0,40 40,40 32,30 8,30" onclick="changeState(this)"></polygon>
        <polygon id="L" fill="white" stroke="black" stroke-width="1px" points="0,0 8,10 8,30 0,40" onclick="changeState(this)"></polygon>
        <polygon id="R" fill="white" stroke="black" stroke-width="1px" points="40,0 40,40 32,30 32,10" onclick="changeState(this)"></polygon>
        <polygon id="C" fill="white" stroke="black" stroke-width="1px" points="8,10 32,10 32,30 8,30" onclick="changeState(this)"></polygon>
        <!--<circle r="18" cx="20" cy="20" stroke-width="2px" stroke-opacity="0" fill-opacity="0"></circle>-->
    </svg>
</div>
</div>
<div></div>
<div id="HistorialClinico" style="padding-bottom: 10px; padding-top: 10px">
    <% if (Session["Paciente"] != null)
       {
           ConnectionDispensario.Modelos.Paciente P = (ConnectionDispensario.Modelos.Paciente)Session["Paciente"];
           if (P != null)
           {
               List<ConnectionDispensario.Modelos.Historial> HP = P.Get_Historial();
               if (HP != null)
               {
                   for (int a = 0; a < HP.Count; a++)
                   {
                       List<ConnectionDispensario.Modelos.ProfileUser> Profile = HP[a].GetProfileUser((int)Session["IdPortal"]);
                       Response.Write("<div class=\"ContenedorFichaMinimizada\" id=\"FichaMinimizada" + a.ToString() + "\">");
                       Response.Write("<div class=\"MaximizeButton\" onclick=\"MaximizarFicha(" + a.ToString() + ")\">+</div>");
                       string Puesto = "No establecido";
                       if (Profile != null && Profile.Count > 0)
                       {
                           for (int b = 0; b < Profile.Count; b++)
                           {
                               if (Profile[b].KEY == "Puesto")
                               {
                                   Puesto = Profile[b].VALUE;
                               }
                           }
                       }

                       Response.Write("(" + Puesto + ")" + " " + HP[a].FECHA.ToLongDateString());
                       Response.Write("</div>");

                       Response.Write("<div class=\"ContenedorFicha\" id=\"Ficha" + a.ToString() + "\">");
                       Response.Write("<div class=\"ProfesionalContainer\">");
                       Response.Write("<div class=\"MinimizeButton\" onclick=\"MinimizarFicha(" + a.ToString() + ")\">-</div>");
                       Response.Write("<img class=\"profilePicture\" src=\"/DnnImageHandler.ashx?mode=profilepic&userId=" + HP[a].IDUSER.ToString() + "&h=100&w=100\"></br>");



                       if (Profile != null && Profile.Count > 0)
                       {
                           for (int b = 0; b < Profile.Count; b++)
                           {
                               Response.Write(Profile[b].KEY + ":<b>" + Profile[b].VALUE + "</b></br>");

                           }
                       }
                       Response.Write("</div>");
                       Response.Write("<div class=\"DiagnosticoContainer\">");
                       Response.Write("<div>");
                       Response.Write("<b>" + HP[a].FECHA.ToLongDateString() + "</b>");

                       Response.Write("</div>");
                       Response.Write(HP[a].DIAGNOSTICO);
                       Response.Write("</div>");
                       Response.Write("</div>");
                   }
               }
           }


       } 
       
       
    %>
    <!--<div id="Muestra" style="height:150px"><div style="float:left;width:30%;height:100%"></div><div style="width:70%;float:right;height:100%"></div></div>-->
</div>
<div></div>
<div id="EditorDeHistorial" runat="server">
    <div>1) Redacte su diagnostico clínico en la caja de texto verde</div>
    <div id="ContainerCajaTexto">
        <textarea
            style="width: 100%; height: 300px; border: solid; border-color: #808080; resize: none; background-color: #e8f5e9;"
            id="CajaTexto"></textarea>
    </div>
    <asp:Button runat="server" Text="Guardar Diagnostico" CssClass="DispensarioButton2 DispensarioNormalButton" ID="btnGuardarDiagnostico" ClientIDMode="Static" OnClientClick="POSTHISTORIAL();return false;" />
    <input type="button" onclick="AumentarTTexto()" class="DispensarioButton2 DispensarioNormalButton" value="Aumentar Texto" />
    <input type="button" onclick="ReducirTTexto()" class="DispensarioButton2 DispensarioNormalButton" value="Reducir Texto" />
    <input type="button" onclick="ResetTTexto()" class="DispensarioButton2 DispensarioNormalButton" value="Normalizar Texto" />
</div>

<div id="Confirmation">
    <div>
        Desea borrar la medicación habitual?
    </div>
    <div>
        <input type="button" value="Si" onclick="ConfirmMed()" />
        <input type="button" value="No" onclick="CancelMed()" />

    </div>
</div>

<input type="hidden" id="IDP" value="<%= ((int)Session["IdPortal"]).ToString() %>" />
<input type="hidden" id="IDU" value="<%= ((int)Session["IdUser"]).ToString() %>" />
<input type="hidden" id="UIP" value="<%= (Session["Paciente"]!=null) ? ((ConnectionDispensario.Modelos.Paciente) Session["Paciente"]).GUID : "0" %>" />
<input type="hidden" id="Med" Value="" />
<script>

    function ConfirmMed()
    {
        Med = $("#Med").val();
        window.location.href = "/Historia-Clinica?delmed="+Med;
    }

    function CancelMed() {
        $("#Confirmation").dialog('close');
    }

    function DelMed(MedID)
    {
        $("#Med").val(MedID);
        $("#Confirmation").dialog('open');

    }

    function changeState(object) {
        if ($(object).attr('fill') == "white") {
            $(object).attr('fill', 'blue');
            return 0;
        }

        if ($(object).attr('fill') == "blue") {
            $(object).attr('fill', 'red');
            return 0;
        }

        if ($(object).attr('fill') == "red") {
            $(object).attr('fill', 'white');
            return 0;
        }
    }

    var NormalText = 16;

    function AumentarTTexto() {
        NormalText++;
        ChangeTextSize(NormalText);
    }

    function ReducirTTexto() {
        NormalText--;
        ChangeTextSize(NormalText);
    }

    function ResetTTexto() {
        NormalText = 16;
        ChangeTextSize(NormalText);
    }

    function ChangeTextSize(textsize) {
        var nts = textsize + 'px';
        $("#CajaTexto").css({
            'fontSize': nts, 'line-height': nts
        });
    }

    var M;

    function MinimizarFicha(idficha) {
        $("#Ficha" + idficha).hide();
        $("#FichaMinimizada" + idficha).show();
    }

    function MaximizarFicha(idficha) {
        $("#Ficha" + idficha).show();
        $("#FichaMinimizada" + idficha).hide();
    }

    function CreateDialog() {
        var dlg = $('#DialogPacienteSearch').dialog(
             {
                 closeOnEscape: true,
                 autoOpen: false,
                 draggable: false,
                 modal: true,
                 resizable: false,
                 autoResize: true,
                 dialogClass: 'dnnFormPopup',
                 width: 'auto'

             });
        dlg.parent().appendTo($("form:first"));
        dlg.parent().css('z-index', '1005');
    }

    function CreateDialogMed() {
        var dlg = $('#Confirmation').dialog(
             {
                 closeOnEscape: true,
                 autoOpen: false,
                 draggable: false,
                 modal: true,
                 resizable: false,
                 autoResize: true,
                 dialogClass: 'dnnFormPopup',
                 width: 'auto'

             });
        dlg.parent().appendTo($("form:first"));
        dlg.parent().css('z-index', '1005');
    }


    function ShowDialog() {
        $('#DialogPacienteSearch').dialog('open');
    }
    function HideDialog() {
        $('#DialogPacienteSearch').dialog('close');
    }
    CreateDialog();
    CreateDialogMed();


    if ($("#<%=show_search.ClientID%>").val() == "1") {
        ShowDialog();
    }

    function OpenWindow(path) {
        window.open(path);
    }

    function POSTHISTORIAL() {

        $.ajax({
            url: "/DesktopModules/HistoriaClinica/Pacientes.asmx/InsertHistory",
            data: { "Historial": $("#CajaTexto").val(), "IdUser": $('#IDU').val(), "IdPortal": $('#IDP').val(), "UIPaciente": $('#UIP').val() },
            method: "POST",
            cache: false,
            success: function (data) {
                alert("Datos Guardados con exito");
                $("#CajaTexto").val("");
                redirecttome();
            }
        });
    }
    function redirecttome() {
        window.location.href = "/Historia-Clinica";
    }
    function ShowHistorial(GUI) {
        window.location.href = "/Historia-Clinica?m=s&gui=" + GUI;
    }

    function EsconderTodasLasFichas() {
        $(".ContenedorFicha").hide();
    }

    $(function () { EsconderTodasLasFichas(); })

</script>
