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
    public partial class CarvajalFESA : Form
    {
        public CarvajalFESA()
        {
            InitializeComponent();
        }
        private void CarvajalFESA_Load(object sender, EventArgs e)
        {
            getdatos();
            getOrigenes();
        }

        private void getdatos()
        {
            try
            {
                dataGridViewCavajal.DataSource = "";
                COBDDataContext a = new COBDDataContext();
                //var buscar = from c in a.OrigenDatosFanasa select c;
                //dataGridViewOracle.DataSource = buscar;


                dataGridViewCavajal.DataSource = from c in a.OrigenDatosCarvajalFESA
                                                 join r in a.ConfiguracionOrigenCarvajalFESA on c.iRegistroConfigOrigen equals r.uiRegistroOrigen
                                                 select new
                                                 {
                                                     IdOrigenDatos = c.IdOrigenDatos,
                                                     Field1 = c.Field1,
                                                     Field2 = c.Field2,
                                                     Field3 = c.Field3,
                                                     Extensión = c.Extension,
                                                     Destino = c.Destino,
                                                     DestinoRespaldo = c.DestinoRespaldo,
                                                     IPFTP = c.IPFTP,
                                                     UserFTP = c.UserFTP,
                                                     PasswordFTP = c.PassFTP,
                                                     DirectorioFTP = c.DirectorioFTP,
                                                     Puerto = c.Puerto,
                                                     //ModoActivo = c.ModoActivo,
                                                     RegistroOrigen = c.iRegistroConfigOrigen,
                                                     Origen = r.sOrigen,
                                                     userConexion = c.userConexion
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
                var buscar = from c in a.ConfiguracionOrigenCarvajalFESA select c;
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
            txtBxDirectorioFTP.Text = "";
            txtBxIPFTP.Text = "";
            txtBxUserFTP.Text = "";
            txtBxPassFTP.Text = "";
            txtBxDirectorioFTP.Text = "";
            txtBxPuerto.Text = "";
            txtBxDestinoRespaldo.Text = "";
            comboBoxOrigen.SelectedIndex = -1;
            textBoxUser.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (lblID.Text == "-")
            {
                if (txtBxField1.Text != "" && txtBxExt.Text != "" && comboBoxOrigen.SelectedIndex != -1)
                {
                    if (txtBxDestino.Text != "" || txtBxDestinoRespaldo.Text != "")
                    {
                        if (txtBxDestino.Text != "" && txtBxDestinoRespaldo.Text != "" && textBoxUser.Text != ""
                            && txtBxIPFTP.Text == "" && txtBxUserFTP.Text == "" &&
                             txtBxPassFTP.Text == "" && txtBxPuerto.Text == "")
                        {
                            if (comboBoxOrigen.SelectedIndex != -1)
                            {
                                COBDDataContext a = new COBDDataContext();


                                string idConfiguracionOrigen = comboBoxOrigen.SelectedItem.ToString();
                                string[] idCofig = idConfiguracionOrigen.Split('_');


                                OrigenDatosCarvajalFESA n = new OrigenDatosCarvajalFESA();
                                n.Field1 = txtBxField1.Text;
                                n.Field2 = txtBxField2.Text;
                                n.Field3 = txtBxField3.Text;
                                n.Extension = txtBxExt.Text;
                                n.Destino = txtBxDestino.Text;
                                n.DestinoRespaldo = txtBxDestinoRespaldo.Text;
                                n.userConexion = textBoxUser.Text;
                                n.iRegistroConfigOrigen = Convert.ToInt32(idCofig[0].ToString());
                                a.OrigenDatosCarvajalFESA.InsertOnSubmit(n);
                                a.SubmitChanges();
                                limpiar();
                                getdatos();
                            }
                        }
                        else
                        {
                            if (txtBxDestino.Text != "" && txtBxDestinoRespaldo.Text != "" && textBoxUser.Text != ""
                                   && txtBxIPFTP.Text != "" && txtBxUserFTP.Text != "" &&
                                    txtBxPassFTP.Text != "" && txtBxPuerto.Text != "")
                            {

                                if (comboBoxOrigen.SelectedIndex != -1)
                                {
                                    COBDDataContext a = new COBDDataContext();

                                    string idConfiguracionOrigen = comboBoxOrigen.SelectedItem.ToString();
                                    string[] idCofig = idConfiguracionOrigen.Split('_');

                                    OrigenDatosCarvajalFESA n = new OrigenDatosCarvajalFESA();
                                    n.Field1 = txtBxField1.Text;
                                    n.Field2 = txtBxField2.Text;
                                    n.Field3 = txtBxField3.Text;
                                    n.Extension = txtBxExt.Text;
                                    n.Destino = txtBxDestino.Text;
                                    n.DestinoRespaldo = txtBxDestinoRespaldo.Text;
                                    n.userConexion = textBoxUser.Text;
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
                                    n.Puerto = txtBxPuerto.Text;
                                    a.OrigenDatosCarvajalFESA.InsertOnSubmit(n);
                                    n.iRegistroConfigOrigen = Convert.ToInt32(idCofig[0].ToString());
                                    a.SubmitChanges();
                                    limpiar();
                                    getdatos();
                                }
                            }
                            else
                            {
                                DialogResult result;
                                result = MessageBox.Show("Debe de llenar todos los datos de configuracion FTP", "Error al guardar");
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

        private void button1_Click(object sender, EventArgs e)
        {
            COBDDataContext a = new COBDDataContext();

            if (lblID.Text != "-")
            {
                int id = Convert.ToInt32(lblID.Text);
                var buscar = from c in a.OrigenDatosCarvajalFESA where c.IdOrigenDatos == id select c;

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

                if (txtBxDestinoRespaldo.Text != "")
                {
                    buscar.First().DestinoRespaldo = txtBxDestinoRespaldo.Text;
                }
                else
                {
                    DialogResult result;
                    result = MessageBox.Show("Debe de colocar Destino de Respaldo", "Error al actualizar");
                }

                if (txtBxDirectorioFTP.Text != "")
                {
                    buscar.First().DirectorioFTP = txtBxDirectorioFTP.Text;
                }
                else
                {
                    buscar.First().DirectorioFTP = null;
                }

                if (textBoxUser.Text != "")
                {
                    buscar.First().userConexion = textBoxUser.Text;
                }
                else
                {
                    DialogResult result;
                    result = MessageBox.Show("Debe de colocar usuario de conexión", "Error al actualizar");
                    //buscar.First().userConexion = null;
                }

                if (txtBxIPFTP.Text != "")
                {
                    buscar.First().IPFTP = txtBxIPFTP.Text;
                }
                else
                {
                    buscar.First().IPFTP = null;
                }
                if (txtBxUserFTP.Text != "")
                {
                    buscar.First().UserFTP = txtBxUserFTP.Text;
                }
                else
                {
                    buscar.First().UserFTP = txtBxUserFTP.Text;
                }
                if (txtBxPassFTP.Text != "")
                {
                    buscar.First().PassFTP = txtBxPassFTP.Text;
                }
                else
                {
                    buscar.First().PassFTP = null;
                }
                if (txtBxDirectorioFTP.Text != "")
                {
                    buscar.First().DirectorioFTP = txtBxDirectorioFTP.Text;
                }
                else
                {
                    buscar.First().DirectorioFTP = "/";
                }

                if (txtBxPuerto.Text != "")
                {
                    buscar.First().Puerto = txtBxPuerto.Text;
                }
                else
                {
                    buscar.First().Puerto = null;
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
                    var buscarcorreos = from c in a.CtlCorreosCarvajalFESA where c.IdOrigenDatos == id select c;
                    foreach (var item in buscarcorreos)
                    {
                        a.CtlCorreosCarvajalFESA.DeleteOnSubmit(item);
                        a.SubmitChanges();
                    }
                    var buscar = from c in a.OrigenDatosCarvajalFESA where c.IdOrigenDatos == id select c;
                    a.OrigenDatosCarvajalFESA.DeleteOnSubmit(buscar.First());
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

        private void dataGridViewCavajal_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                limpiar();
            }

            else
            {
                DataGridViewRow row = (DataGridViewRow)dataGridViewCavajal.Rows[e.RowIndex];
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
                        txtBxDestinoRespaldo.Text = row.Cells[6].Value.ToString();

                    if (row.Cells[7].Value != null)
                        txtBxIPFTP.Text = row.Cells[7].Value.ToString();

                    if (row.Cells[8].Value != null)
                        txtBxUserFTP.Text = row.Cells[8].Value.ToString();

                    if (row.Cells[9].Value != null)
                        txtBxPassFTP.Text = row.Cells[9].Value.ToString();

                    if (row.Cells[10].Value != null)
                        txtBxDirectorioFTP.Text = row.Cells[10].Value.ToString();

                    if (row.Cells[11].Value != null)
                        txtBxPuerto.Text = row.Cells[11].Value.ToString();

                    //if (row.Cells[12].Value != null)
                    //    txtBxPuerto.Text = row.Cells[12].Value.ToString();

                    if (row.Cells[12].Value != null)
                    {
                        comboBoxOrigen.Text = row.Cells[12].Value.ToString() + "_" + row.Cells[13].Value.ToString();
                    }

                    if (row.Cells[14].Value != null)
                        textBoxUser.Text = row.Cells[14].Value.ToString();
                }
            }
        }

        private void configuraciónOrigenCarvajalFESAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            OrigenCarvajalFESA origenCarvaFESA = new OrigenCarvajalFESA();
            origenCarvaFESA.Show();
        }

        private void correroCarvajalFESAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            CorreosCarvajalFESA correosFESA = new CorreosCarvajalFESA();
            correosFESA.Show();
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
