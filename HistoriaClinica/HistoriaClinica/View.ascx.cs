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
using System.Collections.Generic;
using System.Web.Services;
using DotNetNuke.Security;
using DotNetNuke.Services.Exceptions;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Entities.Modules.Actions;
using DotNetNuke.Services.Localization;
using ConnectionDispensario;
using ConnectionDispensario.Modelos;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Text;
using System.Web.UI;

namespace Christoc.Modules.HistoriaClinica
{
    /// -----------------------------------------------------------------------------
    /// <summary>
    /// The View class displays the content
    /// 
    /// Typically your view control would be used to display content or functionality in your module.
    /// 
    /// View may be the only control you have in your project depending on the complexity of your module
    /// 
    /// Because the control inherits from HistoriaClinicaModuleBase you have access to any custom properties
    /// defined there, as well as properties from DNN such as PortalId, ModuleId, TabId, UserId and many more.
    /// 
    /// </summary>
    /// -----------------------------------------------------------------------------
    /// 

    public static class ControlRender
    {
        public static string LoadMyControl(System.Web.UI.Control C)
        {
            System.Text.StringBuilder sb = new StringBuilder();
            StringWriter sw = new StringWriter(sb);
            HtmlTextWriter writer = new HtmlTextWriter(sw);

            C.RenderControl(writer);
            return sb.ToString();
           

        }
    }

    public partial class View : HistoriaClinicaModuleBase, IActionable
    {

        
            
        public static string key_pacientes = "KeyListaPacientes";
       

       
            
           
        
        private DotNetNuke.Entities.Users.UserInfo Getuser(int ID, int IdPortal) 
        {
            DotNetNuke.Entities.Users.UserController UC = new DotNetNuke.Entities.Users.UserController();
            return UC.GetUser(IdPortal, ID);
           
        }

        private void CheckParameters()
        {
            
            if (Request["m"] != null) 
            {
                if (Request["gui"] != null) 
                {
                    if (Request["m"] == "s") 
                    {
                        Paciente P = Paciente.Select_Paciente_by_GUI(Request["gui"].ToString());
                        if (P != null) 
                        {
                            Session.Add("Paciente", P);
                            Response.Redirect("/Historia-Clinica");
                            

                        }

                    }
                }
            }
            if (Request["delmed"] != null) 
            {
                int med = int.Parse(Request["delmed"].ToString());
                Medicacion.Borrar(med);
                Response.Redirect("/Historia-Clinica");
            }
        }

        void ConstruirOdontograma() 
        {
            for (int a=18;a>10;a--){
            
            Tooth MyTooth = LoadControl("/DesktopModules/HistoriaClinica/Tooth.ascx") as Tooth;
            MyTooth.SetTooth(a);                
            Grupo1.Controls.Add(MyTooth);
            }
            
            for (int a = 21; a < 29; a++)
            {

                Tooth MyTooth = LoadControl("/DesktopModules/HistoriaClinica/Tooth.ascx") as Tooth;
                MyTooth.SetTooth(a);
                Grupo2.Controls.Add(MyTooth);
            }
            
            for (int a = 48; a > 40; a--)
            {

                Tooth MyTooth = LoadControl("/DesktopModules/HistoriaClinica/Tooth.ascx") as Tooth;
                MyTooth.SetTooth(a);
                Grupo3.Controls.Add(MyTooth);
            }
            
            for (int a = 31; a < 39; a++)
            {

                Tooth MyTooth = LoadControl("/DesktopModules/HistoriaClinica/Tooth.ascx") as Tooth;
                MyTooth.SetTooth(a);
                Grupo4.Controls.Add(MyTooth);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            EditorDeHistorial.ClientIDMode = System.Web.UI.ClientIDMode.Static;
            OdontogramaConstructor.ClientIDMode = System.Web.UI.ClientIDMode.Static;
            if (UserInfo.IsInRole("Administrativo") == true)
            {
                Session.Add("administrativo", "");
            }
            else
            {
                Session.Remove("administrativo");
            }
            
            try
            {
                EditorDeHistorial.ClientIDMode = System.Web.UI.ClientIDMode.Static;
                if (Session["Paciente"] == null)
                {
                    
                    EditorDeHistorial.Visible = false;
                    ContainerAlergias.Visible = false;
                    ContainerCirugias.Visible = false;
                    ContainerPatologiasFamiliares.Visible = false;
                    ContainerPatologiasPersonales.Visible = false;
                    ContainerMedicacion.Visible = false;
                    divHerramientas.Visible = false;
                }
                else
                {
                    ConstruirOdontograma();
                    Visible = true;
                }
                Session.Add("IdPortal", PortalId);
                Session.Add("IdUser", UserId);
                CheckParameters();
            }
            catch (Exception exc) //Module failed to load
            {
                Exceptions.ProcessModuleLoadException(this, exc);
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

        protected void Buscar_Click(object sender, EventArgs e)
        {
            Session.Remove(key_pacientes);
            List<Paciente> lp=null;
            if (SearchForm.SelectedValue.Contains("APELLIDO") == true)
            {
                 lp = Paciente.BuscarPacientesByApellido(StringSearch.Text);
            }
            if (SearchForm.SelectedValue.Contains("DNI") == true)
            {
                lp = Paciente.BuscarPacientesByDNI(StringSearch.Text);
            }
            if (lp != null) 
            {
                Session.Add(key_pacientes, lp);
            }
            
        }

        protected void btnGuardarAlergia_Click(object sender, EventArgs e)
        {
            if (Session["Paciente"]!=null && txtAlergia.Text!=""){
                Paciente P = Session["Paciente"] as Paciente;
                Alergia A = new Alergia(P.ID, txtAlergia.Text);
                A.Guardar();
                txtAlergia.Text="";
                }
        }

        protected void btnGuardarCirugia_Click(object sender, EventArgs e)
        {
            if (Session["Paciente"] != null && txtCirugia.Text!="")
            {
                Paciente P = Session["Paciente"] as Paciente;
                Cirugia A = new Cirugia(P.ID, txtCirugia.Text);
                A.Guardar();
                txtCirugia.Text = "";
            }
        }

        protected void btnGuardarPatologiaPeronal_Click(object sender, EventArgs e)
        {
            if (Session["Paciente"] != null && txtPatologiasPersonales.Text!="")
            {
                Paciente P = Session["Paciente"] as Paciente;
                APP A = new APP(P.ID, txtPatologiasPersonales.Text);
                A.Guardar();
                txtPatologiasPersonales.Text = "";
            }
        }

        protected void btnGuardarPatologiaFamiliar_Click(object sender, EventArgs e)
        {
            if (Session["Paciente"] != null && txtPatologiasFamiliares.Text!="")
            {
                Paciente P = Session["Paciente"] as Paciente;
                APF A = new APF(P.ID, txtPatologiasFamiliares.Text);
                A.Guardar();
                txtPatologiasFamiliares.Text = "";
            }
        }

        protected void btnGuardarMedicacion_Click(object sender, EventArgs e)
        {
            if (Session["Paciente"] != null && txtMedicacion.Text != "")
            {
                Paciente P = Session["Paciente"] as Paciente;
                Medicacion A = new Medicacion(P.ID, txtMedicacion.Text);
                A.Guardar();
                txtMedicacion.Text = "";
            }
        }
    }
}