using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace ConnectionDispensario.Conexiones
{
    public class Con_AntecedentesQuirurgicos
    {
        public bool Insertar_Cirugia(int IdPaciente, string alergia)
        {
            QTACustomizado QTA = new QTACustomizado();
            int cant = QTA.Insertar_Cirugia(IdPaciente, alergia);
            if (cant > 0)
            {
                return true;
            }
            else 
            {
                return false;
            }
        }

        public DataTable Select_CirugiasPaciente(int IdPaciente) 
        {
            DispensarioACDataSet.Select_CirugiasByIdPacienteDataTable DT = new DispensarioACDataSet.Select_CirugiasByIdPacienteDataTable();
            DispensarioACDataSetTableAdapters.Select_CirugiasByIdPacienteTableAdapter TA = new DispensarioACDataSetTableAdapters.Select_CirugiasByIdPacienteTableAdapter();
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
