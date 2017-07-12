using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace ConnectionDispensario.Modelos
{
    public class APP
    {
        public int IdPaciente;
        public string Patologia;
        public int ID;

        public APP(int p_IdPaciente, string p_Patologia)
        {
            IdPaciente = p_IdPaciente;
            Patologia = p_Patologia;
        }

        public APP(DataRow p_DR) 
        {
            ID = int.Parse(p_DR["Id"].ToString());
            Patologia = p_DR["Patologia"].ToString();
            IdPaciente = int.Parse(p_DR["IdPaciente"].ToString());
        }

        public Boolean Guardar() 
        {
            Conexiones.Con_AntecedentesPatologicosPersonales CAA = new Conexiones.Con_AntecedentesPatologicosPersonales();
            return CAA.InsertAntecedente(IdPaciente, Patologia);

        }


        public static List<APP> GetAntecedentesByIdPaciente(int IdPaciente) 
        {
            DataTable Result = new Conexiones.Con_AntecedentesPatologicosPersonales().SelectByIdPaciente(IdPaciente);
            List<APP> MyTemp;
            if (Result != null) 
            {
                MyTemp = new List<APP>();
                for (int a = 0; a < Result.Rows.Count; a++) 
                {
                    MyTemp.Add(new APP(Result.Rows[a]));
                }
                return MyTemp;
            } else { return null; }
        }
    }
}
