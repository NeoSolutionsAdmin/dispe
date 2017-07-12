using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace ConnectionDispensario.Conexiones
{
    public class Con_Turno
    {
        /*
        int IdUser;
        int IdPaciente;
        DateTime FechaRecepcion;
        DateTime FechaComienzo;
        DateTime FechaFinal;
        string Estado;
        int IdDerivado;
        string Indicaciones;*/

        public void UpdateDiagnostico(int IdTurno, string DiagnosticoFinal, int IdC10, bool ControlDeEmbarazo) 
        {
            QTACustomizado QTA = new QTACustomizado();
            QTA.Update_Diagnostico_In_Turno(IdTurno, DiagnosticoFinal, IdC10, ControlDeEmbarazo);
        }

        public bool insertarTurno(int IdPaciente, int IdUser) 
        {
            QTACustomizado QTA = new QTACustomizado();
            int cant = QTA.Insert_Turno(
                IdUser,
                IdPaciente,
                Utils.Conversiones.SQL_To_FullString_DateTime(DateTime.Now),
                Utils.Conversiones.SQL_To_FullString_DateTime(DateTime.Now),
                Utils.Conversiones.SQL_To_FullString_DateTime(DateTime.Now));
            if (cant == 1)
            {
                return true;
            }
            else 
            {
                return false;
            }
        }

        public DataRow SelectTurnoByID(int IdTurno) 
        {
            DispensarioACDataSet.Select_TurnoByIdDataTable DT = new DispensarioACDataSet.Select_TurnoByIdDataTable();
            DispensarioACDataSetTableAdapters.Select_TurnoByIdTableAdapter TA = new DispensarioACDataSetTableAdapters.Select_TurnoByIdTableAdapter();
            System.Data.SqlClient.SqlConnection SQLCONN = TA.Connection;
            Conexiones.TableAdapterManager.ChangeConnection(ref SQLCONN, this.ToString());
            TA.Connection = SQLCONN;
            TA.Fill(DT, IdTurno);
            if (DT != null && DT.Rows.Count > 0)
            {
                return DT.Rows[0];
            }
            else 
            {
                return null;
            }
        }

        public DataTable SelectTurnosByPeriod(int IdUser, DateTime DS, DateTime DE, string Estado) 
        {
            DispensarioACDataSet.Select_Turnos_By_PeriodDataTable DT = new DispensarioACDataSet.Select_Turnos_By_PeriodDataTable();
            DispensarioACDataSetTableAdapters.Select_Turnos_By_PeriodTableAdapter TA = new DispensarioACDataSetTableAdapters.Select_Turnos_By_PeriodTableAdapter();
            System.Data.SqlClient.SqlConnection SQLCONN = TA.Connection;
            Conexiones.TableAdapterManager.ChangeConnection(ref SQLCONN, this.ToString());
            TA.Connection = SQLCONN;
            TA.Fill(DT, IdUser, Utils.Conversiones.SQL_To_FullString_DateTime(DS), Utils.Conversiones.SQL_To_FullString_DateTime(DE), Estado);
            if (DT != null & DT.Rows.Count > 0)
            {
                return DT;
            }
            else 
            {
                return null;
            }

        }

        public bool comenzarConsulta(int IdTurno)
        {
            QTACustomizado QTA = new QTACustomizado();
            int cant = QTA.ComenzarConsulta(IdTurno, Utils.Conversiones.SQL_To_FullString_DateTime(DateTime.Now));
            if (cant == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool cancelarConsulta(int IdTurno)
        {
            QTACustomizado QTA = new QTACustomizado();
            int cant = QTA.CancelarConsulta(IdTurno);
            if (cant == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public DataTable SelectTurnosByIdUser(int IdUser) 
        {
            DispensarioACDataSet.Select_AllTurnosByIdUserDataTable DT = new DispensarioACDataSet.Select_AllTurnosByIdUserDataTable();
            DispensarioACDataSetTableAdapters.Select_AllTurnosByIdUserTableAdapter TA = new DispensarioACDataSetTableAdapters.Select_AllTurnosByIdUserTableAdapter();
            System.Data.SqlClient.SqlConnection SQLCONN = TA.Connection;
            Conexiones.TableAdapterManager.ChangeConnection(ref SQLCONN, this.ToString());
            TA.Connection = SQLCONN;
            TA.Fill(DT, IdUser);
            
            if (DT != null && DT.Rows.Count > 0)
            {
                Statics.LogCatcher.AddLog("Hay en Con_Turno", "", null, null);
                return DT;
            }
            else 
            {
                Statics.LogCatcher.AddLog("Null en Con_Turno", "", null, null);
                return null;
            }
        }

        public bool finalizarConsulta(int IdTurno)
        {
            QTACustomizado QTA = new QTACustomizado();
            int cant = QTA.FinalizarConsulta(IdTurno, Utils.Conversiones.SQL_To_FullString_DateTime(DateTime.Now));
            if (cant == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Derivar(int IdTurno, int IdDerivado)
        {
            QTACustomizado QTA = new QTACustomizado();
            int cant = QTA.DerivarConsulta(IdTurno, IdDerivado,"");
            if (cant == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }




    }
}
