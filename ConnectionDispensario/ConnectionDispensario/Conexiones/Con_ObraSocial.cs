using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace ConnectionDispensario.Conexiones
{
    public class Con_ObraSocial
    {

        public DataRow Select_ObraSocialById(int IdObraSocial) 
        {
            DispensarioACDataSet.Select_ObraSocial_By_IDDataTable DT = new DispensarioACDataSet.Select_ObraSocial_By_IDDataTable();
            DispensarioACDataSetTableAdapters.Select_ObraSocial_By_IDTableAdapter TA = new DispensarioACDataSetTableAdapters.Select_ObraSocial_By_IDTableAdapter();
            System.Data.SqlClient.SqlConnection SQLCONN = TA.Connection;
            Conexiones.TableAdapterManager.ChangeConnection(ref SQLCONN, this.ToString());
            TA.Connection = SQLCONN;
            TA.Fill(DT, IdObraSocial);
            if (DT != null && DT.Rows.Count > 0)
            {
                return DT.Rows[0];
            }
            else 
            {
                return null;
            }
        }

        public DataTable Search_ObraSocial(string StringSearch) 
        {
            DispensarioACDataSet.Search_ObrasSocialDataTable DT = new DispensarioACDataSet.Search_ObrasSocialDataTable();
            DispensarioACDataSetTableAdapters.Search_ObrasSocialTableAdapter TA = new DispensarioACDataSetTableAdapters.Search_ObrasSocialTableAdapter();
            System.Data.SqlClient.SqlConnection SQLCONN = TA.Connection;
            Conexiones.TableAdapterManager.ChangeConnection(ref SQLCONN, this.ToString());
            TA.Connection = SQLCONN;
            TA.Fill(DT, StringSearch);
            if (DT.Rows.Count > 0)
            {
                return DT;
            }
            else 
            {
                return null;
            }
        }
    }
}
