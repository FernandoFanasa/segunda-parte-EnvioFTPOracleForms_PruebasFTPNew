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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void correosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form5 frm = new Form5();
            frm.Show();
        }

        private void menuPrincipalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 frm = new Form1();
            frm.Show();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
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
                        txtOrigen.Text = row.Cells[1].Value.ToString();
                    if (row.Cells[2].Value != null)
                        txtDestinoLocal.Text = row.Cells[2].Value.ToString();
                    if (row.Cells[3].Value != null)
                        txtIPFTP.Text = row.Cells[3].Value.ToString();
                    if (row.Cells[4].Value != null)
                        txtUserFTP.Text = row.Cells[4].Value.ToString();
                    
                    if (row.Cells[5].Value != null)
                        txtPassFTP.Text = row.Cells[5].Value.ToString();
                    if (row.Cells[6].Value != null)
                        txtDirectorioFTP.Text = row.Cells[6].Value.ToString();
                    if (row.Cells[7].Value != null)
                        txtExtensiones.Text = row.Cells[7].Value.ToString();
                    if (row.Cells[8].Value != null)
                    {
                        string seguro = row.Cells[8].Value.ToString();
                        if (seguro == "True")
                        {
                            comboBox1.SelectedIndex = 0;
                        }
                        else
                        {
                            comboBox1.SelectedIndex = 1;
                        }
                    }
                    if (row.Cells[9].Value != null)
                        txtPuerto.Text = row.Cells[9].Value.ToString();
                }
            }
        }
        private void limpiar()
        {

            lblID.Text = "-";
            txtOrigen.Text = "";
            txtDestinoLocal.Text = "";
            txtIPFTP.Text = "";
            txtUserFTP.Text = "";
            txtUserFTP.Text = "";
            txtPassFTP.Text = "";
            txtDirectorioFTP.Text = "";
            txtExtensiones.Text = "";
            comboBox1.SelectedIndex = -1;
            txtPuerto.Text = "";
        }
        private void getdatos()
        {
            try
            {
                COBDDataContext a = new COBDDataContext();
                var buscar = from c in a.FTP select c;
                dataGridView1.DataSource = buscar;
            }
            catch (Exception ex)
            {
                DialogResult result;
                result = MessageBox.Show(ex.Message, "Error de carga de datos");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (lblID.Text == "-")
            {
                if(txtOrigen.Text != "" && 
                    txtIPFTP.Text != "" && 
                    txtUserFTP.Text != "" && 
                    txtPassFTP.Text != "" &&
                    txtExtensiones.Text != "" && 
                    comboBox1.SelectedIndex != -1 &&
                    txtPuerto.Text != "")
                {
                    COBDDataContext a = new COBDDataContext();
                    FTP n = new FTP();
                    n.Origen = txtOrigen.Text;
                    if(txtDestinoLocal.Text != "")
                    {
                        n.DestinoLocal = txtDestinoLocal.Text;
                    }
                    else
                    {
                        n.DestinoLocal = null;
                    }
                    n.IPFTP = txtIPFTP.Text;
                    n.UserFTP = txtUserFTP.Text;
                    n.PassFTP = txtPassFTP.Text;
                    if(txtDirectorioFTP.Text != "")
                    {
                        n.DirectorioFTP = txtDirectorioFTP.Text;
                    }
                    else
                    {
                        n.DirectorioFTP = "/";
                    }
                    n.Extensiones = txtExtensiones.Text;
                    if (comboBox1.SelectedIndex == 0)
                    {
                        n.FTPSeguro = true;
                    }
                    else
                    {
                        n.FTPSeguro = false;
                    }
                    n.Puerto = txtPuerto.Text;
                    a.FTP.InsertOnSubmit(n);
                    a.SubmitChanges();
                    limpiar();
                    getdatos();
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtOrigen.Text != "" &&
                    txtIPFTP.Text != "" &&
                    txtUserFTP.Text != "" &&
                    txtPassFTP.Text != "" &&
                    txtExtensiones.Text != "" &&
                    comboBox1.SelectedIndex != -1 &&
                    txtPuerto.Text != "")
            {
                COBDDataContext a = new COBDDataContext();

                if (lblID.Text != "-")
                {
                    int id = Convert.ToInt32(lblID.Text);
                    var buscar = from c in a.FTP where c.Id == id select c;
                    if (txtOrigen.Text != "")
                    {
                        buscar.First().Origen = txtOrigen.Text;
                    }
                    if (txtDestinoLocal.Text != "")
                    {
                        buscar.First().DestinoLocal = txtDestinoLocal.Text;
                    }
                    if (txtIPFTP.Text != "")
                    {
                        buscar.First().IPFTP = txtIPFTP.Text;
                    }
                    if (txtUserFTP.Text != "")
                    {
                        buscar.First().UserFTP = txtUserFTP.Text;
                    }
                    if (txtUserFTP.Text != "")
                    {
                        buscar.First().UserFTP = txtUserFTP.Text;
                    }
                    if (txtPassFTP.Text != "")
                    {
                        buscar.First().PassFTP = txtPassFTP.Text;
                    }
                    if (txtDirectorioFTP.Text != "")
                    {
                        buscar.First().DirectorioFTP = txtDirectorioFTP.Text;
                    }
                    if (txtExtensiones.Text != "")
                    {
                        buscar.First().Extensiones = txtExtensiones.Text;
                    }
                    if (comboBox1.SelectedIndex == -1)
                    {
                        buscar.First().FTPSeguro = null;
                    }
                    else
                    {
                        if (comboBox1.SelectedIndex == 0)
                        {
                            buscar.First().FTPSeguro = true;
                        }
                        else
                        {
                            buscar.First().FTPSeguro = false;
                        }

                    }
                    if (txtPuerto.Text != "")
                    {
                        buscar.First().Puerto = txtPuerto.Text;
                    }
                    a.SubmitChanges();
                    getdatos();
                }
                else
                {
                    DialogResult result;
                    result = MessageBox.Show("Debe de selecionar un registro", "Error al actualizar");
                }
            }
            else
            {
                DialogResult result;
                result = MessageBox.Show("Datos obligatorios sin llenar", "Error al guardar");
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
                    var buscarcorreo = from c in a.CtlCorreosFTP where c.IdFTP == id select c;
                    foreach (var item in buscarcorreo)
                    {
                        a.CtlCorreosFTP.DeleteOnSubmit(item);
                        a.SubmitChanges();
                    }

                    var buscar = from c in a.FTP where c.Id == id select c;
                    a.FTP.DeleteOnSubmit(buscar.First());
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

        private void Form3_Load(object sender, EventArgs e)
        {
            getdatos();
        }
    }
}
