using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace ConnectionDispensario.Conexiones
{
   

    public class Con_Pacientes
    {
        QTACustomizado QTA = new QTACustomizado();

        public DataTable BuscarPacienteByDNI(string p_DNI) 
        {
            DispensarioACDataSetTableAdapters.SELECT_PACIENTE_BY_DNITableAdapter TA = new DispensarioACDataSetTableAdapters.SELECT_PACIENTE_BY_DNITableAdapter();
            DispensarioACDataSet.SELECT_PACIENTE_BY_DNIDataTable DT = new DispensarioACDataSet.SELECT_PACIENTE_BY_DNIDataTable();
            System.Data.SqlClient.SqlConnection SQLCONN = TA.Connection;
            Conexiones.TableAdapterManager.ChangeConnection(ref SQLCONN, this.ToString());
            TA.Fill(DT, p_DNI);
            if (DT != null && DT.Rows.Count > 0)
            {
                return DT;
            }
            else 
            {
                return null;
            }
        }

        public DataTable BuscarPacientesByApellido(string CadenaDeBusqueda)
        {
            DispensarioACDataSetTableAdapters.Buscar_Paciente_By_ApellidoTableAdapter TA = new DispensarioACDataSetTableAdapters.Buscar_Paciente_By_ApellidoTableAdapter();
            DispensarioACDataSet.Buscar_Paciente_By_ApellidoDataTable DT = new DispensarioACDataSet.Buscar_Paciente_By_ApellidoDataTable();
            System.Data.SqlClient.SqlConnection SQLCONN = TA.Connection;
            Conexiones.TableAdapterManager.ChangeConnection(ref SQLCONN, this.ToString());
            TA.Connection = SQLCONN;
            TA.Fill(DT, CadenaDeBusqueda);
            if (DT != null && DT.Rows.Count > 0)
            {
                return DT;
            }
            else 
            {
                return null;
            }
        }


        public DataRow SelectPacienteByID(int IdPaciente)
        {
            DispensarioACDataSet.Select_PacienteByIDDataTable DT = new DispensarioACDataSet.Select_PacienteByIDDataTable();
            DispensarioACDataSetTableAdapters.Select_PacienteByIDTableAdapter TA = new DispensarioACDataSetTableAdapters.Select_PacienteByIDTableAdapter();
            System.Data.SqlClient.SqlConnection SQLCONN = TA.Connection;
            Conexiones.TableAdapterManager.ChangeConnection(ref SQLCONN, this.ToString());
            TA.Connection = SQLCONN;
            TA.Fill(DT,IdPaciente);
            if (DT != null && DT.Rows.Count > 0)
            {
                return DT.Rows[0];
            }
            else 
            {
                return null;
            }
        }

        public DataRow SelectPacienteByGUI(string GUI) 
        {
            DispensarioACDataSetTableAdapters.Select_Paciente_By_GUITableAdapter TA = new DispensarioACDataSetTableAdapters.Select_Paciente_By_GUITableAdapter();
            DispensarioACDataSet.Select_Paciente_By_GUIDataTable DT = new DispensarioACDataSet.Select_Paciente_By_GUIDataTable();
            System.Data.SqlClient.SqlConnection SQLCONN = TA.Connection;
            Conexiones.TableAdapterManager.ChangeConnection(ref SQLCONN, this.ToString());
            TA.Connection = SQLCONN;
            TA.Fill(DT, GUI);
            if (DT != null && DT.Rows.Count > 0)
            {
                return DT.Rows[0];
            }
            else 
            {
                return null;
            }
        }

        public bool ActualizarPaciente(Modelos.Paciente p_paciente) 
        {
            
            
            try
            {
                int c = QTA.Update_Paciente(
                    p_paciente.ID,
                    p_paciente.APELLIDO,
                    p_paciente.NOMBRE,
                    Utils.Conversiones.SQL_To_String_DateTime(p_paciente.FECHA_NACIMIENTO),
                    p_paciente.NRODOCUMENTO,
                    p_paciente.DOMICILIO,
                    p_paciente.LOCALIDAD,
                    p_paciente.TELEFONO,
                    p_paciente.IDOBRASOCIAL,
                p_paciente.NROOBRASOCIAL,
                p_paciente.SEXO);
                if (c > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception E) 
            {
                p_paciente.DispararError(E);
                return false;
            }
        }

        

        public bool InsertPaciente(Modelos.Paciente p_paciente) 
        {
            try
            {

                int c = QTA.Insert_Paciente(
                    p_paciente.APELLIDO,
                    p_paciente.NOMBRE,
                    Utils.Conversiones.SQL_To_String_DateTime(p_paciente.FECHA_NACIMIENTO),
                    p_paciente.NRODOCUMENTO,
                    p_paciente.DOMICILIO,
                    p_paciente.LOCALIDAD,
                    p_paciente.TELEFONO,
                    p_paciente.IDOBRASOCIAL,
                    p_paciente.NROOBRASOCIAL,
                    p_paciente.SEXO);
                if (c > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception E) 
            {
                p_paciente.DispararError(E);
                return false;
            }
        }
    }
}
