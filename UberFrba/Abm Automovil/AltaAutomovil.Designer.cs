namespace UberFrba.Abm_Automovil
{
    partial class AltaAutomovil
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
            this.txtPatente = new System.Windows.Forms.TextBox();
            this.btnCrearAutomovil = new System.Windows.Forms.Button();
            this.txtLicencia = new System.Windows.Forms.TextBox();
            this.Licencia = new System.Windows.Forms.Label();
            this.txtTurnoDescripcion = new System.Windows.Forms.TextBox();
            this.txtChoferDni = new System.Windows.Forms.TextBox();
            this.cmdSeleccionarTurno = new System.Windows.Forms.Button();
            this.cmdSeleccionarChofer = new System.Windows.Forms.Button();
            this.cmbModelo = new System.Windows.Forms.ComboBox();
            this.txtTurnoHoraInicio = new System.Windows.Forms.TextBox();
            this.txtTurnoHoraFin = new System.Windows.Forms.TextBox();
            this.txtChoferNombreCompleto = new System.Windows.Forms.TextBox();
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
            this.label4.Location = new System.Drawing.Point(88, 153);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Turno";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(90, 179);
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
            this.cmbMarca.Size = new System.Drawing.Size(140, 21);
            this.cmbMarca.TabIndex = 5;
            // 
            // txtPatente
            // 
            this.txtPatente.Location = new System.Drawing.Point(148, 94);
            this.txtPatente.Name = "txtPatente";
            this.txtPatente.Size = new System.Drawing.Size(141, 20);
            this.txtPatente.TabIndex = 7;
            this.txtPatente.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPatente_KeyPress);
            // 
            // btnCrearAutomovil
            // 
            this.btnCrearAutomovil.Location = new System.Drawing.Point(202, 202);
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
            this.txtLicencia.Size = new System.Drawing.Size(140, 20);
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
            // txtTurnoDescripcion
            // 
            this.txtTurnoDescripcion.Enabled = false;
            this.txtTurnoDescripcion.Location = new System.Drawing.Point(149, 149);
            this.txtTurnoDescripcion.Name = "txtTurnoDescripcion";
            this.txtTurnoDescripcion.Size = new System.Drawing.Size(78, 20);
            this.txtTurnoDescripcion.TabIndex = 14;
            // 
            // txtChoferDni
            // 
            this.txtChoferDni.Enabled = false;
            this.txtChoferDni.Location = new System.Drawing.Point(149, 176);
            this.txtChoferDni.Name = "txtChoferDni";
            this.txtChoferDni.Size = new System.Drawing.Size(52, 20);
            this.txtChoferDni.TabIndex = 15;
            // 
            // cmdSeleccionarTurno
            // 
            this.cmdSeleccionarTurno.Location = new System.Drawing.Point(321, 150);
            this.cmdSeleccionarTurno.Name = "cmdSeleccionarTurno";
            this.cmdSeleccionarTurno.Size = new System.Drawing.Size(111, 19);
            this.cmdSeleccionarTurno.TabIndex = 16;
            this.cmdSeleccionarTurno.Text = "Seleccionar turno";
            this.cmdSeleccionarTurno.UseVisualStyleBackColor = true;
            this.cmdSeleccionarTurno.Click += new System.EventHandler(this.cmdSeleccionarTurno_Click);
            // 
            // cmdSeleccionarChofer
            // 
            this.cmdSeleccionarChofer.Location = new System.Drawing.Point(321, 176);
            this.cmdSeleccionarChofer.Name = "cmdSeleccionarChofer";
            this.cmdSeleccionarChofer.Size = new System.Drawing.Size(111, 20);
            this.cmdSeleccionarChofer.TabIndex = 17;
            this.cmdSeleccionarChofer.Text = "Seleccionar chofer";
            this.cmdSeleccionarChofer.UseVisualStyleBackColor = true;
            this.cmdSeleccionarChofer.Click += new System.EventHandler(this.cmdSeleccionarChofer_Click);
            // 
            // cmbModelo
            // 
            this.cmbModelo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbModelo.FormattingEnabled = true;
            this.cmbModelo.Location = new System.Drawing.Point(149, 65);
            this.cmbModelo.Name = "cmbModelo";
            this.cmbModelo.Size = new System.Drawing.Size(140, 21);
            this.cmbModelo.TabIndex = 18;
            // 
            // txtTurnoHoraInicio
            // 
            this.txtTurnoHoraInicio.Enabled = false;
            this.txtTurnoHoraInicio.Location = new System.Drawing.Point(233, 149);
            this.txtTurnoHoraInicio.Name = "txtTurnoHoraInicio";
            this.txtTurnoHoraInicio.Size = new System.Drawing.Size(25, 20);
            this.txtTurnoHoraInicio.TabIndex = 19;
            // 
            // txtTurnoHoraFin
            // 
            this.txtTurnoHoraFin.Enabled = false;
            this.txtTurnoHoraFin.Location = new System.Drawing.Point(264, 149);
            this.txtTurnoHoraFin.Name = "txtTurnoHoraFin";
            this.txtTurnoHoraFin.Size = new System.Drawing.Size(25, 20);
            this.txtTurnoHoraFin.TabIndex = 20;
            // 
            // txtChoferNombreCompleto
            // 
            this.txtChoferNombreCompleto.Enabled = false;
            this.txtChoferNombreCompleto.Location = new System.Drawing.Point(207, 175);
            this.txtChoferNombreCompleto.Name = "txtChoferNombreCompleto";
            this.txtChoferNombreCompleto.Size = new System.Drawing.Size(82, 20);
            this.txtChoferNombreCompleto.TabIndex = 21;
            // 
            // AltaAutomovil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(527, 334);
            this.Controls.Add(this.txtChoferNombreCompleto);
            this.Controls.Add(this.txtTurnoHoraFin);
            this.Controls.Add(this.txtTurnoHoraInicio);
            this.Controls.Add(this.cmbModelo);
            this.Controls.Add(this.cmdSeleccionarChofer);
            this.Controls.Add(this.cmdSeleccionarTurno);
            this.Controls.Add(this.txtChoferDni);
            this.Controls.Add(this.txtTurnoDescripcion);
            this.Controls.Add(this.Licencia);
            this.Controls.Add(this.txtLicencia);
            this.Controls.Add(this.btnCrearAutomovil);
            this.Controls.Add(this.txtPatente);
            this.Controls.Add(this.cmbMarca);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "AltaAutomovil";
            this.Text = "AltaAutomovil";
            this.Load += new System.EventHandler(this.AltaAutomovil_Load);
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
        private System.Windows.Forms.TextBox txtPatente;
        private System.Windows.Forms.Button btnCrearAutomovil;
        private System.Windows.Forms.TextBox txtLicencia;
        private System.Windows.Forms.Label Licencia;
        private System.Windows.Forms.TextBox txtTurnoDescripcion;
        private System.Windows.Forms.TextBox txtChoferDni;
        private System.Windows.Forms.Button cmdSeleccionarTurno;
        private System.Windows.Forms.Button cmdSeleccionarChofer;
        private System.Windows.Forms.ComboBox cmbModelo;
        private System.Windows.Forms.TextBox txtTurnoHoraInicio;
        private System.Windows.Forms.TextBox txtTurnoHoraFin;
        private System.Windows.Forms.TextBox txtChoferNombreCompleto;
    }
}