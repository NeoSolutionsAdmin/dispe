using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace ConnectionDispensario.Modelos
{
    public class Alergia
    {
        public int IdPaciente;
        public string NameAlergia;
        public int ID;

        public DataTable GetAllCulos() 
        {
            return null;
        }

        public Alergia(int p_IdPaciente, string p_Alergia)
        {
            
            
            IdPaciente = p_IdPaciente;
            NameAlergia = p_Alergia;
        }

        public Alergia(DataRow p_DR) 
        {
            ID = int.Parse(p_DR["Id"].ToString());
            NameAlergia = p_DR["Alergia"].ToString();
            IdPaciente = int.Parse(p_DR["IdPaciente"].ToString());
        }

        public Boolean Guardar() 
        {
            Conexiones.Con_AntecedentesAlergicos CAA = new Conexiones.Con_AntecedentesAlergicos();
            return CAA.Insertar_Alergia(IdPaciente, NameAlergia);

        }


        public static List<Alergia> GetAlergiasByIdPaciente(int IdPaciente) 
        {
            DataTable Result = new Conexiones.Con_AntecedentesAlergicos().Select_AlergiasPaciente(IdPaciente);
            List<Alergia> MyTemp;
            if (Result != null) 
            {
                MyTemp = new List<Alergia>();
                for (int a = 0; a < Result.Rows.Count; a++) 
                {
                    MyTemp.Add(new Alergia(Result.Rows[a]));
                }
                return MyTemp;
            } else { return null; }
        }
    }
}
