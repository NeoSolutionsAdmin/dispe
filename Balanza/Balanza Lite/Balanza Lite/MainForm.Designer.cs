namespace Balanza_Lite
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblBascula = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbPort = new System.Windows.Forms.ComboBox();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.grpBoxRegistro = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblRNeto = new System.Windows.Forms.Label();
            this.lblRTara = new System.Windows.Forms.Label();
            this.lblRBruto = new System.Windows.Forms.Label();
            this.btnSaveTara = new System.Windows.Forms.Button();
            this.btnSaveBruto = new System.Windows.Forms.Button();
            this.txtChofer = new System.Windows.Forms.TextBox();
            this.lblChofer = new System.Windows.Forms.Label();
            this.txtHumedad = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblNeto = new System.Windows.Forms.Label();
            this.lblTara = new System.Windows.Forms.Label();
            this.lblBruto = new System.Windows.Forms.Label();
            this.txtPatente = new System.Windows.Forms.TextBox();
            this.lblPatente = new System.Windows.Forms.Label();
            this.cmbProducto = new System.Windows.Forms.ComboBox();
            this.lblProducto = new System.Windows.Forms.Label();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.lblCliente = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnNuevaTara = new System.Windows.Forms.Button();
            this.btnNuevoPeso = new System.Windows.Forms.Button();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.btnOperador = new System.Windows.Forms.Button();
            this.txtPorcentajeBruto = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblKG = new System.Windows.Forms.Label();
            this.grpCalculoBruto = new System.Windows.Forms.GroupBox();
            this.lblBrutoFinal = new System.Windows.Forms.Label();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.grpBoxRegistro.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.grpCalculoBruto.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.button4);
            this.splitContainer1.Panel1.Controls.Add(this.button3);
            this.splitContainer1.Panel1.Controls.Add(this.button2);
            this.splitContainer1.Panel1.Controls.Add(this.button1);
            this.splitContainer1.Panel1.Controls.Add(this.pictureBox1);
            this.splitContainer1.Panel1.Controls.Add(this.lblBascula);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.cmbPort);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(644, 500);
            this.splitContainer1.SplitterDistance = 146;
            this.splitContainer1.TabIndex = 0;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(390, 93);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(121, 38);
            this.button4.TabIndex = 7;
            this.button4.Text = "Imprimir movimiento seleccionado";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Enabled = false;
            this.button3.Location = new System.Drawing.Point(517, 49);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(121, 38);
            this.button3.TabIndex = 6;
            this.button3.Text = "Notas y Alarmas";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Enabled = false;
            this.button2.Location = new System.Drawing.Point(517, 93);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(121, 38);
            this.button2.TabIndex = 5;
            this.button2.Text = "Control De Barreras";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(390, 49);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(121, 38);
            this.button1.TabIndex = 4;
            this.button1.Text = "Control De Producción";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Balanza_Lite.Properties.Resources.bascula;
            this.pictureBox1.Location = new System.Drawing.Point(13, 35);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 65);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // lblBascula
            // 
            this.lblBascula.AutoSize = true;
            this.lblBascula.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBascula.Location = new System.Drawing.Point(119, 54);
            this.lblBascula.Name = "lblBascula";
            this.lblBascula.Size = new System.Drawing.Size(99, 33);
            this.lblBascula.TabIndex = 0;
            this.lblBascula.Text = "label1";
            this.lblBascula.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(508, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Puerto de lectura";
            // 
            // cmbPort
            // 
            this.cmbPort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbPort.FormattingEnabled = true;
            this.cmbPort.Items.AddRange(new object[] {
            "COM1",
            "COM2",
            "COM3",
            "COM4",
            "COM5",
            "COM6",
            "COM7",
            "COM8",
            "COM9",
            "COM10"});
            this.cmbPort.Location = new System.Drawing.Point(511, 22);
            this.cmbPort.Name = "cmbPort";
            this.cmbPort.Size = new System.Drawing.Size(121, 21);
            this.cmbPort.TabIndex = 1;
            this.cmbPort.SelectedIndexChanged += new System.EventHandler(this.cmbPort_SelectedIndexChanged);
            // 
            // splitContainer2
            // 
            this.splitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.grpBoxRegistro);
            this.splitContainer2.Panel1.Controls.Add(this.btnNuevaTara);
            this.splitContainer2.Panel1.Controls.Add(this.btnNuevoPeso);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.treeView1);
            this.splitContainer2.Size = new System.Drawing.Size(644, 350);
            this.splitContainer2.SplitterDistance = 403;
            this.splitContainer2.TabIndex = 2;
            // 
            // grpBoxRegistro
            // 
            this.grpBoxRegistro.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpBoxRegistro.Controls.Add(this.grpCalculoBruto);
            this.grpBoxRegistro.Controls.Add(this.label6);
            this.grpBoxRegistro.Controls.Add(this.label5);
            this.grpBoxRegistro.Controls.Add(this.label4);
            this.grpBoxRegistro.Controls.Add(this.label1);
            this.grpBoxRegistro.Controls.Add(this.lblRNeto);
            this.grpBoxRegistro.Controls.Add(this.lblRTara);
            this.grpBoxRegistro.Controls.Add(this.lblRBruto);
            this.grpBoxRegistro.Controls.Add(this.btnSaveTara);
            this.grpBoxRegistro.Controls.Add(this.btnSaveBruto);
            this.grpBoxRegistro.Controls.Add(this.txtChofer);
            this.grpBoxRegistro.Controls.Add(this.lblChofer);
            this.grpBoxRegistro.Controls.Add(this.txtHumedad);
            this.grpBoxRegistro.Controls.Add(this.label3);
            this.grpBoxRegistro.Controls.Add(this.lblNeto);
            this.grpBoxRegistro.Controls.Add(this.lblTara);
            this.grpBoxRegistro.Controls.Add(this.lblBruto);
            this.grpBoxRegistro.Controls.Add(this.txtPatente);
            this.grpBoxRegistro.Controls.Add(this.lblPatente);
            this.grpBoxRegistro.Controls.Add(this.cmbProducto);
            this.grpBoxRegistro.Controls.Add(this.lblProducto);
            this.grpBoxRegistro.Controls.Add(this.txtCliente);
            this.grpBoxRegistro.Controls.Add(this.lblCliente);
            this.grpBoxRegistro.Controls.Add(this.pictureBox2);
            this.grpBoxRegistro.Location = new System.Drawing.Point(3, 32);
            this.grpBoxRegistro.Name = "grpBoxRegistro";
            this.grpBoxRegistro.Size = new System.Drawing.Size(395, 305);
            this.grpBoxRegistro.TabIndex = 2;
            this.grpBoxRegistro.TabStop = false;
            this.grpBoxRegistro.Text = "PANEL DE REGISTRO";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(94, 123);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(15, 13);
            this.label6.TabIndex = 22;
            this.label6.Text = "%";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(223, 252);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(22, 13);
            this.label5.TabIndex = 21;
            this.label5.Text = "kg.";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(223, 212);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(22, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "kg.";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(223, 170);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "kg.";
            // 
            // lblRNeto
            // 
            this.lblRNeto.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRNeto.Location = new System.Drawing.Point(124, 247);
            this.lblRNeto.Name = "lblRNeto";
            this.lblRNeto.Size = new System.Drawing.Size(93, 20);
            this.lblRNeto.TabIndex = 18;
            this.lblRNeto.Text = "0";
            this.lblRNeto.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblRTara
            // 
            this.lblRTara.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRTara.Location = new System.Drawing.Point(124, 207);
            this.lblRTara.Name = "lblRTara";
            this.lblRTara.Size = new System.Drawing.Size(93, 20);
            this.lblRTara.TabIndex = 17;
            this.lblRTara.Text = "0";
            this.lblRTara.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblRBruto
            // 
            this.lblRBruto.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRBruto.Location = new System.Drawing.Point(124, 165);
            this.lblRBruto.Name = "lblRBruto";
            this.lblRBruto.Size = new System.Drawing.Size(93, 20);
            this.lblRBruto.TabIndex = 16;
            this.lblRBruto.Text = "0";
            this.lblRBruto.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnSaveTara
            // 
            this.btnSaveTara.BackgroundImage = global::Balanza_Lite.Properties.Resources.Save;
            this.btnSaveTara.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSaveTara.Enabled = false;
            this.btnSaveTara.Location = new System.Drawing.Point(3, 202);
            this.btnSaveTara.Name = "btnSaveTara";
            this.btnSaveTara.Size = new System.Drawing.Size(32, 32);
            this.btnSaveTara.TabIndex = 15;
            this.btnSaveTara.UseVisualStyleBackColor = true;
            this.btnSaveTara.Visible = false;
            this.btnSaveTara.Click += new System.EventHandler(this.btnSaveTara_Click);
            // 
            // btnSaveBruto
            // 
            this.btnSaveBruto.BackgroundImage = global::Balanza_Lite.Properties.Resources.Save;
            this.btnSaveBruto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSaveBruto.Enabled = false;
            this.btnSaveBruto.Location = new System.Drawing.Point(3, 160);
            this.btnSaveBruto.Name = "btnSaveBruto";
            this.btnSaveBruto.Size = new System.Drawing.Size(32, 32);
            this.btnSaveBruto.TabIndex = 14;
            this.btnSaveBruto.UseVisualStyleBackColor = true;
            this.btnSaveBruto.Visible = false;
            this.btnSaveBruto.Click += new System.EventHandler(this.btnSaveBruto_Click);
            // 
            // txtChofer
            // 
            this.txtChofer.Location = new System.Drawing.Point(163, 120);
            this.txtChofer.Name = "txtChofer";
            this.txtChofer.Size = new System.Drawing.Size(178, 20);
            this.txtChofer.TabIndex = 13;
            // 
            // lblChofer
            // 
            this.lblChofer.AutoSize = true;
            this.lblChofer.Location = new System.Drawing.Point(125, 123);
            this.lblChofer.Name = "lblChofer";
            this.lblChofer.Size = new System.Drawing.Size(41, 13);
            this.lblChofer.TabIndex = 12;
            this.lblChofer.Text = "Chofer:";
            // 
            // txtHumedad
            // 
            this.txtHumedad.Location = new System.Drawing.Point(58, 120);
            this.txtHumedad.Name = "txtHumedad";
            this.txtHumedad.Size = new System.Drawing.Size(30, 20);
            this.txtHumedad.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 123);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Humedad:";
            // 
            // lblNeto
            // 
            this.lblNeto.AutoSize = true;
            this.lblNeto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNeto.Location = new System.Drawing.Point(41, 247);
            this.lblNeto.Name = "lblNeto";
            this.lblNeto.Size = new System.Drawing.Size(61, 20);
            this.lblNeto.TabIndex = 9;
            this.lblNeto.Text = "NETO:";
            // 
            // lblTara
            // 
            this.lblTara.AutoSize = true;
            this.lblTara.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTara.Location = new System.Drawing.Point(41, 207);
            this.lblTara.Name = "lblTara";
            this.lblTara.Size = new System.Drawing.Size(61, 20);
            this.lblTara.TabIndex = 8;
            this.lblTara.Text = "TARA:";
            // 
            // lblBruto
            // 
            this.lblBruto.AutoSize = true;
            this.lblBruto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBruto.Location = new System.Drawing.Point(41, 165);
            this.lblBruto.Name = "lblBruto";
            this.lblBruto.Size = new System.Drawing.Size(75, 20);
            this.lblBruto.TabIndex = 7;
            this.lblBruto.Text = "BRUTO:";
            // 
            // txtPatente
            // 
            this.txtPatente.Location = new System.Drawing.Point(229, 69);
            this.txtPatente.Name = "txtPatente";
            this.txtPatente.Size = new System.Drawing.Size(112, 20);
            this.txtPatente.TabIndex = 6;
            // 
            // lblPatente
            // 
            this.lblPatente.AutoSize = true;
            this.lblPatente.Location = new System.Drawing.Point(177, 72);
            this.lblPatente.Name = "lblPatente";
            this.lblPatente.Size = new System.Drawing.Size(47, 13);
            this.lblPatente.TabIndex = 5;
            this.lblPatente.Text = "Patente:";
            // 
            // cmbProducto
            // 
            this.cmbProducto.FormattingEnabled = true;
            this.cmbProducto.Location = new System.Drawing.Point(229, 42);
            this.cmbProducto.Name = "cmbProducto";
            this.cmbProducto.Size = new System.Drawing.Size(112, 21);
            this.cmbProducto.TabIndex = 4;
            this.cmbProducto.SelectedIndexChanged += new System.EventHandler(this.cmbProducto_SelectedIndexChanged);
            // 
            // lblProducto
            // 
            this.lblProducto.AutoSize = true;
            this.lblProducto.Location = new System.Drawing.Point(177, 45);
            this.lblProducto.Name = "lblProducto";
            this.lblProducto.Size = new System.Drawing.Size(53, 13);
            this.lblProducto.TabIndex = 3;
            this.lblProducto.Text = "Producto:";
            // 
            // txtCliente
            // 
            this.txtCliente.Location = new System.Drawing.Point(229, 16);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.Size = new System.Drawing.Size(112, 20);
            this.txtCliente.TabIndex = 2;
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Location = new System.Drawing.Point(177, 19);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(42, 13);
            this.lblCliente.TabIndex = 1;
            this.lblCliente.Text = "Cliente:";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Balanza_Lite.Properties.Resources.truck;
            this.pictureBox2.Location = new System.Drawing.Point(6, 19);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(164, 92);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            // 
            // btnNuevaTara
            // 
            this.btnNuevaTara.Location = new System.Drawing.Point(137, 2);
            this.btnNuevaTara.Name = "btnNuevaTara";
            this.btnNuevaTara.Size = new System.Drawing.Size(109, 23);
            this.btnNuevaTara.TabIndex = 1;
            this.btnNuevaTara.Text = "Nueva Tara";
            this.btnNuevaTara.UseVisualStyleBackColor = true;
            this.btnNuevaTara.Click += new System.EventHandler(this.btnNuevaTara_Click);
            // 
            // btnNuevoPeso
            // 
            this.btnNuevoPeso.Location = new System.Drawing.Point(3, 3);
            this.btnNuevoPeso.Name = "btnNuevoPeso";
            this.btnNuevoPeso.Size = new System.Drawing.Size(128, 23);
            this.btnNuevoPeso.TabIndex = 0;
            this.btnNuevoPeso.Text = "Nuevo Bruto";
            this.btnNuevoPeso.UseVisualStyleBackColor = true;
            this.btnNuevoPeso.Click += new System.EventHandler(this.btnNuevoPeso_Click);
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(235, 348);
            this.treeView1.TabIndex = 0;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // btnOperador
            // 
            this.btnOperador.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOperador.Location = new System.Drawing.Point(3, 16);
            this.btnOperador.Margin = new System.Windows.Forms.Padding(0);
            this.btnOperador.Name = "btnOperador";
            this.btnOperador.Size = new System.Drawing.Size(32, 27);
            this.btnOperador.TabIndex = 23;
            this.btnOperador.Text = "+";
            this.btnOperador.UseVisualStyleBackColor = true;
            this.btnOperador.Click += new System.EventHandler(this.btnOperador_Click);
            // 
            // txtPorcentajeBruto
            // 
            this.txtPorcentajeBruto.Location = new System.Drawing.Point(38, 19);
            this.txtPorcentajeBruto.Name = "txtPorcentajeBruto";
            this.txtPorcentajeBruto.Size = new System.Drawing.Size(47, 20);
            this.txtPorcentajeBruto.TabIndex = 24;
            this.txtPorcentajeBruto.Text = "0";
            this.txtPorcentajeBruto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPorcentajeBruto.TextChanged += new System.EventHandler(this.txtPorcentajeBruto_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(91, 24);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(15, 13);
            this.label7.TabIndex = 25;
            this.label7.Text = "%";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 51);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 13);
            this.label8.TabIndex = 26;
            this.label8.Text = "Nuevo Bruto:";
            // 
            // lblKG
            // 
            this.lblKG.AutoSize = true;
            this.lblKG.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKG.Location = new System.Drawing.Point(91, 77);
            this.lblKG.Name = "lblKG";
            this.lblKG.Size = new System.Drawing.Size(26, 13);
            this.lblKG.TabIndex = 27;
            this.lblKG.Text = "Kg.";
            // 
            // grpCalculoBruto
            // 
            this.grpCalculoBruto.Controls.Add(this.lblBrutoFinal);
            this.grpCalculoBruto.Controls.Add(this.lblKG);
            this.grpCalculoBruto.Controls.Add(this.label7);
            this.grpCalculoBruto.Controls.Add(this.btnOperador);
            this.grpCalculoBruto.Controls.Add(this.label8);
            this.grpCalculoBruto.Controls.Add(this.txtPorcentajeBruto);
            this.grpCalculoBruto.Location = new System.Drawing.Point(251, 170);
            this.grpCalculoBruto.Name = "grpCalculoBruto";
            this.grpCalculoBruto.Size = new System.Drawing.Size(138, 100);
            this.grpCalculoBruto.TabIndex = 26;
            this.grpCalculoBruto.TabStop = false;
            this.grpCalculoBruto.Text = "Bruto Final";
            // 
            // lblBrutoFinal
            // 
            this.lblBrutoFinal.AutoSize = true;
            this.lblBrutoFinal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBrutoFinal.Location = new System.Drawing.Point(8, 77);
            this.lblBrutoFinal.Name = "lblBrutoFinal";
            this.lblBrutoFinal.Size = new System.Drawing.Size(77, 13);
            this.lblBrutoFinal.TabIndex = 28;
            this.lblBrutoFinal.Text = "0000000000";
            this.lblBrutoFinal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(644, 500);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "MainForm";
            this.Text = "Balanza Lite -- Registrado a nombre de Migul";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            this.grpBoxRegistro.ResumeLayout(false);
            this.grpBoxRegistro.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.grpCalculoBruto.ResumeLayout(false);
            this.grpCalculoBruto.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btnNuevoPeso;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Button btnNuevaTara;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.GroupBox grpBoxRegistro;
        private System.Windows.Forms.Label lblBascula;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbPort;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TextBox txtPatente;
        private System.Windows.Forms.Label lblPatente;
        private System.Windows.Forms.ComboBox cmbProducto;
        private System.Windows.Forms.Label lblProducto;
        private System.Windows.Forms.TextBox txtCliente;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.Label lblNeto;
        private System.Windows.Forms.Label lblTara;
        private System.Windows.Forms.Label lblBruto;
        private System.Windows.Forms.TextBox txtChofer;
        private System.Windows.Forms.Label lblChofer;
        private System.Windows.Forms.TextBox txtHumedad;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSaveBruto;
        private System.Windows.Forms.Label lblRNeto;
        private System.Windows.Forms.Label lblRTara;
        private System.Windows.Forms.Label lblRBruto;
        private System.Windows.Forms.Button btnSaveTara;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button btnOperador;
        private System.Windows.Forms.GroupBox grpCalculoBruto;
        private System.Windows.Forms.Label lblBrutoFinal;
        private System.Windows.Forms.Label lblKG;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtPorcentajeBruto;
    }
}

