using ConnectionDispensario.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DotNetNuke;


namespace Christoc.Modules.HistoriaClinica
{



    public partial class WSHistoriaClinica : System.Web.UI.Page
    {
        string Modalidad;
        int UID;
        int PID;
        string KEY;
        int TID;
        string PIDS;
        string data;
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Clear();
            if (Request["MOD"] != null)
            {

                if (Request["MOD"] != null) Modalidad = Request["MOD"].ToString();
                if (Request["UID"] != null) UID = int.Parse(Request["UID"].ToString());
                if (Request["KEY"] != null) KEY = Request["KEY"].ToString();
                if (Request["TID"] != null) TID = int.Parse(Request["TID"].ToString());
                if (Request["data"] != null) data = Request["data"].ToString();
                if (Request["PID"]!=null) PIDS = Request["PID"].ToString();
                Paciente P = ConnectionDispensario.Modelos.Paciente.Select_Paciente_by_GUI(PIDS);
                if (P != null)
                {
                    PID = P.ID;
                }
                if (Modalidad.ToLower().Contains("getuidodontograma"))
                {
                    GetUIDOdontograma();
                }
                if (Modalidad.ToLower().Contains("inserttooth"))
                {
                    InsertTooth();
                }
            }
            else
            {
                Response.Write("null");
            }
            Response.End();
        }


        void InsertTooth()
        {
            bool res;
            res = ConnectionDispensario.Modelos.Odontograma.InsertDiente(KEY, TID, data);
            if (res==true)
            {
                Response.Write("ok");
            }
            else
            {
                Response.Write("fail");
            } 
        }

        void GetUIDOdontograma()
        {
            ConnectionDispensario.Modelos.Odontograma Odontograma = new ConnectionDispensario.Modelos.Odontograma(UID, PID);
            if (Odontograma.UID != "")
            {
                Response.Write(Odontograma.UID);
            }
            else
            {

                Response.Write("null");
            }
        }
        
    }
}