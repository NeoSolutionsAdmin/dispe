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
using System.Collections.Generic;
using DotNetNuke.Security;
using DotNetNuke.Services.Exceptions;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Entities.Modules.Actions;
using DotNetNuke.Services.Localization;
using System.Web.UI.HtmlControls;
using Data2.Class;

namespace Christoc.Modules.ListadoFacturas
{
    /// -----------------------------------------------------------------------------
    /// <summary>
    /// The View class displays the content
    /// 
    /// Typically your view control would be used to display content or functionality in your module.
    /// 
    /// View may be the only control you have in your project depending on the complexity of your module
    /// 
    /// Because the control inherits from ListadoFacturasModuleBase you have access to any custom properties
    /// defined there, as well as properties from DNN such as PortalId, ModuleId, TabId, UserId and many more.
    /// 
    /// </summary>
    /// -----------------------------------------------------------------------------
    public partial class View : ListadoFacturasModuleBase, IActionable
    {

        public class SubMateriasPrimas
        {
            public int IdMateriaPrima;
            public decimal CANTDEC;
            public int CANTINT;
            public bool isdec;
        }

        string sessionkey = "SearchFacturas";


        HtmlGenericControl GenerarFilaPieFactura(string p_label, string p_value)
        {
            HtmlGenericControl _row = new HtmlGenericControl("tr");
            HtmlGenericControl _label = new HtmlGenericControl("td");
            HtmlGenericControl _value = new HtmlGenericControl("td");
            _row.Attributes.Add("Class", "colorpiedefactura");
            _label.Attributes.Add("colspan", "3");
            _label.InnerText = p_label;
            _label.Attributes.Add("Class", "valuepiedefactura labelpiedefactura");
            _value.InnerText = "$ " + p_value;
            _value.Attributes.Add("Class", "valuepiedefactura");

            _row.Controls.Add(_label);
            _row.Controls.Add(_value);
            return _row;
        }

        HtmlGenericControl GenerarFilaDetalle(string cant, string detalle, string importe, string total, bool alternatecolor)
        {
            string classrow;
            if (alternatecolor) { classrow = "metroparline animationline"; } else { classrow = "metroimparline animationline"; }
            HtmlGenericControl _row = new HtmlGenericControl("tr");
            HtmlGenericControl _cant = new HtmlGenericControl("td");
            HtmlGenericControl _desc = new HtmlGenericControl("td");
            HtmlGenericControl _precu = new HtmlGenericControl("td");
            HtmlGenericControl _total = new HtmlGenericControl("td");
            _desc.Attributes.Add("Class", "descripcionarticulo");
            _cant.Attributes.Add("class", "valuepiedefactura");
            _precu.Attributes.Add("class", "valuepiedefactura");
            _total.Attributes.Add("class", "valuepiedefactura");
            _cant.InnerText = cant.ToString();
            _desc.InnerText = detalle;
            _precu.InnerText = "$ " + importe.ToString();
            _total.InnerText = "$ " + total;
            _row.Attributes.Add("Class", classrow);
            _row.Controls.Add(_cant);
            _row.Controls.Add(_desc);
            _row.Controls.Add(_precu);
            _row.Controls.Add(_total);
            return _row;
        }

