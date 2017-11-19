using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectionDispensario.Modelos.Reporting
{

    public class C1Item
    {
        int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        string apelldoynombre;

        public string Apelldoynombre
        {
            get { return apelldoynombre; }
            set { apelldoynombre = value; }
        }
        string residenciahabitual;

        public string Residenciahabitual
        {
            get { return residenciahabitual; }
            set { residenciahabitual = value; }
        }
        string obrasocialplandesalud;

        public string Obrasocialplandesalud
        {
            get { return obrasocialplandesalud; }
            set { obrasocialplandesalud = value; }
        }
        string ningunplandesalud;

        public string Ningunplandesalud
        {
            get { return ningunplandesalud; }
            set { ningunplandesalud = value; }
        }
        string menor1m;

        public string Menor1m
        {
            get { return menor1m; }
            set { menor1m = value; }
        }
        string menor1f;

        public string Menor1f
        {
            get { return menor1f; }
            set { menor1f = value; }
        }
        string ano1m;

        public string Ano1m
        {
            get { return ano1m; }
            set { ano1m = value; }
        }
        string ano1f;

        public string Ano1f
        {
            get { return ano1f; }
            set { ano1f = value; }
        }
        string ano2a4m;

        public string Ano2a4m
        {
            get { return ano2a4m; }
            set { ano2a4m = value; }
        }
        string ano2a4f;

        public string Ano2a4f
        {
            get { return ano2a4f; }
            set { ano2a4f = value; }
        }
        string ano5a9m;

        public string Ano5a9m
        {
            get { return ano5a9m; }
            set { ano5a9m = value; }
        }
        string ano5a9f;

        public string Ano5a9f
        {
            get { return ano5a9f; }
            set { ano5a9f = value; }
        }
        string ano10a14m;

        public string Ano10a14m
        {
            get { return ano10a14m; }
            set { ano10a14m = value; }
        }
        string ano10a14f;

        public string Ano10a14f
        {
            get { return ano10a14f; }
            set { ano10a14f = value; }
        }
        string ano15a49m;

        public string Ano15a49m
        {
            get { return ano15a49m; }
            set { ano15a49m = value; }
        }
        string ano15a49f;

        public string Ano15a49f
        {
            get { return ano15a49f; }
            set { ano15a49f = value; }
        }
        string ano50ymasm;

        public string Ano50ymasm
        {
            get { return ano50ymasm; }
            set { ano50ymasm = value; }
        }
        string ano50ymasf;

        public string Ano50ymasf
        {
            get { return ano50ymasf; }
            set { ano50ymasf = value; }
        }
        string diagnostico;

        public string Diagnostico
        {
            get { return diagnostico; }
            set { diagnostico = value; }
        }
        string codcie;

        public string Codcie
        {
            get { return codcie; }
            set { codcie = value; }
        }
        string controlembarazo;

        public string Controlembarazo
        {
            get { return controlembarazo; }
            set { controlembarazo = value; }
        }

        string dni;
        public string DNI 
        {
            get { return dni; }
            set { dni = value; }
        }


    }

    public class C1
    {
        public int totalplandesalud=0;
        public int totalsinplandesalud = 0;
        public int totalmenor1m = 0;
        public int totalmenor1f = 0;
        public int total1anom = 0;
        public int total1anof = 0;
        public int total2a4m = 0;
        public int total2a4f = 0;
        public int total5a9m = 0;
        public int total5a9f = 0;
        public int total10a14m = 0;
        public int total10a14f = 0;
        public int total15a49m = 0;
        public int total15a49f = 0;
        public int total50amasm = 0;
        public int total50amasf = 0;
        public int totalm = 0;
        public int totalf = 0;
        public int totalcontrolembarazo = 0;





        public List<C1Item> GetC1(DateTime Start, DateTime End, int Iduser, string estado)
        {
            List<Turno> T = Modelos.Turno.GetTurnosByPeriod(Start, End, Iduser, estado);
            int count = 0;

            if (T != null)
            {
                List<C1Item> C1List = new List<C1Item>();
                for (int a = 0; a < T.Count; a++)
                {
                    C1Item t_C1 = new C1Item();

                    if (T[a].Pac != null)
                    {
                        count++;
                        t_C1.Id = count;
                        t_C1.Apelldoynombre = T[a].Pac.APELLIDO + ", " + T[a].Pac.NOMBRE;
                        t_C1.Residenciahabitual = T[a].Pac.LOCALIDAD;
                        t_C1.DNI = T[a].Pac.NRODOCUMENTO;
                        if (T[a].Pac.IDOBRASOCIAL != 0)
                        {
                            ObraSocial t_OS = ObraSocial.GetObraSocial(T[a].Pac.IDOBRASOCIAL);
                            if (t_OS != null)
                            {
                                t_C1.Obrasocialplandesalud = t_OS.NOMBRE;
                                totalplandesalud++;
                            }
                            else
                            {
                                t_C1.Ningunplandesalud = "X";
                                totalsinplandesalud++;
                            }
                        }
                        else 
                        {
                            t_C1.Ningunplandesalud = "X";
                            totalsinplandesalud++;
                        }


                        int t_edad = Utils.Conversiones.getAge(T[a].Pac.FECHA_NACIMIENTO);

                        //Edad Masculino
                        if (T[a].Pac.SEXO == "Masculino")
                        {
                            totalm++;
                            if (t_edad < 1) { t_C1.Menor1m = "X"; totalmenor1m++; }
                            if (t_edad == 1) {t_C1.Ano1m = "X"; total1anom++; }
                            if (t_edad > 1 && t_edad < 5) { t_C1.Ano2a4m = "X"; total2a4m++; }
                            if (t_edad > 4 && t_edad < 10) { t_C1.Ano5a9m = "X"; total5a9m++; }
                            if (t_edad > 9 && t_edad < 15) {t_C1.Ano10a14m = "X"; total10a14m++;}
                            if (t_edad > 14 && t_edad < 50) {t_C1.Ano15a49m = "X";total15a49m++;}
                            if (t_edad > 49) { t_C1.Ano50ymasm = "X"; total50amasm++; }
                        }
                        else //Edad Femenino
                        {
                            totalf++;
                            if (t_edad < 1) { t_C1.Menor1f = "X"; totalmenor1f++; }
                            if (t_edad == 1) { t_C1.Ano1f = "X"; total1anof++; }
                            if (t_edad > 1 && t_edad < 5) { t_C1.Ano2a4f = "X"; total2a4f++; }
                            if (t_edad > 4 && t_edad < 10) { t_C1.Ano5a9f = "X"; total5a9f++; }
                            if (t_edad > 9 && t_edad < 15) { t_C1.Ano10a14f = "X"; total10a14f++; }
                            if (t_edad > 14 && t_edad < 50) { t_C1.Ano15a49f = "X"; total15a49f++; }
                            if (t_edad > 49) { t_C1.Ano50ymasf = "X"; total50amasf++; }
                        }

                        t_C1.Diagnostico = T[a].DiagnosticoFinal;
                        if (T[a].ControlEmbarazo==true){
                            t_C1.Controlembarazo = "X";
                            totalcontrolembarazo++;
                        }

                        C1List.Add(t_C1);

                    }
                   
                }
                return C1List;
            }
            else 
            {
                return null;
            }


        }
    }
}
