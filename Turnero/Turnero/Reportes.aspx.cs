using DotNetNuke.Entities.Users;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace Christoc.Modules.Turnero
{
    public partial class Reportes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            filenamefield.ClientIDMode = ClientIDMode.Static;

            if (!IsPostBack) 
            {
                string filename = Guid.NewGuid().ToString() + ".pdf";
                filenamefield.Value = filename;
                RV.LocalReport.ReportPath = MapPath("/DesktopModules/Turnero/Reports/ReportC1.rdlc");

                ConnectionDispensario.Modelos.Reporting.C1 C1 = new ConnectionDispensario.Modelos.Reporting.C1();

                int PID = int.Parse(Request["PID"].ToString());
                int UID = int.Parse(Request["UID"].ToString());
                string Y = Request["Y"].ToString();
                string MS = Request["MS"].ToString();
                string ME = Request["ME"].ToString();
                string DS = Request["DS"].ToString();
                string DE = Request["DE"].ToString();
                string HS = Request["HS"].ToString();
                string HE = Request["HE"].ToString();
                string Est = Request["EST"].ToString();

                string datestart = Y + "-" + MS + "-" + DS + " " + HS + ":00:00";
                string dateend = Y + "-" + ME + "-" + DE + " " + HE + ":00:00";


                
                List<ConnectionDispensario.Modelos.Reporting.C1Item> LIST = C1.GetC1(DateTime.Parse(datestart),DateTime.Parse(dateend), int.Parse(Request["UID"].ToString()), "Finalizado");
                if (LIST == null) {
                    LIST = new List<ConnectionDispensario.Modelos.Reporting.C1Item>();
                }
                UserController UC = new UserController();
                UserInfo UI = UC.GetUser(int.Parse(Request["PID"].ToString()), int.Parse(Request["UID"].ToString()));
                
                ReportDataSource RDS = new ReportDataSource("DS1", LIST);
                RV.LocalReport.DataSources.Add(RDS);
                
                RV.LocalReport.SetParameters(new ReportParameter[] {
                    new ReportParameter("NombreMedico",UI.FirstName + " " + UI.LastName),
                    new ReportParameter("Establecimiento","Dispensario Municipal \"Dr. H Weihmuller\""),
                    new ReportParameter("Servicio",UI.Profile.GetPropertyValue("Puesto")),
                    new ReportParameter("CodigoEstablecimiento","4200026"),
                    new ReportParameter("CodigoServicio","..."),
                    new ReportParameter("TotalObraSocial",C1.totalplandesalud.ToString()),
                    new ReportParameter("TotalNingunaObraSocial",C1.totalsinplandesalud.ToString()),
                    new ReportParameter("Tmenor1m",C1.totalmenor1m.ToString()),
                    new ReportParameter("Tmenor1f",C1.totalmenor1f.ToString()),
                    new ReportParameter("T1m",C1.total1anom.ToString()),
                    new ReportParameter("T1f",C1.total1anof.ToString()),
                    new ReportParameter("T2a4m",C1.total2a4m.ToString()),
                    new ReportParameter("T2a4f",C1.total2a4f.ToString()),
                    new ReportParameter("T5a9m",C1.total5a9m.ToString()),
                    new ReportParameter("T5a9f",C1.total5a9f.ToString()),
                    new ReportParameter("T10a14m",C1.total10a14m.ToString()),
                    new ReportParameter("T10a14f",C1.total10a14f.ToString()),
                    new ReportParameter("T15a49m",C1.total15a49m.ToString()),
                    new ReportParameter("T15a49f",C1.total15a49f.ToString()),
                    new ReportParameter("T50m",C1.total50amasm.ToString()),
                    new ReportParameter("T50f",C1.total50amasf.ToString()),
                    new ReportParameter("Totalmenor1",(C1.totalmenor1f+C1.totalmenor1m).ToString()),
                    new ReportParameter("Total1",(C1.total1anof+C1.total1anom).ToString()),
                    new ReportParameter("Total2a4",(C1.total2a4f+C1.total2a4m).ToString()),
                    new ReportParameter("Total5a9",(C1.total5a9f+C1.total5a9m).ToString()),
                    new ReportParameter("Total10a14",(C1.total10a14f+C1.total10a14m).ToString()),
                    new ReportParameter("Total15a49",(C1.total15a49f+C1.total15a49m).ToString()),
                    new ReportParameter("Total50",(C1.total50amasf+C1.total50amasm).ToString()),
                    new ReportParameter("TotalM",(C1.totalmenor1m+C1.total1anom+C1.total2a4m+C1.total5a9m+C1.total10a14m+C1.total15a49m+C1.total50amasm).ToString()),
                    new ReportParameter("TotalF",(C1.totalmenor1f+C1.total1anof+C1.total2a4f+C1.total5a9f+C1.total10a14f+C1.total15a49f+C1.total50amasf).ToString()),
                    new ReportParameter("Total",(LIST.Count).ToString()),
                    new ReportParameter("TotalCtrlEmb",(C1.totalcontrolembarazo).ToString()),
                    new ReportParameter("Fecha", DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year)


                });
                
                
                RV.LocalReport.Refresh();
                byte[] b = RV.LocalReport.Render("PDF");


                string path = Server.MapPath(DotNetNuke.Entities.Portals.PortalSettings.Current.HomeDirectory);
                File.WriteAllBytes(path + "\\"+filename,b);
            }
        }
    }
}