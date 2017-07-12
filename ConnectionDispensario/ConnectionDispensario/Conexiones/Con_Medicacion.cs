using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace ConnectionDispensario.Conexiones
{
    public class Con_Medicacion
    {
        public bool Insertar_Medicacion(int IdPaciente, string Medicacion)
        {
            QTACustomizado QTA = new QTACustomizado();
            int cant = QTA.Insertar_Medicacion(IdPaciente, Medicacion);
            if (cant > 0)
            {
                return true;
            }
            else 
            {
                return false;
            }
        }

        public bool Borrar_Medicacion(int Id)
        {
            QTACustomizado QTA = new QTACustomizado();
            int cant = QTA.Borrar_Medicacion(Id);
            if (cant > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public DataTable Select_Medicacion(int IdPaciente) 
        {
            DispensarioACDataSet.Select_MedicacionHabitualDataTable DT = new DispensarioACDataSet.Select_MedicacionHabitualDataTable();
            DispensarioACDataSetTableAdapters.Select_MedicacionHabitualTableAdapter TA = new DispensarioACDataSetTableAdapters.Select_MedicacionHabitualTableAdapter();
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
