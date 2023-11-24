using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ABCFTPOracle
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            getdatos();
        }

        private void getdatos()
        {
            try
            { 
                COBDDataContext a = new COBDDataContext();
                var buscar = from c in a.OrigenDatos select c;
                dataGridView1.DataSource = buscar;
            }
            catch (Exception ex)
            {
                DialogResult result;
                result = MessageBox.Show(ex.Message, "Error de carga de datos");
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            COBDDataContext a = new COBDDataContext();

            if(lblID.Text != "-")
            {
                int id = Convert.ToInt32(lblID.Text);
                var buscar = from c in a.OrigenDatos where c.IdOrigenDatos == id select c;
                if(txtBxLab.Text != "")
                {
                    buscar.First().IdLaboratorio = txtBxLab.Text;
                }
                else
                {
                    buscar.First().IdLaboratorio = null;
                }
                if(txtBxTipo.Text != "")
                {
                    buscar.First().Tipo = txtBxTipo.Text;
                }
                else
                {
                    buscar.First().Tipo = null;
                }
                if(txtBxExt.Text != "")
                {
                    buscar.First().Extension = txtBxExt.Text;
                }
                else
                {
                    buscar.First().Extension = null;
                }
                if(txtBxDestino.Text != "")
                {
                    buscar.First().Destino = txtBxDestino.Text;
                }
                else
                {
                    buscar.First().Destino = null;
                }

                if(txtBxDesFTPPaso.Text != "")
                {
                    buscar.First().DestinoFTPPaso = txtBxDesFTPPaso.Text;
                }

                if(txtBxDirectorioFTP.Text != "")
                {
                    buscar.First().DirectorioFTP = txtBxDirectorioFTP.Text;
                }
                else
                {
                    buscar.First().DirectorioFTP = null;
                }
                if(txtBxIPFTP.Text != "")
                {
                    buscar.First().IPFTP = txtBxIPFTP.Text;
                }
                else
                {
                    buscar.First().IPFTP = null;
                }
                if(txtBxUserFTP.Text != "")
                {
                    buscar.First().UserFTP = txtBxUserFTP.Text;
                }
                else
                {
                    buscar.First().UserFTP = txtBxUserFTP.Text;
                }
                if(txtBxPassFTP.Text != "")
                {
                    buscar.First().PassFTP = txtBxPassFTP.Text;
                }
                else
                {
                    buscar.First().PassFTP = null;
                }
                if(txtBxDirectorioFTP.Text != "")
                {
                    buscar.First().DirectorioFTP = txtBxDirectorioFTP.Text;
                }
                else
                {
                    buscar.First().DirectorioFTP = "/";
                }
                if(comboBox1.SelectedIndex == -1)
                {
                    buscar.First().FTPSeguro = null;
                }
                else
                {
                    if(comboBox1.SelectedIndex == 0)
                    {
                        buscar.First().FTPSeguro = true;
                    }
                    else
                    {
                        buscar.First().FTPSeguro = false;
                    }
                    
                }
                if(txtBxPuerto.Text != "")
                {
                    buscar.First().Puerto = txtBxPuerto.Text;
                }
                else
                {
                    buscar.First().Puerto = null;
                }
                if (comboBox2.SelectedIndex == -1)
                {
                    buscar.First().AdjuntarArchivo = null;
                }
                else
                {
                    if (comboBox2.SelectedIndex == 0)
                    {
                        buscar.First().AdjuntarArchivo = true;
                    }
                    else
                    {
                        buscar.First().AdjuntarArchivo = false;
                    }

                }

                if(txtEnvioPDF.Text != "")
                {
                    buscar.First().EnvioPDF = txtEnvioPDF.Text;
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex == -1)
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
                    if (row.Cells[1].Value != null)
                        txtBxLab.Text = row.Cells[1].Value.ToString();
                    if (row.Cells[2].Value != null)
                        txtBxTipo.Text = row.Cells[2].Value.ToString();
                    if (row.Cells[3].Value != null)
                        txtBxExt.Text = row.Cells[3].Value.ToString();
                    if (row.Cells[4].Value != null)
                        txtBxDestino.Text = row.Cells[4].Value.ToString();
                    if (row.Cells[5].Value != null)
                        txtBxDirectorioFTP.Text = row.Cells[5].Value.ToString();
                    if (row.Cells[6].Value != null)
                        txtBxIPFTP.Text = row.Cells[6].Value.ToString();
                    if (row.Cells[7].Value != null)
                        txtBxUserFTP.Text = row.Cells[7].Value.ToString();
                    if (row.Cells[8].Value != null)
                        txtBxPassFTP.Text = row.Cells[8].Value.ToString();
                    if (row.Cells[9].Value != null)
                        txtBxDirectorioFTP.Text = row.Cells[9].Value.ToString();
                    if (row.Cells[10].Value != null)
                    {
                        string seguro = row.Cells[10].Value.ToString();
                        if (seguro == "True")
                        {
                            comboBox1.SelectedIndex = 0;
                        }
                        else
                        {
                            comboBox1.SelectedIndex = 1;
                        }
                    }
                    if (row.Cells[11].Value != null)
                        txtBxPuerto.Text = row.Cells[11].Value.ToString();
                    if(row.Cells[12].Value != null)
                    {
                        string adjunto = row.Cells[12].Value.ToString();
                        if (adjunto == "True")
                        {
                            comboBox2.SelectedIndex = 0;
                        }
                        else
                        {
                            comboBox2.SelectedIndex = 1;
                        }
                    }
                    if (row.Cells[12].Value != null)
                        txtEnvioPDF.Text = row.Cells[12].Value.ToString();
                }
            }
            

        }

        private void limpiar()
        {
            lblID.Text = "-";
            txtBxLab.Text = "";
            txtBxTipo.Text = "";
            txtBxExt.Text = "";
            txtBxDestino.Text = "";
            txtBxDirectorioFTP.Text = "";
            txtBxIPFTP.Text = "";
            txtBxUserFTP.Text = "";
            txtBxPassFTP.Text = "";
            txtBxDirectorioFTP.Text = "";
            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
            txtBxPuerto.Text = "";
            txtBxDesFTPPaso.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(lblID.Text == "-")
            {
                if (txtBxLab.Text != "" && txtBxTipo.Text != "" && txtBxExt.Text != "")
                {
                    if(txtBxDestino.Text != "" || txtBxDesFTPPaso.Text != "")
                    {
                        if(txtBxDestino.Text != "" && txtBxDesFTPPaso.Text == "")
                        {
                            COBDDataContext a = new COBDDataContext();
                            OrigenDatos n = new OrigenDatos();
                            n.IdLaboratorio = txtBxLab.Text;
                            n.Tipo = txtBxTipo.Text;
                            n.Extension = txtBxExt.Text;
                            n.Destino = txtBxDestino.Text;
                            a.OrigenDatos.InsertOnSubmit(n);
                            a.SubmitChanges();
                            limpiar();
                            getdatos();
                        }
                        else
                        {
                            if (txtBxDestino.Text == "" && txtBxDesFTPPaso.Text != "")
                            {
                                if (txtBxIPFTP.Text != "" &&
                                    txtBxUserFTP.Text != "" &&
                                    txtBxPassFTP.Text != "" &&
                                    comboBox1.SelectedIndex != -1 &&
                                    txtBxPuerto.Text != "" &&
                                    comboBox2.SelectedIndex != -2)
                                {
                                    COBDDataContext a = new COBDDataContext();
                                    OrigenDatos n = new OrigenDatos();
                                    n.IdLaboratorio = txtBxLab.Text;
                                    n.Tipo = txtBxTipo.Text;
                                    n.Extension = txtBxExt.Text;
                                    n.Destino = null;
                                    n.DestinoFTPPaso = txtBxDesFTPPaso.Text;
                                    n.IPFTP = txtBxIPFTP.Text;
                                    n.UserFTP = txtBxUserFTP.Text;
                                    n.PassFTP = txtBxPassFTP.Text;
                                    if (txtBxDirectorioFTP.Text != "")
                                    {
                                        n.DirectorioFTP = "/";
                                    }
                                    else
                                    {
                                        n.DirectorioFTP = txtBxDirectorioFTP.Text;
                                    }
                                    if(comboBox1.SelectedIndex == 0)
                                    {
                                        n.FTPSeguro = true;
                                    }
                                    else
                                    {
                                        n.FTPSeguro = false;
                                    }
                                    n.Puerto = txtBxPuerto.Text;
                                    if (comboBox2.SelectedIndex == 0)
                                    {
                                        n.AdjuntarArchivo = true;
                                    }
                                    else
                                    {
                                        n.AdjuntarArchivo = false;
                                    }
                                    n.EnvioPDF = txtEnvioPDF.Text;
                                    
                                    a.OrigenDatos.InsertOnSubmit(n);
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
                            else if(txtBxDestino.Text != "" && txtBxDesFTPPaso.Text != "")
                            {
                                if (txtBxIPFTP.Text != "" &&
                                    txtBxUserFTP.Text != "" &&
                                    txtBxPassFTP.Text != "" &&
                                    comboBox1.SelectedIndex != -1 &&
                                    txtBxPuerto.Text != "")
                                {
                                    COBDDataContext a = new COBDDataContext();
                                    OrigenDatos n = new OrigenDatos();
                                    n.IdLaboratorio = txtBxLab.Text;
                                    n.Tipo = txtBxTipo.Text;
                                    n.Extension = txtBxExt.Text;
                                    n.Destino = txtBxDestino.Text;
                                    n.DestinoFTPPaso = txtBxDesFTPPaso.Text;
                                    n.IPFTP = txtBxIPFTP.Text;
                                    n.UserFTP = txtBxUserFTP.Text;
                                    n.PassFTP = txtBxPassFTP.Text;
                                    if (txtBxDirectorioFTP.Text != "")
                                    {
                                        n.DirectorioFTP = "/";
                                    }
                                    else
                                    {
                                        n.DirectorioFTP = txtBxDirectorioFTP.Text;
                                    }
                                    if (comboBox1.SelectedIndex == 0)
                                    {
                                        n.FTPSeguro = true;
                                    }
                                    else
                                    {
                                        n.FTPSeguro = false;
                                    }
                                    n.Puerto = txtBxPuerto.Text;
                                    n.EnvioPDF = txtEnvioPDF.Text;
                                    a.OrigenDatos.InsertOnSubmit(n);
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
                    result = MessageBox.Show("Datos obligatorios sin llenar", "Error al guardar");
                }
            }
            else
            {
                DialogResult result;
                result = MessageBox.Show("Esta selecionado un registro", "Error al guardar");
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (lblID.Text != "-")
            {
                COBDDataContext a = new COBDDataContext();
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;

                result = MessageBox.Show("¿ESTAS SEGURO QUE QUIERES BORRAR EL REGISTRO " + lblID.Text +  "?", "ALERTA", buttons);
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    int id = Convert.ToInt32(lblID.Text);
                    var buscarcorreos = from c in a.CtlCorreos where c.IdOrigenDatos == id select c;
                    foreach (var item in buscarcorreos)
                    {
                        a.CtlCorreos.DeleteOnSubmit(item);
                        a.SubmitChanges();
                    }
                    var buscar = from c in a.OrigenDatos where c.IdOrigenDatos == id select c;
                    a.OrigenDatos.DeleteOnSubmit(buscar.First());
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

        private void insertarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 frm = new Form1();
            frm.Show();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void correosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form4 frm = new Form4();
            frm.Show();
        }

    }
}
