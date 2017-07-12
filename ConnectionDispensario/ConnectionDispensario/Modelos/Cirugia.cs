using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace ConnectionDispensario.Modelos
{
    public class Cirugia
    {
        public int IdPaciente;
        public string NameCirugia;
        public int ID;

        public Cirugia(int p_IdPaciente, string p_Alergia)
        {
            IdPaciente = p_IdPaciente;
            NameCirugia = p_Alergia;
        }

        public Cirugia(DataRow p_DR) 
        {
            ID = int.Parse(p_DR["Id"].ToString());
            NameCirugia = p_DR["Cirugia"].ToString();
            IdPaciente = int.Parse(p_DR["IdPaciente"].ToString());
        }

        public Boolean Guardar() 
        {
            Conexiones.Con_AntecedentesQuirurgicos CAA = new Conexiones.Con_AntecedentesQuirurgicos();
            return CAA.Insertar_Cirugia(IdPaciente, NameCirugia);

        }


        public static List<Cirugia> GetCirugiasByIdPaciente(int IdPaciente) 
        {
            DataTable Result = new Conexiones.Con_AntecedentesQuirurgicos().Select_CirugiasPaciente(IdPaciente);
            List<Cirugia> MyTemp;
            if (Result != null) 
            {
                MyTemp = new List<Cirugia>();
                for (int a = 0; a < Result.Rows.Count; a++) 
                {
                    MyTemp.Add(new Cirugia(Result.Rows[a]));
                }
                return MyTemp;
            } else { return null; }
        }
    }
}
