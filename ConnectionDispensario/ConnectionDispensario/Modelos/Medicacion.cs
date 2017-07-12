using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace ConnectionDispensario.Modelos
{
    public class Medicacion
    {
        public int IdPaciente;
        public string NameMedicacion;
        public int ID;

        public Medicacion(int p_IdPaciente, string p_Medicacion)
        {
            IdPaciente = p_IdPaciente;
            NameMedicacion = p_Medicacion;
        }

        public Medicacion(DataRow p_DR) 
        {
            ID = int.Parse(p_DR["Id"].ToString());
            NameMedicacion = p_DR["Medicacion"].ToString();
            IdPaciente = int.Parse(p_DR["IdPaciente"].ToString());
        }

        public Boolean Guardar() 
        {
            Conexiones.Con_Medicacion CM = new Conexiones.Con_Medicacion();
            return CM.Insertar_Medicacion(IdPaciente, NameMedicacion);

        }

        public static Boolean Borrar(int IdMedicacion)
        {
            return new Conexiones.Con_Medicacion().Borrar_Medicacion(IdMedicacion);
        }


        public static List<Medicacion> GetMedicacionByIdPaciente(int IdPaciente) 
        {
            DataTable Result = new Conexiones.Con_Medicacion().Select_Medicacion(IdPaciente);
            List<Medicacion> MyTemp;
            if (Result != null) 
            {
                MyTemp = new List<Medicacion>();
                for (int a = 0; a < Result.Rows.Count; a++) 
                {
                    MyTemp.Add(new Medicacion(Result.Rows[a]));
                }
                return MyTemp;
            } else { return null; }
        }
    }
}
