using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectionDispensario.Modelos
{

    [Serializable]
    public class Diente
    {



        public enum EstadoParteDiente { none, azul, rojo };
        public enum Marca_X { none, rojo, azul };
        public enum Marca_O { none, rojo, azul };

        EstadoParteDiente top = EstadoParteDiente.none;
        EstadoParteDiente bottom = EstadoParteDiente.none;
        EstadoParteDiente left = EstadoParteDiente.none;
        EstadoParteDiente right = EstadoParteDiente.none;
        EstadoParteDiente center = EstadoParteDiente.none;
        Marca_O marca_o = Marca_O.none;
        Marca_X marca_x = Marca_X.none;

        Odontograma MyOdontograma;
        int iddiente;
        string estadodiente = "xxxxxxx";
        int id;

        public EstadoParteDiente Top { get => top; set => top = value; }
        public EstadoParteDiente Bottom { get => bottom; set => bottom = value; }
        public EstadoParteDiente Left { get => left; set => left = value; }
        public EstadoParteDiente Right { get => right; set => right = value; }
        public EstadoParteDiente Center { get => center; set => center = value; }
        public Marca_O Marca_o { get => marca_o; set => marca_o = value; }
        public Marca_X Marca_x { get => marca_x; set => marca_x = value; }
        public Odontograma Odontograma { get => MyOdontograma; set => MyOdontograma = value; }
        public int Iddiente { get => iddiente; set => iddiente = value; }
        public string Estadodiente { get => estadodiente; set => estadodiente = value; }
        public int Id { get => id; set => id = value; }

        public Diente(DataRow DR, Odontograma O)
        {
            MyOdontograma = O;
            id = int.Parse(DR["Id"].ToString());
            iddiente = int.Parse(DR["DienteID"].ToString());
            estadodiente = DR["Estado"].ToString();
            llenarvalores();


        }

        void llenarvalores()
        {
            if (estadodiente[0] == 'r') top = EstadoParteDiente.rojo;
            if (estadodiente[0] == 'b') top = EstadoParteDiente.azul;

            if (estadodiente[1] == 'r') bottom = EstadoParteDiente.rojo;
            if (estadodiente[1] == 'b') bottom = EstadoParteDiente.azul;

            if (estadodiente[2] == 'r') left = EstadoParteDiente.rojo;
            if (estadodiente[2] == 'b') left = EstadoParteDiente.azul;

            if (estadodiente[3] == 'r') right = EstadoParteDiente.rojo;
            if (estadodiente[3] == 'b') right = EstadoParteDiente.azul;

            if (estadodiente[4] == 'r') center = EstadoParteDiente.rojo;
            if (estadodiente[4] == 'b') center = EstadoParteDiente.azul;

            if (estadodiente[5] == 'r') marca_x = Marca_X.rojo;
            if (estadodiente[5] == 'b') marca_x = Marca_X.azul;

            if (estadodiente[6] == 'r') marca_o = Marca_O.rojo;
            if (estadodiente[6] == 'b') marca_o = Marca_O.azul;





        }
        
    }
}
