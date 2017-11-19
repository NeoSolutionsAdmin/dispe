/*
' Copyright (c) 2017  Christoc.com
'  All rights reserved.
' 
' THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED
' TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL
' THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF
' CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
' DEALINGS IN THE SOFTWARE.
' 
*/

using System;
using DotNetNuke.Security;
using DotNetNuke.Services.Exceptions;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Entities.Modules.Actions;
using DotNetNuke.Services.Localization;
using ConnectionDispensario.Modelos;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using System.IO;
using System.Web.UI.HtmlControls;

namespace Christoc.Modules.Pacientes
{
    /// -----------------------------------------------------------------------------
    /// <summary>
    /// The View class displays the content
    /// 
    /// Typically your view control would be used to display content or functionality in your module.
    /// 
    /// View may be the only control you have in your project depending on the complexity of your module
    /// 
    /// Because the control inherits from PacientesModuleBase you have access to any custom properties
    /// defined there, as well as properties from DNN such as PortalId, ModuleId, TabId, UserId and many more.
    /// 
    /// </summary>
    /// -----------------------------------------------------------------------------
    public partial class View : PacientesModuleBase, IActionable
    {

        string SessionPaciente = "KeyPaciente";
        string SessionListaPacientes = "KeyListaPacientes";
        string ModeEdit = "ModeEdit";
        string ModeNew = "ModeNew";
        string ModeNone = "ModeNone";
        
        List<string> Errores;
        

        

        private void ConfigVars() 
        {
            if (Session[SessionPaciente] == null)
            {
                form_mode.Value = ModeNone;
            }
            else 
            {

                form_mode.Value = ModeEdit;
                if (!IsPostBack)
                {
                    LoadPaciente();
                }
                

            }
            if (Request["m"] != null) 
            {
                if (Request["m"] == "e") 
                {
                    Paciente t_p = ConnectionDispensario.Modelos.Paciente.Select_Paciente_by_GUI(Request["gui"]);
                    if (t_p != null) 
                    {
                        Session.Add(SessionPaciente, t_p);
                        Response.Redirect("/Gestion-de-pacientes");
                    }
                }
                
                //SACA TURNO
                if (Request["m"] == "turno")
                {
                    string IDP = Request["IDP"].ToString();
                    string IDU = Request["IDU"].ToString();
                    Turno T = new Turno(int.Parse(IDU), ((Paciente)Session[SessionPaciente]));
                    T.EstablecerTurno();
                    Session.Remove(SessionPaciente);
                    Response.Redirect("/Gestion-de-pacientes");
                }
            }
            
            
        }

        void LoadPaciente()
        {
            Paciente t_p = Session[SessionPaciente] as Paciente;
            txtApellido.Text = t_p.APELLIDO;
            txtNombre.Text = t_p.NOMBRE;
            txtNumeroDoc.Text = t_p.NRODOCUMENTO;
            txtTelefono.Text = t_p.TELEFONO;
            txtdianac.Text = t_p.FECHA_NACIMIENTO.Day.ToString();
            txtmesnac.Text = t_p.FECHA_NACIMIENTO.Month.ToString();
            txtanonac.Text = t_p.FECHA_NACIMIENTO.Year.ToString();
            txtDomicilio.Text = t_p.DOMICILIO;
            txtLocalidad.Text = t_p.LOCALIDAD;
            txtNroAfiliado.Text = t_p.NROOBRASOCIAL;
            

            for (int a = 0; a < CmbObraSocial.Items.Count; a++) 
            {
                if (CmbObraSocial.Items[a].Value == t_p.IDOBRASOCIAL.ToString()) 
                {
                    CmbObraSocial.SelectedIndex = a;
                    break;
                }
            }

            for (int a = 0; a < cmbSexo.Items.Count; a++) 
            {
                if (cmbSexo.Items[a].Value == t_p.SEXO) 
                {
                    cmbSexo.SelectedIndex = a;
                    break;
                }
            }

            
        }

        

