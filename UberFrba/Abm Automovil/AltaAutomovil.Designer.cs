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
            this.label5 = new System.Windows.Forms.Label();
            this.cmbMarca = new System.Windows.Forms.ComboBox();
            this.txtPatente = new System.Windows.Forms.TextBox();
            this.btnCrearAutomovil = new System.Windows.Forms.Button();
            this.txtLicencia = new System.Windows.Forms.TextBox();
            this.Licencia = new System.Windows.Forms.Label();
            this.txtChoferDni = new System.Windows.Forms.TextBox();
            this.cmdSeleccionarChofer = new System.Windows.Forms.Button();
            this.cmbModelo = new System.Windows.Forms.ComboBox();
            this.txtChoferNombreCompleto = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtAutoRodado = new System.Windows.Forms.TextBox();
            this.btnModificar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkAutoActivo = new System.Windows.Forms.CheckBox();
            this.lblAutoActivo = new System.Windows.Forms.Label();
            this.dgvTurnos = new System.Windows.Forms.DataGridView();
            this.turnoDescripcionColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.turnoHoraInicialColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.turnoHoraFinalColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmbTurno = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnAgregarTurno = new System.Windows.Forms.Button();
            this.btnRemoverTurno = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTurnos)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Marca";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Modelo";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Patente";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(19, 135);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Chofer";
            // 
            // cmbMarca
            // 
            this.cmbMarca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMarca.FormattingEnabled = true;
            this.cmbMarca.Location = new System.Drawing.Point(85, 18);
            this.cmbMarca.Name = "cmbMarca";
            this.cmbMarca.Size = new System.Drawing.Size(195, 21);
            this.cmbMarca.TabIndex = 1;
            // 
            // txtPatente
            // 
            this.txtPatente.Location = new System.Drawing.Point(84, 74);
            this.txtPatente.Name = "txtPatente";
            this.txtPatente.Size = new System.Drawing.Size(196, 20);
            this.txtPatente.TabIndex = 3;
            this.txtPatente.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPatente_KeyPress);
            // 
            // btnCrearAutomovil
            // 
            this.btnCrearAutomovil.Location = new System.Drawing.Point(339, 455);
            this.btnCrearAutomovil.Name = "btnCrearAutomovil";
            this.btnCrearAutomovil.Size = new System.Drawing.Size(87, 23);
            this.btnCrearAutomovil.TabIndex = 10;
            this.btnCrearAutomovil.Text = "Crear";
            this.btnCrearAutomovil.UseVisualStyleBackColor = true;
            this.btnCrearAutomovil.Click += new System.EventHandler(this.btnCrearAutomovil_Click);
            // 
            // txtLicencia
            // 
            this.txtLicencia.Location = new System.Drawing.Point(85, 100);
            this.txtLicencia.Name = "txtLicencia";
            this.txtLicencia.Size = new System.Drawing.Size(195, 20);
            this.txtLicencia.TabIndex = 4;
            this.txtLicencia.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLicencia_KeyPress);
            // 
            // Licencia
            // 
            this.Licencia.AutoSize = true;
            this.Licencia.Location = new System.Drawing.Point(19, 103);
            this.Licencia.Name = "Licencia";
            this.Licencia.Size = new System.Drawing.Size(47, 13);
            this.Licencia.TabIndex = 12;
            this.Licencia.Text = "Licencia";
            // 
            // txtChoferDni
            // 
            this.txtChoferDni.Enabled = false;
            this.txtChoferDni.Location = new System.Drawing.Point(84, 128);
            this.txtChoferDni.Name = "txtChoferDni";
            this.txtChoferDni.Size = new System.Drawing.Size(66, 20);
            this.txtChoferDni.TabIndex = 15;
            // 
            // cmdSeleccionarChofer
            // 
            this.cmdSeleccionarChofer.Location = new System.Drawing.Point(286, 127);
            this.cmdSeleccionarChofer.Name = "cmdSeleccionarChofer";
            this.cmdSeleccionarChofer.Size = new System.Drawing.Size(122, 20);
            this.cmdSeleccionarChofer.TabIndex = 5;
            this.cmdSeleccionarChofer.Text = "Seleccionar chofer";
            this.cmdSeleccionarChofer.UseVisualStyleBackColor = true;
            this.cmdSeleccionarChofer.Click += new System.EventHandler(this.cmdSeleccionarChofer_Click);
            // 
            // cmbModelo
            // 
            this.cmbModelo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbModelo.FormattingEnabled = true;
            this.cmbModelo.Location = new System.Drawing.Point(85, 45);
            this.cmbModelo.Name = "cmbModelo";
            this.cmbModelo.Size = new System.Drawing.Size(195, 21);
            this.cmbModelo.TabIndex = 2;
            // 
            // txtChoferNombreCompleto
            // 
            this.txtChoferNombreCompleto.Enabled = false;
            this.txtChoferNombreCompleto.Location = new System.Drawing.Point(157, 128);
            this.txtChoferNombreCompleto.Name = "txtChoferNombreCompleto";
            this.txtChoferNombreCompleto.Size = new System.Drawing.Size(123, 20);
            this.txtChoferNombreCompleto.TabIndex = 21;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(19, 160);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 13);
            this.label6.TabIndex = 22;
            this.label6.Text = "Auto rodado";
            // 
            // txtAutoRodado
            // 
            this.txtAutoRodado.Location = new System.Drawing.Point(84, 157);
            this.txtAutoRodado.Name = "txtAutoRodado";
            this.txtAutoRodado.Size = new System.Drawing.Size(195, 20);
            this.txtAutoRodado.TabIndex = 6;
            this.txtAutoRodado.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAutoRodado_KeyPress);
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(339, 455);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(87, 23);
            this.btnModificar.TabIndex = 10;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Visible = false;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.chkAutoActivo);
            this.groupBox1.Controls.Add(this.lblAutoActivo);
            this.groupBox1.Controls.Add(this.cmbModelo);
            this.groupBox1.Controls.Add(this.cmdSeleccionarChofer);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtAutoRodado);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtChoferNombreCompleto);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.cmbMarca);
            this.groupBox1.Controls.Add(this.txtPatente);
            this.groupBox1.Controls.Add(this.txtLicencia);
            this.groupBox1.Controls.Add(this.Licencia);
            this.groupBox1.Controls.Add(this.txtChoferDni);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(414, 437);
            this.groupBox1.TabIndex = 25;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos automovil";
            // 
            // chkAutoActivo
            // 
            this.chkAutoActivo.AutoSize = true;
            this.chkAutoActivo.Location = new System.Drawing.Point(84, 187);
            this.chkAutoActivo.Name = "chkAutoActivo";
            this.chkAutoActivo.Size = new System.Drawing.Size(81, 17);
            this.chkAutoActivo.TabIndex = 7;
            this.chkAutoActivo.Text = "Auto Activo";
            this.chkAutoActivo.UseVisualStyleBackColor = true;
            this.chkAutoActivo.Visible = false;
            // 
            // lblAutoActivo
            // 
            this.lblAutoActivo.AutoSize = true;
            this.lblAutoActivo.Location = new System.Drawing.Point(19, 188);
            this.lblAutoActivo.Name = "lblAutoActivo";
            this.lblAutoActivo.Size = new System.Drawing.Size(61, 13);
            this.lblAutoActivo.TabIndex = 24;
            this.lblAutoActivo.Text = "Auto activo";
            this.lblAutoActivo.Visible = false;
            // 
            // dgvTurnos
            // 
            this.dgvTurnos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTurnos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.turnoDescripcionColumn,
            this.turnoHoraInicialColumn,
            this.turnoHoraFinalColumn});
            this.dgvTurnos.Location = new System.Drawing.Point(9, 64);
            this.dgvTurnos.Name = "dgvTurnos";
            this.dgvTurnos.Size = new System.Drawing.Size(343, 142);
            this.dgvTurnos.TabIndex = 26;
            // 
            // turnoDescripcionColumn
            // 
            this.turnoDescripcionColumn.HeaderText = "Descripcion";
            this.turnoDescripcionColumn.Name = "turnoDescripcionColumn";
            this.turnoDescripcionColumn.ReadOnly = true;
            // 
            // turnoHoraInicialColumn
            // 
            this.turnoHoraInicialColumn.HeaderText = "Hora Inicial";
            this.turnoHoraInicialColumn.Name = "turnoHoraInicialColumn";
            this.turnoHoraInicialColumn.ReadOnly = true;
            // 
            // turnoHoraFinalColumn
            // 
            this.turnoHoraFinalColumn.HeaderText = "Hora Final";
            this.turnoHoraFinalColumn.Name = "turnoHoraFinalColumn";
            this.turnoHoraFinalColumn.ReadOnly = true;
            // 
            // cmbTurno
            // 
            this.cmbTurno.FormattingEnabled = true;
            this.cmbTurno.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTurno.Location = new System.Drawing.Point(9, 37);
            this.cmbTurno.Name = "cmbTurno";
            this.cmbTurno.Size = new System.Drawing.Size(121, 21);
            this.cmbTurno.TabIndex = 8;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 21);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 13);
            this.label7.TabIndex = 28;
            this.label7.Text = "Turno";
            // 
            // btnAgregarTurno
            // 
            this.btnAgregarTurno.Location = new System.Drawing.Point(136, 35);
            this.btnAgregarTurno.Name = "btnAgregarTurno";
            this.btnAgregarTurno.Size = new System.Drawing.Size(99, 23);
            this.btnAgregarTurno.TabIndex = 9;
            this.btnAgregarTurno.Text = "Agregar turno";
            this.btnAgregarTurno.UseVisualStyleBackColor = true;
            this.btnAgregarTurno.Click += new System.EventHandler(this.btnAgregarTurno_Click);
            // 
            // btnRemoverTurno
            // 
            this.btnRemoverTurno.Location = new System.Drawing.Point(241, 35);
            this.btnRemoverTurno.Name = "btnRemoverTurno";
            this.btnRemoverTurno.Size = new System.Drawing.Size(111, 23);
            this.btnRemoverTurno.TabIndex = 30;
            this.btnRemoverTurno.Text = "Remover turno";
            this.btnRemoverTurno.UseVisualStyleBackColor = true;
            this.btnRemoverTurno.Click += new System.EventHandler(this.btnRemoverTurno_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvTurnos);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.btnRemoverTurno);
            this.groupBox2.Controls.Add(this.cmbTurno);
            this.groupBox2.Controls.Add(this.btnAgregarTurno);
            this.groupBox2.Location = new System.Drawing.Point(22, 210);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(363, 218);
            this.groupBox2.TabIndex = 31;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Seleccionar turnos del automovil";
            // 
            // AltaAutomovil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 500);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnCrearAutomovil);
            this.Name = "AltaAutomovil";
            this.Text = "AltaAutomovil";
            this.Load += new System.EventHandler(this.AltaAutomovil_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTurnos)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbMarca;
        private System.Windows.Forms.TextBox txtPatente;
        private System.Windows.Forms.Button btnCrearAutomovil;
        private System.Windows.Forms.TextBox txtLicencia;
        private System.Windows.Forms.Label Licencia;
        private System.Windows.Forms.TextBox txtChoferDni;
        private System.Windows.Forms.Button cmdSeleccionarChofer;
        private System.Windows.Forms.ComboBox cmbModelo;
        private System.Windows.Forms.TextBox txtChoferNombreCompleto;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtAutoRodado;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkAutoActivo;
        private System.Windows.Forms.Label lblAutoActivo;
        private System.Windows.Forms.DataGridView dgvTurnos;
        private System.Windows.Forms.ComboBox cmbTurno;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnAgregarTurno;
        private System.Windows.Forms.Button btnRemoverTurno;
        private System.Windows.Forms.GroupBox groupBox2;


        private System.Windows.Forms.DataGridViewTextBoxColumn turnoHoraInicialColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn turnoHoraFinalColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn turnoDescripcionColumn;
    }
}