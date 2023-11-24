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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void aBCEnvioFTPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 frm = new Form3();
            frm.Show();
        }

        private void menuPrincipalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 frm = new Form1();
            frm.Show();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void getdatos()
        {
            try
            {
                dataGridView1.DataSource = "";
                COBDDataContext a = new COBDDataContext();
                var buscar = from c in a.CtlCorreosFTP join r in a.FTP on c.IdFTP equals r.Id select c;
                DataTable dt = getDataTABLE();
                foreach (var item in buscar)
                {
                    DataRow Row1 = dt.NewRow();
                    Row1[0] = item.IdCorreoFTP;
                    Row1[1] = item.FTP.Id;
                    Row1[2] = item.FTP.Origen;
                    Row1[3] = item.FTP.Extensiones;
                    Row1[4] = item.Correo;
                    dt.Rows.Add(Row1);
                }
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                DialogResult result;
                result = MessageBox.Show(ex.Message, "Error de carga de datos");
            }
        }
        protected DataTable getDataTABLE()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("IdCorreoFTP");
            dt.Columns.Add("IdFTP");
            dt.Columns.Add("Origen");
            dt.Columns.Add("Extensiones");
            dt.Columns.Add("Correo");
            return dt;
        }

        private void getFTPS()
        {
            try
            {
                COBDDataContext a = new COBDDataContext();
                var buscar = from c in a.FTP select c;
                foreach (var item in buscar)
                {
                    cmbBoxLab.Items.Add(item.Id + "_" + item.Origen + "_" + item.Extensiones);
                }
            }
            catch (Exception ex)
            {
                DialogResult result;
                result = MessageBox.Show(ex.Message, "Error de carga de datos");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (lblID.Text == "-")
            {
                COBDDataContext a = new COBDDataContext();
                if (cmbBoxLab.SelectedIndex != -1)
                {
                    string idorigendatos = cmbBoxLab.SelectedItem.ToString();
                    string[] desgloce = idorigendatos.Split('_');

                    CtlCorreosFTP n = new CtlCorreosFTP();
                    n.IdFTP = Convert.ToInt32(desgloce[0].ToString());
                    n.Correo = txtCorreo.Text;
                    a.CtlCorreosFTP.InsertOnSubmit(n);
                    a.SubmitChanges();
                    limpiar();
                    getdatos();
                }
                else
                {
                    DialogResult result;
                    result = MessageBox.Show("No debe selecionar un registro del envio FTP", "Error en crear nuevo registro");
                }
            }
        }

        private void limpiar()
        {
            txtCorreo.Text = "";
            lblID.Text = "-";
            cmbBoxLab.SelectedIndex = -1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            COBDDataContext a = new COBDDataContext();
            if (lblID.Text != "-")
            {
                int id = Convert.ToInt32(lblID.Text);
                var buscar = from c in a.CtlCorreosFTP where c.IdCorreoFTP == id select c;
                if (txtCorreo.Text != "")
                {
                    buscar.First().Correo = txtCorreo.Text;
                    a.SubmitChanges();
                    limpiar();
                    getdatos();
                }
                else
                {
                    DialogResult result;
                    result = MessageBox.Show("Debe de llenar el dato del correo", "Error en actualizar registro");
                }
            }
            else
            {
                DialogResult result;
                result = MessageBox.Show("Debe de Selecionar un registro", "Error en actualizar registro");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (lblID.Text != "-")
            {
                COBDDataContext a = new COBDDataContext();
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;

                result = MessageBox.Show("¿ESTAS SEGURO QUE QUIERES BORRAR EL REGISTRO " + lblID.Text + "?", "ALERTA", buttons);
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    int id = Convert.ToInt32(lblID.Text);
                    var buscar = from c in a.CtlCorreosFTP where c.IdCorreoFTP == id select c;
                    a.CtlCorreosFTP.DeleteOnSubmit(buscar.First());
                    a.SubmitChanges();
                    limpiar();
                    getdatos();
                }
            }
            else
            {
                DialogResult result;
                result = MessageBox.Show("No esta selecionado un registro, favor de", "Error al guardar");
            }
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            getdatos();
            getFTPS();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                limpiar();
            }
            else
            {
                DataGridViewRow row = (DataGridViewRow)dataGridView1.Rows[e.RowIndex];
                if (row != null)
                {
                    limpiar();
                    if (row.Cells[0].Value != null)
                    {
                        lblID.Text = row.Cells[0].Value.ToString();
                    }
                    if (row.Cells[3].Value != null)
                        txtCorreo.Text = row.Cells[4].Value.ToString();

                }
            }
        }
    }
}
