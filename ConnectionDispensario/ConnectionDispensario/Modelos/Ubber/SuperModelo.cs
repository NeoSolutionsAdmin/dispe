using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectionDispensario.Modelos.Ubber
{
    [Serializable]
    public class SuperModelo
    {

        public interface SuperInterface
        {
            bool Guardar();
        }

        public enum Estado { Nuevo, Borrado, Cargado, Editado }

        private int id;
        private string guid;
        public string GUID { get { return guid; } set { guid = value; } }
        public int ID { get { return id; } set { id = value; } }
        public List<String> EmptyFields;

        private Estado estado = Estado.Nuevo;
        public Estado ESTADO
        {
            get { return estado; }
            set
            {
                estado = value;
                if (estado == Estado.Nuevo) id = 0;
            }
        }

        public void DispararError(Exception E) 
        {
            throw E;
        }
        
        public void ControlarEdicion()
        {
            if (ESTADO == Estado.Cargado) 
            {
                ESTADO = Estado.Editado;
            }
        }

        public void ErrorControl(bool ControlEmpty) 
        {
            EmptyFields = new List<string>();
            if (ControlEmpty==true)
            {
                bool C = this.GetType().GetProperties()
          .Where(pi => pi.GetValue(this) is string)
          .Select(pi => (string)pi.GetValue(this))
          .Any(value => String.IsNullOrEmpty(value));

                EmptyFields = this.GetType().GetProperties()
          .Where(pi => pi.GetValue(this) is string)
          .Select(pi => (string)pi.GetValue(this)).ToList<string>();
          

                if (C == true)
                {
                    string message = "Campos vacios:";
                    for (int a = 0; a < EmptyFields.Count; a++)
                    {
                        message = message + EmptyFields[a];
                        if (a < EmptyFields.Count - 1) message = message + ",";
                         
                    }
                    Exception E = new Exception(message);
                    throw E;
                }
            }
        }

    }
}
