<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="View.ascx.cs" Inherits="Christoc.Modules.Pacientes.View" %>
<%@ Import Namespace="System.IO" %>
<%@ Import Namespace="DotNetNuke" %>

<div>
    Administración de Pacientes
</div>
<asp:Button ID="btnNuevoPaciente" runat="server" CssClass="DispensarioButton DispensarioIconNewPaciente" Text="Agregar Paciente" OnClientClick="ShowForm();NewPaciente();return false;" ClientIDMode="Static" />
<asp:Button ID="btnBorrarPaciente" runat="server" CssClass="DispensarioButton DispensarioIconBorrarPaciente" Text="Borrar Paciente" OnClientClick="return false;" ClientIDMode="Static" />
<asp:Button ID="btnGuardarPaciente" runat="server" CssClass="DispensarioButton DispensarioIconGuardarPaciente" Text="Guardar Paciente" OnClientClick="" OnClick="btnGuardarPaciente_Click" ClientIDMode="Static" />
<asp:Button ID="btnBuscarPaciente" runat="server" CssClass="DispensarioButton DispensarioIconBuscarPaciente" Text="Buscar Paciente" OnClientClick="ShowDialogSearchPaciente();return false;" ClientIDMode="Static" />
<asp:Button ID="btnCancelarPaciente" runat="server" CssClass="DispensarioButton DispensarioIconCancelarPaciente" Text="Cancelar y Cerrar" OnClientClick="HideForm();CancelarPaciente();" OnClick="btnCancelarPaciente_Click" ClientIDMode="Static" />

<br />
<div>
    <% 
        if (Request["t"] != null && Request["mssg"] != null)
        {
            Response.Write("<div id='mssg' class='disp_" + Request["t"] + "'>" + Request["mssg"].Replace("-"," ") + "</div>");
        } 
    %>
</div>
<br />
<div class="DispensarioContainer" id="DispensarioContainer">
    <div class="DispensarioFieldContainer">
        <span class="DispensarioLabel">Apellido:</span>
        <asp:TextBox runat="server" ID="txtApellido" CssClass="DispensarioTextBox"></asp:TextBox>
    </div>
    <div class="DispensarioFieldContainer">
        <span class="DispensarioLabel">Nombre:</span>
        <asp:TextBox runat="server" ID="txtNombre" CssClass="DispensarioTextBox"></asp:TextBox>
    </div>
    <div class="DispensarioFieldContainer">
        <span class="DispensarioLabel">Nro. Doc.:</span>
        <asp:TextBox runat="server" ID="txtNumeroDoc" CssClass="DispensarioTextBox"></asp:TextBox>
    </div>
    <div class="DispensarioFieldContainer">
        <span class="DispensarioLabel">Domicilio:</span>
        <asp:TextBox runat="server" ID="txtDomicilio" CssClass="DispensarioTextBox"></asp:TextBox>
    </div>
    <div class="DispensarioFieldContainer">
        <span class="DispensarioLabel">Localidad:</span>
        <asp:TextBox runat="server" ID="txtLocalidad" CssClass="DispensarioTextBox"></asp:TextBox>
    </div>
    <div class="DispensarioFieldContainer">
        <span class="DispensarioLabel">Fecha Nacimiento:</span>
        <asp:TextBox runat="server" ID="txtdianac" CssClass="DispensarioTextBox DispensarioTinyTXT" MaxLength="2"></asp:TextBox>
        <span>/</span>
        <asp:TextBox runat="server" ID="txtmesnac" CssClass="DispensarioTextBox DispensarioTinyTXT" MaxLength="2"></asp:TextBox>
        <span>/</span>
        <asp:TextBox runat="server" ID="txtanonac" CssClass="DispensarioTextBox DispensarioTinyTXT" MaxLength="4"></asp:TextBox>
    </div>
    <div class="DispensarioFieldContainer">
        <span class="DispensarioLabel">Sexo:</span>
        <asp:DropDownList ID="cmbSexo" runat="server" ClientIDMode="Static">
        </asp:DropDownList>
    </div>
    <div class="DispensarioFieldContainer">
        <span class="DispensarioLabel">Teléfono:</span>
        <asp:TextBox runat="server" ID="txtTelefono" CssClass="DispensarioTextBox"></asp:TextBox>
    </div>
    <div class="DispensarioFieldContainer">
        <span class="DispensarioLabel">Obra Social:</span>
        <asp:DropDownList runat="server" ID="CmbObraSocial" ClientIDMode="Static">
        </asp:DropDownList>
    </div>
    <div class="DispensarioFieldContainer" id="nroDeAfiliado">
        <span class="DispensarioLabel">Nro. Afiliado:</span>
        <asp:TextBox runat="server" ID="txtNroAfiliado" CssClass="DispensarioTextBox"></asp:TextBox>
    </div>
