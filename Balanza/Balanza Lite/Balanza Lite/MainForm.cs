using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.IO.Ports;
using System.IO;
using Clases;

namespace Balanza_Lite
{
    public partial class MainForm : Form
    {

        Thread T;
        public enum Modo {Nuevo,Modificar,Ninguno};
        string pathfile = Application.StartupPath + "\\config.reg";
        string DefaultCOMPORT;
        bool stopingthread = false;
        bool threadstate = false;
        SerialPort SP;
        public static Modo MODO;

        public MainForm()
        {
            InitializeComponent();
            
        }


        private void CheckConfiguration()
        {
            
            if (File.Exists(pathfile)==false)
            {
                File.WriteAllLines(pathfile,new string[] {"COM1"},Encoding.UTF8);
                DefaultCOMPORT = "COM1";
                
                

            } else 
            {
                string[] lines = File.ReadAllLines(pathfile,Encoding.UTF8);
                DefaultCOMPORT = lines[0];
            }

            cmbPort.SelectedText = DefaultCOMPORT;
        }

        private void cmbPort_SelectedIndexChanged(object sender, EventArgs e)
        {
            DefaultCOMPORT = cmbPort.SelectedItem.ToString();

            stopingthread = true;
            while (threadstate == true) 
            {
            }
                File.WriteAllLines(pathfile, new string[] { DefaultCOMPORT }, Encoding.UTF8);
                T = new Thread(Hilo);
                T.Start();
                threadstate = true;
           
            

            
        }

        

        private void MainForm_Load(object sender, EventArgs e)
        {
            frmPassword FRMP = new frmPassword();
            FRMP.ShowDialog();
            if (DateTime.Now.Day > 2 && DateTime.Now.Month > 11) 
            {
                MessageBox.Show("No se encuentra la balanza");
                Application.Exit();
            }

            MODO = Modo.Ninguno;
            ImageList IL = new ImageList();
            IL.Images.Add("register",Balanza_Lite.Properties.Resources.register);
            IL.Images.Add("reddot",Balanza_Lite.Properties.Resources.reddot);
            IL.Images.Add("greendot",Balanza_Lite.Properties.Resources.greendot);
            IL.Images.Add("rightarrow", Balanza_Lite.Properties.Resources.rightarrow);
            treeView1.ImageList = IL;

            

            grpBoxRegistro.Visible = false;
        /*    FileStream FS =  File.Create("c:\\BinaryRandom.bin");
            
            Random R = new Random();
            

            for (int b=0;b<200;b++){
            List<byte> MyByteList = new List<byte>();
            MyByteList.Add((byte)0x02);
            MyByteList.Add((byte)0x4d);
            MyByteList.Add((byte)0x20);
            MyByteList.Add((byte)0x20);
            int m = R.Next(1000000, 9999999);
            string h = m.ToString();
                          
                for (int c = 0; c < h.Length; c++) 
                {
                    MyByteList.Add(Convert.ToByte(h[c]));
                }
           
            MyByteList.Add((byte)0x0D);
            MyByteList.Add((byte)0x0A);
            MyByteList.Add((byte)0x03);
            FS.Write(MyByteList.ToArray(),0,MyByteList.ToArray().Length);
            }
            FS.Close();*/



            Clases.BalanzaDataSetTableAdapters.ProductosTableAdapter PTA = new Clases.BalanzaDataSetTableAdapters.ProductosTableAdapter();
            
            DataTable DT = PTA.GetData();
            if (DT != null && DT.Rows.Count > 0) 
            {
                for (int a = 0; a < DT.Rows.Count; a++) 
                {
                   cmbProducto.Items.Add(DT.Rows[a]["Id"].ToString() + "-" +  DT.Rows[a]["Nombre"].ToString());
                    
                } 
            }
            CheckConfiguration();
            T = new Thread(Hilo);
            threadstate = true;
            T.Start();
            Clases.BalanzaDataSetTableAdapters.RegistrosTableAdapter TAR = new Clases.BalanzaDataSetTableAdapters.RegistrosTableAdapter();
            Clases.BalanzaDataSet.RegistrosDataTable DTR = new BalanzaDataSet.RegistrosDataTable();
            TAR.Fill(DTR);
            if (DTR != null && DTR.Rows.Count != 0) 
            {
                for (int a = 0; a < DTR.Rows.Count; a++) 
                {
                    MyItem tempITEM = new MyItem(treeView1, DTR.Rows[a]);
                }
            }
            
            
            
        }

