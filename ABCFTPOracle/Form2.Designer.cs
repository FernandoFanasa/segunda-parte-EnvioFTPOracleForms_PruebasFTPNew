namespace ABCFTPOracle
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.correosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.insertarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.envioFTPOracleDataSet = new ABCFTPOracle.EnvioFTPOracleDataSet();
            this.origenDatosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.origenDatosTableAdapter = new ABCFTPOracle.EnvioFTPOracleDataSetTableAdapters.OrigenDatosTableAdapter();
            this.button1 = new System.Windows.Forms.Button();
            this.origenDatosBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.txtBxLab = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBxUserFTP = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBxTipo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBxPassFTP = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtBxExt = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtBxDirectorioFTP = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtBxDestino = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtBxDesFTPPaso = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtBxPuerto = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtBxIPFTP = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.lblID = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtEnvioPDF = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.envioFTPOracleDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.origenDatosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.origenDatosBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1100, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.correosToolStripMenuItem,
            this.insertarToolStripMenuItem,
            this.salirToolStripMenuItem});
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.menuToolStripMenuItem.Text = "Menu";
            // 
            // correosToolStripMenuItem
            // 
            this.correosToolStripMenuItem.Name = "correosToolStripMenuItem";
            this.correosToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.correosToolStripMenuItem.Text = "Correos";
            this.correosToolStripMenuItem.Click += new System.EventHandler(this.correosToolStripMenuItem_Click);
            // 
            // insertarToolStripMenuItem
            // 
            this.insertarToolStripMenuItem.Name = "insertarToolStripMenuItem";
            this.insertarToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.insertarToolStripMenuItem.Text = "Menu Inicial";
            this.insertarToolStripMenuItem.Click += new System.EventHandler(this.insertarToolStripMenuItem_Click);
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.salirToolStripMenuItem.Text = "Salir";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(31, 72);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(1040, 150);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // envioFTPOracleDataSet
            // 
            this.envioFTPOracleDataSet.DataSetName = "EnvioFTPOracleDataSet";
            this.envioFTPOracleDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // origenDatosBindingSource
            // 
            this.origenDatosBindingSource.DataMember = "OrigenDatos";
            this.origenDatosBindingSource.DataSource = this.envioFTPOracleDataSet;
            // 
            // origenDatosTableAdapter
            // 
            this.origenDatosTableAdapter.ClearBeforeFill = true;
            // 
            // button1
            // 
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(944, 330);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(127, 59);
            this.button1.TabIndex = 2;
            this.button1.Text = "ACTUALIZAR";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // origenDatosBindingSource1
            // 
            this.origenDatosBindingSource1.DataMember = "OrigenDatos";
            this.origenDatosBindingSource1.DataSource = this.envioFTPOracleDataSet;
            // 
            // txtBxLab
            // 
            this.txtBxLab.Location = new System.Drawing.Point(107, 254);
            this.txtBxLab.Name = "txtBxLab";
            this.txtBxLab.Size = new System.Drawing.Size(185, 20);
            this.txtBxLab.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(41, 257);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "IdLaboratorio";
            // 
            // txtBxUserFTP
            // 
            this.txtBxUserFTP.Location = new System.Drawing.Point(639, 256);
            this.txtBxUserFTP.Name = "txtBxUserFTP";
            this.txtBxUserFTP.Size = new System.Drawing.Size(185, 20);
            this.txtBxUserFTP.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(573, 259);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "UserFTP";
            // 
            // txtBxTipo
            // 
            this.txtBxTipo.Location = new System.Drawing.Point(107, 295);
            this.txtBxTipo.Name = "txtBxTipo";
            this.txtBxTipo.Size = new System.Drawing.Size(185, 20);
            this.txtBxTipo.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(41, 298);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Tipo";
            // 
            // txtBxPassFTP
            // 
            this.txtBxPassFTP.Location = new System.Drawing.Point(639, 297);
            this.txtBxPassFTP.Name = "txtBxPassFTP";
            this.txtBxPassFTP.Size = new System.Drawing.Size(185, 20);
            this.txtBxPassFTP.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(573, 300);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "PassFTP";
            // 
            // txtBxExt
            // 
            this.txtBxExt.Location = new System.Drawing.Point(107, 335);
            this.txtBxExt.Name = "txtBxExt";
            this.txtBxExt.Size = new System.Drawing.Size(185, 20);
            this.txtBxExt.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(41, 338);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Extension";
            // 
            // txtBxDirectorioFTP
            // 
            this.txtBxDirectorioFTP.Location = new System.Drawing.Point(639, 338);
            this.txtBxDirectorioFTP.Name = "txtBxDirectorioFTP";
            this.txtBxDirectorioFTP.Size = new System.Drawing.Size(267, 20);
            this.txtBxDirectorioFTP.TabIndex = 16;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(565, 341);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "DirectorioFTP";
            // 
            // txtBxDestino
            // 
            this.txtBxDestino.Location = new System.Drawing.Point(107, 379);
            this.txtBxDestino.Name = "txtBxDestino";
            this.txtBxDestino.Size = new System.Drawing.Size(310, 20);
            this.txtBxDestino.TabIndex = 18;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(41, 382);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "Destino";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(573, 384);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(61, 13);
            this.label8.TabIndex = 19;
            this.label8.Text = "FTPSeguro";
            // 
            // txtBxDesFTPPaso
            // 
            this.txtBxDesFTPPaso.Location = new System.Drawing.Point(107, 417);
            this.txtBxDesFTPPaso.Name = "txtBxDesFTPPaso";
            this.txtBxDesFTPPaso.Size = new System.Drawing.Size(310, 20);
            this.txtBxDesFTPPaso.TabIndex = 22;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(18, 420);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(87, 13);
            this.label9.TabIndex = 21;
            this.label9.Text = "DestinoFTPPaso";
            // 
            // txtBxPuerto
            // 
            this.txtBxPuerto.Location = new System.Drawing.Point(639, 419);
            this.txtBxPuerto.Name = "txtBxPuerto";
            this.txtBxPuerto.Size = new System.Drawing.Size(185, 20);
            this.txtBxPuerto.TabIndex = 24;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(573, 422);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(38, 13);
            this.label10.TabIndex = 23;
            this.label10.Text = "Puerto";
            // 
            // txtBxIPFTP
            // 
            this.txtBxIPFTP.Location = new System.Drawing.Point(107, 451);
            this.txtBxIPFTP.Name = "txtBxIPFTP";
            this.txtBxIPFTP.Size = new System.Drawing.Size(185, 20);
            this.txtBxIPFTP.TabIndex = 26;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(41, 454);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(37, 13);
            this.label11.TabIndex = 25;
            this.label11.Text = "IPFTP";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "SI",
            "NO"});
            this.comboBox1.Location = new System.Drawing.Point(639, 377);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 27;
            this.comboBox1.Text = "Seleccionar";
            // 
            // button2
            // 
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(944, 249);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(127, 59);
            this.button2.TabIndex = 28;
            this.button2.Text = "NUEVO";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Image = ((System.Drawing.Image)(resources.GetObject("button3.Image")));
            this.button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button3.Location = new System.Drawing.Point(944, 413);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(127, 60);
            this.button3.TabIndex = 29;
            this.button3.Text = "BORRAR";
            this.button3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(574, 486);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(18, 13);
            this.label12.TabIndex = 30;
            this.label12.Text = "ID";
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(637, 487);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(10, 13);
            this.lblID.TabIndex = 31;
            this.lblID.Text = "-";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(245, 24);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(628, 39);
            this.label13.TabIndex = 32;
            this.label13.Text = "Altas, Bajas, Cambios Envio FTP Oracle";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(552, 458);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(85, 13);
            this.label14.TabIndex = 33;
            this.label14.Text = "Adjuntar Archivo";
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "SI",
            "NO"});
            this.comboBox2.Location = new System.Drawing.Point(639, 455);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(121, 21);
            this.comboBox2.TabIndex = 34;
            this.comboBox2.Text = "Seleccionar";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(36, 487);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(58, 13);
            this.label15.TabIndex = 35;
            this.label15.Text = "Envio PDF";
            // 
            // txtEnvioPDF
            // 
            this.txtEnvioPDF.Location = new System.Drawing.Point(107, 484);
            this.txtEnvioPDF.Name = "txtEnvioPDF";
            this.txtEnvioPDF.Size = new System.Drawing.Size(185, 20);
            this.txtEnvioPDF.TabIndex = 36;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 522);
            this.Controls.Add(this.txtEnvioPDF);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.lblID);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.txtBxIPFTP);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtBxPuerto);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtBxDesFTPPaso);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtBxDestino);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtBxDirectorioFTP);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtBxExt);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtBxPassFTP);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtBxTipo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtBxUserFTP);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtBxLab);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximumSize = new System.Drawing.Size(1116, 561);
            this.MinimumSize = new System.Drawing.Size(1116, 561);
            this.Name = "Form2";
            this.Text = "Envio FTP Oracle OneDrive";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.envioFTPOracleDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.origenDatosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.origenDatosBindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem insertarToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridView1;
        private EnvioFTPOracleDataSet envioFTPOracleDataSet;
        private System.Windows.Forms.BindingSource origenDatosBindingSource;
        private EnvioFTPOracleDataSetTableAdapters.OrigenDatosTableAdapter origenDatosTableAdapter;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.BindingSource origenDatosBindingSource1;
        private System.Windows.Forms.TextBox txtBxLab;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBxUserFTP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBxTipo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtBxPassFTP;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtBxExt;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtBxDirectorioFTP;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtBxDestino;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtBxDesFTPPaso;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtBxPuerto;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtBxIPFTP;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem correosToolStripMenuItem;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtEnvioPDF;
    }
}