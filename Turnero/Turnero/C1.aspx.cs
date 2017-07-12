using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DotNetNuke;
using DotNetNuke.Entities;
using DotNetNuke.Entities.Users;
using ConnectionDispensario.Modelos;
using System.Globalization;


namespace Christoc.Modules.Turnero
{
    public partial class C1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["IDU"]!=null && 
                Request["IDP"]!=null &&  
                Request["Y"]!=null &&
                Request["M"]!=null &&
                Request["DS"]!=null && 
                Request["DE"]!=null && 
                Request["HS"]!=null &&
                Request["HE"]!=null){

                int IDU = int.Parse(Request["IDU"].ToString());
                int IDP = int.Parse(Request["IDP"].ToString());
                int Y = int.Parse(Request["Y"].ToString());
                int M = int.Parse(Request["M"].ToString());
                int DS = int.Parse(Request["DS"].ToString());
                int DE = int.Parse(Request["DE"].ToString());
                int HS = int.Parse(Request["HS"].ToString());
                int HE = int.Parse(Request["HE"].ToString());

                

                DateTime DateStart = new DateTime(Y, M, DS, HS, 0, 0);
                DateTime DateEnd = new DateTime(Y, M, DE, HE, 0, 0);

                System.Collections.Generic.List<Turno> LT = Turno.GetTurnosByPeriod(DateStart, DateEnd,IDU, "Finalizado");
                if (LT != null)
                {
                    Session.Add("result", LT);
                }
                else 
                {
                    Session.Remove("result");
                }


            UserController UC = new UserController();
            UserInfo UI = UC.GetUser(IDP, IDU);

            Establecimiento.Text = "___________________________________________________";
            IndependenciaNro.Text = "________________";
            Departamento.Text = "________________";


            if (UI != null)
            {
                
                NombreMedico.Text = UI.FirstName + " " + UI.LastName;
                Servicio.Text = UI.Profile.GetPropertyValue("Puesto");
                Mes.Text = DateTime.Now.ToString("MMMM", CultureInfo.CreateSpecificCulture("es"));
                Año.Text = DateTime.Now.Year.ToString();



            }
            else 
            {
                
            }


            }
            
        }
    }
}