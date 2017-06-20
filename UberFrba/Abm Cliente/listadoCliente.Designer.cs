namespace UberFrba.Abm_Cliente
{
    partial class ListadoCliente
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
            this.txtFiltroNombre = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFiltroApellido = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtFiltroDni = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // botonLimpiar
            // 
            this.botonLimpiar.Click += new System.EventHandler(this.botonLimpiar_Click_1);
            // 
            // botonBuscar
            // 
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
            // txtFiltroNombre
            // 
            this.txtFiltroNombre.Location = new System.Drawing.Point(102, 34);
            this.txtFiltroNombre.Name = "txtFiltroNombre";
            this.txtFiltroNombre.Size = new System.Drawing.Size(173, 20);
            this.txtFiltroNombre.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Nombre";
            // 
            // txtFiltroApellido
            // 
            this.txtFiltroApellido.Location = new System.Drawing.Point(102, 64);
            this.txtFiltroApellido.Name = "txtFiltroApellido";
            this.txtFiltroApellido.Size = new System.Drawing.Size(173, 20);
            this.txtFiltroApellido.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Apellido";
            // 
            // txtFiltroDni
            // 
            this.txtFiltroDni.Location = new System.Drawing.Point(102, 94);
            this.txtFiltroDni.Name = "txtFiltroDni";
            this.txtFiltroDni.Size = new System.Drawing.Size(173, 20);
            this.txtFiltroDni.TabIndex = 15;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(29, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Dni";
            // 
            // ListadoCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(550, 470);
            this.Controls.Add(this.txtFiltroDni);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtFiltroApellido);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtFiltroNombre);
            this.Controls.Add(this.label2);
            this.Name = "ListadoCliente";
            this.Text = "ListadoCliente";
            this.Load += new System.EventHandler(this.listadoCliente_Load);
            this.Controls.SetChildIndex(this.botonLimpiar, 0);
            this.Controls.SetChildIndex(this.botonBuscar, 0);
            this.Controls.SetChildIndex(this.botonBaja, 0);
            this.Controls.SetChildIndex(this.botonAlta, 0);
            this.Controls.SetChildIndex(this.botonModificacion, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.txtFiltroNombre, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.txtFiltroApellido, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.txtFiltroDni, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtFiltroNombre;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtFiltroApellido;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtFiltroDni;
        private System.Windows.Forms.Label label4;

    }
}