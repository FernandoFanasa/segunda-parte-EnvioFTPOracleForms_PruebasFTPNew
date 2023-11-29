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
    public partial class ClientesFANASA : Form
    {
        public ClientesFANASA()
        {
            InitializeComponent();
        }
        private void getdatos()
        {
            try
            {
                dataGridViewClientesFANASA.DataSource = "";
                COBDDataContext a = new COBDDataContext();


                dataGridViewClientesFANASA.DataSource = from c in a.OrigenDatosBenavides
                                                   join r in a.ConfiguracionOrigenBenavides on c.iRegistroConfigOrigen equals r.uiRegistroOrigen
                                                   select new
                                                   {
                                                       IdOrigenDatos = c.IdOrigenDatos,
                                                       Field1 = c.Field1,
                                                       Field2 = c.Field2,
                                                       Extensión = c.Extension,
                                                       Destino = c.Destino,
                                                       RegistroOrigen = c.iRegistroConfigOrigen,
                                                       Origen = r.sOrigen
                                                   };
            }
            catch (Exception ex)
            {
                DialogResult result;
                result = MessageBox.Show(ex.Message, "Error de carga de datos");
            }
        }

        private void getOrigenes()
        {
            try
            {
                COBDDataContext a = new COBDDataContext();
                var buscar = from c in a.ConfiguracionOrigenClientesFANASA select c;
                foreach (var item in buscar)
                {
                    comboBoxOrigen.Items.Add(item.uiRegistroOrigen + "_" + item.sOrigen);
                }
            }
            catch (Exception ex)
            {
                DialogResult result;
                result = MessageBox.Show(ex.Message, "Error de carga de datos");
                throw;
            }
        }


        private void limpiar()
        {
            lblID.Text = "-";
            txtBxField1.Text = "";
            txtBxField2.Text = "";
            txtBxExt.Text = "";
            txtBxDestino.Text = "";
            comboBoxOrigen.SelectedIndex = -1;
        }


        private void ClientesFANASA_Load(object sender, EventArgs e)
        {
            getdatos();
            getOrigenes();
        }

        private void menúInicialToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form1 = new Form1();
            form1.Show();
        }

        private void salisToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (lblID.Text == "-")
            {
                if (txtBxDestino.Text != "" || comboBoxOrigen.SelectedIndex != -1)
                {
                    COBDDataContext a = new COBDDataContext();

                    string idConfiguracionOrigen = comboBoxOrigen.SelectedItem.ToString();
                    string[] idCofig = idConfiguracionOrigen.Split('_');

                    OrigenDatosClientesFANASA n = new OrigenDatosClientesFANASA();
                    n.Field1 = txtBxField1.Text;
                    n.Field2 = txtBxField2.Text;
                    n.Extension = txtBxExt.Text;
                    n.Destino = txtBxDestino.Text;
                    a.OrigenDatosClientesFANASA.InsertOnSubmit(n);
                    n.iRegistroConfigOrigen = Convert.ToInt32(idCofig[0].ToString());
                    a.SubmitChanges();
                    limpiar();
                    getdatos();

                }
                else
                {
                    DialogResult result;
                    result = MessageBox.Show("Debe de llenar todos los datos de configuracion FTP", "Error al guardar");
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            COBDDataContext a = new COBDDataContext();

            if (lblID.Text != "-")
            {
                int id = Convert.ToInt32(lblID.Text);
                var buscar = from c in a.OrigenDatosClientesFANASA where c.IdOrigenDatos == id select c;

                if (txtBxField1.Text != "")
                {
                    buscar.First().Field1 = txtBxField1.Text;
                }
                else
                {
                    buscar.First().Field1 = null;
                }


                if (txtBxField2.Text != "" || txtBxField2.Text == "")
                {
                    buscar.First().Field2 = txtBxField2.Text;
                }
                else
                {
                    buscar.First().Field2 = null;
                }

                if (txtBxExt.Text != "")
                {
                    buscar.First().Extension = txtBxExt.Text;
                }
                else
                {
                    buscar.First().Extension = null;
                }
                if (txtBxDestino.Text != "")
                {
                    buscar.First().Destino = txtBxDestino.Text;
                }
                else
                {
                    buscar.First().Destino = null;
                }

                if (comboBoxOrigen.SelectedIndex == -1)
                {
                    buscar.First().iRegistroConfigOrigen = null;
                }
                else
                {
                    string idConfiguracionOrigen = comboBoxOrigen.SelectedItem.ToString();
                    string[] idCofig = idConfiguracionOrigen.Split('_');

                    buscar.First().iRegistroConfigOrigen = Convert.ToInt32(idCofig[0].ToString());
                }

                a.SubmitChanges();
                limpiar();
                getdatos();
            }
            else
            {
                DialogResult result;
                result = MessageBox.Show("Debe de selecionar un registro", "Error al actualizar");
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
                    var buscarcorreos = from c in a.CtlCorreosClientesFANASA where c.IdOrigenDatosClientesFANASA == id select c;
                    foreach (var item in buscarcorreos)
                    {
                        a.CtlCorreosClientesFANASA.DeleteOnSubmit(item);
                        a.SubmitChanges();
                    }
                    var buscar = from c in a.OrigenDatosClientesFANASA where c.IdOrigenDatos == id select c;
                    a.OrigenDatosClientesFANASA.DeleteOnSubmit(buscar.First());
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

        private void dataGridViewBenavides_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                limpiar();
            }

            else
            {
                DataGridViewRow row = (DataGridViewRow)dataGridViewClientesFANASA.Rows[e.RowIndex];
                if (row != null)
                {
                    limpiar();
                    if (row.Cells[0].Value != null)
                    {
                        lblID.Text = row.Cells[0].Value.ToString();
                    }
                    if (row.Cells[1].Value != null)
                        txtBxField1.Text = row.Cells[1].Value.ToString();

                    if (row.Cells[2].Value != null)
                        txtBxField2.Text = row.Cells[2].Value.ToString();


                    if (row.Cells[4].Value != null)
                        txtBxExt.Text = row.Cells[4].Value.ToString();

                    if (row.Cells[5].Value != null)
                        txtBxDestino.Text = row.Cells[5].Value.ToString();

                    if (row.Cells[6].Value != null)
                    {
                        comboBoxOrigen.Text = row.Cells[6].Value.ToString() + "_" + row.Cells[7].Value.ToString();
                    }
                }
            }
        }



    }
}
