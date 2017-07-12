using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotNetNuke;
using System.Web.Util;

namespace ConnectionDispensario.Statics
{
    public static class LogCatcher
    {
       public static DotNetNuke.Services.Log.EventLog.EventLogController ELP;
        public static void AddLog( string Message, string stack, DotNetNuke.Entities.Modules.PortalModuleBase Module, System.Web.SessionState.HttpSessionState SS)
        {
            ELP = new DotNetNuke.Services.Log.EventLog.EventLogController();
            DotNetNuke.Services.Log.EventLog.LogTypeInfo LT = new DotNetNuke.Services.Log.EventLog.LogTypeInfo();
            LT.LogTypeDescription = "Error en sistema...";
            LT.LogTypeFriendlyName = "Error en sistema...";
            LT.LogTypeKey = "Dispensario";
            LT.LogTypeOwner = "Administrador";
            
            DotNetNuke.Services.Log.EventLog.LogInfo LI = new DotNetNuke.Services.Log.EventLog.LogInfo();
            if (Module != null)
            {
                LI.LogPortalID = Module.PortalId;
                LI.LogUserID = Module.UserId;
                LI.AddProperty("Usuario:", Module.UserInfo.Username);
            }
            else 
            {
                LI.LogPortalID = 0;
                LI.LogUserID = 1;
                LI.AddProperty("FromWebservice", "0000");
            }
            LI.LogTypeKey = "Dispensario";
            
            LI.AddProperty("Error", Message);
            LI.AddProperty("Stack", stack);

            if (SS != null)
            {

                for (int a = 0; a < SS.Count; a++)
                {
                    System.Web.Script.Serialization.JavaScriptSerializer JSC = new System.Web.Script.Serialization.JavaScriptSerializer();
                    string serializationtype = SS[a].GetType().Name;

                    string serialization = "";
                    //MAPA DE SERIALIZACIONES Y CASTEOS

                    if (serializationtype == "Paciente") serialization = JSC.Serialize(SS[a] as Modelos.Paciente);
                    if (serializationtype == "String") serialization = JSC.Serialize(SS[a] as String);

                    if (serialization == "") { serialization = "No se pudo serializar"; }



                    LI.AddProperty("From session Nro. " + a.ToString() + " and key " + SS.Keys[a] + " type [" + serializationtype + "] ", serialization);

                }
            }
            LI.BypassBuffering = true;
            
            ELP.AddLog(LI);
           


        }
        public static T ConvertValue<T>(string value)
        {
            return (T)Convert.ChangeType(value, typeof(T));
        }
    }
}