        protected void Page_Load(object sender, EventArgs e)
        {
            ConfigControls();
            Errores = new List<string>();
            ConfigVars();
            ConfigTurnero();
           
            
            
            
            
                
            
            try
            {

            }
            catch (Exception exc) //Module failed to load
            {
                Exceptions.ProcessModuleLoadException(this, exc);
            }
        }

        private void ConfigTurnero()
        {
            carouselTurnos.ClientIDMode = System.Web.UI.ClientIDMode.Static;
            if (Session["KeyPaciente"] != null)
            {

                DotNetNuke.Entities.Portals.PortalController PC = new DotNetNuke.Entities.Portals.PortalController();
                System.Collections.ArrayList AL = DotNetNuke.Entities.Users.UserController.GetUsers(PortalId);
                for (int a = 0; a < AL.Count; a++)
                {
                    DotNetNuke.Entities.Users.UserInfo UI = (DotNetNuke.Entities.Users.UserInfo)AL[a];
                    System.Web.UI.HtmlControls.HtmlGenericControl HTML = new System.Web.UI.HtmlControls.HtmlGenericControl("div");
                    HTML.Attributes.Add("Class", "TurnoContainer");
                    
                    if (UI.IsInRole("Medico") == true)
                    {

                        List<ProfileUser> PU = ConnectionDispensario.Modelos.ProfileUser.getProfileUser(PortalId, UI.UserID);
                        HtmlGenericControl DivFoto = new HtmlGenericControl("div");
                        HtmlGenericControl DivDatos = new HtmlGenericControl("div");
                        HtmlGenericControl ButtonTurno = new HtmlGenericControl("Input");
                        HtmlGenericControl ButtonTurnero = new HtmlGenericControl("Input");

                        HtmlGenericControl DivTurnero = new HtmlGenericControl("div");
                        DivTurnero.ID = "ContainerTurno" + UI.UserID.ToString();
                        DivTurnero.ClientIDMode = System.Web.UI.ClientIDMode.Static;

                        ButtonTurno.Attributes.Add("Type", "Button");
                        ButtonTurno.Attributes.Add("Value", "Sacar Turno");
                        ButtonTurno.Attributes.Add("UserID", UI.UserID.ToString());
                        ButtonTurno.Attributes.Add("OnClick", "AsignarTurno(this)");
                        
                        ButtonTurnero.Attributes.Add("Type", "Button");
                        ButtonTurnero.Attributes.Add("Value", "Turnero");
                        ButtonTurnero.Attributes.Add("UserID", UI.UserID.ToString());
                        ButtonTurnero.Attributes.Add("OnClick", "AbrirTurneroMedico(this)");
                        


                        string ProfileData = "";
                        if (PU != null && PU.Count > 0)
                        {

                            for (int b = 0; b < PU.Count; b++)
                            {
                                ProfileData += "<b>" + PU[b].KEY + ":</b>" + PU[b].VALUE + "</br>";
                            }
                            DivDatos.InnerHtml = ProfileData;
                        }
                        String imagestyle = "background-image:url([token])";
                        imagestyle = imagestyle.Replace("[token]", "" + UI.Profile.PhotoURL + "");
                        DivFoto.Attributes.Add("Style", imagestyle);
                        DivFoto.Attributes.Add("Class", "fotoTurnero");
                        HTML.Controls.Add(DivFoto);
                        HTML.Controls.Add(DivDatos);
                        HTML.Controls.Add(ButtonTurno);
                        HTML.Controls.Add(ButtonTurnero);
                        HTML.Controls.Add(DivTurnero);

                        carouselTurnos.Controls.Add(HTML);
                    }
                }
            }
        }

