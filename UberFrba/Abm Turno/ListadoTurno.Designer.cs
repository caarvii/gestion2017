﻿namespace UberFrba.Abm_Turno
{
    partial class ListadoTurno
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
            this.filtroDescripcion = new System.Windows.Forms.TextBox();
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
            this.botonModificacion.Click += new System.EventHandler(this.botonModificacion_Click_2);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Descripcion";
            // 
            // filtroDescripcion
            // 
            this.filtroDescripcion.Location = new System.Drawing.Point(92, 34);
            this.filtroDescripcion.Name = "filtroDescripcion";
            this.filtroDescripcion.Size = new System.Drawing.Size(173, 20);
            this.filtroDescripcion.TabIndex = 9;
            // 
            // ListadoTurno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(550, 470);
            this.Controls.Add(this.filtroDescripcion);
            this.Controls.Add(this.label2);
            this.Name = "ListadoTurno";
            this.Text = "ListadoTurno";
            this.Load += new System.EventHandler(this.ListadoTurno_Load);
            this.Controls.SetChildIndex(this.botonLimpiar, 0);
            this.Controls.SetChildIndex(this.botonBuscar, 0);
            this.Controls.SetChildIndex(this.botonBaja, 0);
            this.Controls.SetChildIndex(this.botonAlta, 0);
            this.Controls.SetChildIndex(this.botonModificacion, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.filtroDescripcion, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }



        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox filtroDescripcion;
    }
}