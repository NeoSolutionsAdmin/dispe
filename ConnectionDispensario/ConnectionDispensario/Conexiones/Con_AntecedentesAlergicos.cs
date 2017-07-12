using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace ConnectionDispensario.Conexiones
{
    public class Con_AntecedentesAlergicos
    {
        public bool Insertar_Alergia(int IdPaciente, string alergia)
        {
            QTACustomizado QTA = new QTACustomizado();
            int cant = QTA.Insert_Alergia(IdPaciente, alergia);
            if (cant > 0)
            {
                return true;
            }
            else 
            {
                return false;
            }
        }

        public DataTable Select_AlergiasPaciente(int IdPaciente) 
        {
            DispensarioACDataSet.Select_AlergiasByIdPacienteDataTable DT = new DispensarioACDataSet.Select_AlergiasByIdPacienteDataTable();
            DispensarioACDataSetTableAdapters.Select_AlergiasByIdPacienteTableAdapter TA = new DispensarioACDataSetTableAdapters.Select_AlergiasByIdPacienteTableAdapter();
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
