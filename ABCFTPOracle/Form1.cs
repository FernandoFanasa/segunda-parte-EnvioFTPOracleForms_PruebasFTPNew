using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ABCFTPOracle
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void oracleFTPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 frm = new Form2();
            frm.Show();
            this.Owner = frm;
        }

        private void fTPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 frm = new Form3();
            frm.Show();
            this.Owner = frm;
        }

        private void oracleFTPRenovadoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Hide();
            OracleRenovado formOracleRenovado = new OracleRenovado();
            formOracleRenovado.Show();
            this.Owner = formOracleRenovado;
        }

        private void depurarArchivosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            DepuracionArchivos formDepuracionFiles = new DepuracionArchivos();
            formDepuracionFiles.Show();
            this.Owner = formDepuracionFiles;
        }

        private void fTPBenavidesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Benavides formBenavides = new Benavides();
            formBenavides.Show();
            this.Owner = formBenavides;
        }

        private void etiquetasOracleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Etiquetas etiquetas = new Etiquetas();
            etiquetas.Show();
            this.Owner = etiquetas;
        }

        private void ateneaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Atenea atenea = new Atenea();
            atenea.Show();
            this.Owner = atenea;
        }

        private void carvajalFANASAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            CarvajalFANASA carvaFANASA = new CarvajalFANASA();
            carvaFANASA.Show();
            this.Owner = carvaFANASA;
        }

        private void carvajalFESAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            CarvajalFESA carvaFESA = new CarvajalFESA();
            carvaFESA.Show();
            this.Owner = carvaFESA;
        }

        private void clientesFANASAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            ClientesFANASA clientes = new ClientesFANASA();
            clientes.Show();
            this.Owner = clientes;
        }


    }
}
