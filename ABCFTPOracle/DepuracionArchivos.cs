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
    public partial class DepuracionArchivos : Form
    {
        public DepuracionArchivos()
        {
            InitializeComponent();
        }

        private void DepuracionArchivos_Load(object sender, EventArgs e)
        {
            getDatos();
        }

        private void limpiar()
        {
            textDias.Text = "";
            textRuta.Text = "";
            labelID.Text = "";
        }

        private void getDatos()
        {
            try
            {
                dataGridView1.DataSource = "";
                COBDDataContext a = new COBDDataContext();

                dataGridView1.DataSource = from d in a.DepuracionFiles
                                           select new
                                           {

                                               IdRutaDepuracion = d.IdDepuracion,
                                               RutaDepuracion = d.RutaDepuracion,
                                               DiasPermanencia = d.DiasFiles
                                           };
            }
            catch (Exception ex)
            {
                DialogResult result;
                result = MessageBox.Show(ex.Message, "Error de carga de Datos");
            }


        }

        private void menuInicialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form1 = new Form1();
            form1.Show();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (labelID.Text == "-")
            {
                if (textRuta.Text != "" && textDias.Text != "")
                {
                    COBDDataContext a = new COBDDataContext();

                    DepuracionFiles d = new DepuracionFiles();

                    d.RutaDepuracion = textRuta.Text;
                    d.DiasFiles = Convert.ToInt32(textDias.Text);
                    a.DepuracionFiles.InsertOnSubmit(d);
                    a.SubmitChanges();
                    limpiar();
                    getDatos();
                }
                else
                {
                    DialogResult result;
                    result = MessageBox.Show("Debe llenar todos los datos", "Error al guardar");
                }
            }
            else
            {
                DialogResult result;
                result = MessageBox.Show("Esta selecionado un registro", "Error al guardar");
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            COBDDataContext a = new COBDDataContext();

            if (labelID.Text != "-")
            {
                int id = Convert.ToInt32(labelID.Text);
                var buscar = from c in a.DepuracionFiles where c.IdDepuracion == id select c;

                if (textRuta.Text != "")
                {
                    buscar.First().RutaDepuracion = textRuta.Text;
                }

                else
                {
                    buscar.First().RutaDepuracion = null;
                }

                if (textDias.Text != "")
                {
                    buscar.First().DiasFiles = Convert.ToInt32(textDias.Text.ToString());
                }

                else
                {
                    buscar.First().DiasFiles = null;
                }

                a.SubmitChanges();
                limpiar();
                getDatos();
            }
            else
            {
                DialogResult result;
                result = MessageBox.Show("Debe de selecionar un registro", "Error al actualizar");
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
                    if (row.Cells["IdRutaDepuracion"].Value != null)
                    {
                        labelID.Text = row.Cells["IdRutaDepuracion"].Value.ToString();
                    }
                    if (row.Cells["RutaDepuracion"].Value != null)
                    {
                        textRuta.Text = row.Cells["RutaDepuracion"].Value.ToString();
                    }

                    if (row.Cells["DiasPermanencia"].Value != null)
                    {
                        textDias.Text = row.Cells["DiasPermanencia"].Value.ToString();
                    }
                        
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (labelID.Text != "-")
            {
                COBDDataContext a = new COBDDataContext();
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;

                result = MessageBox.Show("¿ESTAS SEGURO QUE QUIERES BORRAR EL REGISTRO " + labelID.Text + "?", "ALERTA", buttons);

                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    int id = Convert.ToInt32(labelID.Text);
                    var buscar = from c in a.DepuracionFiles where c.IdDepuracion == id select c;

                    a.DepuracionFiles.DeleteOnSubmit(buscar.First());
                    a.SubmitChanges();
                    limpiar();
                    getDatos();
                }
                else
                {
                    limpiar();
                }
            }
            else
            {
                DialogResult result;
                result = MessageBox.Show("No esta selecionado un registro, favor de", "Error al borrar");
            }
        }
    }
}
