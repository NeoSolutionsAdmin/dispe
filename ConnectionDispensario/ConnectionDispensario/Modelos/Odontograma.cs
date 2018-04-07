using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectionDispensario.Modelos
{
    [Serializable]
    public class Odontograma
    {

        int PacienteID;
        int UserID;
        string Uid;
        DateTime Fecha;
        List<Diente> MisDientes = new List<Diente>();

        public int PACIENTEID { get { return PacienteID; } }
        public int USERID { get { return UserID; } }
        public string UID { get { return Uid; } }
        public List<Diente> DIENTES { get => MisDientes; }
        public DateTime FECHA {get=>Fecha;}

        public static bool InsertDiente(string OdontogramaID, int DienteID, string Estado)
        {
            ConnectionDispensario.Conexiones.Con_Odontograma CO = new Conexiones.Con_Odontograma();
            bool res = CO.Insert_Diente(OdontogramaID, DienteID, Estado);
            return res;
        }


        public Odontograma(DataRow p_DR)
        {
            PacienteID = int.Parse(p_DR["PacienteId"].ToString());
            UserID = int.Parse(p_DR["UserId"].ToString());
            Uid = p_DR["UID"].ToString();
            Fecha = DateTime.Parse(p_DR["Fecha"].ToString());
            Conexiones.Con_Odontograma CO = new Conexiones.Con_Odontograma();
            DataTable DT = CO.GetDientes(Uid);
            if (DT != null)
            {
                MisDientes.Clear();
                for(int a = 0; a < DT.Rows.Count; a++)
                {
                    Diente D = new Diente(DT.Rows[a], this);
                    MisDientes.Add(D);
                }
            }
        }

        public static List<Odontograma> Get_OdontogramasByIdPaciente(int IdPaciente)
        {
            List<Odontograma> LO = new List<Odontograma>();
            Conexiones.Con_Odontograma CO = new Conexiones.Con_Odontograma();
            DataTable DT = CO.GetOdontogramas(IdPaciente);
            if (DT != null)
            {
                for (int a = 0; a < DT.Rows.Count; a++) {
                    LO.Add(new Odontograma(DT.Rows[a]));
                        }
                return LO;
            } else
            {
                return null;
            }

        }

        public Odontograma(int p_UserID, int p_PacienteID)
        {



            Conexiones.Con_Odontograma CO = new Conexiones.Con_Odontograma();
            DataRow DR = CO.Insert_Odontograma(p_UserID, p_PacienteID);
            if (DR != null)
            {
                PacienteID = p_PacienteID;
                UserID = p_UserID;

                Uid = DR["UID"].ToString();
            }
            else
            {
                Uid = "";
            }


        }
    }
}