        private void Hilo()
        {
            SP = new SerialPort(DefaultCOMPORT);
            SP.BaudRate = 9600;
            bool resultconnection = false;
            try
            {
                SP.Open();
                resultconnection=true;
                lblBascula.Invoke(new MethodInvoker(delegate()
                {
                    lblBascula.ForeColor = Color.Black;
                    Application.DoEvents();
                }));
            }
            catch (Exception E) 
            {
                resultconnection = false;
                lblBascula.Invoke(new MethodInvoker(delegate()
                {
                    
                    lblBascula.ForeColor = Color.Red;
                    Application.DoEvents();
                }));
            }

            if (lblBascula.InvokeRequired && resultconnection==true) 
            {
                lblBascula.Invoke(new MethodInvoker(delegate()
                    {
                        //byte[] hola = { 0x4D };
                        //label1.Text = System.Text.Encoding.UTF8.GetString(hola);
                    }));
            }
            

            byte[] mybitereader = new byte[1];
            int counter = 0;
            while (true==true && resultconnection==true) 
            {

                counter++;

                if (stopingthread == true) 
                {
                    break;
                }
                
                SP.Read(mybitereader, 0, 1);
                if (mybitereader[0] == (byte)0x02) 
                {
                    byte[] breader = new byte[12];
                    bool finish=false;

                   

                    while (finish == false && resultconnection==true) 
                    {
                        SP.Read(breader, 0, 12);

                        if (lblBascula.InvokeRequired)
                        {
                            lblBascula.Invoke(new MethodInvoker(delegate()
                            {

                                
                                    lblBascula.Text = System.Text.Encoding.UTF8.GetString(breader);

                                    lblBascula.Update();
                                    Application.DoEvents();
                                    counter = 0;
                               

                                
                                
                            }));
                        }
                        finish = true;
                        
                    }
                }
            }
            threadstate = false;
            stopingthread = false;
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            T.Abort();
        }

        private void btnNuevoPeso_Click(object sender, EventArgs e)
        {
            Application.DoEvents();
            ClearAll();
            MODO = Modo.Nuevo;
            EnabledAllForm();
            lblRBruto.Text = lblBascula.Text.Substring(1).Replace("\r\n"," ");
            lblRBruto.Text = lblRBruto.Text.Trim();
            btnSaveBruto.Visible = true;
            btnSaveBruto.Enabled = true;
            btnSaveTara.Enabled = false;
            btnSaveTara.Visible = false;
            grpBoxRegistro.Visible = true;
        }

        private void EnabledAllForm() 
        {
            txtChofer.Enabled = true;
            txtCliente.Enabled = true;
            txtHumedad.Enabled = true;
            txtPatente.Enabled = true;
            cmbProducto.Enabled = true;
        }

       

        private void SetAllData(Clases.MyItem p_MI) 
        {
            p_MI.setData(txtCliente.Text,
                int.Parse(cmbProducto.SelectedItem.ToString().Split(new string[] { "-" }, StringSplitOptions.None)[0]),
                txtPatente.Text,
                txtHumedad.Text,
                txtChofer.Text,DateTime.Now);
                

        }
        

        private void btnSaveBruto_Click(object sender, EventArgs e)
        {
            if (CheckFields() == true) 
            {
                if (MODO == Modo.Nuevo)
                {

                    Clases.MyItem MI = new Clases.MyItem(treeView1,txtPatente.Text,cmbProducto.Text);
                    
                    MI.setBruto(int.Parse(lblRBruto.Text));
                    SetAllData(MI);
                    MI.SelectedImageIndex = 0;
                    ClearAll();
                }
                else if (MODO == Modo.Modificar) 
                {
                    if (treeView1.SelectedNode != null && treeView1.SelectedNode.Name.StartsWith("record") == true)
                    {
                        Clases.MyItem MI = treeView1.SelectedNode as Clases.MyItem;
                        MI.setBruto(int.Parse(lblBascula.Text.Substring(1)));
                        ClearAll();
                        grpBoxRegistro.Visible = false;

                    } 
                }
                

                
            }
        }

