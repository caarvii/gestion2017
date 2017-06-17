namespace UberFrba.Abm_Automovil
{
    partial class frmCrearAutomovil
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbMarca = new System.Windows.Forms.ComboBox();
            this.txtModelo = new System.Windows.Forms.TextBox();
            this.txtPatente = new System.Windows.Forms.TextBox();
            this.cmbTurno = new System.Windows.Forms.ComboBox();
            this.cmbChofer = new System.Windows.Forms.ComboBox();
            this.btnCrearAutomovil = new System.Windows.Forms.Button();
            this.txtLicencia = new System.Windows.Forms.TextBox();
            this.Licencia = new System.Windows.Forms.Label();
            this.cmbModelo = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(91, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Marca";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(91, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Modelo";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(91, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Patente";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(91, 149);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Turno";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(91, 179);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Chofer";
            // 
            // cmbMarca
            // 
            this.cmbMarca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMarca.FormattingEnabled = true;
            this.cmbMarca.Location = new System.Drawing.Point(149, 38);
            this.cmbMarca.Name = "cmbMarca";
            this.cmbMarca.Size = new System.Drawing.Size(160, 21);
            this.cmbMarca.TabIndex = 5;
            this.cmbMarca.SelectedIndexChanged += new System.EventHandler(this.cmbMarca_SelectedIndexChanged);
            // 
            // txtModelo
            // 
            this.txtModelo.Location = new System.Drawing.Point(149, 66);
            this.txtModelo.Name = "txtModelo";
            this.txtModelo.Size = new System.Drawing.Size(160, 20);
            this.txtModelo.TabIndex = 6;
            // 
            // txtPatente
            // 
            this.txtPatente.Location = new System.Drawing.Point(149, 93);
            this.txtPatente.Name = "txtPatente";
            this.txtPatente.Size = new System.Drawing.Size(160, 20);
            this.txtPatente.TabIndex = 7;
            this.txtPatente.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPatente_KeyPress);
            // 
            // cmbTurno
            // 
            this.cmbTurno.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTurno.FormattingEnabled = true;
            this.cmbTurno.Location = new System.Drawing.Point(149, 146);
            this.cmbTurno.Name = "cmbTurno";
            this.cmbTurno.Size = new System.Drawing.Size(160, 21);
            this.cmbTurno.TabIndex = 8;
            // 
            // cmbChofer
            // 
            this.cmbChofer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbChofer.FormattingEnabled = true;
            this.cmbChofer.Location = new System.Drawing.Point(149, 176);
            this.cmbChofer.Name = "cmbChofer";
            this.cmbChofer.Size = new System.Drawing.Size(160, 21);
            this.cmbChofer.TabIndex = 9;
            // 
            // btnCrearAutomovil
            // 
            this.btnCrearAutomovil.Location = new System.Drawing.Point(222, 285);
            this.btnCrearAutomovil.Name = "btnCrearAutomovil";
            this.btnCrearAutomovil.Size = new System.Drawing.Size(87, 23);
            this.btnCrearAutomovil.TabIndex = 10;
            this.btnCrearAutomovil.Text = "Crear";
            this.btnCrearAutomovil.UseVisualStyleBackColor = true;
            this.btnCrearAutomovil.Click += new System.EventHandler(this.btnCrearAutomovil_Click);
            // 
            // txtLicencia
            // 
            this.txtLicencia.Location = new System.Drawing.Point(149, 120);
            this.txtLicencia.Name = "txtLicencia";
            this.txtLicencia.Size = new System.Drawing.Size(160, 20);
            this.txtLicencia.TabIndex = 11;
            // 
            // Licencia
            // 
            this.Licencia.AutoSize = true;
            this.Licencia.Location = new System.Drawing.Point(88, 123);
            this.Licencia.Name = "Licencia";
            this.Licencia.Size = new System.Drawing.Size(47, 13);
            this.Licencia.TabIndex = 12;
            this.Licencia.Text = "Licencia";
            // 
            // cmbModelo
            // 
            this.cmbModelo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbModelo.FormattingEnabled = true;
            this.cmbModelo.Location = new System.Drawing.Point(322, 69);
            this.cmbModelo.Name = "cmbModelo";
            this.cmbModelo.Size = new System.Drawing.Size(160, 21);
            this.cmbModelo.TabIndex = 13;
            this.cmbModelo.SelectedIndexChanged += new System.EventHandler(this.cmbModelo_SelectedIndexChanged);
            // 
            // frmCrearAutomovil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 334);
            this.Controls.Add(this.cmbModelo);
            this.Controls.Add(this.Licencia);
            this.Controls.Add(this.txtLicencia);
            this.Controls.Add(this.btnCrearAutomovil);
            this.Controls.Add(this.cmbChofer);
            this.Controls.Add(this.cmbTurno);
            this.Controls.Add(this.txtPatente);
            this.Controls.Add(this.txtModelo);
            this.Controls.Add(this.cmbMarca);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmCrearAutomovil";
            this.Text = "crearAutomovil";
            this.Load += new System.EventHandler(this.frmCrearAutomovil_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbMarca;
        private System.Windows.Forms.TextBox txtModelo;
        private System.Windows.Forms.TextBox txtPatente;
        private System.Windows.Forms.ComboBox cmbTurno;
        private System.Windows.Forms.ComboBox cmbChofer;
        private System.Windows.Forms.Button btnCrearAutomovil;
        private System.Windows.Forms.TextBox txtLicencia;
        private System.Windows.Forms.Label Licencia;
        private System.Windows.Forms.ComboBox cmbModelo;
    }
}