﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DotNetNuke;

namespace ConnectionDispensario.Modelos
{
    [Serializable]
    public class ProfileUser 
    {

        string key;
        string val;

        

        public string KEY { get { return key; } set { key = value; } }
        public string VALUE { get { return val; } set { val = value; } }

        public ProfileUser(string p_Key, string p_Value) 
        {
            key = p_Key;
            val = p_Value;
        }

        

        public static List<ProfileUser> getProfileUser(int IdPortal, int IdUser) 
        {

            DotNetNuke.Entities.Users.UserController UC = new DotNetNuke.Entities.Users.UserController();
            DotNetNuke.Entities.Users.UserInfo UI = UC.GetUser(IdPortal,IdUser);
            DotNetNuke.Entities.Profile.ProfilePropertyDefinitionCollection C = UI.Profile.ProfileProperties;
            
            
            List<ProfileUser> PUV = null;
            if (C != null) 
            {
                
                
                PUV = new List<ProfileUser>();
                /*
                for (int b = 0; b < C.Count; b++) 
                {
                    if (C[b].PropertyValue!=null && C[b].PropertyValue.Trim() != "")
                    {
                        PUV.Add(new ProfileUser(C[b].PropertyName, C[b].PropertyValue));
                    }
                }*/




                if (C["FirstName"] != null) PUV.Add(new ProfileUser("Nombre", C["FirstName"].PropertyValue));
                if (C["LastName"] != null) PUV.Add(new ProfileUser("Apellido", C["LastName"].PropertyValue));
                if (C["Puesto"] != null) PUV.Add(new ProfileUser("Puesto", C["Puesto"].PropertyValue));
                if (C["Telephone"] != null) PUV.Add(new ProfileUser("Teléfono", C["Telephone"].PropertyValue));
                if (C["MP"] != null) PUV.Add(new ProfileUser("M.P.", C["MP"].PropertyValue));
                if (C["ME"] != null) PUV.Add(new ProfileUser("M.E.", C["ME"].PropertyValue));
                if (UI.IsInRole("Medico") == true) { PUV.Add(new ProfileUser("Medico", "si")); }
                if (UI.IsInRole("Enfermero") == true) { PUV.Add(new ProfileUser("Enfermero", "si")); }
                if (UI.IsInRole("Administrativo") == true) { PUV.Add(new ProfileUser("Administrativo", "si")); }






            }
            return PUV;

        }

        public ProfileUser() 
        {
            
        }
    }



    [Serializable]
    public class Historial : Ubber.SuperModelo, Ubber.SuperInterface
    {
        string diagnostico;
        DateTime fecha;
        int iduser;
        int idpaciente;
        bool IsOdontograma = false;
        Odontograma Odontog = null;
        string diagnosticoCensurado;
        bool censuredpresent = false;

        public Historial() { }

        public Historial(string p_diagnostico, int p_iduser, int p_idpaciente)
        {
            fecha = DateTime.Now;
            diagnostico = p_diagnostico;
            iduser = p_iduser;
            idpaciente = p_idpaciente;

        }

        public Historial(Odontograma p_O)
        {
            ID = 0;
            idpaciente = p_O.PACIENTEID;
            iduser = p_O.USERID;
            fecha = p_O.FECHA;
            GUID = p_O.UID;
            diagnostico = "";
            IsOdontograma = true;
            Odontog = p_O;
        }

        public Historial(DataRow _DR)
        {
            ID = int.Parse(_DR["Id"].ToString());
            idpaciente = int.Parse(_DR["IdPaciente"].ToString());
            iduser = int.Parse(_DR["IdUser"].ToString());
            fecha = DateTime.Parse(_DR["Fecha"].ToString());
            GUID = _DR["HUID"].ToString();

            diagnostico = _DR["Diagnostico"].ToString().Replace("[LineJump]", "<br/>");
            int firstint = diagnostico.IndexOf('*');
            int secondint = diagnostico.LastIndexOf('*');

            if (firstint != -1 && secondint != -1)
            {
                diagnosticoCensurado = diagnostico.Remove(firstint, (secondint - firstint) + 1);
                diagnostico = diagnostico.Insert(firstint, "<span style='color:red'> INFORMACION PROTEGIDA:");
                secondint = diagnostico.LastIndexOf('*');
                diagnostico = diagnostico.Insert(secondint + 1, "</span>");
            }
            else
            {
                diagnosticoCensurado = diagnostico;
            }
            
            


        }




        public string DIAGNOSTICO { get { return diagnostico; } }
        public string DIAGNOSTICOCENSURADO { get { return diagnosticoCensurado; } }
        public DateTime FECHA { get { return fecha; } }
        public int IDUSER { get { return iduser; } }
        public bool ISODONTOGRAMA { get => IsOdontograma; }
        public Odontograma ODONTOGRAMA { get => Odontog; }
        


        public List<ProfileUser> GetProfileUser(int IdPortal) 
        {
            return ProfileUser.getProfileUser(IdPortal, iduser);
        }

        public bool Guardar()
        {
            bool ok = false;
            if (diagnostico != null && diagnostico != "")
            {
                if (iduser != 0 && idpaciente != 0)
                {
                    if (fecha != null)
                    {
                        Conexiones.Con_Historial H = new Conexiones.Con_Historial();
                        GUID = H.InsertarHistorial(diagnostico, iduser, idpaciente, fecha);
                        if (GUID != "")
                        {
                            ok = true;
                            ConnectionDispensario.Statics.LogCatcher.AddLog("EL HISTORIAL FUE GUARDADO", "EL HISTORIAL FUE GUARDADO", null, null);
                        }
                        else 
                        {
                            ConnectionDispensario.Statics.LogCatcher.AddLog("GUID ES NULL", "GUID ES NULL", null, null);
                        }
                    }
                    else 
                    {
                        ConnectionDispensario.Statics.LogCatcher.AddLog("Fecha es null", "Fecha es null", null, null);
                    }
                }
                else 
                {
                    ConnectionDispensario.Statics.LogCatcher.AddLog("Id de paciente e id de user no llegan", "Id de paciente e id de user no llegan", null, null);
                }
            }
            else 
            {
                ConnectionDispensario.Statics.LogCatcher.AddLog("No llega el diagnostico", "No llega el diagnostico", null, null);
            }
            return ok;
        }
    }
    
}
