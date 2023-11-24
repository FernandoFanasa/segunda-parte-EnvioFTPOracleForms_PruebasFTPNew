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
    public partial class CorreosCarvajalFANASA : Form
    {
        public CorreosCarvajalFANASA()
        {
            InitializeComponent();
        }
        private void CorreosCarvajalFANASA_Load(object sender, EventArgs e)
        {
            getdatos();
            getFields();
        }

        private void getdatos()
        {
            try
            {
                dataGridViewCorreosCarvajal.DataSource = "";
                COBDDataContext a = new COBDDataContext();
                //var buscar = from c in a.CtlCorreosNew
                //             join r in a.OrigenDatosNew on c.IdOrigenDatosNew equals r.IdOrigenDatos
                //             select c;
                dataGridViewCorreosCarvajal.DataSource = from c in a.CtlCorreosCarvajalFANASA
                                           join r in a.OrigenDatosCarvajalFANASA on c.IdOrigenDatos equals r.IdOrigenDatos
                                           select new
                                           {
                                               IdCorreo = c.IdCorreos,
                                               IdOrigenDatos = c.IdOrigenDatos,
                                               Field1 = c.OrigenDatosCarvajalFANASA.Field1,
                                               Field2 = c.OrigenDatosCarvajalFANASA.Field2,
                                               Field3 = c.OrigenDatosCarvajalFANASA.Field3,
                                               Correo = c.Correo
                                           };
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
                var buscar = from c in a.OrigenDatosCarvajalFANASA select c;
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

        private void limpiar()
        {
            txtCorreo.Text = "";
            lblID.Text = "-";
            cmbBoxLab.SelectedIndex = -1;
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

                    CtlCorreosCarvajalFANASA n = new CtlCorreosCarvajalFANASA();
                    n.IdOrigenDatos = Convert.ToInt32(desgloce[0].ToString());
                    n.Correo = txtCorreo.Text;
                    a.CtlCorreosCarvajalFANASA.InsertOnSubmit(n);
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
                var buscar = from c in a.CtlCorreosCarvajalFANASA where c.IdCorreos == id select c;

                var bucarDato = (from c in a.CtlCorreosCarvajalFANASA where c.IdCorreos == id select c).FirstOrDefault();

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
                    var buscar = from c in a.CtlCorreosCarvajalFANASA where c.IdCorreos == id select c;
                    a.CtlCorreosCarvajalFANASA.DeleteOnSubmit(buscar.First());
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

        private void dataGridViewCorreosCarvajal_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                limpiar();
            }
            else
            {
                DataGridViewRow row = dataGridViewCorreosCarvajal.Rows[e.RowIndex];
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

        private void envioCarvajalFANASAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            CarvajalFANASA carvaFANASA = new CarvajalFANASA();
            carvaFANASA.Show();
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
    }
}