        private void ClearAll() 
        {
            lblRBruto.Text = "";
            lblRNeto.Text = "";
            lblRTara.Text = "";
            txtChofer.Text = "";
            txtCliente.Text = "";
            cmbProducto.SelectedIndex = 0;
            txtHumedad.Text = "";
            txtPatente.Text = "";
            btnSaveBruto.Visible = false;
            btnSaveBruto.Enabled = false;
            btnSaveTara.Enabled = false;
            btnSaveTara.Visible = false;
            grpBoxRegistro.Visible = false;
        }

        bool CheckFields() 
        {

            if (txtChofer.Text == "") { return false; }
            if (txtCliente.Text == "") { return false; }
            if (txtHumedad.Text == "") { return false; }
            if (txtPatente.Text == "") { return false; }
            if (cmbProducto.SelectedText != "") { return false; }
            return true;
        }

        private void cmbProducto_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnNuevaTara_Click(object sender, EventArgs e)
        {
            Application.DoEvents();
            ClearAll();
            MODO = Modo.Nuevo;
            EnabledAllForm();
            lblRTara.Text = lblBascula.Text.Substring(1).Replace("\r\n", " ");
            lblRTara.Text = lblRTara.Text.Trim();
            btnSaveBruto.Visible = false;
            btnSaveBruto.Enabled = false;
            btnSaveTara.Enabled = true;
            btnSaveTara.Visible = true;
            grpBoxRegistro.Visible = true;
        }

        private void btnSaveTara_Click(object sender, EventArgs e)
        {
            if (CheckFields() == true)
            {
                if (MODO == Modo.Nuevo)
                {

                    Clases.MyItem MI = new Clases.MyItem(treeView1, txtPatente.Text, cmbProducto.Text);
                    
                    MI.setTara(int.Parse(lblRTara.Text));
                    SetAllData(MI);
                    MI.SelectedImageIndex = 0;
                    ClearAll();
                }
                else if (MODO == Modo.Modificar)
                {
                    if (treeView1.SelectedNode != null && treeView1.SelectedNode.Name.StartsWith("record") == true) 
                    {
                        Clases.MyItem MI = treeView1.SelectedNode as Clases.MyItem;
                        MI.setTara(int.Parse(lblBascula.Text.Substring(1)));
                        ClearAll();
                        grpBoxRegistro.Visible = false;

                    } 
                    
                }



            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Name.StartsWith("record") == true)
            {
                Clases.MyItem MI = e.Node as Clases.MyItem;
                Clases.Registro R = MI.REG;
                if (R != null)
                {
                    txtChofer.Text = R.Chofer;
                    txtCliente.Text = R.Cliente;
                    txtHumedad.Text = R.Humedad.ToString();
                    txtPatente.Text = R.Patente;
                    lblRBruto.Text = R.Peso.ToString();
                    lblRTara.Text = R.Tara.ToString();
                    btnSaveBruto.Visible = false;
                    btnSaveTara.Visible = false;
                    txtCliente.Enabled = false;
                    txtChofer.Enabled = false;
                    txtHumedad.Enabled = false;
                    txtPatente.Enabled = false;
                    cmbProducto.Enabled = false;




                    for (int a = 0; a < cmbProducto.Items.Count; a++)
                    {
                        if (int.Parse(cmbProducto.Items[a].ToString().Split(new string[] { "-" }, StringSplitOptions.None)[0]) == R.IdProducto)
                        {
                            cmbProducto.SelectedIndex = a;
                            break;
                        }
                    }
                    MODO = Modo.Modificar;
                    if (R.Peso == 0)
                    {
                        grpBoxRegistro.Visible = true;
                        btnSaveBruto.Visible = true;
                        btnSaveBruto.Enabled = true;

                    }
                    if (R.Tara == 0)
                    {
                        grpBoxRegistro.Visible = true;
                        btnSaveTara.Visible = true;
                        btnSaveTara.Enabled = true;
                    }
                }

            }
            else 
            {
                ClearAll();
                grpBoxRegistro.Visible = false;
            }
        }

      
       

       
    }
}
