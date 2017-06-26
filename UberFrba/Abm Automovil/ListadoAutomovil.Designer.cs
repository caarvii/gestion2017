namespace UberFrba.Abm_Automovil
{
    partial class ListadoAutomovil
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
            this.txtFiltroModelo = new System.Windows.Forms.TextBox();
            this.txtFiltroPatente = new System.Windows.Forms.TextBox();
            this.txtFiltroChofer = new System.Windows.Forms.TextBox();
            this.cmbFiltroMarca = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbFiltroModelo = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // botonLimpiar
            // 
            this.botonLimpiar.Click += new System.EventHandler(this.botonLimpiar_Click);
            // 
            // botonBuscar
            // 
            this.botonBuscar.TabIndex = 5;
            this.botonBuscar.Click += new System.EventHandler(this.botonBuscar_Click);
            // 
            // botonBaja
            // 
            this.botonBaja.Click += new System.EventHandler(this.botonBaja_Click_1);
            // 
            // botonAlta
            // 
            this.botonAlta.Click += new System.EventHandler(this.botonAlta_Click_1);
            // 
            // botonModificacion
            // 
            this.botonModificacion.Click += new System.EventHandler(this.botonModificacion_Click_1);
            // 
            // txtFiltroModelo
            // 
            this.txtFiltroModelo.Location = new System.Drawing.Point(311, 73);
            this.txtFiltroModelo.Name = "txtFiltroModelo";
            this.txtFiltroModelo.Size = new System.Drawing.Size(121, 20);
            this.txtFiltroModelo.TabIndex = 2;
            // 
            // txtFiltroPatente
            // 
            this.txtFiltroPatente.Location = new System.Drawing.Point(112, 97);
            this.txtFiltroPatente.Name = "txtFiltroPatente";
            this.txtFiltroPatente.Size = new System.Drawing.Size(121, 20);
            this.txtFiltroPatente.TabIndex = 93;
            // 
            // txtFiltroChofer
            // 
            this.txtFiltroChofer.Location = new System.Drawing.Point(112, 123);
            this.txtFiltroChofer.Name = "txtFiltroChofer";
            this.txtFiltroChofer.Size = new System.Drawing.Size(121, 20);
            this.txtFiltroChofer.TabIndex = 4;
            // 
            // cmbFiltroMarca
            // 
            this.cmbFiltroMarca.FormattingEnabled = true;
            this.cmbFiltroMarca.Location = new System.Drawing.Point(112, 43);
            this.cmbFiltroMarca.Name = "cmbFiltroMarca";
            this.cmbFiltroMarca.Size = new System.Drawing.Size(121, 21);
            this.cmbFiltroMarca.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(42, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Marca";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(42, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 94;
            this.label3.Text = "Patente";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(42, 73);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 95;
            this.label4.Text = "Modelo";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(42, 126);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 96;
            this.label5.Text = "Chofer";
            // 
            // cmbFiltroModelo
            // 
            this.cmbFiltroModelo.FormattingEnabled = true;
            this.cmbFiltroModelo.Location = new System.Drawing.Point(112, 71);
            this.cmbFiltroModelo.Name = "cmbFiltroModelo";
            this.cmbFiltroModelo.Size = new System.Drawing.Size(121, 21);
            this.cmbFiltroModelo.TabIndex = 97;
            // 
            // ListadoAutomovil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(642, 497);
            this.Controls.Add(this.cmbFiltroModelo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbFiltroMarca);
            this.Controls.Add(this.txtFiltroChofer);
            this.Controls.Add(this.txtFiltroPatente);
            this.Controls.Add(this.txtFiltroModelo);
            this.Name = "ListadoAutomovil";
            this.Load += new System.EventHandler(this.ListadoAutomovil_Load_1);
            this.Controls.SetChildIndex(this.botonLimpiar, 0);
            this.Controls.SetChildIndex(this.botonBuscar, 0);
            this.Controls.SetChildIndex(this.botonBaja, 0);
            this.Controls.SetChildIndex(this.botonAlta, 0);
            this.Controls.SetChildIndex(this.botonModificacion, 0);
            this.Controls.SetChildIndex(this.txtFiltroModelo, 0);
            this.Controls.SetChildIndex(this.txtFiltroPatente, 0);
            this.Controls.SetChildIndex(this.txtFiltroChofer, 0);
            this.Controls.SetChildIndex(this.cmbFiltroMarca, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.cmbFiltroModelo, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void ListadoAutomovil_Load(object sender, System.EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        #endregion

        private System.Windows.Forms.TextBox txtFiltroModelo;
        private System.Windows.Forms.TextBox txtFiltroPatente;
        private System.Windows.Forms.TextBox txtFiltroChofer;
        private System.Windows.Forms.ComboBox cmbFiltroMarca;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbFiltroModelo;
    }
}