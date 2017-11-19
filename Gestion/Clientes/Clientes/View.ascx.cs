/*
' Copyright (c) 2016  Christoc.com
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
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace Christoc.Modules.Clientes
{
    /// -----------------------------------------------------------------------------
    /// <summary>
    /// The View class displays the content
    /// 
    /// Typically your view control would be used to display content or functionality in your module.
    /// 
    /// View may be the only control you have in your project depending on the complexity of your module
    /// 
    /// Because the control inherits from ClientesModuleBase you have access to any custom properties
    /// defined there, as well as properties from DNN such as PortalId, ModuleId, TabId, UserId and many more.
    /// 
    /// </summary>
    /// -----------------------------------------------------------------------------
    public partial class View : ClientesModuleBase, IActionable
    {

        string KeyIDC = "IDC";
        string KeyVCC = "VCC";
        string KeyMOV = "mov";
        string KeyValue = "value";
        string Keyidc = "idcm";

        void ConfigHF() 
        {
            string[] splitter = { "?" };
            HF_Host.Value = "/DesktopModules/Clientes/API/ModuleTask/";
            HF_RawHost.Value = Request.RawUrl.Split(splitter,StringSplitOptions.None)[0];
            Data2.Connection.D_StaticWebService SWS = new Data2.Connection.D_StaticWebService();
            K.Value = SWS.GetPrivateKeyByIdUser(UserId);

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            
            try
            {
                ConfigHF();
                ConfigFields();

            }
            catch (Exception exc) //Module failed to load
            {
                Exceptions.ProcessModuleLoadException(this, exc);
            }
        }

        private void AddRowTotal(string labeltotal = "Total", String Monto = "0")
    {
        HtmlGenericControl MyTr = new HtmlGenericControl("tr");
        HtmlGenericControl MyLabel = new HtmlGenericControl("td");
        HtmlGenericControl MyTotal = new HtmlGenericControl("td");
        MyLabel.InnerText = labeltotal;
        MyTotal.InnerText = Monto;
            MyTotal.Attributes.Add("style","text-align:right;font-weight:bolder");
            MyLabel.Attributes.Add("style", "text-align:right;padding-right:10px;font-weight:bolder");
        MyLabel.Attributes.Add("Colspan", "2");
        MyTr.Controls.Add(MyLabel);
        MyTr.Controls.Add(MyTotal);
        TBDetalleCC.Controls.Add(MyTr);
    }

        private void AddRowDetalleCC(string Fecha="", String Detalle="", String Factura="0", String Monto="") 
        {
            HtmlGenericControl MyTr = new HtmlGenericControl("tr");

            HtmlGenericControl _fecha = new HtmlGenericControl("td");
            HtmlGenericControl _detalle = new HtmlGenericControl("td");
            HtmlGenericControl _monto = new HtmlGenericControl("td");
            HtmlGenericControl _a = new HtmlGenericControl("a");
            _monto.Attributes.Add("style", "text-align:right");
            _a.Attributes.Add("href", "/MyManager/ListadoDeComprobantes?VC=" + Factura);
            _a.Attributes.Add("target", "_blank");
            _a.InnerText = "[Factura]";
            

            if (Factura != "0")
            {
                _detalle.Controls.Add(_a);
            }
            else 
            {
                _detalle.InnerText = Detalle;
            }

            _fecha.InnerText = Fecha;
            
            _monto.InnerText = Monto;

            MyTr.Controls.Add(_fecha);
            MyTr.Controls.Add(_detalle);
            MyTr.Controls.Add(_monto);

            TBDetalleCC.Controls.Add(MyTr);
        }

        private void ConfigFields()
        {
           
            if (cmbprovincia.Items.Count == 0)
            {
                cmbprovincia.Items.Clear();
                List<Data2.Class.Struct_Provincia> LP = Data2.Class.Struct_Provincia.GetAll();
                Data2.Statics.Log.ADD(LP.Count.ToString(), this);
                if (LP != null && LP.Count > 0)
                {
                    for (int a = 0; a < LP.Count; a++)
                    {
                        ListItem LI = new ListItem(LP[a].getName(), LP[a].getName());

                        cmbprovincia.Items.Add(LI);
                    }
                }
            }

            DetalleCC.Visible = false;

            if (Request[KeyMOV] != null & Request[KeyValue] != null & Request[Keyidc] != null) 
            {
                
                    int idc = int.Parse(Request[Keyidc]);
                    decimal mount = Data2.Statics.Conversion.GetDecimal(Request[KeyValue]);
                    Data2.Class.Struct_Cliente SC = Data2.Class.Struct_Cliente.GetClient(idc, UserId);
                    if (SC != null)
                    {
                        SC.insertMovCliente(mount, Request[KeyMOV].ToUpper());
                        Response.Redirect(Request.RawUrl.Split('?')[0]+"?MSG=OK");
                        
                    }
                
            }

            if (Request["MSG"] != null)
            {
                MessageOK.Visible = true;
            }
            else 
            {
                MessageOK.Visible = false;
            }

            if (Request[KeyVCC] != null && !IsPostBack)
            {
                Data2.Class.Struct_Cliente _Cliente = Data2.Class.Struct_Cliente.GetClient(int.Parse(Request[KeyVCC].ToString()), UserId);
                if (_Cliente != null)
                {

                    String DataCliente = "";

                    DetalleCC.Visible = true;
                    List<Data2.Class.Struct_DetalleCuentaCorriente> DCC = _Cliente.GetDetalleCC();
                    if (DCC != null) 
                    {
                        decimal total = 0;
                        for (int a = 0; a < DCC.Count; a++) 
                        {
                            string detalle;
                            string idfactura="0";

                            

                            switch (DCC[a].TIPOCC)
                            {
                                case Data2.Class.Struct_DetalleCuentaCorriente.TipoDetalleCC.Entrega:
                                    detalle="Entrega";
                                    total = total - DCC[a].Monto;
                                    break;
                                case Data2.Class.Struct_DetalleCuentaCorriente.TipoDetalleCC.Factura:
                                    detalle="Factura";
                                    idfactura=DCC[a].IdFactura.ToString();
                                    total = total + DCC[a].Monto;
                                    break;
                                case Data2.Class.Struct_DetalleCuentaCorriente.TipoDetalleCC.Inicializacion:
                                    detalle="Inicio";
                                    total = total + DCC[a].Monto;
                                    break;
                                default: detalle="Error";
                                    break;

                            }
                            AddRowDetalleCC(DCC[a].Fecha.ToShortDateString(),detalle,idfactura,DCC[a].Monto.ToString("#.00"));

                        }
                        AddRowTotal("Total:",total.ToString("#.00"));
                    }
                }

            }
           

            if (Request[KeyIDC] != null && !IsPostBack)
            {
                Session.Remove(KeyIDC);
                Session.Add(KeyIDC, Request[KeyIDC].ToString());

                Data2.Class.Struct_Cliente SC = Data2.Class.Struct_Cliente.GetClient(int.Parse(Session[KeyIDC].ToString()), UserId);
                if (SC != null && !IsPostBack)
                {
                    txt_descuento.Text = SC.DESCUENTO.ToString("#.00");
                    txt_dnicuilcuit.Text = SC.DNI;
                    txt_domicilio.Text = SC.DOMICILIO;
                    txt_email.Text = SC.EMAIL;
                    txt_limite.Text = SC.LIMITEDECREDITO.ToString("#.00");
                    txt_localidad.Text = SC.LOCALIDAD;
                    txt_observaciones.Text = SC.OBSERVACIONES;
                    txt_razonsocial.Text = SC.RS;
                    cmbpais.SelectedValue = SC.PAIS;
                    cmbprovincia.SelectedValue = SC.PROVINCIA;
                    cmbsituacion.SelectedValue = SC.TIPOIVA;
                    HF_EU.Value = SC.ID.ToString();

                }

            }
            else 
            {
                HF_EU.Value = "0";
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

        protected void btnGuardar_Click(object sender, EventArgs e)
        {

            if (Session[KeyIDC] == null)
            {

                Data2.Class.Struct_Cliente CL = new Data2.Class.Struct_Cliente(
                    txt_razonsocial.Text,
                    txt_dnicuilcuit.Text,
                    cmbpais.SelectedValue,
                    cmbprovincia.SelectedValue,
                    txt_localidad.Text,
                    txt_domicilio.Text,
                    txt_observaciones.Text,
                    cmbsituacion.SelectedValue,
                    Data2.Statics.Conversion.GetDecimal(txt_descuento.Text),
                    txt_email.Text,
                    UserId,
                    Data2.Statics.Conversion.GetDecimal(txt_limite.Text),
                    chk_Suspendida.Checked);
                CL.Guardar();
            }
            else 
            {
                Data2.Class.Struct_Cliente SC = Data2.Class.Struct_Cliente.GetClient(int.Parse(Session[KeyIDC].ToString()), UserId);
                if (SC != null && Request[KeyIDC] != null)
                {
                    SC.DESCUENTO = Data2.Statics.Conversion.GetDecimal(txt_descuento.Text);
                    SC.DNI = txt_dnicuilcuit.Text;
                    SC.DOMICILIO = txt_domicilio.Text;
                    SC.EMAIL = txt_domicilio.Text;
                    SC.LIMITEDECREDITO = Data2.Statics.Conversion.GetDecimal(txt_limite.Text);
                    SC.LOCALIDAD = txt_localidad.Text;
                    SC.OBSERVACIONES = txt_observaciones.Text;
                    SC.PAIS = cmbpais.SelectedValue;
                    SC.PROVINCIA = cmbprovincia.SelectedValue;
                    SC.RS = txt_razonsocial.Text;
                    SC.TIPOIVA = cmbsituacion.SelectedValue;
                    SC.Guardar();
                    Session.Remove(KeyIDC);
                    Response.Redirect(Request.RawUrl.Split('?')[0]);
                }
                else 
                {
                    Session.Remove(KeyIDC);
                    HF_EU.Value = "0";
                    Response.Redirect(Request.RawUrl.Split('?')[0]);

                }
            }

        }
    }
}