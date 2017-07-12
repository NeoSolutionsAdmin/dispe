using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace ConnectionDispensario.Conexiones
{
    public class Con_CIE
    {
        public DataRow  Get_CIE10(int id)
        {
            
            DispensarioACDataSet.Get_CIE10_by_IdDataTable DT = new DispensarioACDataSet.Get_CIE10_by_IdDataTable();
            DispensarioACDataSetTableAdapters.Get_CIE10_by_IdTableAdapter TA = new DispensarioACDataSetTableAdapters.Get_CIE10_by_IdTableAdapter();
            System.Data.SqlClient.SqlConnection SQLCONN = TA.Connection;
            Conexiones.TableAdapterManager.ChangeConnection(ref SQLCONN, this.ToString());
            TA.Connection = SQLCONN;
            TA.Fill(DT, id);
            if (DT != null && DT.Rows.Count > 0)
            {
                return DT.Rows[0];
            }
            else 
            {
                return null;
            }
        }
    }
}
