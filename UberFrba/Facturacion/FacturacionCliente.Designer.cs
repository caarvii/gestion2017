namespace UberFrba.Facturacion
{
    partial class FacturacionCliente
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.botonFacturar = new System.Windows.Forms.Button();
            this.botonBuscarViajes = new System.Windows.Forms.Button();
            this.botonLimpiar = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.totalFacturaLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.viajesParaFacturar = new System.Windows.Forms.DataGridView();
            this.botonSeleccionarCliente = new System.Windows.Forms.Button();
            this.txtNombreApellido = new System.Windows.Forms.TextBox();
            this.txtDNI = new System.Windows.Forms.TextBox();
            this.dateInicio = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.viajesParaFacturar)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.botonFacturar);
            this.groupBox1.Controls.Add(this.botonBuscarViajes);
            this.groupBox1.Controls.Add(this.botonLimpiar);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.botonSeleccionarCliente);
            this.groupBox1.Controls.Add(this.txtNombreApellido);
            this.groupBox1.Controls.Add(this.txtDNI);
            this.groupBox1.Controls.Add(this.dateInicio);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(14, 14);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(524, 444);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Atributos";
            // 
            // botonFacturar
            // 
            this.botonFacturar.Location = new System.Drawing.Point(402, 401);
            this.botonFacturar.Name = "botonFacturar";
            this.botonFacturar.Size = new System.Drawing.Size(94, 23);
            this.botonFacturar.TabIndex = 13;
            this.botonFacturar.Text = "Facturar Viajes";
            this.botonFacturar.UseVisualStyleBackColor = true;
            this.botonFacturar.Click += new System.EventHandler(this.botonFacturar_Click);
            // 
            // botonBuscarViajes
            // 
            this.botonBuscarViajes.Location = new System.Drawing.Point(21, 101);
            this.botonBuscarViajes.Name = "botonBuscarViajes";
            this.botonBuscarViajes.Size = new System.Drawing.Size(93, 22);
            this.botonBuscarViajes.TabIndex = 12;
            this.botonBuscarViajes.Text = "Buscar Viajes";
            this.botonBuscarViajes.UseVisualStyleBackColor = true;
            this.botonBuscarViajes.Click += new System.EventHandler(this.botonBuscarViajes_Click);
            // 
            // botonLimpiar
            // 
            this.botonLimpiar.Location = new System.Drawing.Point(131, 101);
            this.botonLimpiar.Name = "botonLimpiar";
            this.botonLimpiar.Size = new System.Drawing.Size(94, 22);
            this.botonLimpiar.TabIndex = 11;
            this.botonLimpiar.Text = "Limpiar";
            this.botonLimpiar.UseVisualStyleBackColor = true;
            this.botonLimpiar.Click += new System.EventHandler(this.botonLimpiar_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.totalFacturaLabel);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.viajesParaFacturar);
            this.groupBox2.Location = new System.Drawing.Point(21, 142);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(476, 244);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Viajes para Facturar";
            // 
            // totalFacturaLabel
            // 
            this.totalFacturaLabel.Location = new System.Drawing.Point(391, 218);
            this.totalFacturaLabel.Name = "totalFacturaLabel";
            this.totalFacturaLabel.Size = new System.Drawing.Size(70, 13);
            this.totalFacturaLabel.TabIndex = 2;
            this.totalFacturaLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(308, 218);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Total Factura: ";
            // 
            // viajesParaFacturar
            // 
            this.viajesParaFacturar.AllowUserToAddRows = false;
            this.viajesParaFacturar.AllowUserToDeleteRows = false;
            this.viajesParaFacturar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.viajesParaFacturar.Location = new System.Drawing.Point(19, 33);
            this.viajesParaFacturar.MultiSelect = false;
            this.viajesParaFacturar.Name = "viajesParaFacturar";
            this.viajesParaFacturar.ReadOnly = true;
            this.viajesParaFacturar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.viajesParaFacturar.Size = new System.Drawing.Size(442, 172);
            this.viajesParaFacturar.TabIndex = 1;
            // 
            // botonSeleccionarCliente
            // 
            this.botonSeleccionarCliente.Location = new System.Drawing.Point(387, 60);
            this.botonSeleccionarCliente.Name = "botonSeleccionarCliente";
            this.botonSeleccionarCliente.Size = new System.Drawing.Size(95, 20);
            this.botonSeleccionarCliente.TabIndex = 9;
            this.botonSeleccionarCliente.Text = "Seleccionar";
            this.botonSeleccionarCliente.UseVisualStyleBackColor = true;
            this.botonSeleccionarCliente.Click += new System.EventHandler(this.botonSeleccionarCliente_Click);
            // 
            // txtNombreApellido
            // 
            this.txtNombreApellido.Enabled = false;
            this.txtNombreApellido.Location = new System.Drawing.Point(189, 60);
            this.txtNombreApellido.Name = "txtNombreApellido";
            this.txtNombreApellido.ReadOnly = true;
            this.txtNombreApellido.Size = new System.Drawing.Size(192, 20);
            this.txtNombreApellido.TabIndex = 8;
            // 
            // txtDNI
            // 
            this.txtDNI.Enabled = false;
            this.txtDNI.Location = new System.Drawing.Point(92, 60);
            this.txtDNI.Name = "txtDNI";
            this.txtDNI.ReadOnly = true;
            this.txtDNI.Size = new System.Drawing.Size(91, 20);
            this.txtDNI.TabIndex = 7;
            // 
            // dateInicio
            // 
            this.dateInicio.CustomFormat = "MM/yyyy";
            this.dateInicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateInicio.Location = new System.Drawing.Point(92, 31);
            this.dateInicio.Name = "dateInicio";
            this.dateInicio.Size = new System.Drawing.Size(92, 20);
            this.dateInicio.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Cliente";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Fecha inicio ";
            // 
            // FacturacionCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(550, 470);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FacturacionCliente";
            this.Text = "Facturacion";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.viajesParaFacturar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dateInicio;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNombreApellido;
        private System.Windows.Forms.TextBox txtDNI;
        private System.Windows.Forms.Button botonBuscarViajes;
        private System.Windows.Forms.Button botonLimpiar;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button botonSeleccionarCliente;
        private System.Windows.Forms.Button botonFacturar;
        private System.Windows.Forms.DataGridView viajesParaFacturar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label totalFacturaLabel;
    }
}