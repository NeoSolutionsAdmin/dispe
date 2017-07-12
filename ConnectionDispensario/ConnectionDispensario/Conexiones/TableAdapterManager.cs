using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DotNetNuke.Common.Utilities;

namespace ConnectionDispensario.Conexiones
{

    public class QTACustomizado : DispensarioACDataSetTableAdapters.QueriesTableAdapter
    {

        public QTACustomizado() 
        {
            ChangeConnectionString();
        }

        public void ChangeConnectionString()
        {
            foreach (IDbCommand i in CommandCollection)
            {

                i.Connection.ConnectionString = DotNetNuke.Common.Utilities.Config.GetSetting("CONEXION SISTEMA");
            }
        }

    }

    public static class TableAdapterManager
    {
       public static void ChangeConnection (ref System.Data.SqlClient.SqlConnection MyConnection, string MyClass)
       {



           string conexion = DotNetNuke.Common.Utilities.Config.GetSetting("CONEXION SISTEMA");
           MyConnection.ConnectionString = conexion;
           
       
       }
    }
}
