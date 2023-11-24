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
    public partial class OracleRenovado : Form
    {
        public OracleRenovado()
        {
            InitializeComponent();
        }

        private void OracleRenovado_Load(object sender, EventArgs e)
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


                dataGridViewOracle.DataSource = from c in a.OrigenDatosFanasa
                                                join r in a.ConfiguracionOrigen on c.iRegistroConfigOrigen equals r.uiRegistroOrigen
                                                select new
                                                {
                                                    IdOrigenDatos = c.IdOrigenDatos,
                                                    Field1 = c.Field1,
                                                    Field2 = c.Field2,
                                                    Field3 = c.Field3,
                                                    Extensión = c.Extension,
                                                    Destino = c.Destino,
                                                    DestinoFTPPaso = c.DestinoFTPPaso,
                                                    IPFTP = c.IPFTP,
                                                    UserFTP = c.UserFTP,
                                                    PasswordFTP = c.PassFTP,
                                                    DirectorioFTP = c.DirectorioFTP,
                                                    FTPSeguro = c.FTPSeguro,
                                                    Puerto = c.Puerto,
                                                    AdjuntarArchivo = c.AdjuntarArchivo,
                                                    EnvioPDF = c.EnvioPDF,
                                                    ModoActivo = c.ModoActivo,
                                                    RegistroOrigen = c.iRegistroConfigOrigen,
                                                    Origen = r.sOrigen,
                                                    BenavidesDestino = c.bBenavides,
                                                    CarvajalFANASA = c.bCarvajalFANASA,
                                                    CarvajalFESA = c.bCarvajalFESA
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
                var buscar = from c in a.ConfiguracionOrigen select c;
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
            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
            txtBxPuerto.Text = "";
            txtBxDesFTPPaso.Text = "";
            comboBoxOrigen.SelectedIndex = -1;
            checkBoxBenavides.Checked = false;
            checkBoxFANASA.Checked = false;
            checkBoxFESA.Checked = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            COBDDataContext a = new COBDDataContext();

            if (lblID.Text != "-")
            {
                int id = Convert.ToInt32(lblID.Text);
                var buscar = from c in a.OrigenDatosFanasa where c.IdOrigenDatos == id select c;

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

                if (txtBxDesFTPPaso.Text != "")
                {
                    buscar.First().DestinoFTPPaso = txtBxDesFTPPaso.Text;
                }

                if (txtBxDirectorioFTP.Text != "")
                {
                    buscar.First().DirectorioFTP = txtBxDirectorioFTP.Text;
                }
                else
                {
                    buscar.First().DirectorioFTP = null;
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
                if (txtBxPuerto.Text != "")
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

                if (txtEnvioPDF.Text != "")
                {
                    buscar.First().EnvioPDF = txtEnvioPDF.Text;
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

                buscar.First().bBenavides = checkBoxBenavides.Checked;
                buscar.First().bCarvajalFANASA = checkBoxFANASA.Checked;
                buscar.First().bCarvajalFESA = checkBoxFESA.Checked;

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
                        txtBxDirectorioFTP.Text = row.Cells[6].Value.ToString();

                    if (row.Cells[7].Value != null)
                        txtBxIPFTP.Text = row.Cells[7].Value.ToString();

                    if (row.Cells[8].Value != null)
                        txtBxUserFTP.Text = row.Cells[8].Value.ToString();

                    if (row.Cells[9].Value != null)
                        txtBxPassFTP.Text = row.Cells[9].Value.ToString();

                    if (row.Cells[10].Value != null)
                        txtBxDirectorioFTP.Text = row.Cells[10].Value.ToString();

                    if (row.Cells[11].Value != null)
                    {
                        string seguro = row.Cells[11].Value.ToString();
                        if (seguro == "True")
                        {
                            comboBox1.SelectedIndex = 0;
                        }
                        else
                        {
                            comboBox1.SelectedIndex = 1;
                        }
                    }

                    if (row.Cells[12].Value != null)
                        txtBxPuerto.Text = row.Cells[12].Value.ToString();

                    if (row.Cells[13].Value != null)
                    {
                        string adjunto = row.Cells[13].Value.ToString();
                        if (adjunto == "True")
                        {
                            comboBox2.SelectedIndex = 0;
                        }
                        else
                        {
                            comboBox2.SelectedIndex = 1;
                        }
                    }

                    if (row.Cells[14].Value != null)
                        txtEnvioPDF.Text = row.Cells[14].Value.ToString();

                    if (row.Cells[16].Value != null)
                    {
                        comboBoxOrigen.Text = row.Cells[16].Value.ToString() + "_" + row.Cells[17].Value.ToString();
                    }

                    if (row.Cells[18].Value != null)
                    {
                        bool valor = Convert.ToBoolean(row.Cells[18].Value);

                        if (valor == true)
                        {
                            checkBoxBenavides.Checked = true;
                        }
                        else
                        {
                            checkBoxBenavides.Checked = false;
                        }
                    }

                    if (row.Cells[19].Value != null)
                    {
                        bool valor = Convert.ToBoolean(row.Cells[19].Value);

                        if (valor == true)
                        {
                            checkBoxFANASA.Checked = true;
                        }
                        else
                        {
                            checkBoxFANASA.Checked = false;
                        }
                    }

                    if (row.Cells[20].Value != null)
                    {
                        bool valor = Convert.ToBoolean(row.Cells[20].Value);

                        if (valor == true)
                        {
                            checkBoxFESA.Checked = true;
                        }
                        else
                        {
                            checkBoxFESA.Checked = false;
                        }
                    }

                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (lblID.Text == "-")
            {
                if (txtBxField1.Text != ""  && txtBxExt.Text != "" && comboBoxOrigen.SelectedIndex != -1)
                {
                    if (txtBxDestino.Text != "" || txtBxDesFTPPaso.Text != "")
                    {
                        if (txtBxDestino.Text != "" && txtBxDesFTPPaso.Text == "")
                        {
                            if (comboBoxOrigen.SelectedIndex != -1)
                            {
                                COBDDataContext a = new COBDDataContext();


                                string idConfiguracionOrigen = comboBoxOrigen.SelectedItem.ToString();
                                string[] idCofig = idConfiguracionOrigen.Split('_');
                          

                            OrigenDatosFanasa n = new OrigenDatosFanasa();
                            n.Field1 = txtBxField1.Text;
                            n.Field2 = txtBxField2.Text;
                            n.Field3 = txtBxField3.Text;
                            n.Extension = txtBxExt.Text;
                            n.Destino = txtBxDestino.Text;
                            n.bBenavides = false;
                            n.bCarvajalFANASA = false;
                            n.bCarvajalFESA = false;
                            n.iRegistroConfigOrigen = Convert.ToInt32(idCofig[0].ToString());                           
                            a.OrigenDatosFanasa.InsertOnSubmit(n);
                            a.SubmitChanges();
                            limpiar();
                            getdatos();
                           }
                        }
                        else
                        {
                            if (txtBxDestino.Text == "" && txtBxDesFTPPaso.Text != "" && checkBoxBenavides.Checked == false)
                            {
                                if (txtBxIPFTP.Text != "" &&
                                    txtBxUserFTP.Text != "" &&
                                    txtBxPassFTP.Text != "" &&
                                    comboBox1.SelectedIndex != -1 &&
                                    txtBxPuerto.Text != "" &&
                                    comboBox2.SelectedIndex != -2)
                                {

                                    if (comboBoxOrigen.SelectedIndex != -1)
                                    {
                                        COBDDataContext a = new COBDDataContext();

                                        string idConfiguracionOrigen = comboBoxOrigen.SelectedItem.ToString();
                                        string[] idCofig = idConfiguracionOrigen.Split('_');

                                        OrigenDatosFanasa n = new OrigenDatosFanasa();
                                        n.Field1 = txtBxField1.Text;
                                        n.Field2 = txtBxField2.Text;
                                        n.Field3 = txtBxField3.Text;
                                        n.Extension = txtBxExt.Text;
                                        n.Destino = null;
                                        n.bBenavides = false;
                                        n.bCarvajalFANASA = false;
                                        n.bCarvajalFESA = false;
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
                                        if (comboBox2.SelectedIndex == 0)
                                        {
                                            n.AdjuntarArchivo = true;
                                        }
                                        else
                                        {
                                            n.AdjuntarArchivo = false;
                                        }
                                        n.EnvioPDF = txtEnvioPDF.Text;

                                        a.OrigenDatosFanasa.InsertOnSubmit(n);
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

                            else if (checkBoxBenavides.Checked)
                            {
                                if (txtBxDestino.Text != "" && txtBxDesFTPPaso.Text != ""
                                    && txtBxField1 != null)
                                {

                                    if (comboBoxOrigen.SelectedIndex != -1)
                                    {
                                        COBDDataContext a = new COBDDataContext();

                                        string idConfiguracionOrigen = comboBoxOrigen.SelectedItem.ToString();
                                        string[] idCofig = idConfiguracionOrigen.Split('_');

                                        OrigenDatosFanasa n = new OrigenDatosFanasa();
                                        n.Field1 = txtBxField1.Text;
                                        n.Field2 = txtBxField2.Text;
                                        n.Field3 = txtBxField3.Text;
                                        n.Extension = txtBxExt.Text;
                                        n.Destino = txtBxDestino.Text;
                                        n.DestinoFTPPaso = txtBxDesFTPPaso.Text;
                                        n.bBenavides = checkBoxBenavides.Checked;
                                        n.bCarvajalFANASA = false;
                                        n.bCarvajalFESA = false;
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
                                        if (comboBox2.SelectedIndex == 0)
                                        {
                                            n.AdjuntarArchivo = true;
                                        }
                                        else
                                        {
                                            n.AdjuntarArchivo = false;
                                        }                                      
                                        n.Puerto = txtBxPuerto.Text;
                                        n.iRegistroConfigOrigen = Convert.ToInt32(idCofig[0].ToString());
                                        a.OrigenDatosFanasa.InsertOnSubmit(n);
                                        a.SubmitChanges();
                                        limpiar();
                                        getdatos();
                                    }
                                    else
                                    {
                                        DialogResult result;
                                        result = MessageBox.Show("Debe seleccionar un origen de Benavides", "Error al guardar");
                                    }
                                }
                                else
                                {
                                    DialogResult result;
                                    result = MessageBox.Show("Debe de llenar todos los datos de configuracion FTP para Benavides", "Error al guardar");
                                }
                            }

                            else if (checkBoxFANASA.Checked)
                            {
                                if (txtBxDestino.Text != "" && txtBxDesFTPPaso.Text != ""
                                    && txtBxField1 != null)
                                {

                                    if (comboBoxOrigen.SelectedIndex != -1)
                                    {
                                        COBDDataContext a = new COBDDataContext();

                                        string idConfiguracionOrigen = comboBoxOrigen.SelectedItem.ToString();
                                        string[] idCofig = idConfiguracionOrigen.Split('_');

                                        OrigenDatosFanasa n = new OrigenDatosFanasa();
                                        n.Field1 = txtBxField1.Text;
                                        n.Field2 = txtBxField2.Text;
                                        n.Field3 = txtBxField3.Text;
                                        n.Extension = txtBxExt.Text;
                                        n.Destino = txtBxDestino.Text;
                                        n.DestinoFTPPaso = txtBxDesFTPPaso.Text;
                                        n.bCarvajalFANASA = checkBoxFANASA.Checked;
                                        n.bBenavides = false;
                                        n.bCarvajalFESA = false;
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
                                        if (comboBox2.SelectedIndex == 0)
                                        {
                                            n.AdjuntarArchivo = true;
                                        }
                                        else
                                        {
                                            n.AdjuntarArchivo = false;
                                        }
                                        n.Puerto = txtBxPuerto.Text;
                                        n.iRegistroConfigOrigen = Convert.ToInt32(idCofig[0].ToString());
                                        a.OrigenDatosFanasa.InsertOnSubmit(n);
                                        a.SubmitChanges();
                                        limpiar();
                                        getdatos();
                                    }
                                    else
                                    {
                                        DialogResult result;
                                        result = MessageBox.Show("Debe seleccionar un origen de Carvajal FANASA", "Error al guardar");
                                    }
                                }
                                else
                                {
                                    DialogResult result;
                                    result = MessageBox.Show("Debe de llenar todos los datos de configuracion SFTP para Carvajal FANASA", "Error al guardar");
                                }
                            }

                            else if (checkBoxFESA.Checked)
                            {
                                if (txtBxDestino.Text != "" && txtBxDesFTPPaso.Text != ""
                                    && txtBxField1 != null)
                                {

                                    if (comboBoxOrigen.SelectedIndex != -1)
                                    {
                                        COBDDataContext a = new COBDDataContext();

                                        string idConfiguracionOrigen = comboBoxOrigen.SelectedItem.ToString();
                                        string[] idCofig = idConfiguracionOrigen.Split('_');

                                        OrigenDatosFanasa n = new OrigenDatosFanasa();
                                        n.Field1 = txtBxField1.Text;
                                        n.Field2 = txtBxField2.Text;
                                        n.Field3 = txtBxField3.Text;
                                        n.Extension = txtBxExt.Text;
                                        n.Destino = txtBxDestino.Text;
                                        n.DestinoFTPPaso = txtBxDesFTPPaso.Text;
                                        n.bCarvajalFESA = checkBoxFESA.Checked;
                                        n.bBenavides = false;
                                        n.bCarvajalFANASA = false;
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
                                        if (comboBox2.SelectedIndex == 0)
                                        {
                                            n.AdjuntarArchivo = true;
                                        }
                                        else
                                        {
                                            n.AdjuntarArchivo = false;
                                        }
                                        n.Puerto = txtBxPuerto.Text;
                                        n.iRegistroConfigOrigen = Convert.ToInt32(idCofig[0].ToString());
                                        a.OrigenDatosFanasa.InsertOnSubmit(n);
                                        a.SubmitChanges();
                                        limpiar();
                                        getdatos();
                                    }
                                    else
                                    {
                                        DialogResult result;
                                        result = MessageBox.Show("Debe seleccionar un origen de Carvajal FESA", "Error al guardar");
                                    }
                                }
                                else
                                {
                                    DialogResult result;
                                    result = MessageBox.Show("Debe de llenar todos los datos de configuracion SFTP para Carvajal FESA", "Error al guardar");
                                }
                            }

                            else if (txtBxDestino.Text != "" && txtBxDesFTPPaso.Text != "")
                            {
                                if (txtBxIPFTP.Text != "" &&
                                    txtBxUserFTP.Text != "" &&
                                    txtBxPassFTP.Text != "" &&
                                    comboBox1.SelectedIndex != -1 &&
                                    txtBxPuerto.Text != "")
                                {

                                    if (comboBoxOrigen.SelectedIndex != -1)
                                    {
                                        COBDDataContext a = new COBDDataContext();

                                        string idConfiguracionOrigen = comboBoxOrigen.SelectedItem.ToString();
                                        string[] idCofig = idConfiguracionOrigen.Split('_');

                                        OrigenDatosFanasa n = new OrigenDatosFanasa();
                                        n.Field1 = txtBxField1.Text;
                                        n.Field2 = txtBxField2.Text;
                                        n.Field3 = txtBxField3.Text;
                                        n.Extension = txtBxExt.Text;
                                        n.Destino = txtBxDestino.Text;
                                        n.DestinoFTPPaso = txtBxDesFTPPaso.Text;
                                        n.bBenavides = false;
                                        n.bCarvajalFANASA = false;
                                        n.bCarvajalFESA = false;
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
                                        a.OrigenDatosFanasa.InsertOnSubmit(n);
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

                result = MessageBox.Show("¿ESTAS SEGURO QUE QUIERES BORRAR EL REGISTRO " + lblID.Text + "?", "ALERTA", buttons);
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    int id = Convert.ToInt32(lblID.Text);
                    var buscarcorreos = from c in a.CtlCorreosFanasa where c.IdOrigenDatosFanasa == id select c;
                    foreach (var item in buscarcorreos)
                    {
                        a.CtlCorreosFanasa.DeleteOnSubmit(item);
                        a.SubmitChanges();
                    }
                    var buscar = from c in a.OrigenDatosFanasa where c.IdOrigenDatos == id select c;
                    a.OrigenDatosFanasa.DeleteOnSubmit(buscar.First());
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
            CorreosOracleRenovado correosOracle = new CorreosOracleRenovado();
            correosOracle.Show();
        }

        private void configuraciónOrigenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Origen origen = new Origen();
            origen.Show();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkBoxBenavides_Click(object sender, EventArgs e)
        {

            txtBxDesFTPPaso.Text = @"C:\FTP_PASO";
            txtBxDirectorioFTP.Text = "/";
            txtBxPuerto.Text = "21";

        }

        private void checkBoxFANASA_Click(object sender, EventArgs e)
        {
            txtBxDesFTPPaso.Text = @"C:\FTP_PASO";
            txtBxDirectorioFTP.Text = "/";
            txtBxPuerto.Text = "21";
        }

        private void checkBoxFESA_Click(object sender, EventArgs e)
        {
            txtBxDesFTPPaso.Text = @"C:\FTP_PASO";
            txtBxDirectorioFTP.Text = "/";
            txtBxPuerto.Text = "21";
        }
    }
}
