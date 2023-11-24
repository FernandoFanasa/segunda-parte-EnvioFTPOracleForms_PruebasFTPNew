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
    public partial class OrigenEtiquetas : Form
    {
        public OrigenEtiquetas()
        {
            InitializeComponent();
        }

        private void OrigenEtiquetas_Load(object sender, EventArgs e)
        {
            getdatos();
        }

        private void getdatos()
        {
            try
            {
                dataGridViewOrigen.DataSource = "";
                COBDDataContext a = new COBDDataContext();

                dataGridViewOrigen.DataSource = from c in a.ConfiguracionOrigenEtiquetas
                                                select new
                                                {
                                                    IdOrigen = c.uiRegistroOrigen,
                                                    RutaOrigen = c.sOrigen,
                                                    Correo = c.sCorreo,
                                                    Destinatario = c.sDestinatario,
                                                    Asunto = c.sAsunto,
                                                    DireccionIP = c.sDireccionIP,
                                                    Puerto = c.iPuerto,
                                                    Password = c.sPassword,
                                                };

            }
            catch (Exception ex)
            {
                DialogResult result;
                result = MessageBox.Show(ex.Message, "Error de carga de datos");
            }
        }

        private void limpiar()
        {
            lblID.Text = "-";
            txtBxOrigen.Text = "";
            txtBxCorreo.Text = "";
            txtBxDestinatario.Text = "";
            txtBxAsunto.Text = "";
            txtBxDireccion.Text = "";
            txtBxPuerto.Text = "";
            txtBxPassword.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (lblID.Text == "-")
            {
                COBDDataContext a = new COBDDataContext();

                ConfiguracionOrigenEtiquetas c = new ConfiguracionOrigenEtiquetas();
                c.sOrigen = txtBxOrigen.Text;
                c.sCorreo = txtBxCorreo.Text;
                c.sDestinatario = txtBxDestinatario.Text;
                c.sAsunto = txtBxAsunto.Text;
                c.sDireccionIP = txtBxDireccion.Text;
                c.iPuerto = Convert.ToInt32(txtBxPuerto.Text);
                c.sPassword = txtBxPassword.Text;

                a.ConfiguracionOrigenEtiquetas.InsertOnSubmit(c);
                a.SubmitChanges();
                limpiar();
                getdatos();

            }
            else
            {
                DialogResult result;
                result = MessageBox.Show("Error en crear una nueva configuración");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            COBDDataContext a = new COBDDataContext();

            if (lblID.Text != "-")
            {
                int id = Convert.ToInt32(lblID.Text);
                var buscar = from c in a.ConfiguracionOrigenEtiquetas where c.uiRegistroOrigen == id select c;
                if (txtBxOrigen.Text != "")
                {
                    buscar.First().sOrigen = txtBxOrigen.Text;
                }
                else
                {
                    buscar.First().sOrigen = null;
                }


                if (txtBxCorreo.Text != "")
                {
                    buscar.First().sCorreo = txtBxCorreo.Text;
                }
                else
                {
                    buscar.First().sCorreo = null;
                }


                if (txtBxDestinatario.Text != "")
                {
                    buscar.First().sDestinatario = txtBxDestinatario.Text;
                }
                else
                {
                    buscar.First().sDestinatario = null;
                }

                if (txtBxAsunto.Text != "")
                {
                    buscar.First().sAsunto = txtBxAsunto.Text;
                }
                else
                {
                    buscar.First().sAsunto = null;
                }

                if (txtBxDireccion.Text != "")
                {
                    buscar.First().sDireccionIP = txtBxDireccion.Text;
                }
                else
                {
                    buscar.First().sDireccionIP = null;
                }


                if (txtBxPuerto.Text != "")
                {
                    buscar.First().iPuerto = Convert.ToInt32(txtBxPuerto.Text);
                }

                else
                {
                    buscar.First().iPuerto = 0;
                }


                if (txtBxPassword.Text != "")
                {
                    buscar.First().sPassword = txtBxPassword.Text;
                }
                else
                {
                    buscar.First().sPassword = null;
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
                    var buscarOrigen = from c in a.ConfiguracionOrigenEtiquetas where c.uiRegistroOrigen == id select c;
                    a.ConfiguracionOrigenEtiquetas.DeleteOnSubmit(buscarOrigen.First());
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

        private void dataGridViewOrigen_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                limpiar();
            }
            else
            {
                DataGridViewRow row = dataGridViewOrigen.Rows[e.RowIndex];
                if (row != null)
                {
                    limpiar();

                    if (row.Cells["IdOrigen"].Value != null)
                    {
                        lblID.Text = row.Cells["IdOrigen"].Value.ToString();
                    }

                    if (row.Cells["RutaOrigen"].Value != null)
                    {
                        txtBxOrigen.Text = row.Cells["RutaOrigen"].Value.ToString();
                    }

                    if (row.Cells["Correo"].Value != null)
                    {
                        txtBxCorreo.Text = row.Cells["Correo"].Value.ToString();
                    }


                    if (row.Cells["Destinatario"].Value != null)
                    {
                        txtBxDestinatario.Text = row.Cells["Destinatario"].Value.ToString();
                    }


                    if (row.Cells["Asunto"].Value != null)
                    {
                        txtBxAsunto.Text = row.Cells["Asunto"].Value.ToString();
                    }

                    if (row.Cells["DireccionIP"].Value != null)
                    {
                        txtBxDireccion.Text = row.Cells["DireccionIP"].Value.ToString();
                    }


                    if (row.Cells["Puerto"].Value != null)
                    {
                        txtBxPuerto.Text = row.Cells["Puerto"].Value.ToString();
                    }

                    if (row.Cells["Password"].Value != null)
                    {
                        txtBxPassword.Text = row.Cells["Password"].Value.ToString();
                    }
                }
            }
        }

        private void envioEtiquetasOracleRenovadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Etiquetas etiqueta = new Etiquetas();
            etiqueta.Show();
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
