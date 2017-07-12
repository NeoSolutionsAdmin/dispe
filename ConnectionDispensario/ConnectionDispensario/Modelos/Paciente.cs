using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace ConnectionDispensario.Modelos
{
 [Serializable]   
    public class Paciente:Ubber.SuperModelo, Ubber.SuperInterface
    {

        
        
        private string apellido;
        private string nombre;
        private DateTime fecha_nacimiento;
        private string nro_documento;
        private string telefono;
        private int id_obra_social;
        private string domicilio;
        private string localidad;
        private string nroobrasocial;
        private string sexo;

        public string APELLIDO { get { return apellido; } set { apellido = value; ControlarEdicion(); } }
        public string NOMBRE { get { return nombre; } set { nombre = value; ControlarEdicion(); } }
        public DateTime FECHA_NACIMIENTO { get { return fecha_nacimiento; } set { fecha_nacimiento = value; ControlarEdicion(); } }
        public string NRODOCUMENTO { get { return nro_documento; } set { nro_documento = value; ControlarEdicion(); } }
        public string TELEFONO { get { return telefono; } set { telefono = value; ControlarEdicion(); } }
        public int IDOBRASOCIAL { get { return id_obra_social; } set { id_obra_social = value; ControlarEdicion(); } }
        public string DOMICILIO { get { return domicilio; } set { domicilio = value; ControlarEdicion(); } }
        public string LOCALIDAD { get { return localidad; } set { localidad = value; ControlarEdicion(); } }
        public string NROOBRASOCIAL { get { return nroobrasocial; } set { nroobrasocial = value; ControlarEdicion(); } }
        public string SEXO { get { return sexo; } set { sexo = value; } }


        private Conexiones.Con_Pacientes CON = new Conexiones.Con_Pacientes();


        public Paciente() 
        {

        }

        public Paciente(
            string p_apellido,
            string p_nombre,
            DateTime p_fecha_nacimiento,
            string p_nrodocumento,
            string p_domicilio,
            string p_localidad,
            string p_telefono,
            int p_id_obra_social,
            string p_nroobrasocial,
            string p_sexo,
            bool ControlEmpty = false
            
            ) 
        {
            ESTADO = Estado.Nuevo;
            apellido = p_apellido;
            nombre = p_nombre;
            fecha_nacimiento = p_fecha_nacimiento;
            nro_documento = p_nrodocumento;
            telefono = p_telefono;
            id_obra_social = p_id_obra_social;
            domicilio = p_domicilio;
            localidad = p_localidad;
            nroobrasocial = p_nroobrasocial;
            sexo = p_sexo;
            ErrorControl(ControlEmpty);
            
        }

        public Paciente(DataRow DR)
        {
            try
            {

                ID = int.Parse(DR["Id"].ToString());
                GUID = DR["GUID"].ToString();
                APELLIDO = DR["Apellido"].ToString();
                NOMBRE = DR["Nombre"].ToString();
                FECHA_NACIMIENTO = DateTime.Parse(DR["FechaNacimiento"].ToString());
                NRODOCUMENTO = DR["NroDocumento"].ToString();
                TELEFONO = DR["Telefono"].ToString();
                IDOBRASOCIAL = int.Parse(DR["IdObraSocial"].ToString());
                DOMICILIO = DR["Domicilio"].ToString();
                LOCALIDAD = DR["Localidad"].ToString();
                NROOBRASOCIAL = DR["NroObraSocial"].ToString();
                SEXO = DR["Sexo"].ToString();
                ESTADO = Estado.Cargado;
            }
            catch (Exception E)
            {
                DispararError(E);
            }
        }


        public List<Historial> Get_Historial() 
        {
            Conexiones.Con_Historial CH = new Conexiones.Con_Historial();
            DataTable DT =  CH.Select_Diagnosticos_By_IdPaciente(ID);
            if (DT != null) 
            {
                List<Historial> t_L = new List<Historial>();
                foreach (DataRow DR in DT.Rows) 
                {
                    t_L.Add(new Historial(DR));
                }
                return t_L;
            } else 
            {
                return null;
            }
        }

        public bool Guardar()
        {
           
            if (ESTADO == Estado.Nuevo)
            {

                if (BuscarPacientesByDNI(NRODOCUMENTO) != null && BuscarPacientesByDNI(NRODOCUMENTO).Count > 0)
                {
                    return false;
                }
                else 
                {
                    return CON.InsertPaciente(this);
                }

            } if (ESTADO == Estado.Editado)
            {
                return CON.ActualizarPaciente(this);
            }
            else { return false; }

        }


        public static Paciente Select_Paciente_By_Id(int IdPaciente) 
        {
            Conexiones.Con_Pacientes CP = new Conexiones.Con_Pacientes();
            DataRow t_dr = CP.SelectPacienteByID(IdPaciente);
            if (t_dr != null)
            {
                return new Paciente(t_dr);
            }
            else 
            {
                return null;
            }
        }

        public static Paciente Select_Paciente_by_GUI(string GUI) 
        {
            Conexiones.Con_Pacientes CP = new Conexiones.Con_Pacientes();

            DataRow t_dr = CP.SelectPacienteByGUI(GUI);
            if (t_dr != null)
            {
                return new Paciente(t_dr);
            }
            else 
            {
                return null;
            }
        }

        public static List<Paciente> BuscarPacientesByApellido(string CadenaDeBusqueda)
        {
            Conexiones.Con_Pacientes CP = new Conexiones.Con_Pacientes();
            DataTable DT = CP.BuscarPacientesByApellido(CadenaDeBusqueda);
            if (DT != null)
            {
                List<Paciente> t_l = new List<Paciente>();
                foreach (DataRow DR in DT.Rows)
                {
                    t_l.Add(new Paciente(DR));
                }
                return t_l;
            }
            else
            {
                return null;
            }
        }

        public static List<Paciente> BuscarPacientesByDNI(string CadenaDeBusqueda)
        {
            Conexiones.Con_Pacientes CP = new Conexiones.Con_Pacientes();
            DataTable DT = CP.BuscarPacienteByDNI(CadenaDeBusqueda);
            if (DT != null)
            {
                List<Paciente> t_l = new List<Paciente>();
                foreach (DataRow DR in DT.Rows)
                {
                    t_l.Add(new Paciente(DR));
                }
                return t_l;
            }
            else
            {
                return null;
            }
        }
        
     


    }
}
