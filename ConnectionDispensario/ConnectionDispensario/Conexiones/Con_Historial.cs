using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace ConnectionDispensario.Conexiones
{
    public class Con_Historial
    {

        public DataTable Select_Diagnosticos_By_IdPaciente(int IdPaciente) 
        {
            DispensarioACDataSet.Select_Diagnosticos_By_IdPacienteDataTable DT = new DispensarioACDataSet.Select_Diagnosticos_By_IdPacienteDataTable();
            DispensarioACDataSetTableAdapters.Select_Diagnosticos_By_IdPacienteTableAdapter TA = new DispensarioACDataSetTableAdapters.Select_Diagnosticos_By_IdPacienteTableAdapter();
            
            System.Data.SqlClient.SqlConnection SQLCONN = TA.Connection;
            Conexiones.TableAdapterManager.ChangeConnection(ref SQLCONN, this.ToString());
            TA.Connection = SQLCONN;
            
            TA.Fill(DT, IdPaciente);
            if (DT.Rows.Count > 0)
            {
                return DT;
            }
            else 
            {
                return null;
            }
        }

        public string InsertarHistorial(string p_Historial, int p_iduser, int p_idpaciente, DateTime p_fecha) 
        {
            DispensarioACDataSet.INSERT_DIAGNOSTICODataTable DT = new DispensarioACDataSet.INSERT_DIAGNOSTICODataTable();
            DispensarioACDataSetTableAdapters.INSERT_DIAGNOSTICOTableAdapter TA = new DispensarioACDataSetTableAdapters.INSERT_DIAGNOSTICOTableAdapter();
            System.Data.SqlClient.SqlConnection SQLCONN = TA.Connection;
            Conexiones.TableAdapterManager.ChangeConnection(ref SQLCONN, this.ToString());
            TA.Connection = SQLCONN;
            try
            {
                TA.Fill(DT, p_idpaciente, p_iduser, Utils.Conversiones.SQL_To_String_DateTime(p_fecha), p_Historial);
                if (DT.Rows.Count > 0)
                {
                    return DT.Rows[0]["HUID"].ToString();
                }
                else
                {
                    return "";
                }
            }
            catch (Exception E) 
            {
                Statics.LogCatcher.AddLog(E.Message, E.StackTrace, null, null);
                return "";
            }
        }
    }
}
