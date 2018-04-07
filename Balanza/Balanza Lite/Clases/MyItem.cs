using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Clases
{
    public class MyItem : System.Windows.Forms.TreeNode
    {

        public Registro REG;
        public Clases.BalanzaDataSetTableAdapters.ProductosTableAdapter PTA = new BalanzaDataSetTableAdapters.ProductosTableAdapter();
        public Clases.BalanzaDataSet.ProductosDataTable PDT = new BalanzaDataSet.ProductosDataTable();

        

        public MyItem(System.Windows.Forms.TreeView TV, System.Data.DataRow p_DR) : base() 
        {
            
            string GUID = p_DR["GUID"].ToString();
            DateTime Fecha = DateTime.Parse( p_DR["Fecha"].ToString());
            string Cliente = p_DR["Cliente"].ToString();
            int ProductoId = int.Parse(p_DR["Producto"].ToString());
            string Patente = p_DR["Patente"].ToString();
            int Bruto = int.Parse(p_DR["Bruto"].ToString());
            int Tara = int.Parse(p_DR["Tara"].ToString());
            int Neto = int.Parse(p_DR["Neto"].ToString());
            string Humedad = p_DR["Humedad"].ToString();
            string Chofer = p_DR["Chofer"].ToString();

            PTA.GetProductByID(PDT, ProductoId);




            string ProductoCompuestoDeId = ProductoId.ToString() + "-" +PDT.Rows[0]["Nombre"].ToString();
 


            this.Text = Patente + "(" + Fecha.ToShortDateString() + "[" + Fecha.ToShortTimeString() + "]" + ")";
            this.Nodes.Add("fecha", "Fecha:" + Fecha.ToShortDateString()).ImageIndex = 2;
            this.Nodes.Add("bruto", "Bruto:").ImageIndex = 1;
            this.Nodes.Add("tara", "Tara:").ImageIndex = 1;
            this.Nodes.Add("neto", "Neto:").ImageIndex = 1;
            this.Nodes.Add("producto", "Producto:" + ProductoCompuestoDeId).ImageIndex = 2;
            this.ForeColor = System.Drawing.Color.Red;
            this.NodeFont = new System.Drawing.Font(SystemFonts.DefaultFont, FontStyle.Bold);

            TV.Nodes.Add(this);
            this.Name = "record" + Guid.NewGuid().ToString();

            for (int a = 0; a < this.Nodes.Count; a++)
            {
                Nodes[a].SelectedImageIndex = 3;

            }
            REG = new Registro(Tara, true);
            setData(Cliente, ProductoId, Patente, Humedad, Chofer, Fecha);
            setBruto(Bruto, false);
            setTara(Tara, false);
            checkForNeto();
            
        }

        public void setBruto(int p_bruto, Boolean p_save = true) 
        {
            this.Nodes["bruto"].Text = "Bruto:" + p_bruto.ToString();
            this.Nodes["bruto"].ImageIndex = 2;
            if (REG == null) { REG = new Registro(p_bruto, false); } else 
            {
                REG.Peso = p_bruto;
                checkForNeto();
                this.ForeColor = System.Drawing.Color.Black;
                this.NodeFont = new System.Drawing.Font(this.NodeFont, FontStyle.Regular);
                if (p_save == true)
                {
                    REG.Guardar();
                }
            }
            
        }

        private void checkForNeto() 
        {
            if (REG.Neto != 0) 
            {
                this.Nodes["neto"].Text = "Neto:" + REG.Neto.ToString();
                this.Nodes["neto"].ImageIndex = 2;
            }
        }

        public void setData(
            string p_cliente,
            int p_idproducto,
            string p_patente,
            string p_humedad,
            string p_chofer,
            DateTime p_fecha

            )
        {

            string symbol = "";
            if (decimal.Parse("1.1")==1.1m)
            {
                symbol = ".";

            }
            else 
            {
                symbol = ",";
            }

            string newhumed = p_humedad.Replace(".", symbol).Replace(",", symbol);
            decimal humed = decimal.Parse(newhumed);
           

            REG.setData(p_cliente, p_idproducto, p_patente, humed, p_chofer, p_fecha);
            this.Nodes.Add("cliente", "Cliente:" + p_cliente).ImageIndex = 2;
            this.Nodes.Add("chofer", "Chofer:" + p_chofer).ImageIndex = 2;
            this.Nodes.Add("humedad", "Humedad:" + newhumed + "%").ImageIndex = 2;
            this.Nodes["cliente"].SelectedImageIndex = 3;
            this.Nodes["chofer"].SelectedImageIndex = 3;
            this.Nodes["humedad"].SelectedImageIndex = 3;
            
            

        }

        public void setTara(int p_tara, Boolean p_save=true)
        {
            this.Nodes["tara"].Text = "Tara:" + p_tara.ToString();
            this.Nodes["tara"].ImageIndex = 2;
            if (REG == null) { REG = new Registro(p_tara, true); }
            else
            {
                REG.Tara = p_tara;
                checkForNeto();
                this.ForeColor = System.Drawing.Color.Black;
                this.NodeFont = new System.Drawing.Font(this.NodeFont, FontStyle.Regular);
                if (p_save == true)
                {
                    REG.Guardar();
                }
            }
        }
        
        public MyItem(System.Windows.Forms.TreeView TV, string Patente, string Producto):base()
        {
            
            this.Text = Patente + "(" + DateTime.Now.ToShortDateString() + "[" + DateTime.Now.ToShortTimeString() + "]" + ")";
            this.Nodes.Add("fecha", "Fecha:"  + DateTime.Now.ToShortDateString()).ImageIndex=2;
            this.Nodes.Add("bruto", "Bruto:").ImageIndex = 1;
            this.Nodes.Add("tara", "Tara:").ImageIndex = 1;
            this.Nodes.Add("neto", "Neto:").ImageIndex = 1;
            this.Nodes.Add("producto", "Producto:" + Producto).ImageIndex = 2;
            this.ForeColor = System.Drawing.Color.Red;
            this.NodeFont = new System.Drawing.Font(SystemFonts.DefaultFont, FontStyle.Bold);
            
            TV.Nodes.Add(this);
            this.Name = "record" + Guid.NewGuid().ToString();

            for (int a = 0; a < this.Nodes.Count; a++) 
            {
                Nodes[a].SelectedImageIndex = 3;
                
            }
            

        }
    }
}