        void LlenarFactura(int facturaid, int idRemito = 0)
        {



            Struct_Factura _F = Struct_Factura.GetFacturaById(UserId, facturaid);

            try
            {
                if (idRemito == 1)
                {

                    Struct_Remito R = Struct_Remito.Get_Remito(facturaid, UserId);
                    _F = new Struct_Factura(R);
                    _F.IsRemito = true;
                    _F.Remito.GetAndFillDetalle();
                }
            }
            catch (Exception E)
            {
                Data2.Statics.Log.ADD(E.StackTrace + "(" + E.Message + ")", this);
            }
            if (_F != null)
            {
                if (_F.IsRemito == false)
                {

                    field_date.InnerText = _F.Fecha.ToLongDateString();
                    field_domi.InnerText = _F.domicilio;
                    field_iva.InnerText = _F.Condicion_IVA.ToString();
                    field_name.InnerText = _F.senores;
                    field_pay.InnerText = _F.Pago.ToString();
                    field_phone.InnerText = _F.telefono;

                    List<Struct_DetalleFactura> List_detalle = _F.GetDetalle();
                    if (List_detalle != null && List_detalle.Count > 0)
                    {
                        int renglones = 1;
                        bool alternate = false;
                        foreach (Struct_DetalleFactura D in List_detalle)
                        {
                            string _cantidad;
                            string _preciou;
                            string _total;

                            if (D.isdec) { _cantidad = D.DETALLEDEC.ToString("#.00"); } else { _cantidad = D.DETALLEINT.ToString(); }
                            if (_F.FacturaTipo == Struct_Factura.TipoDeFactura.FacturaA) { _preciou = D.getPrecioFinalSinIva().ToString("#.00"); } else { _preciou = D.PRODUCTO.PrecioFinal.ToString("#.00"); }
                            if (_F.FacturaTipo == Struct_Factura.TipoDeFactura.FacturaA) { _total = D.getTotalSinIva().ToString("#.00"); } else { _total = D.getTotalConIva().ToString("#.00"); }

                            HtmlGenericControl _HTMLCONTROL = GenerarFilaDetalle(_cantidad, D.PRODUCTO.Descripcion, _preciou, _total, alternate);
                            Table_detail.Controls.AddAt(renglones, _HTMLCONTROL);
                            if (alternate) { alternate = false; } else { alternate = true; }

                            renglones++;//Para que los meta en orden correspondiente
                        }
                    }
                    if (_F.FacturaTipo == Struct_Factura.TipoDeFactura.FacturaA)
                    {

                        Table_detail.Controls.Add(GenerarFilaPieFactura("Sub Total:", _F.subtotal.ToString("#.00")));

                        foreach (decimal DEC in _F.GetIvasInscriptos())
                        {
                            decimal _CurrentIva = _F.GetTotalDeInsceripcionIva(DEC);
                            Table_detail.Controls.Add(GenerarFilaPieFactura("IVA Insc: " + DEC.ToString("#.00") + "%", _CurrentIva.ToString("#.00")));
                        }
                    }

                    Table_detail.Controls.Add(GenerarFilaPieFactura("Total:", _F.total.ToString("#.00")));

                }
                else
                {

                    try
                    {

                        field_date.InnerText = _F.Remito.Fecha.ToLongDateString();
                        field_domi.InnerText = _F.Remito.get_SUPPLIER().Localidad;
                        field_iva.InnerText = "";
                        field_name.InnerText = _F.Remito.get_SUPPLIER().NombreFantasia;
                        field_pay.InnerText = "";
                        field_phone.InnerText = _F.Remito.get_SUPPLIER().Telefono1;



                        List<Struct_DetalleRemito> List_detalle = _F.Remito.GetAndFillDetalle();

                        if (List_detalle != null && List_detalle.Count > 0)
                        {
                            int renglones = 1;
                            bool alternate = false;
                            foreach (Struct_DetalleRemito D in List_detalle)
                            {
                                string _cantidad;
                                string _preciou;
                                string _total;

                                if (D.IsDecimal) { _cantidad = D.CANTDEC.ToString("#.00"); } else { _cantidad = D.CANTINT.ToString(); }
                                _preciou = D.Costo.ToString("#.00");
                                _total = D.Total.ToString("#.00");

                                HtmlGenericControl _HTMLCONTROL = GenerarFilaDetalle(_cantidad, D.P.Descripcion, D.Costo.ToString("#.00"), D.Total.ToString("#.00"), alternate);
                                Table_detail.Controls.AddAt(renglones, _HTMLCONTROL);
                                if (alternate) { alternate = false; } else { alternate = true; }

                                renglones++;//Para que los meta en orden correspondiente
                            }
                        }


                        Table_detail.Controls.Add(GenerarFilaPieFactura("Total:", _F.Remito.total.ToString("#0.00")));
                    }
                    catch (Exception E)
                    {
                        Data2.Statics.Log.ADD(E.StackTrace + "(" + E.Message + ")", this);
                    }
                }







            }
        }




        protected void Page_Load(object sender, EventArgs e)
        {



            string[] split = { "?" };
            urlbase.Value = Request.RawUrl.Split(split, StringSplitOptions.None)[0];
            try
            {

                if (Request["VC"] != null)
                {
                    if (Request["R"] == null)
                    {
                        LlenarFactura(int.Parse(Request["VC"].ToString()));
                    }
                    else
                    {
                        LlenarFactura(int.Parse(Request["VC"].ToString()), int.Parse(Request["R"].ToString()));
                    }

                }

                if (Session[sessionkey] != null)
                {
                    BuildStatics();
                    BuildSearch();
                    BuildGraph();

                }
                else
                {
                    HF_Data.Value = "0";
                }

            }
            catch (Exception exc) //Module failed to load
            {
                Exceptions.ProcessModuleLoadException(this, exc);
            }
        }

