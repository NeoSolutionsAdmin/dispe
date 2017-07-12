using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectionDispensario.Conexiones
{
    public class Con_AntecedentesPatologicosPersonales
    {
        public bool InsertAntecedente(int IdPaciente, string Antecedente)
        {
            QTACustomizado QTA = new QTACustomizado();
            int result = QTA.Insert_APP(IdPaciente, Antecedente);
            if (result > 0)
            {
                return true;
            }
            else 
            {
                return false;
            }
        }

        public DataTable SelectByIdPaciente(int IdPaciente) 
        {
            DispensarioACDataSet.Select_APPDataTable DT = new DispensarioACDataSet.Select_APPDataTable();
            DispensarioACDataSetTableAdapters.Select_APPTableAdapter TA = new DispensarioACDataSetTableAdapters.Select_APPTableAdapter();
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

    }
}
