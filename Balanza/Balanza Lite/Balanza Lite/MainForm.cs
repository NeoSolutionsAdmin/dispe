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

        public Boolean Sum = true;

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
            if (DateTime.Now.Day > 27 && DateTime.Now.Month > 11) 
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
            /*
            FileStream FS =  File.Create("d:\\BinaryRandom.bin");
            
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
            FS.Close();

    */

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
            grpCalculoBruto.Visible = true;
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
            txtPorcentajeBruto.Text = "0";
            RecalculoBruto();

            
        }

        void RecalculoBruto()
        {
            if (lblRBruto.Text == "") {
                lblRBruto.Text = lblBascula.Text.Substring(1).Replace("\r\n", " ");
                lblRBruto.Text = lblRBruto.Text.Trim();
                
            }
            string rs = RightSign();
            txtPorcentajeBruto.Text = txtPorcentajeBruto.Text.Replace(rs[0], rs[1]);
            txtPorcentajeBruto.Select(txtPorcentajeBruto.Text.Length, 0);
            if (txtPorcentajeBruto.Text != "")
            {
                try
                {
                    decimal PorcentajeBruto = decimal.Parse(txtPorcentajeBruto.Text);
                    decimal result = 0m;

                    
                        result = (decimal.Parse(lblRBruto.Text) * PorcentajeBruto) / 100;



                    if (Sum == true)
                    {

                        lblBrutoFinal.Text = (int.Parse(Math.Round(result, 0).ToString()) + int.Parse(lblRBruto.Text)).ToString();

                    }
                    else
                    {
                        lblBrutoFinal.Text =  (int.Parse(lblRBruto.Text) - int.Parse(Math.Round(result, 0).ToString())).ToString();
                    }

                } catch (Exception E)
                {
                    lblBrutoFinal.Text = "[Error]";
                }
            }

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
                    
                    MI.setBruto(int.Parse(lblBrutoFinal.Text));
                    SetAllData(MI);
                    MI.SelectedImageIndex = 0;
                    ClearAll();
                }
                else if (MODO == Modo.Modificar) 
                {
                    if (treeView1.SelectedNode != null && treeView1.SelectedNode.Name.StartsWith("record") == true)
                    {
                        Clases.MyItem MI = treeView1.SelectedNode as Clases.MyItem;
                        MI.setBruto(int.Parse(lblBrutoFinal.Text));
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
            grpCalculoBruto.Visible = false;
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
                        lblRBruto.Text = lblBascula.Text.Substring(1);
                        grpBoxRegistro.Visible = true;
                        btnSaveBruto.Visible = true;
                        btnSaveBruto.Enabled = true;
                        txtPorcentajeBruto.Text = "0";
                        grpCalculoBruto.Visible = true;
                        RecalculoBruto();


                    }
                    if (R.Tara == 0)
                    {
                        grpCalculoBruto.Visible = false;
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

        private void button4_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode != null)
            {
                if (treeView1.SelectedNode.Name.StartsWith("record") == true)
                {
                    MyItem T_MI = (MyItem) treeView1.SelectedNode;
                    Registro R = T_MI.REG;

                    string path_temp = Application.StartupPath;
                    string path_file = path_temp + "\\readme.html";
                    if (File.Exists(path_file) == true)
                    {
                        File.Delete(path_file);
                    }

                    while ( File.Exists(path_file)==true )
                    {
                    }

                    string htmlmatrix =
                        "<!DOCTYPE html> <html> <head>  </head>  <body style=\"border-style:solid; width: 400px\"> " + 
                        " [bodyfields] </body> </html>";
                    string htmlbodyfields = "<p style = \"font-size:40px;padding-left:125px\"><img src = \"./logomigul.jpg\\\"><br><span style = \"font-size:20px;line-height:10px;display:inline-block\"> COMPROBANTE DE CARGA </br> <span style=\"font-size:8px\"> [FechaYHora]</span></span></p><table style=\"margin-top:-30px\"> <tbody><tr style = \"font-size:15px\"> <td style = \"width:400px;border:solid;border-width:1px; border-color:black\"> Cliente: [Cliente] <br>Chofer: [Chofer] <br>Carga: [Carga] <br>Bruto: [Bruto] Kg.<br>Tara: [Tara] Kg.<br>Neto: [Neto] Kg.<br> </td> <td style = \"width:100px;border:solid;border-width:1px; border-color:black;text-align:center;vertical-align:top\"> Firma </td> </tr>  </tbody></table>";



                    
htmlmatrix = htmlmatrix.Replace("[bodyfields]", htmlbodyfields);
                    htmlmatrix = htmlmatrix.Replace("[FechaYHora]", R.FechaYHora.ToShortDateString() + " " + R.FechaYHora.ToShortTimeString());
                    htmlmatrix = htmlmatrix.Replace("[Cliente]", R.Cliente);
                    htmlmatrix = htmlmatrix.Replace("[Chofer]", R.Chofer);

                    Clases.BalanzaDataSetTableAdapters.ProductosTableAdapter TA = new Clases.BalanzaDataSetTableAdapters.ProductosTableAdapter();
                    string producto = TA.GetProductByID2(R.IdProducto).Rows[0]["Nombre"].ToString();
                    
                    htmlmatrix = htmlmatrix.Replace("[Carga]", producto);
                    htmlmatrix = htmlmatrix.Replace("[Bruto]", R.Peso.ToString());
                    htmlmatrix = htmlmatrix.Replace("[Tara]", R.Tara.ToString());
                    htmlmatrix = htmlmatrix.Replace("[Neto]", R.Neto.ToString());
                    FileStream FS = File.Create(path_file);
                    FS.Close();
                    File.WriteAllText(path_file, htmlmatrix);
                    System.Diagnostics.Process.Start("file:///" + path_file);

                }
            }
        }

        private string RightSign()
        {
            if (1.1f == float.Parse("1.1"))
            {
                return ",.";
            }
            else
            {
                return ".,";
            }
        }

        private void btnOperador_Click(object sender, EventArgs e)
        {
            if (Sum == true)
            {
                Sum = false;
                btnOperador.Text = "-";
                RecalculoBruto();

            }
            else
            {
                Sum = true;
                btnOperador.Text = "+";
                RecalculoBruto();
            }
        }

        private void txtPorcentajeBruto_TextChanged(object sender, EventArgs e)
        {
            RecalculoBruto();
        }
    }
}
