using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BoletoForm2
{
    public partial class frmMain : Form
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmMain());
        }

        public frmMain()
        {
            InitializeComponent();
        }

        private void btnBasico_Click(object sender, EventArgs e)
        {
            Form frm = new frmBasico();
            frm.ShowDialog();
        }

        private void btnCustom_Click(object sender, EventArgs e)
        {
            Form frm = new frmCustromizado();
            frm.ShowDialog();
        }

        private void btnCarne_Click(object sender, EventArgs e)
        {
            Form frm = new frmCarne();
            frm.ShowDialog();
        }

        private void btnRemessa_Click(object sender, EventArgs e)
        {
            Form frm = new frmRemessa();
            frm.ShowDialog();
        }

        private void btnRetorno_Click(object sender, EventArgs e)
        {
            Form frm = new frmRetorno();
            frm.ShowDialog();
        }
          
    }
}