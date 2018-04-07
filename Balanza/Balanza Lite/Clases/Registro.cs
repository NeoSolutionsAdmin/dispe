using System;
using System.Collections.Generic;
using System.Text;
using Clases;

namespace Clases
{
    public class Registro
    {
        private BalanzaDataSetTableAdapters.RegistrosTableAdapter TA = new BalanzaDataSetTableAdapters.RegistrosTableAdapter();
        private string UID;
        private int TARA = 0;
        private int PESO = 0;
        private int PESOCARGA = 0;
        private string CLIENTE = "";
        private int IDPRODUCTO = 0;
        private string PATENTE = "";
        private decimal HUMEDAD = 0;
        private string CHOFER = "";
        private DateTime Fecha;

        public string Cliente { get { return CLIENTE; } }
        public string Patente { get { return PATENTE; } }
        public decimal Humedad { get { return HUMEDAD; } }
        public string Chofer { get { return CHOFER; } }
        public DateTime FechaYHora   { get { return Fecha; } }

        public void setData(
            string p_cliente,
            int p_idproducto,
            string p_patente,
            decimal p_humedad,
            string p_chofer,
            DateTime p_fecha

            )
        {
            CLIENTE = p_cliente;
            IDPRODUCTO = p_idproducto;
            PATENTE = p_patente;
            HUMEDAD = p_humedad;
            CHOFER = p_chofer;
            Fecha = p_fecha;

        }

        public int IdProducto { get{ return IDPRODUCTO;} }

        public Registro(int p_valor, bool p_istara)
        {

            
            

            if (p_istara == true)
            {
                TARA = p_valor;
            }
            else
            {
                PESO=p_valor;
            }

            GenerateGUID();
            
           

            
        }

        public void Guardar() 
        {
            BalanzaDataSetTableAdapters.RegistrosTableAdapter RTA = new BalanzaDataSetTableAdapters.RegistrosTableAdapter();
            RTA.InsertarRegistro(UID, DateTime.Now, CLIENTE, IDPRODUCTO, PATENTE, PESO, TARA, PESOCARGA, HUMEDAD.ToString(), CHOFER);
            

        }

        private void  GenerateGUID()
        {
            UID = System.Guid.NewGuid().ToString();
        }

        private void checkResgistros()
        {
            if (TARA > 0 && PESO > 0) PESOCARGA = PESO - TARA;
        }

        public int Tara { get { return TARA; } set { TARA = value; checkResgistros(); } }
        public int Peso { get { return PESO; } set { PESO = value; checkResgistros(); } }
        public int Neto { get { return PESOCARGA; } }

        
    }
}