</div>


<div class="DispensarioContainer">
    <asp:Button ID="btnAbrirTurnero" ClientIDMode="Static" runat="server" Text="Abrir Turnero" CssClass="DispensarioButton DispensarioIconBuscarPaciente" OnClientClick="AbrirTurnero();return false;" />
    <div id="carouselTurnos" runat="server" class="TurneroContainer">
    </div>
</div>

<div class="DispensarioContainer" id="Gallery">
    <%
        
        if (Session["KeyPaciente"] != null)
        {
            ConnectionDispensario.Modelos.Paciente t_p = Session["KeyPaciente"] as ConnectionDispensario.Modelos.Paciente;
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
<div class="DispensarioContainer" id="FileUploader">
    <span class="DispensarioLabel">Subir Archivo:</span>
    <label for="UPLFileUpload" id="LabelFileUpload" class="FileUploadFakeButton">Click aqui para agregar un archivo</label>
    <asp:FileUpload runat="server" ID="UPLFileUpload" ClientIDMode="Static" CssClass="FileUploadButton" />

    <asp:Button ID="BtnUpload" runat="server" CssClass="DispensarioButton DispensarioIconUploadPaciente" Text="Subir" OnClick="BtnUpload_Click" ClientIDMode="Static" Style="vertical-align: top" />
</div>



<div id="DialogPacienteSearch" title="Busqueda de pacientes">
    <asp:TextBox ID="StringSearch" runat="server" CssClass="DispensarioTextBox" ClientIDMode="Static"></asp:TextBox>
    <asp:Button ID="Buscar" runat="server" OnClick="Buscar_Click" CssClass="DispensarioButton DispensarioIconBuscarPaciente" Text="BUSCAR" />
    <asp:RadioButtonList runat="server" ID="SearchForOption">
        <asp:ListItem Text="Buscar por DNI" Value="DNI" Selected="true"></asp:ListItem>
        <asp:ListItem Text="Buscar por Apellido" Value="APE"></asp:ListItem>
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
                    if (Session["KeyListaPacientes"] != null)
                    {
                        List<ConnectionDispensario.Modelos.Paciente> resultados = Session["KeyListaPacientes"] as List<ConnectionDispensario.Modelos.Paciente>;
                        foreach (ConnectionDispensario.Modelos.Paciente P in resultados)
                        {
                            Response.Write("<tr class=\"DispensarioTableContentRow\" onclick=\"EditUser('" + P.GUID + "')\">");
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
            </tbody>
        </table>
    </div>
</div>

<%
    // int Edad = ConnectionDispensario.Utils.Conversiones.getAge(new DateTime(1985, 11, 16));
    // Response.Write(Edad.ToString());

%>

<asp:HiddenField ID="form_mode" ClientIDMode="Static" runat="server" Value="" />
<asp:HiddenField ID="show_search" ClientIDMode="Static" runat="server" />
<input id="IdPaciente" type="hidden" value="<% 
    
    if (Session["KeyPaciente"] != null)
    {
        ConnectionDispensario.Modelos.Paciente t_p = Session["KeyPaciente"] as ConnectionDispensario.Modelos.Paciente;
        Response.Write(t_p.ID.ToString());
    }
    else
    {
        Response.Write("0");
    }
    
     %>" />
<script type="text/javascript" src="/DesktopModules/Pacientes/jquery.jcarousel.min.js"></script>
<script>

    var ModeEdit = "ModeEdit";
    var ModeNew = "ModeNew";
    var ModeNone = "ModeNone";

    var idGallery = "#Gallery";
    var idFileUploader = "#FileUploader"
    var idbtnNuevoPaciente = "#btnNuevoPaciente";
    var idbtnBorrarPaciente = "#btnBorrarPaciente";
    var idbtnGuardarPaciente = "#btnGuardarPaciente";
    var idbtnBuscarPaciente = "#btnBuscarPaciente";
    var idbtnCancelarPaciente = "#btnCancelarPaciente";
    var idForm_Mode = "#form_mode";

    $("#CmbObraSocial").change(function () {
        if ($("#CmbObraSocial").val() != "0") {
            $("#nroDeAfiliado").show();
        } else {
            $("#nroDeAfiliado").hide();
        }
    });

    $("#UPLFileUpload").change(function () {
        var filename = $("#UPLFileUpload")[0].files[0].name;
        $("#LabelFileUpload").text(filename);


    });

    function OpenWindow(path) {
        window.open(path);
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

    function ShowDialogSearchPaciente() {
        $('#DialogPacienteSearch').dialog('open');
    }



    function HideForm() {
        $('#DispensarioContainer').hide(1000);
    }

    function CancelarPaciente() {
        $('#form_mode').val(ModeNone);
        $(idbtnCancelarPaciente).hide();
        $(idbtnGuardarPaciente).hide();
        HideForm();
    }

    function NewPaciente() {
        $('#form_mode').val(ModeNew);
        $(idbtnGuardarPaciente).show();
        $(idbtnCancelarPaciente).show();
    }

    function ShowForm() {
        $('#DispensarioContainer').show(1000);

    }

    function ConfigButtons() {

        if ($(idForm_Mode).val() == ModeNone) {
            $(idbtnBorrarPaciente).hide();
            $(idbtnCancelarPaciente).hide();
            $(idbtnGuardarPaciente).hide();
            $(idbtnCancelarPaciente).hide();
        }



    }

    function EditUser(usergui) {
        window.location.href = "/Gestion-de-pacientes?m=e&gui=" + usergui;
    }
    function TurnoPaciente(IdPaciente, IdUser) {
        alert("Turno Asignado");
        window.location.href = "/Gestion-de-pacientes?m=turno&IDP=" + IdPaciente + "&IDU=" + IdUser;
    }

    function CheckMode() {
        if ($('#form_mode').val() == ModeEdit) {
            ShowForm();
            $(idbtnNuevoPaciente).hide();
            $(idbtnBorrarPaciente).hide();
            $(idFileUploader).show();
            $(idGallery).show();
        } else {
            HideForm();
            $(idFileUploader).hide();
            $(idGallery).hide();
        }
    }

    function checkSearchDialog() {
        if ($("#show_search").val() == 1) {
            ShowDialogSearchPaciente();
        }
    }

    function AsignarTurno(Sender) {
        var ID = $(Sender).attr('UserID');
        var IDP = $('#IdPaciente').val();
        TurnoPaciente(IDP, ID);


    }

    function AbrirTurneroMedico(Sender) {
        var ID = $(Sender).attr('UserID');
        var MyWindow = window.open('/DesktopModules/Turnero/TurnoMedico.aspx?UIP=' + ID, 'Turnero', 'width=600,height=400', false);
        //$('#ContainerTurno' + ID).load('/DesktopModules/Turnero/TurnoMedico.aspx?UIP=' + ID);
    }

    function AbrirTurnero() {
        $('#carouselTurnos').toggle();
    }
    $('#carouselTurnos').hide();
    if ($('#IdPaciente').val() == "0") {
        $('#btnAbrirTurnero').hide();
    }
    CreateDialog();
    ConfigButtons();
    CheckMode();
    checkSearchDialog();

    function CloseMessage()
    {
        $('#mssg').hide(1000);
    }

    setTimeout(CloseMessage, 6000);



</script>
