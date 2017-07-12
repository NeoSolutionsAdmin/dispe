using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace ConnectionDispensario.Modelos
{
    public class CIE
    {

        public int ID;
        public string CODIGO;
        public string ETIQUETA;
        public int COUNTER;

        public CIE(DataRow DR) 
        {
            ID = int.Parse(DR["Id"].ToString());
            CODIGO = DR["Codigo"].ToString();
            ETIQUETA = DR["Etiqueta"].ToString();
            COUNTER = int.Parse(DR["Counter"].ToString());
        }

        public static CIE get_CIE(int Id)
        {
            Conexiones.Con_CIE CC = new Conexiones.Con_CIE();
            DataRow DR = CC.Get_CIE10(Id);
            if (DR != null)
            {
                return new CIE(DR);
            }
            else 
            {
                return null;
            }
        }

    }
}
