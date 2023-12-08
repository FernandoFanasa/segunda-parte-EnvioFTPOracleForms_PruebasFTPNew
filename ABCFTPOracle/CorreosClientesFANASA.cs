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
    public partial class CorreosClientesFANASA : Form
    {
        public CorreosClientesFANASA()
        {
            InitializeComponent();
        }
        private void CorreosClientesFANASA_Load_1(object sender, EventArgs e)
        {
            getdatos();
            getFields();
        }

        private void getdatos()
        {
            try
            {
                dataGridViewCorreosClientes.DataSource = "";
                COBDDataContext a = new COBDDataContext();
                //var buscar = from c in a.CtlCorreosNew
                //             join r in a.OrigenDatosNew on c.IdOrigenDatosNew equals r.IdOrigenDatos
                //             select c;
                dataGridViewCorreosClientes.DataSource = from c in a.CtlCorreosClientesFANASA
                                                         join r in a.OrigenDatosClientesFANASA on c.IdOrigenDatosClientesFANASA equals r.idOrigenDatos
                                                         select new
                                                         {
                                                             IdCorreo = c.idCorreos,
                                                             IdOrigenDatos = c.IdOrigenDatosClientesFANASA,
                                                             field1 = c.IdOrigenDatosClientesFANASA,
                                                             field2 = c.IdOrigenDatosClientesFANASA,
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
                var buscar = from c in a.OrigenDatosClientesFANASA select c;
                foreach (var item in buscar)
                {
                    cmbBoxLab.Items.Add(item.idOrigenDatos + "_" + item.field1 + "_" + item.field2 + "_" + item.Extension);
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

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (lblID.Text == "-")
            {
                COBDDataContext a = new COBDDataContext();
                if (cmbBoxLab.SelectedIndex != -1)
                {
                    string idorigendatos = cmbBoxLab.SelectedItem.ToString();
                    string[] desgloce = idorigendatos.Split('_');

                    CtlCorreosClientesFANASA n = new CtlCorreosClientesFANASA();
                    n.IdOrigenDatosClientesFANASA = Convert.ToInt32(desgloce[0].ToString());
                    n.Correo = txtCorreo.Text;
                    a.CtlCorreosClientesFANASA.InsertOnSubmit(n);
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

        private void button1_Click_1(object sender, EventArgs e)
        {
            COBDDataContext a = new COBDDataContext();
            if (lblID.Text != "-")
            {
                int id = Convert.ToInt32(lblID.Text);
                var buscar = from c in a.CtlCorreosClientesFANASA where c.idCorreos == id select c;

                var bucarDato = (from c in a.CtlCorreosClientesFANASA where c.idCorreos == id select c).FirstOrDefault();

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

        private void button3_Click_1(object sender, EventArgs e)
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
                    var buscar = from c in a.CtlCorreosClientesFANASA where c.idCorreos == id select c;
                    a.CtlCorreosClientesFANASA.DeleteOnSubmit(buscar.First());
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

        private void dataGridViewCorreosClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                limpiar();
            }
            else
            {
                DataGridViewRow row = dataGridViewCorreosClientes.Rows[e.RowIndex];
                if (row != null)
                {
                    limpiar();
                    if (row.Cells["idCorreo"].Value != null)
                    {
                        lblID.Text = row.Cells["idCorreo"].Value.ToString();
                    }
                    if (row.Cells["Correo"].Value != null)
                        txtCorreo.Text = row.Cells["Correo"].Value.ToString();

                }
            }
        }

        private void envioClientesFANASAToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            ClientesFANASA carvaFANASA = new ClientesFANASA();
            carvaFANASA.Show();
        }

        private void menuPrincipalToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form1 = new Form1();
            form1.Show();
        }

        private void salirToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