        private void ConfigControls()
        {
            
            if (CmbObraSocial.Items.Count == 0) 
            {
                List<ObraSocial> OSL = ObraSocial.BuscarObrasSociales();
                ListItem LiNone = new ListItem("(Ninguno)", "0");
                CmbObraSocial.Items.Add(LiNone);
                if (OSL != null) 
                {
                    
                    
                    for (int a=0;a<OSL.Count;a++){
                        ListItem LI = new ListItem(OSL[a].NOMBRE, OSL[a].ID.ToString());
                        CmbObraSocial.Items.Add(LI);
                        }
                }
               
            }
            if (cmbSexo.Items.Count == 0) 
            {
                ListItem Masc = new ListItem("Masculino", "Masculino");
                ListItem Feme = new ListItem("Femenino", "Femenino");
                cmbSexo.Items.Add(Masc);
                cmbSexo.Items.Add(Feme);

            }
        }

        public ModuleActionCollection ModuleActions
        {
            get
            {
                var actions = new ModuleActionCollection
                    {
                        {
                            GetNextActionID(), Localization.GetString("EditModule", LocalResourceFile), "", "", "",
                            EditUrl(), false, SecurityAccessLevel.Edit, true, false
                        }
                    };
                return actions;
            }
        }

        protected void btnGuardarPaciente_Click(object sender, EventArgs e)
        {

            if (txtNroAfiliado.Text == null || txtNroAfiliado.Text == "")
            {
                txtNroAfiliado.Text = "0";
            }

            if (Session[SessionPaciente] == null)
            {
                

                try
                {
                    
                    DateTime t_dt = new DateTime(
                        int.Parse(txtanonac.Text),
                        int.Parse(txtmesnac.Text),
                        int.Parse(txtdianac.Text));
                    Paciente t_p = new Paciente(txtApellido.Text, txtNombre.Text, t_dt, txtNumeroDoc.Text,txtDomicilio.Text,txtLocalidad.Text, txtTelefono.Text,int.Parse(CmbObraSocial.SelectedValue),txtNroAfiliado.Text,cmbSexo.SelectedValue,ControlEmpty: true);
                    
                    bool result = t_p.Guardar();

                    if (result == true)
                    {
                        Response.Redirect("/Gestion-de-pacientes?mssg=Paciente-guardado&t=ok");
                    }
                    else 
                    {
                        Response.Redirect("/Gestion-de-pacientes?mssg=El-paciente-ya-se-encuentra-registrado-en-el-sistema&t=error");
                    }

                }
                catch (Exception E)
                {
                    ConnectionDispensario.Statics.LogCatcher.AddLog(E.Message, E.StackTrace, this, Session);
                }



            }
            else 
            {
                Paciente P = Session[SessionPaciente] as Paciente;
                P.APELLIDO = txtApellido.Text;
                P.NOMBRE = txtNombre.Text;
                P.NRODOCUMENTO = txtNumeroDoc.Text;
                P.TELEFONO = txtTelefono.Text;
                
               
                DateTime t_dt = new DateTime(
                       int.Parse(txtanonac.Text),
                       int.Parse(txtmesnac.Text),
                       int.Parse(txtdianac.Text));

                P.FECHA_NACIMIENTO = t_dt;
                P.DOMICILIO = txtDomicilio.Text;
                P.LOCALIDAD = txtLocalidad.Text;
                P.NROOBRASOCIAL = txtNroAfiliado.Text;
                P.IDOBRASOCIAL = int.Parse(CmbObraSocial.SelectedValue);
                P.SEXO = cmbSexo.SelectedValue;
                Session.Remove(SessionPaciente);
                
                bool result = P.Guardar();
                if (result == true)
                {
                    Response.Redirect("/Gestion-de-pacientes?mssg=Paciente-actualizado&t=ok");
                }
                else 
                {
                    Response.Redirect("/Gestion-de-pacientes?mssg=Error-al-actualizar-paciente&t=error");
                }

            }
        }

        protected void Buscar_Click(object sender, EventArgs e)
        {
            List<Paciente> LP;
            if (SearchForOption.SelectedValue == "APE")
            {
                LP = Paciente.BuscarPacientesByApellido(StringSearch.Text);
            }
            else 
            {
                LP = Paciente.BuscarPacientesByDNI(StringSearch.Text);
            }
            
            

                Session.Remove(SessionListaPacientes);
          
                Session.Add(SessionListaPacientes, LP);
            
            
           
        }

