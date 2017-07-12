using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace ConnectionDispensario.Modelos
{
    public class APF
    {
        public int IdPaciente;
        public string Patologia;
        public int ID;

        public APF(int p_IdPaciente, string p_Patologia)
        {
            IdPaciente = p_IdPaciente;
            Patologia = p_Patologia;
        }

        public APF(DataRow p_DR) 
        {
            ID = int.Parse(p_DR["Id"].ToString());
            Patologia = p_DR["Patologia"].ToString();
            IdPaciente = int.Parse(p_DR["IdPaciente"].ToString());
        }

        public Boolean Guardar() 
        {
            Conexiones.Con_AntecedentesPatologicosFamiliares CAA = new Conexiones.Con_AntecedentesPatologicosFamiliares();
            return CAA.InsertAntecedente(IdPaciente, Patologia);

        }


        public static List<APF> GetAntecedentesByIdPaciente(int IdPaciente) 
        {
            DataTable Result = new Conexiones.Con_AntecedentesPatologicosFamiliares().SelectByIdPaciente(IdPaciente);
            List<APF> MyTemp;
            if (Result != null) 
            {
                MyTemp = new List<APF>();
                for (int a = 0; a < Result.Rows.Count; a++) 
                {
                    MyTemp.Add(new APF(Result.Rows[a]));
                }
                return MyTemp;
            } else { return null; }
        }
    }
}
