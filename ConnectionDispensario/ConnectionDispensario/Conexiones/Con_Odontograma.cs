using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectionDispensario.Conexiones
{
    public class Con_Odontograma
    {

        public Boolean Insert_Diente(string OdontogramaID, int DienteID, string Estado)
        {

            QTACustomizado QTA = new QTACustomizado();
            int result = 0;
            result = QTA.Insert_Diente(OdontogramaID, DienteID, Estado);
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
             
        }

        public DataTable GetDientes(string keyOdontograma)
        {
            DispensarioACDataSetTableAdapters.Select_DientesByKeyOdontogramaTableAdapter TA = new DispensarioACDataSetTableAdapters.Select_DientesByKeyOdontogramaTableAdapter();
            DispensarioACDataSet.Select_DientesByKeyOdontogramaDataTable DT = new DispensarioACDataSet.Select_DientesByKeyOdontogramaDataTable();
            System.Data.SqlClient.SqlConnection SQLCONN = TA.Connection;
            Conexiones.TableAdapterManager.ChangeConnection(ref SQLCONN, this.ToString());
            TA.Connection = SQLCONN;
            TA.Fill(DT, keyOdontograma);
            if (DT.Rows.Count > 0)
            {
                return DT;
            }
            else
            {
                return null;
            }
        }

        public DataTable GetOdontogramas(int IdPaciente)
        {
            DispensarioACDataSet.Select_OdontogramasByIdPacienteDataTable DT = new DispensarioACDataSet.Select_OdontogramasByIdPacienteDataTable();
            DispensarioACDataSetTableAdapters.Select_OdontogramasByIdPacienteTableAdapter TA = new DispensarioACDataSetTableAdapters.Select_OdontogramasByIdPacienteTableAdapter();
            System.Data.SqlClient.SqlConnection SQLCONN = TA.Connection;
            Conexiones.TableAdapterManager.ChangeConnection(ref SQLCONN, this.ToString());
            TA.Connection = SQLCONN;

            TA.Fill(DT, IdPaciente);
            if (DT.Rows.Count != 0)
            {
                return DT;
            }
            else
            {
                return null;
            }

        }

        public DataRow Insert_Odontograma(int UserID, int PacienteID)
        {
            DispensarioACDataSetTableAdapters.InsertOdontogramaTableAdapter TA = new DispensarioACDataSetTableAdapters.InsertOdontogramaTableAdapter();
            DispensarioACDataSet.InsertOdontogramaDataTable DT = new DispensarioACDataSet.InsertOdontogramaDataTable();
            System.Data.SqlClient.SqlConnection SQLCONN = TA.Connection;
            Conexiones.TableAdapterManager.ChangeConnection(ref SQLCONN, this.ToString());
            TA.Connection = SQLCONN;

            TA.Fill(DT, UserID, PacienteID, Guid.NewGuid().ToString(), Utils.Conversiones.SQL_To_String_DateTime(DateTime.Now));
            if (DT.Rows.Count > 0)
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