        private void BuildGraph()
        {

            List<Data2.Class.Struct_Factura> _LF = Session[sessionkey] as List<Data2.Class.Struct_Factura>;
            List<Data2.Class.Struct_Remito> _LR = Struct_Remito.GetAllRemitos(UserId);

            if (_LF != null && _LF.Count > 0)
            {
                HF_Data.Value = "1";
                int _FA = 0;
                int _FB = 0;
                int _FC = 0;
                int _FX = 0;
                int _FP = 0;
                int _R = 0;

                if (_LR != null)
                {
                    _R = _LR.Count;
                }

                for (int a = 0; a < _LF.Count; a++)
                {
                    switch (_LF[a].FacturaTipo)
                    {
                        case Struct_Factura.TipoDeFactura.FacturaA:
                            _FA++;
                            break;
                        case Struct_Factura.TipoDeFactura.FacturaB:
                            _FB++;
                            break;
                        case Struct_Factura.TipoDeFactura.FacturaC:
                            _FC++;
                            break;
                        case Struct_Factura.TipoDeFactura.FacturaX:
                            _FX++;
                            break;
                        case Struct_Factura.TipoDeFactura.Presupuesto:
                            _FP++;
                            break;
                    }
                }

                HF_DataCant.Value = _FA.ToString() + "," + _FB.ToString() + "," + _FC.ToString() + "," + _FX.ToString() + "," + _FP.ToString() + "," + _R.ToString();
                HF_DataTitle.Value = "Comprobantes periodo:" + _LF[0].Fecha.ToShortDateString() + "-" + _LF[_LF.Count - 1].Fecha.ToShortDateString();
            }
            else
            {
                HF_Data.Value = "0";
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

        void BuildStatics()
        {
            List<Struct_DetalleFactura> MyProds = new List<Struct_DetalleFactura>();
            List<SubMateriasPrimas> SubMatPrim = new List<SubMateriasPrimas>();

            MyProds.Clear();
            SubMatPrim.Clear();

            ListOfProducts.Controls.Clear();
            ListOfMateriasPrimas.Controls.Clear();
            

            if (Session[sessionkey] != null)
            {
                List<Data2.Class.Struct_Factura> _LF = Session[sessionkey] as List<Data2.Class.Struct_Factura>;
                for (int FACTURAS = 0; FACTURAS < _LF.Count; FACTURAS++)
                {
                    Struct_Factura F = _LF[FACTURAS];
                    if (F.GetDetalle() != null && F.GetDetalle().Count > 0)
                    {

                        for (int DFC = 0; DFC < F.GetDetalle().Count; DFC++)
                        {
                            Struct_DetalleFactura DF = F.GetDetalle()[DFC];
                            bool coincidenceMat = false;
                            for (int SBMC = 0; SBMC < SubMatPrim.Count; SBMC++)
                            {
                                SubMateriasPrimas SMP = SubMatPrim[SBMC];
                                if (DF.PRODUCTO.MateriaPrima == SMP.IdMateriaPrima)
                                {
                                    if (DF.isdec == true)
                                    {
                                        SMP.CANTDEC = SMP.CANTDEC + DF.DETALLEDEC;
                                    }
                                    else
                                    {
                                        SMP.CANTINT = SMP.CANTINT + DF.DETALLEINT;
                                    }
                                    coincidenceMat = true;
                                    break;
                                }
                            }
                            if (coincidenceMat == false)
                            {
                                SubMateriasPrimas NSMP = new SubMateriasPrimas();
                                NSMP.IdMateriaPrima = DF.PRODUCTO.MateriaPrima;
                                NSMP.CANTDEC = DF.DETALLEDEC;
                                NSMP.CANTINT = DF.DETALLEINT;
                                NSMP.isdec = DF.isdec;
                                SubMatPrim.Add(NSMP);
                            }
                        }


                        for (int DFC = 0; DFC < F.GetDetalle().Count; DFC++)
                        {
                            Struct_DetalleFactura DF = F.GetDetalle()[DFC];
                            bool coincidenceProd = false;
                            for (int UDFC = 0; UDFC < MyProds.Count; UDFC++)
                            {
                                Struct_DetalleFactura UDF = MyProds[UDFC];
                                if (DF.PRODUCTO.Id == UDF.PRODUCTO.Id)
                                {
                                    if (UDF.isdec == true)
                                    {
                                        decimal cant = DF.DETALLEDEC + UDF.DETALLEDEC;
                                        UDF.set_cant(cant.ToString());
                                    }
                                    else
                                    {
                                        int cant = DF.DETALLEINT + UDF.DETALLEINT;
                                        UDF.set_cant(cant.ToString());
                                    }
                                    coincidenceProd = true;
                                    break;
                                }
                            }
                            if (coincidenceProd == false) { MyProds.Add(DF.Clone() as Struct_DetalleFactura); }
                        }
                    }
                }
            }

            int max = 0;

            if (MyProds != null && MyProds.Count > 0)
            {


                for (int a = 0; a < MyProds.Count; a++)
                {
                    int newval = 0;
                    if (MyProds[a].isdec == true)
                    {
                        newval = decimal.ToInt32(MyProds[a].DETALLEDEC) + 1;
                    }
                    else
                    {
                        newval = MyProds[a].DETALLEINT + 1;
                    }

                    if (max <= newval) max = newval;

                }
            }

            Random R = new Random(DateTime.Now.Millisecond);




            if (MyProds != null && MyProds.Count > 0)
            {
                decimal total = 0;
                HtmlGenericControl headerDiv = new HtmlGenericControl("div");
                HtmlGenericControl DescHeader = new HtmlGenericControl("span");
                HtmlGenericControl CantHeader = new HtmlGenericControl("span");
                HtmlGenericControl TotalVentaheader = new HtmlGenericControl("span");
                DescHeader.Attributes.Add("style", "width:200px;background-color:#EEEEEE;text-align:center;display:inline-block;font;font-weight:bolder");
                CantHeader.Attributes.Add("style", "width:100px;background-color:#EEEEEE;text-align:center;display:inline-block;font-weight:bolder");
                TotalVentaheader.Attributes.Add("style", "width:100px;background-color:#EEEEEE;text-align:center;display:inline-block;font-weight:bolder");

                DescHeader.InnerText="Detalle";
                CantHeader.InnerText = "Cantidad";
                TotalVentaheader.InnerText = "Total";

                headerDiv.Controls.Add(DescHeader);
                headerDiv.Controls.Add(CantHeader);
                headerDiv.Controls.Add(TotalVentaheader);
                ListOfProducts.Controls.Add(headerDiv);

                for (int a = 0; a < MyProds.Count; a++)
                {
                    HtmlGenericControl StaticContainer = new HtmlGenericControl("div");
                    HtmlGenericControl DescContainer = new HtmlGenericControl("span");
                    HtmlGenericControl CantContainer = new HtmlGenericControl("span");
                    HtmlGenericControl TotalVentaContainer = new HtmlGenericControl("span");
                    HtmlGenericControl Bar = new HtmlGenericControl("div");
                    


                    string colorvalue = "#" + R.Next(10, 250).ToString("X2");
                    colorvalue += R.Next(10, 250).ToString("X2");
                    colorvalue += R.Next(10, 250).ToString("X2");





                    DescContainer.Attributes.Add("style", "width:200px;background-color:#EEEEEE;display:inline-block");
                    CantContainer.Attributes.Add("style", "width:100px;background-color:#EEEEEE;text-align:right;display:inline-block");
                    TotalVentaContainer.Attributes.Add("style", "width:100px;background-color:#EEEEEE;text-align:right;display:inline-block");
                    if (Struct_Producto.Get_SingleArticle(UserId, MyProds[a].PRODUCTO.MateriaPrima) != null)
                    {
                        DescContainer.InnerText = MyProds[a].PRODUCTO.Descripcion + "(" + Struct_Producto.Get_SingleArticle(UserId, MyProds[a].PRODUCTO.MateriaPrima).Descripcion + ")";
                    }
                    else
                    {
                        DescContainer.InnerText = MyProds[a].PRODUCTO.Descripcion;
                    }

                    int cant = 0;
                    if (MyProds[a].isdec == true)
                    {
                        CantContainer.InnerText = MyProds[a].DETALLEDEC.ToString("#.000");
                        cant = decimal.ToInt32(MyProds[a].DETALLEDEC);

                    }
                    else
                    {
                        CantContainer.InnerText = MyProds[a].DETALLEINT.ToString("#.000");
                        cant = MyProds[a].DETALLEINT;
                    }

                    int newvalpix = (cant * 400) / max;

                    Bar.Attributes.Add("style", "width:" + newvalpix.ToString() + "px;background-color:" + colorvalue + ";height:10px");



                    TotalVentaContainer.InnerText = "$" + MyProds[a].getTotalConIva().ToString("#.00");
                    total = total + MyProds[a].getTotalConIva();
                    StaticContainer.Controls.Add(DescContainer);
                    StaticContainer.Controls.Add(CantContainer);
                    StaticContainer.Controls.Add(TotalVentaContainer);
                    ListOfProducts.Controls.Add(StaticContainer);
                    ListOfProducts.Controls.Add(Bar);




                }
                HtmlGenericControl DivTotal = new HtmlGenericControl("div");
                DivTotal.InnerText = "Total: $" + total.ToString("#.00");
                ListOfProducts.Controls.Add(DivTotal);
            }
            if (SubMatPrim != null && SubMatPrim.Count > 0)
            {
                for (int a = 0; a < SubMatPrim.Count; a++)
                {
                    if (SubMatPrim[a].IdMateriaPrima != 0) { 
                    
                        Struct_Producto Product = Struct_Producto.Get_SingleArticle(UserId, SubMatPrim[a].IdMateriaPrima);
                        if (Product != null)
                        {
                            HtmlGenericControl MatPrimContainer = new HtmlGenericControl("div");
                            HtmlGenericControl DescMatPrim = new HtmlGenericControl("span");
                            HtmlGenericControl CantMatPrim = new HtmlGenericControl("span");
                            DescMatPrim.Attributes.Add("style", "width:200px;background-color:#EEEEEE;display:inline-block");
                            CantMatPrim.Attributes.Add("style", "width:100px;background-color:#EEEEEE;display:inline-block");

                            DescMatPrim.InnerText = Product.Descripcion;
                            if (SubMatPrim[a].isdec == true)
                            {
                                CantMatPrim.InnerText = SubMatPrim[a].CANTDEC.ToString("#.00");
                            }
                            else
                            {
                                CantMatPrim.InnerText = SubMatPrim[a].CANTDEC.ToString("#.00");
                            }
                            MatPrimContainer.Controls.Add(DescMatPrim);
                            MatPrimContainer.Controls.Add(CantMatPrim);
                            ListOfMateriasPrimas.Controls.Add(MatPrimContainer);

                        }
                    }

                }
            }

        }
    

        void BuildSearch()
        {
            
            if (Session[sessionkey] != null)
            {

                List<Data2.Class.Struct_Factura> _LF = Session[sessionkey] as List<Data2.Class.Struct_Factura>;
                ListadoFacturas.Controls.Clear();

                foreach (Data2.Class.Struct_Factura F in _LF)
                {


                    HtmlGenericControl ParentDiv = new HtmlGenericControl("Div");
                    HtmlGenericControl ParentTable = new HtmlGenericControl("Table");
                    HtmlGenericControl ParentRow = new HtmlGenericControl("tr");
                    HtmlGenericControl ColumnLetter = new HtmlGenericControl("td");
                    HtmlGenericControl ColumnInfo = new HtmlGenericControl("td");
                    HtmlGenericControl Letter = new HtmlGenericControl("Div");
                    HtmlGenericControl Info = new HtmlGenericControl("Div");




                    string facturatipo = "";
                    string infofactura;
                    if (!F.IsRemito)
                    {
                        if (F.FacturaTipo == Struct_Factura.TipoDeFactura.FacturaA) facturatipo = "A";
                        if (F.FacturaTipo == Struct_Factura.TipoDeFactura.FacturaB) facturatipo = "B";
                        if (F.FacturaTipo == Struct_Factura.TipoDeFactura.FacturaC) facturatipo = "C";
                        if (F.FacturaTipo == Struct_Factura.TipoDeFactura.FacturaX) facturatipo = "X";
                        if (F.FacturaTipo == Struct_Factura.TipoDeFactura.Presupuesto) facturatipo = "P";
                    }
                    else 
                    {
                        facturatipo = "R";
                    }
                    Letter.Attributes.Add("Class", "LetraFactura");
                    string total = F.total.ToString("#.00");
                    if (F.IsRemito)
                    {
                        total = F.Remito.total.ToString("#.00");
                    }
                    string[] splitters = { ".", "," };
                    string strentero = "00";
                    string strdecimal = "00";
                    try
                    {
                        strentero = total.Split(splitters, StringSplitOptions.None)[0];
                    }
                    catch { }
                    try
                    {
                        strdecimal = total.Split(splitters, StringSplitOptions.None)[1];
                    }
                    catch { }

                    

                    infofactura = "<b>Fecha:</b> " +
                        F.Fecha.ToShortDateString() +
                        "<br/><b>Total:</b> " +
                        strentero + "<sup>" + strdecimal + "</sup>"+
                        "<br/><b>IID: </b>" + F.Id.ToString();
                    if (F.IsRemito) 
                    {
                        infofactura = "<b>Fecha:</b> " +
                        F.Remito.Fecha.ToShortDateString() +
                        "<br/><b>Total:</b> " +
                        strentero + "<sup>" + strdecimal + "</sup>" +
                        "<br/><b>IID: </b>" + F.Remito.IdRemito.ToString();
                    }
                    if (F.FacturaTipo == Struct_Factura.TipoDeFactura.FacturaA) 
                    {
                        infofactura += "</br><b>Razon social: </b>" + F.senores;
                    }

                    Letter.InnerText = facturatipo;
                    Info.InnerHtml = infofactura;
                    Info.Attributes.Add("Class", "InfoFactura");
                    ParentDiv.Attributes.Add("Class", "ContainerFactura");
                    if (!F.IsRemito)
                    {
                        ParentDiv.Attributes.Add("OnClick", "OpenC(" + F.Id.ToString() + ",false)");
                    }
                    else 
                    {
                        ParentDiv.Attributes.Add("OnClick", "OpenC(" + F.Remito.IdRemito.ToString() + ",true)");
                    }
                    


                    ParentDiv.Controls.Add(ParentTable);
                    ParentTable.Controls.Add(ParentRow);
                    ParentRow.Controls.Add(ColumnLetter);
                    ParentRow.Controls.Add(ColumnInfo);
                    ColumnLetter.Controls.Add(Letter);
                    ColumnInfo.Controls.Add(Info);
                    ListadoFacturas.Controls.Add(ParentDiv);
                }
                
            }
        
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {


            

            DateTime Start = DateTime.Parse(txt_fechadesde.Text);
            DateTime End = DateTime.Parse(txt_fechahasta.Text);
            Start = Start.AddHours(-Start.Hour);
            End = End.AddHours(24 - End.Hour);
            
            Data2.Class.Struct_Factura.TipoDeFactura TF = Data2.Class.Struct_Factura.TipoDeFactura.Null;
            
            if (cmb_TipoComprobante.SelectedValue=="0") TF = Data2.Class.Struct_Factura.TipoDeFactura.Null;
            if (cmb_TipoComprobante.SelectedValue=="A") TF = Data2.Class.Struct_Factura.TipoDeFactura.FacturaA;
            if (cmb_TipoComprobante.SelectedValue=="B") TF = Data2.Class.Struct_Factura.TipoDeFactura.FacturaB;
            if (cmb_TipoComprobante.SelectedValue == "C") TF = Data2.Class.Struct_Factura.TipoDeFactura.FacturaC;
            if (cmb_TipoComprobante.SelectedValue == "X") TF = Data2.Class.Struct_Factura.TipoDeFactura.FacturaX;
            if (cmb_TipoComprobante.SelectedValue == "P") TF = Data2.Class.Struct_Factura.TipoDeFactura.Presupuesto;
            
            

            List<Data2.Class.Struct_Factura> _LF = Data2.Class.Struct_Factura.GetFacturasBetweenDates(Start, End, UserId, false, TF);


            if (_LF != null && _LF.Count > 0)
            {
                if (Session != null)
                {
                    Session.Remove(sessionkey);
                }
                Session.Add(sessionkey, _LF);
                BuildSearch();
                BuildGraph();
                BuildStatics();
            }
            else
            {
                Session.Remove(sessionkey);
                BuildSearch();
                BuildGraph();
                BuildStatics();
                Response.Redirect("/MyManager/ListadoDeComprobantes");
            }



        }

        protected void btnBuscarRemitos_Click(object sender, EventArgs e)
        {

        }
    }
}