using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Balanza_Lite
{
    public partial class frmPassword : Form
    {
        bool cancel = true;
        public frmPassword()
        {
            InitializeComponent();
        }

        private void frmPassword_Load(object sender, EventArgs e)
        {
            
        }

        private void frmPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F12) 
            {
                this.Close();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F12)
            {
                cancel = false;
                this.Close();
                
            }

        }

        private void frmPassword_FormClosing(object sender, FormClosingEventArgs e)
        {

            e.Cancel = cancel;

        }
    }
}
