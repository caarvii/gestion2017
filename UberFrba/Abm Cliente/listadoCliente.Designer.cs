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
            this.SuspendLayout();
            // 
            // botonLimpiar
            // 
            this.botonLimpiar.Click += new System.EventHandler(this.botonLimpiar_Click_1);
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
            // listadoCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(550, 470);
            this.Name = "ListadoCliente";
            this.Text = "ListadoCliente";
            this.Load += new System.EventHandler(this.listadoCliente_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

    }
}