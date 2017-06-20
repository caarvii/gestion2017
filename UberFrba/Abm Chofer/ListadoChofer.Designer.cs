namespace UberFrba.Abm_Chofer
{
    partial class ListadoChofer
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.filtroNombre = new System.Windows.Forms.TextBox();
            this.filtroApellido = new System.Windows.Forms.TextBox();
            this.filtroDNI = new System.Windows.Forms.TextBox();
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Nombre";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Apellido";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(29, 86);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(26, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "DNI";
            // 
            // filtroNombre
            // 
            this.filtroNombre.Location = new System.Drawing.Point(86, 30);
            this.filtroNombre.Name = "filtroNombre";
            this.filtroNombre.Size = new System.Drawing.Size(155, 20);
            this.filtroNombre.TabIndex = 11;
            // 
            // filtroApellido
            // 
            this.filtroApellido.Location = new System.Drawing.Point(85, 56);
            this.filtroApellido.Name = "filtroApellido";
            this.filtroApellido.Size = new System.Drawing.Size(155, 20);
            this.filtroApellido.TabIndex = 12;
            // 
            // filtroDNI
            // 
            this.filtroDNI.Location = new System.Drawing.Point(86, 82);
            this.filtroDNI.Name = "filtroDNI";
            this.filtroDNI.Size = new System.Drawing.Size(154, 20);
            this.filtroDNI.TabIndex = 13;
            // 
            // ListadoChofer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(550, 470);
            this.Controls.Add(this.filtroDNI);
            this.Controls.Add(this.filtroApellido);
            this.Controls.Add(this.filtroNombre);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Name = "ListadoChofer";
            this.Text = "ListadoChofer";
            this.Controls.SetChildIndex(this.botonLimpiar, 0);
            this.Controls.SetChildIndex(this.botonBuscar, 0);
            this.Controls.SetChildIndex(this.botonBaja, 0);
            this.Controls.SetChildIndex(this.botonAlta, 0);
            this.Controls.SetChildIndex(this.botonModificacion, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.filtroNombre, 0);
            this.Controls.SetChildIndex(this.filtroApellido, 0);
            this.Controls.SetChildIndex(this.filtroDNI, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox filtroNombre;
        private System.Windows.Forms.TextBox filtroApellido;
        private System.Windows.Forms.TextBox filtroDNI;
    }
}