        protected void btnCancelarPaciente_Click(object sender, EventArgs e)
        {
            Session.Remove(SessionPaciente);
            Session.Remove(SessionListaPacientes);
            Response.Redirect("/Gestion-de-pacientes");
            
        }

        bool delegateforthat() 
        {
            return false;
        }

        protected void BtnUpload_Click(object sender, EventArgs e)
        {
            
            string Map = Server.MapPath("/DesktopModules/Pacientes");
            if (Directory.Exists(Map)==true)
            {
                ConnectionDispensario.Statics.LogCatcher.AddLog("El directorio existe", Map, this, Session);
                if (Directory.Exists(Map + "\\ArchivosPacientes")==false)
                {
                    ConnectionDispensario.Statics.LogCatcher.AddLog("Intentando crear directorio", Map, this, Session);
                    Directory.CreateDirectory(Map + "\\ArchivosPacientes");
                }
                else 
                {
                    ConnectionDispensario.Statics.LogCatcher.AddLog("El directorio Archivos de pacientes existe", Map, this, Session);
                }
                Paciente t_p = Session[SessionPaciente] as Paciente;
                string NomenclaturaPaciente = "Paciente"+t_p.ID.ToString();

                if (Directory.Exists(Map+"\\ArchivosPacientes\\"+NomenclaturaPaciente)==false)
                {
                    Directory.CreateDirectory(Map + "\\ArchivosPacientes\\" + NomenclaturaPaciente);
                }
                if (UPLFileUpload.HasFile) 
                {
                    char[] splitter = {'.'};
                    string extension = UPLFileUpload.FileName.Split(splitter)[1];
                    if (extension.ToLower() == "jpg" || extension.ToLower() == "jpg" || extension.ToLower() == "png" || extension.ToLower() == "bmp")
                    {

                        string Second;
                        string Minute;
                        string Hour;
                        string Day;
                        string Month;
                        string Year;

                        DateTime N = DateTime.Now;

                        if (N.Second.ToString().Length == 1) { Second = "0" + N.Second.ToString(); } else { Second = N.Second.ToString(); }
                        if (N.Minute.ToString().Length == 1) { Minute = "0" + N.Minute.ToString(); } else { Minute = N.Minute.ToString(); }
                        if (N.Hour.ToString().Length == 1) { Hour = "0" + N.Hour.ToString(); } else { Hour = N.Hour.ToString(); }
                        if (N.Day.ToString().Length == 1) { Day = "0" + N.Day.ToString(); } else { Day = N.Day.ToString(); }
                        if (N.Month.ToString().Length == 1) { Month = "0" + N.Month.ToString(); } else { Month = N.Month.ToString(); }
                        if (N.Year.ToString().Length == 1) { Year = "0" + N.Year.ToString(); } else { Year = N.Year.ToString(); }

                        string filename = Year + Month + Day + Hour + Minute + Second;



                        UPLFileUpload.SaveAs(Map + "\\ArchivosPacientes\\" + NomenclaturaPaciente + "\\" + filename + "." + extension);

                        System.Drawing.Image I = System.Drawing.Image.FromFile(Map + "\\ArchivosPacientes\\" + NomenclaturaPaciente + "\\" + filename + "." + extension);
                        System.Drawing.Image.GetThumbnailImageAbort G = new System.Drawing.Image.GetThumbnailImageAbort(delegateforthat);
                        System.Drawing.Image T = I.GetThumbnailImage(100, 100, G, IntPtr.Zero);
                        T.Save(Map + "\\ArchivosPacientes\\" + NomenclaturaPaciente + "\\" + "THMB" + filename + "." + extension);

                    }
                       
                    
                    
                }
                
            }
            else 
            {
                
            }

        }
    }
}