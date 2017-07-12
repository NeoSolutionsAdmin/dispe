using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using ConnectionDispensario.Conexiones;

namespace ConnectionDispensario.Modelos
{
    public class Turno 
    {
        public int IDT;
        public int IdUser;
        public Paciente Pac;
        public DateTime FechaRecepcion;
        public DateTime FechaComienzo;
        public DateTime FechaFinal;
        public string Esstado;
        public int IdDerivado;
        public string Indicaciones;
        public string DiagnosticoFinal;
        public int CIE10=0;
        public bool ControlEmbarazo = false;

        public Turno(int p_IdUser, Paciente p_P) 
        {
            IdUser = p_IdUser;
            Pac = p_P;
        }



        public Turno(DataRow DR) 
        {
            IDT = int.Parse(DR["Id"].ToString());
            IdUser = int.Parse(DR["UserId"].ToString());
            FechaRecepcion = DateTime.Parse(DR["HoraRecepcion"].ToString());
            FechaComienzo = DateTime.Parse(DR["HoraComienzoConsulta"].ToString());
            FechaFinal = DateTime.Parse(DR["HoraFinalConsulta"].ToString());
            Esstado = DR["Estado"].ToString();
            Pac = Paciente.Select_Paciente_By_Id(int.Parse(DR["PacienteId"].ToString()));
            IdDerivado = int.Parse(DR["IdDerivado"].ToString());
            Indicaciones = DR["Indicaciones"].ToString();
            if (DBNull.Value.Equals(DR["DiagnosticoFinal"]) == false)
            {
                DiagnosticoFinal = DR["DiagnosticoFinal"].ToString();
            }
            if (DBNull.Value.Equals(DR["CIE10"]) == false) 
            {
                CIE10 = int.Parse(DR["CIE10"].ToString());
            }
            if (DBNull.Value.Equals(DR["ControlEmbarazo"]) == false) 
            {
                ControlEmbarazo = bool.Parse(DR["ControlEmbarazo"].ToString());
            }

            
        }

        public static List<Turno> GetTurnosByPeriod(DateTime Start, DateTime End, int IdUser, string Estado) 
        {
            Conexiones.Con_Turno CT = new Con_Turno();
            DataTable DT = CT.SelectTurnosByPeriod(IdUser, Start, End, Estado);
            if (DT != null)
            {
                List<Turno> LT = new List<Turno>();
                for (int a=0;a<DT.Rows.Count;a++)
                {
                    LT.Add(new Turno(DT.Rows[a]));
                }
                return LT;
            }
            else 
            {
                return null;
            }
        }

        public static List<Turno> GetTurnosByUser(int IdUser) 
        {
            Con_Turno CT = new Con_Turno();
            DataTable DT = CT.SelectTurnosByIdUser(IdUser);
            List<Turno> LT = new List<Turno>();

            if (DT != null)
            {
                //Statics.LogCatcher.AddLog("Hay DT", "", null, null);
                for (int a = 0; a < DT.Rows.Count; a++)
                {
                    LT.Add(new Turno(DT.Rows[a]));
                }
                return LT;
            }
            else
            {
                //Statics.LogCatcher.AddLog("Es null en modelo", "", null, null);
                return null;
            }
        }

        public static Turno GetTurnoByID(int IdTurno)
        {
            Con_Turno CT = new Con_Turno();
            DataRow DR = CT.SelectTurnoByID(IdTurno);
            if (DR != null)
            {
                return new Turno(DR);
            }
            else 
            {
                return null;
            }
        }

        public void ActualizarTurno(string p_DiagnosticoFinal, int p_IdC10, bool p_ControlEmbarazo) 
        {
            Con_Turno CT = new Con_Turno();
            DiagnosticoFinal = p_DiagnosticoFinal;
            CIE10 = p_IdC10;
            ControlEmbarazo = p_ControlEmbarazo;
            CT.UpdateDiagnostico(IDT, DiagnosticoFinal,CIE10,ControlEmbarazo);
        }

        public bool ComenzarTurno() 
        {
            Con_Turno CT = new Con_Turno();
           return CT.comenzarConsulta(IDT);
        }

        public bool CancelarTurno()
        {
            Con_Turno CT = new Con_Turno();
            return CT.cancelarConsulta(IDT);
        }

        public bool FinalizarTurno()
        {
            Con_Turno CT = new Con_Turno();
            return CT.finalizarConsulta(IDT);
        }

        public bool Derivar(int IdDerivacion) 
        {
            Con_Turno CT = new Con_Turno();
            Turno T = new Turno(IdDerivacion, Pac);
            T.EstablecerTurno();
            return CT.Derivar(IDT, IdDerivacion);

        }

        public bool EstablecerTurno()
        {
            Con_Turno CT = new Con_Turno();
            return CT.insertarTurno(Pac.ID, IdUser);
        }





    }
}
