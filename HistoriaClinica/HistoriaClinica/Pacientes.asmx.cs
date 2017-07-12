using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Script.Serialization;
using ConnectionDispensario.Modelos;

namespace Christoc.Modules.HistoriaClinica
{
    /// <summary>
    /// Summary description for Pacientes
    /// </summary>
    [WebService]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    
    public class Pacientes : System.Web.Services.WebService
    {

        [Serializable]
        public class prueba
        {

            public string mensaje1;
            public string mensaje2;

        }

        JavaScriptSerializer jss = new JavaScriptSerializer();
        [WebMethod]
        public string PostHistorial(string Historial, int IDPaciente, int IDProfesional)
        {
            
            return "Genial" + Historial;
        }
        [WebMethod]
        public prueba Cool(string id) 
        {
            prueba p = new prueba();
            p.mensaje1 = id;
            p.mensaje2 = "como estas?";

            return p;
        }
        [WebMethod]
        public Paciente InsertHistory(string Historial, int IdUser, int IdPortal ,string UIPaciente) 
        {
            Paciente p = new Paciente("error", "error", DateTime.Now, "error", "error", "error", "error", 0, "error", "error", false);
            Paciente t_P = ConnectionDispensario.Modelos.Paciente.Select_Paciente_by_GUI(UIPaciente);
            if (t_P != null)
            {
                DotNetNuke.Entities.Users.UserController UC = new DotNetNuke.Entities.Users.UserController();
                DotNetNuke.Entities.Users.UserInfo t_UI = UC.GetUser(IdPortal, IdUser);
                if (t_UI != null)
                {
                    
                    Historial H = new Historial(Historial.Replace("\n","[LineJump]"), IdUser, t_P.ID);
                    if (H.Guardar() == true)
                    {
                        ConnectionDispensario.Statics.LogCatcher.AddLog("Se inserto correctamente", "Se inserto correctamente", null, null);
                        return t_P;
                    }
                    else
                    {
                        ConnectionDispensario.Statics.LogCatcher.AddLog("No se pudo Guardar", "No se pudo Guardar", null, null);
                        return p;
                        
                    }
                }
                else
                {
                    ConnectionDispensario.Statics.LogCatcher.AddLog("No existe el usuario", "No existe el usuario", null, null);
                    return p;
                }

            }
            else 
            {
                ConnectionDispensario.Statics.LogCatcher.AddLog("No existe el Paciente", "No existe el Paciente", null, null);
                

                return p;
            }
        }
    }
}
