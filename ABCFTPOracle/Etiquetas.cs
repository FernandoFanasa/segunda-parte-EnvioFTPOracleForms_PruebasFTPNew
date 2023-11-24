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
    public partial class Etiquetas : Form
    {
        public Etiquetas()
        {
            InitializeComponent();
        }

        private void Etiquetas_Load(object sender, EventArgs e)
        {
            getdatos();
            getOrigenes();
        }

        private void getdatos()
        {
            try
            {
                dataGridViewOracle.DataSource = "";
                COBDDataContext a = new COBDDataContext();
                //var buscar = from c in a.OrigenDatosFanasa select c;
                //dataGridViewOracle.DataSource = buscar;


                dataGridViewOracle.DataSource = from c in a.OrigenDatosEtiquetas
                                                join r in a.ConfiguracionOrigenEtiquetas on c.iRegistroConfigOrigen equals r.uiRegistroOrigen
                                                select new
                                                {
                                                    IdOrigenDatos = c.IdOrigenDatos,
                                                    Field1 = c.Field1,
                                                    Field2 = c.Field2,
                                                    Field3 = c.Field3,
                                                    Extensión = c.Extension,
                                                    Destino = c.Destino,
                                                    RegistroOrigen = c.iRegistroConfigOrigen,
                                                    Origen = r.sOrigen,
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
                var buscar = from c in a.ConfiguracionOrigenEtiquetas select c;
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

        private void button1_Click(object sender, EventArgs e)
        {
            COBDDataContext a = new COBDDataContext();

            if (lblID.Text != "-")
            {
                int id = Convert.ToInt32(lblID.Text);
                var buscar = from c in a.OrigenDatosEtiquetas where c.IdOrigenDatos == id select c;

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


        private void dataGridViewOracle_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                limpiar();
            }

            else
            {
                DataGridViewRow row = (DataGridViewRow)dataGridViewOracle.Rows[e.RowIndex];
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

        private void button2_Click(object sender, EventArgs e)
        {
            if (lblID.Text == "-")
            {
                if (txtBxField1.Text != "" && txtBxExt.Text != "" && comboBoxOrigen.SelectedIndex != -1)
                {
                    if (txtBxDestino.Text != "")
                    {
                        if (comboBoxOrigen.SelectedIndex != -1)
                        {
                            COBDDataContext a = new COBDDataContext();


                            string idConfiguracionOrigen = comboBoxOrigen.SelectedItem.ToString();
                            string[] idCofig = idConfiguracionOrigen.Split('_');


                            OrigenDatosEtiquetas n = new OrigenDatosEtiquetas();
                            n.Field1 = txtBxField1.Text;
                            n.Field2 = txtBxField2.Text;
                            n.Field3 = txtBxField3.Text;
                            n.Extension = txtBxExt.Text;
                            n.Destino = txtBxDestino.Text;
                            n.iRegistroConfigOrigen = Convert.ToInt32(idCofig[0].ToString());
                            a.OrigenDatosEtiquetas.InsertOnSubmit(n);
                            a.SubmitChanges();
                            limpiar();
                            getdatos();
                        }
                    }
                    else
                    {
                        DialogResult result;
                        result = MessageBox.Show("Debe de llenar el destino onedrive o el destino FTP", "Error al guardar");
                    }

                }
                else
                {
                    DialogResult result;
                    result = MessageBox.Show("Faltan Datos", "Error al guardar");
                }
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
                    var buscarcorreos = from c in a.CtlCorreosEtiquetas where c.IdOrigenDatosEtiquetas == id select c;
                    foreach (var item in buscarcorreos)
                    {
                        a.CtlCorreosEtiquetas.DeleteOnSubmit(item);
                        a.SubmitChanges();
                    }
                    var buscar = from c in a.OrigenDatosEtiquetas where c.IdOrigenDatos == id select c;
                    a.OrigenDatosEtiquetas.DeleteOnSubmit(buscar.First());
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

        private void menuInicialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form1 = new Form1();
            form1.Show();
        }

        private void correosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            CorreosEtiquetas correoEtiqueta = new CorreosEtiquetas();
            correoEtiqueta.Show();
        }

        private void configuraciónOrigenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            OrigenEtiquetas orgEtiqueta = new OrigenEtiquetas();
            orgEtiqueta.Show();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
