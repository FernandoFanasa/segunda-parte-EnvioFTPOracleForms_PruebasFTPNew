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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void aBCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 frm = new Form2();
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

        private void Form4_Load(object sender, EventArgs e)
        {
            getdatos();
            getlaboratorios();
        }
        private void getdatos()
        {
            try
            {
                dataGridView1.DataSource = "";
                COBDDataContext a = new COBDDataContext();
                var buscar = from c in a.CtlCorreos join r in a.OrigenDatos on c.IdOrigenDatos equals r.IdOrigenDatos select c;
                DataTable dt = getDataTABLE();
                foreach (var item in buscar)
                {
                    DataRow Row1 = dt.NewRow();
                    Row1[0] = item.IdCorreos;
                    Row1[1] = item.IdOrigenDatos;
                    Row1[2] = item.OrigenDatos.IdLaboratorio;
                    Row1[3] = item.OrigenDatos.Tipo;
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
        private void getlaboratorios()
        {
            try
            {
                COBDDataContext a = new COBDDataContext();
                var buscar = from c in a.OrigenDatos select c;
                foreach (var item in buscar)
                {
                    cmbBoxLab.Items.Add(item.IdOrigenDatos + "_" + item.IdLaboratorio + "_" + item.Tipo + "_" + item.Extension);
                }
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
            dt.Columns.Add("IdCorreo");
            dt.Columns.Add("IdOrigenDatos");
            dt.Columns.Add("IdLaboratorio");
            dt.Columns.Add("Tipo");
            dt.Columns.Add("Correo");
            return dt;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(lblID.Text == "-")
            {
                COBDDataContext a = new COBDDataContext();
                if (cmbBoxLab.SelectedIndex != -1)
                {
                    string idorigendatos = cmbBoxLab.SelectedItem.ToString();
                    string[] desgloce = idorigendatos.Split('_');

                    CtlCorreos n = new CtlCorreos();
                    n.IdOrigenDatos = Convert.ToInt32(desgloce[0].ToString());
                    n.Correo = txtCorreo.Text;
                    a.CtlCorreos.InsertOnSubmit(n);
                    a.SubmitChanges();
                    limpiar();
                    getdatos();
                }
                else
                {
                    DialogResult result;
                    result = MessageBox.Show("Debe de selecionar una opcion de la lista de los envios FTP", "Error en crear nuevo registro");
                }
            }
            else
            {
                DialogResult result;
                result = MessageBox.Show("No debe selecionar un registro del envio FTP", "Error en crear nuevo registro");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            COBDDataContext a = new COBDDataContext();
            if (lblID.Text != "-")
            {
                int id = Convert.ToInt32(lblID.Text);
                var buscar = from c in a.CtlCorreos where c.IdCorreos == id select c;

                var buscarDato = (from c in a.CtlCorreos where c.IdCorreos == id select c).FirstOrDefault();


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
                    var buscar = from c in a.CtlCorreos where c.IdCorreos == id select c;
                    a.CtlCorreos.DeleteOnSubmit(buscar.First());
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
        private void limpiar()
        {
            txtCorreo.Text = "";
            lblID.Text = "-";
            cmbBoxLab.SelectedIndex = -1;
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
