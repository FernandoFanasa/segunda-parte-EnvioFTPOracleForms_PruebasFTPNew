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

        private void ClientesFANSA_Load(object sender, EventArgs e)
        {
            getdatos();
            getOrigenes();
        }

        private void getdatos()
        {
            try
            {
                dataGridViewClientesFANASA.DataSource = "";
                COBDDataContext a = new COBDDataContext();
                var buscar = from c in a.OrigenDatosClientesFANASA select c;
                //dataGridViewOracle.DataSource = buscar;


                dataGridViewClientesFANASA.DataSource = from c in a.OrigenDatosClientesFANASA
                                                 join r in a.ConfiguracionOrigenClientesFANASA on c.iRegistroConfigOrigen equals r.uiRegistroOrigen
                                                 select new
                                                 {
                                                     IdOrigenDatos = c.idOrigenDatos,
                                                     Field1 = c.field1,
                                                     Field2 = c.field2,
                                                     Extensión = c.Extension,
                                                     Destino = c.Destino,
                                                     DestinoRespaldo = c.DestinoRespaldo,
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
            lblID2.Text = "-";
            txtBxField1.Text = "";
            txtBxField2.Text = "";
            txtBxExt.Text = "";
            txtBxDestino.Text = "";
            txtBxDestinoRespaldo.Text = "";
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

        private void origenFANASAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            OrigenClientesFANASA OrigenClientesFANASA = new OrigenClientesFANASA();
            OrigenClientesFANASA.Show();
        }
        private void correosClientesFANASAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            CorreosClientesFANASA correosFANASA = new CorreosClientesFANASA();
            correosFANASA.Show();
        }
        private void salisToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
        private void button2_Click_1(object sender, EventArgs e)
        {
            if (lblID2.Text == "-")
            {
                if (txtBxField1.Text != "" && txtBxExt.Text != "" /*&& comboBoxOrigen.SelectedIndex != -1*/)
                {
                    if (txtBxDestino.Text != "" || txtBxDestinoRespaldo.Text != "")
                    {
                        if (txtBxDestino.Text != "" && txtBxDestinoRespaldo.Text != "")
                            
                        {
                            if (comboBoxOrigen.SelectedIndex != -1)
                            {
                                COBDDataContext a = new COBDDataContext();

                                string idConfiguracionOrigen = comboBoxOrigen.SelectedItem.ToString();
                                string[] idCofig = idConfiguracionOrigen.Split('_');

                                OrigenDatosClientesFANASA n = new OrigenDatosClientesFANASA();
                                n.field1 = txtBxField1.Text;
                                n.field2 = txtBxField2.Text;
                                n.Extension = txtBxExt.Text;
                                n.Destino = txtBxDestino.Text;
                                n.DestinoRespaldo = txtBxDestinoRespaldo.Text;
                                //n.userConexion = textBoxCnecionOracle.Text;
                                n.iRegistroConfigOrigen = Convert.ToInt32(idCofig[0].ToString());
                                a.OrigenDatosClientesFANASA.InsertOnSubmit(n);
                                a.SubmitChanges();
                                limpiar();
                                getdatos();
                            }
                        }
                        else
                        {
                            if (txtBxDestino.Text != "" && txtBxDestinoRespaldo.Text != "")
                            {
                                if (comboBoxOrigen.SelectedIndex != -1)
                                {
                                    COBDDataContext a = new COBDDataContext();

                                    string idConfiguracionOrigen = comboBoxOrigen.SelectedItem.ToString();
                                    string[] idCofig = idConfiguracionOrigen.Split('_');

                                    OrigenDatosClientesFANASA n = new OrigenDatosClientesFANASA();
                                    n.field1 = txtBxField1.Text;
                                    n.field2 = txtBxField2.Text;
                                    n.Extension = txtBxExt.Text;
                                    n.Destino = txtBxDestino.Text;
                                    n.DestinoRespaldo = txtBxDestinoRespaldo.Text;
                                    //n.userConexion = textBoxCnecionOracle.Text;
                                    a.OrigenDatosClientesFANASA.InsertOnSubmit(n);
                                    n.iRegistroConfigOrigen = Convert.ToInt32(idCofig[0].ToString());
                                    a.SubmitChanges();
                                    limpiar();
                                    getdatos();
                                }
                            }
                            else
                            {
                                DialogResult result;
                                result = MessageBox.Show("Debe de llenar todos los datos de configuracion ", "Error al guardar");
                            }
                        }
                    }
                    else
                    {
                        DialogResult result;
                        result = MessageBox.Show("Debe de llenar el destino Oracle y Respaldo", "Error al guardar");
                    }
                }
                else
                {
                    DialogResult result;
                    result = MessageBox.Show("Datos obligatorios sin llenar", "Error al guardar");
                }
            }
            else
            {
                DialogResult result;
                result = MessageBox.Show("Esta selecionado un registro", "Error al guardar");
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            COBDDataContext a = new COBDDataContext();

            if (lblID2.Text != "-")
            {
                int id = Convert.ToInt32(lblID2.Text);
                var buscar = from c in a.OrigenDatosClientesFANASA where c.idOrigenDatos == id select c;

                if (txtBxField1.Text != "")
                {
                    buscar.First().field1 = txtBxField1.Text;
                }
                else
                {
                    buscar.First().field1 = null;
                }


                if (txtBxField2.Text != "" || txtBxField2.Text == "")
                {
                    buscar.First().field2 = txtBxField2.Text;
                }
                else
                {
                    buscar.First().field2 = null;
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

                if (txtBxDestinoRespaldo.Text != "")
                {
                    buscar.First().DestinoRespaldo = txtBxDestinoRespaldo.Text;
                }
                else
                {
                    DialogResult result;
                    result = MessageBox.Show("Debe de colocar Destino de Respaldo", "Error al actualizar");
                }

                //if (textBoxCnecionOracle.Text != "")
                //{
                //    buscar.First().userConexion = textBoxCnecionOracle.Text;
                //}
                //else
                //{
                //    DialogResult result;
                //    result = MessageBox.Show("Debe de colocar usuario de conexión", "Error al actualizar");
                //}

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


        private void button3_Click_1(object sender, EventArgs e)
        {
            if (lblID2.Text != "-")
            {
                COBDDataContext a = new COBDDataContext();
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;

                result = MessageBox.Show("¿ESTAS SEGURO QUE QUIERES BORRAR EL REGISTRO " + lblID2.Text + "?", "ALERTA", buttons);
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    int id = Convert.ToInt32(lblID2.Text);
                    var buscarcorreos = from c in a.CtlCorreosClientesFANASA where c.IdOrigenDatosClientesFANASA == id select c;
                    foreach (var item in buscarcorreos)
                    {
                        a.CtlCorreosClientesFANASA.DeleteOnSubmit(item);
                        a.SubmitChanges();
                    }
                    var buscar = from c in a.OrigenDatosClientesFANASA where c.idOrigenDatos == id select c;
                    a.OrigenDatosClientesFANASA.DeleteOnSubmit(buscar.First());
                    a.SubmitChanges();
                    limpiar();
                    getdatos();
                }
            }
            else
            {
                DialogResult result;
                result = MessageBox.Show("No esta selecionado un registro, favor de seleccionar un registro", "Error al guardar");
            }
        }

        private void dataGridViewClientesFANASA_CellContentClick(object sender, DataGridViewCellEventArgs e)
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
                        lblID2.Text = row.Cells[0].Value.ToString();
                    }
                    if (row.Cells[1].Value != null)
                        txtBxField1.Text = row.Cells[1].Value.ToString();

                    if (row.Cells[2].Value != null)
                        txtBxField2.Text = row.Cells[2].Value.ToString();

                    if (row.Cells[3].Value != null)
                        txtBxExt.Text = row.Cells[3].Value.ToString();

                    if (row.Cells[4].Value != null)
                        txtBxDestino.Text = row.Cells[4].Value.ToString();

                    if (row.Cells[5].Value != null)
                        txtBxDestinoRespaldo.Text = row.Cells[5].Value.ToString();

                    if (row.Cells[6].Value != null)
                    {
                        comboBoxOrigen.Text = row.Cells[6].Value.ToString() + "_" + row.Cells[7].Value.ToString();
                    }
                    
                }
            }
        }
    }
}
