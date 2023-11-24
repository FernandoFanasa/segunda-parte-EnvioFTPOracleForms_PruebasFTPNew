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
    public partial class Benavides : Form
    {
        public Benavides()
        {
            InitializeComponent();
        }

        private void getdatos()
        {
            try
            {
                dataGridViewBenavides.DataSource = "";
                COBDDataContext a = new COBDDataContext();
                //var buscar = from c in a.OrigenDatosFanasa select c;
                //dataGridViewOracle.DataSource = buscar;


                dataGridViewBenavides.DataSource = from c in a.OrigenDatosBenavides
                                                   join r in a.ConfiguracionOrigenBenavides on c.iRegistroConfigOrigen equals r.uiRegistroOrigen
                                                   select new
                                                   {
                                                       IdOrigenDatos = c.IdOrigenDatos,
                                                       Field1 = c.Field1,
                                                       Field2 = c.Field2,
                                                       Field3 = c.Field3,
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
                var buscar = from c in a.ConfiguracionOrigenBenavides select c;
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
            txtBxField3.Text = "";
            txtBxExt.Text = "";
            txtBxDestino.Text = "";
            comboBoxOrigen.SelectedIndex = -1;
        }

        private void Benavides_Load(object sender, EventArgs e)
        {
            getdatos();
            getOrigenes();
        }



        private void salisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void menúInicialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form1 = new Form1();
            form1.Show();
        }

        private void configuraciónOrigenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            OrigenBenavides origenBenavides = new OrigenBenavides();
            origenBenavides.Show();
        }

        private void correosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            CorreosBenavides correoBenavides = new CorreosBenavides();
            correoBenavides.Show();
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

                    OrigenDatosBenavides n = new OrigenDatosBenavides();
                    n.Field1 = txtBxField1.Text;
                    n.Field2 = txtBxField2.Text;
                    n.Field3 = txtBxField3.Text;
                    n.Extension = txtBxExt.Text;
                    n.Destino = txtBxDestino.Text;
                    a.OrigenDatosBenavides.InsertOnSubmit(n);
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
                var buscar = from c in a.OrigenDatosBenavides where c.IdOrigenDatos == id select c;

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


                if (txtBxField3.Text != "" || txtBxField3.Text == "")
                {
                    buscar.First().Field3 = txtBxField3.Text;
                }
                else
                {
                    buscar.First().Field3 = null;
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
                    var buscarcorreos = from c in a.CtlCorreosBenavides where c.IdOrigenDatosBenavides == id select c;
                    foreach (var item in buscarcorreos)
                    {
                        a.CtlCorreosBenavides.DeleteOnSubmit(item);
                        a.SubmitChanges();
                    }
                    var buscar = from c in a.OrigenDatosBenavides where c.IdOrigenDatos == id select c;
                    a.OrigenDatosBenavides.DeleteOnSubmit(buscar.First());
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
                DataGridViewRow row = (DataGridViewRow)dataGridViewBenavides.Rows[e.RowIndex];
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

                    if (row.Cells[3].Value != null)
                        txtBxField3.Text = row.Cells[3].Value.ToString();

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

