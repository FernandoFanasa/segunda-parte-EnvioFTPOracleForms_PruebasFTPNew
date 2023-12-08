
namespace ABCFTPOracle
{
    public partial class ClientesFANASA
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClientesFANASA));
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menúInicialToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.origenFANASAToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1Titulo = new System.Windows.Forms.Label();
            this.dataGridViewClientesFANASA = new System.Windows.Forms.DataGridView();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.lblID = new System.Windows.Forms.Label();
            this.label7ID = new System.Windows.Forms.Label();
            this.txtBxDestino = new System.Windows.Forms.TextBox();
            this.label5Destino = new System.Windows.Forms.Label();
            this.txtBxExt = new System.Windows.Forms.TextBox();
            this.label4_Extencion = new System.Windows.Forms.Label();
            this.txtBxField2 = new System.Windows.Forms.TextBox();
            this.label2_Documento2 = new System.Windows.Forms.Label();
            this.label1_Documento1 = new System.Windows.Forms.Label();
            this.txtBxField1 = new System.Windows.Forms.TextBox();
            this.txtBxDestinoRespaldo = new System.Windows.Forms.TextBox();
            this.label6DEstinoRespaldo = new System.Windows.Forms.Label();
            this.comboBoxOrigen = new System.Windows.Forms.ComboBox();
            this.label17Config_Origen = new System.Windows.Forms.Label();
            this.lblID2 = new System.Windows.Forms.Label();
            this.correosClientesFANASAToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewClientesFANASA)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip2
            // 
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem});
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(950, 24);
            this.menuStrip2.TabIndex = 2;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menúInicialToolStripMenuItem,
            this.origenFANASAToolStripMenuItem,
            this.correosClientesFANASAToolStripMenuItem,
            this.salisToolStripMenuItem});
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.menuToolStripMenuItem.Text = "Menu";
            // 
            // menúInicialToolStripMenuItem
            // 
            this.menúInicialToolStripMenuItem.Name = "menúInicialToolStripMenuItem";
            this.menúInicialToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.menúInicialToolStripMenuItem.Text = "Menu Inicial";
            this.menúInicialToolStripMenuItem.Click += new System.EventHandler(this.menúInicialToolStripMenuItem_Click_1);
            // 
            // origenFANASAToolStripMenuItem
            // 
            this.origenFANASAToolStripMenuItem.Name = "origenFANASAToolStripMenuItem";
            this.origenFANASAToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.origenFANASAToolStripMenuItem.Text = "Origen FANASA";
            this.origenFANASAToolStripMenuItem.Click += new System.EventHandler(this.origenFANASAToolStripMenuItem_Click);
            // 
            // salisToolStripMenuItem
            // 
            this.salisToolStripMenuItem.Name = "salisToolStripMenuItem";
            this.salisToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.salisToolStripMenuItem.Text = "Salir";
            this.salisToolStripMenuItem.Click += new System.EventHandler(this.salisToolStripMenuItem_Click_1);
            // 
            // label1Titulo
            // 
            this.label1Titulo.AutoSize = true;
            this.label1Titulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 24.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1Titulo.Location = new System.Drawing.Point(225, 33);
            this.label1Titulo.Name = "label1Titulo";
            this.label1Titulo.Size = new System.Drawing.Size(276, 38);
            this.label1Titulo.TabIndex = 3;
            this.label1Titulo.Text = "Clientes FANASA";
            // 
            // dataGridViewClientesFANASA
            // 
            this.dataGridViewClientesFANASA.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewClientesFANASA.Location = new System.Drawing.Point(12, 85);
            this.dataGridViewClientesFANASA.Name = "dataGridViewClientesFANASA";
            this.dataGridViewClientesFANASA.Size = new System.Drawing.Size(770, 150);
            this.dataGridViewClientesFANASA.TabIndex = 36;
            this.dataGridViewClientesFANASA.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewClientesFANASA_CellContentClick);
            // 
            // button3
            // 
            this.button3.Image = ((System.Drawing.Image)(resources.GetObject("button3.Image")));
            this.button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button3.Location = new System.Drawing.Point(801, 340);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(127, 60);
            this.button3.TabIndex = 67;
            this.button3.Text = "BORRAR";
            this.button3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // button2
            // 
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(801, 176);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(127, 59);
            this.button2.TabIndex = 65;
            this.button2.Text = "NUEVO";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // button1
            // 
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(801, 257);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(127, 59);
            this.button1.TabIndex = 66;
            this.button1.Text = "ACTUALIZAR";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(479, 392);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(10, 13);
            this.lblID.TabIndex = 64;
            this.lblID.Text = "-";
            // 
            // label7ID
            // 
            this.label7ID.AutoSize = true;
            this.label7ID.Location = new System.Drawing.Point(442, 387);
            this.label7ID.Name = "label7ID";
            this.label7ID.Size = new System.Drawing.Size(18, 13);
            this.label7ID.TabIndex = 63;
            this.label7ID.Text = "ID";
            // 
            // txtBxDestino
            // 
            this.txtBxDestino.Location = new System.Drawing.Point(445, 265);
            this.txtBxDestino.Name = "txtBxDestino";
            this.txtBxDestino.Size = new System.Drawing.Size(323, 20);
            this.txtBxDestino.TabIndex = 60;
            // 
            // label5Destino
            // 
            this.label5Destino.AutoSize = true;
            this.label5Destino.Location = new System.Drawing.Point(373, 265);
            this.label5Destino.Name = "label5Destino";
            this.label5Destino.Size = new System.Drawing.Size(43, 13);
            this.label5Destino.TabIndex = 59;
            this.label5Destino.Text = "Destino";
            // 
            // txtBxExt
            // 
            this.txtBxExt.Location = new System.Drawing.Point(73, 340);
            this.txtBxExt.Name = "txtBxExt";
            this.txtBxExt.Size = new System.Drawing.Size(213, 20);
            this.txtBxExt.TabIndex = 58;
            // 
            // label4_Extencion
            // 
            this.label4_Extencion.AutoSize = true;
            this.label4_Extencion.Location = new System.Drawing.Point(15, 346);
            this.label4_Extencion.Name = "label4_Extencion";
            this.label4_Extencion.Size = new System.Drawing.Size(53, 13);
            this.label4_Extencion.TabIndex = 57;
            this.label4_Extencion.Text = "Extensión";
            // 
            // txtBxField2
            // 
            this.txtBxField2.Location = new System.Drawing.Point(73, 298);
            this.txtBxField2.Name = "txtBxField2";
            this.txtBxField2.Size = new System.Drawing.Size(213, 20);
            this.txtBxField2.TabIndex = 56;
            // 
            // label2_Documento2
            // 
            this.label2_Documento2.AutoSize = true;
            this.label2_Documento2.Location = new System.Drawing.Point(15, 298);
            this.label2_Documento2.Name = "label2_Documento2";
            this.label2_Documento2.Size = new System.Drawing.Size(38, 13);
            this.label2_Documento2.TabIndex = 55;
            this.label2_Documento2.Text = "Field 2";
            // 
            // label1_Documento1
            // 
            this.label1_Documento1.AutoSize = true;
            this.label1_Documento1.Location = new System.Drawing.Point(15, 265);
            this.label1_Documento1.Name = "label1_Documento1";
            this.label1_Documento1.Size = new System.Drawing.Size(38, 13);
            this.label1_Documento1.TabIndex = 53;
            this.label1_Documento1.Text = "Field 1";
            // 
            // txtBxField1
            // 
            this.txtBxField1.Location = new System.Drawing.Point(73, 258);
            this.txtBxField1.Name = "txtBxField1";
            this.txtBxField1.Size = new System.Drawing.Size(213, 20);
            this.txtBxField1.TabIndex = 68;
            // 
            // txtBxDestinoRespaldo
            // 
            this.txtBxDestinoRespaldo.Location = new System.Drawing.Point(462, 302);
            this.txtBxDestinoRespaldo.Name = "txtBxDestinoRespaldo";
            this.txtBxDestinoRespaldo.Size = new System.Drawing.Size(310, 20);
            this.txtBxDestinoRespaldo.TabIndex = 110;
            // 
            // label6DEstinoRespaldo
            // 
            this.label6DEstinoRespaldo.AutoSize = true;
            this.label6DEstinoRespaldo.Location = new System.Drawing.Point(365, 305);
            this.label6DEstinoRespaldo.Name = "label6DEstinoRespaldo";
            this.label6DEstinoRespaldo.Size = new System.Drawing.Size(91, 13);
            this.label6DEstinoRespaldo.TabIndex = 111;
            this.label6DEstinoRespaldo.Text = "Destino Respaldo";
            // 
            // comboBoxOrigen
            // 
            this.comboBoxOrigen.FormattingEnabled = true;
            this.comboBoxOrigen.Location = new System.Drawing.Point(124, 384);
            this.comboBoxOrigen.Name = "comboBoxOrigen";
            this.comboBoxOrigen.Size = new System.Drawing.Size(287, 21);
            this.comboBoxOrigen.TabIndex = 115;
            // 
            // label17Config_Origen
            // 
            this.label17Config_Origen.AutoSize = true;
            this.label17Config_Origen.Location = new System.Drawing.Point(12, 387);
            this.label17Config_Origen.Name = "label17Config_Origen";
            this.label17Config_Origen.Size = new System.Drawing.Size(109, 13);
            this.label17Config_Origen.TabIndex = 114;
            this.label17Config_Origen.Text = "Configuración Origen ";
            // 
            // lblID2
            // 
            this.lblID2.AutoSize = true;
            this.lblID2.Location = new System.Drawing.Point(491, 387);
            this.lblID2.Name = "lblID2";
            this.lblID2.Size = new System.Drawing.Size(10, 13);
            this.lblID2.TabIndex = 134;
            this.lblID2.Text = "-";
            // 
            // correosClientesFANASAToolStripMenuItem
            // 
            this.correosClientesFANASAToolStripMenuItem.Name = "correosClientesFANASAToolStripMenuItem";
            this.correosClientesFANASAToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.correosClientesFANASAToolStripMenuItem.Text = "Correos Clientes FANASA";
            this.correosClientesFANASAToolStripMenuItem.Click += new System.EventHandler(this.correosClientesFANASAToolStripMenuItem_Click);
            // 
            // ClientesFANASA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(950, 450);
            this.Controls.Add(this.lblID2);
            this.Controls.Add(this.comboBoxOrigen);
            this.Controls.Add(this.label17Config_Origen);
            this.Controls.Add(this.txtBxDestinoRespaldo);
            this.Controls.Add(this.label6DEstinoRespaldo);
            this.Controls.Add(this.txtBxField1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label7ID);
            this.Controls.Add(this.txtBxDestino);
            this.Controls.Add(this.label5Destino);
            this.Controls.Add(this.txtBxExt);
            this.Controls.Add(this.label4_Extencion);
            this.Controls.Add(this.txtBxField2);
            this.Controls.Add(this.label2_Documento2);
            this.Controls.Add(this.label1_Documento1);
            this.Controls.Add(this.dataGridViewClientesFANASA);
            this.Controls.Add(this.label1Titulo);
            this.Controls.Add(this.menuStrip2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ClientesFANASA";
            this.Text = "ClientesFANASA";
            this.Load += new System.EventHandler(this.ClientesFANSA_Load);
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewClientesFANASA)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menúInicialToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salisToolStripMenuItem;
        private System.Windows.Forms.Label label1Titulo;
        private System.Windows.Forms.DataGridView dataGridViewClientesFANASA;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Label label7ID;
        private System.Windows.Forms.TextBox txtBxDestino;
        private System.Windows.Forms.Label label5Destino;
        private System.Windows.Forms.TextBox txtBxExt;
        private System.Windows.Forms.Label label4_Extencion;
        private System.Windows.Forms.TextBox txtBxField2;
        private System.Windows.Forms.Label label2_Documento2;
        private System.Windows.Forms.Label label1_Documento1;
        private System.Windows.Forms.TextBox txtBxField1;
        private System.Windows.Forms.TextBox txtBxDestinoRespaldo;
        private System.Windows.Forms.Label label6DEstinoRespaldo;
        private System.Windows.Forms.ComboBox comboBoxOrigen;
        private System.Windows.Forms.Label label17Config_Origen;
        private System.Windows.Forms.Label lblID2;
        private System.Windows.Forms.ToolStripMenuItem origenFANASAToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem correosClientesFANASAToolStripMenuItem;
    }
}