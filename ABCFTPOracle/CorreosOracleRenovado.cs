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
    public partial class CorreosOracleRenovado : Form
    {
        public CorreosOracleRenovado()
        {
            InitializeComponent();
        }

        private void envioFTPOracleRenovadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            OracleRenovado formOracleRenovado = new OracleRenovado();
            formOracleRenovado.Show();
        }

        private void menuPrincipalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form1 = new Form1();
            form1.Show();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CorreosOracleRenovado_Load(object sender, EventArgs e)
        {
            getdatos();
            getFields();
        }

        private void getdatos()
        {
            try
            {
                dataGridView1.DataSource = "";
                COBDDataContext a = new COBDDataContext();
                //var buscar = from c in a.CtlCorreosNew
                //             join r in a.OrigenDatosNew on c.IdOrigenDatosNew equals r.IdOrigenDatos
                //             select c;
                dataGridView1.DataSource = from c in a.CtlCorreosFanasa
                                           join r in a.OrigenDatosFanasa on c.IdOrigenDatosFanasa equals r.IdOrigenDatos
                                           select new
                                           {
                                               IdCorreo = c.IdCorreos,
                                               IdOrigenDatosNew = c.IdOrigenDatosFanasa,
                                               Field1 = c.OrigenDatosFanasa.Field1,
                                               Field2 = c.OrigenDatosFanasa.Field2,
                                               Field3 = c.OrigenDatosFanasa.Field3,
                                               Correo = c.Correo
                                           };
                //DataTable dt = getDataTABLE();
                //foreach (var item in buscar)
                //{
                //    DataRow Row1 = dt.NewRow();
                //    Row1[0] = item.IdCorreos;
                //    Row1[1] = item.IdOrigenDatosNew;
                //    Row1[2] = item.OrigenDatosNew.Field1;
                //    Row1[3] = item.OrigenDatosNew.Field2;
                //    Row1[4] = item.OrigenDatosNew.Field3;
                //    Row1[5] = item.Correo;
                //    dt.Rows.Add(Row1);
                //}
                //dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                DialogResult result;
                result = MessageBox.Show(ex.Message, "Error de carga de datos");
            }
        }

        private void getFields()
        {
            try
            {
                COBDDataContext a = new COBDDataContext();
                var buscar = from c in a.OrigenDatosFanasa select c;
                foreach (var item in buscar)
                {
                    cmbBoxLab.Items.Add(item.IdOrigenDatos + "_" + item.Field1 + "_" + item.Field2 + "_" + item.Field3 + "_" + item.Extension);
                }
            }
            catch (Exception ex)
            {
                DialogResult result;
                result = MessageBox.Show(ex.Message, "Error de carga de datos");
            }
        }

        //protected DataTable getDataTABLE()
        //{
        //    DataTable dt = new DataTable();
        //    dt.Columns.Add("IdCorreo");
        //    dt.Columns.Add("IdOrigenDatos");
        //    dt.Columns.Add("Field 1");
        //    dt.Columns.Add("Field 2");
        //    dt.Columns.Add("Field 3");
        //    dt.Columns.Add("Correo");
        //    return dt;
        //}

        private void button2_Click(object sender, EventArgs e)
        {
            if (lblID.Text == "-")
            {
                COBDDataContext a = new COBDDataContext();
                if (cmbBoxLab.SelectedIndex != -1)
                {
                    string idorigendatos = cmbBoxLab.SelectedItem.ToString();
                    string[] desgloce = idorigendatos.Split('_');

                    CtlCorreosFanasa n = new CtlCorreosFanasa();
                    n.IdOrigenDatosFanasa = Convert.ToInt32(desgloce[0].ToString());
                    n.Correo = txtCorreo.Text;
                    a.CtlCorreosFanasa.InsertOnSubmit(n);
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
                var buscar = from c in a.CtlCorreosFanasa where c.IdCorreos == id select c;

                var bucarDato = (from c in a.CtlCorreosFanasa where c.IdCorreos == id select c).FirstOrDefault();

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
                    var buscar = from c in a.CtlCorreosFanasa where c.IdCorreos == id select c;
                    a.CtlCorreosFanasa.DeleteOnSubmit(buscar.First());
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                limpiar();
            }
            else
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                if (row != null)
                {
                    limpiar();
                    if (row.Cells["IdCorreo"].Value != null)
                    {
                        lblID.Text = row.Cells["IdCorreo"].Value.ToString();
                    }
                    if (row.Cells["Correo"].Value != null)
                        txtCorreo.Text = row.Cells["Correo"].Value.ToString();

                }
            }
        }
    }
}
