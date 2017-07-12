using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace ConnectionDispensario.Modelos
{
    public class ObraSocial:Ubber.SuperModelo
    {
        private string nombre;


        public string NOMBRE { get { return nombre; } set { nombre = value; ControlarEdicion(); } }
        public ObraSocial(DataRow DR) 
        {
            NOMBRE = DR["Nombre"].ToString();
            ID = int.Parse(DR["Id"].ToString());
        }


        public static ObraSocial GetObraSocial(int IdObraSocial) 
        {
            Conexiones.Con_ObraSocial Conn = new Conexiones.Con_ObraSocial();
             DataRow  DR = Conn.Select_ObraSocialById(IdObraSocial);
             if (DR != null)
             {
                 return new ObraSocial(DR);
             }
             else 
             {
                 return null;
             }
        }

        public static List<ObraSocial> BuscarObrasSociales(string SearchString = "%") 
        {
            Conexiones.Con_ObraSocial Conn = new Conexiones.Con_ObraSocial();
            DataTable DT = Conn.Search_ObraSocial(SearchString);
            if (DT != null)
            {
                List<ObraSocial> t_OS = new List<ObraSocial>();
                for (int a = 0; a < DT.Rows.Count; a++)
                {
                    t_OS.Add(new ObraSocial(DT.Rows[a]));
                }
                return t_OS;
            }
            else 
            {
                return null;
            }
            
        }
    }
}
