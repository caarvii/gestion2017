﻿using System.Windows.Forms;
namespace UberFrba
{
    partial class ListadoGenerico
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
            this.tablaListado = new System.Windows.Forms.DataGridView();
            this.botonLimpiar = new System.Windows.Forms.Button();
            this.botonBuscar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.botonBaja = new System.Windows.Forms.Button();
            this.botonAlta = new System.Windows.Forms.Button();
            this.botonModificacion = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.tablaListado)).BeginInit();
            this.SuspendLayout();
            // 
            // tablaListado
            // 
            this.tablaListado.AllowUserToAddRows = false;
            this.tablaListado.AllowUserToDeleteRows = false;
            this.tablaListado.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.tablaListado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tablaListado.Location = new System.Drawing.Point(20, 173);
            this.tablaListado.Name = "tablaListado";
            this.tablaListado.ReadOnly = true;
            this.tablaListado.Size = new System.Drawing.Size(511, 237);
            this.tablaListado.TabIndex = 1;
            this.tablaListado.MultiSelect = false;
            this.tablaListado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            // 
            // botonLimpiar
            // 
            this.botonLimpiar.Location = new System.Drawing.Point(336, 133);
            this.botonLimpiar.Name = "botonLimpiar";
            this.botonLimpiar.Size = new System.Drawing.Size(96, 34);
            this.botonLimpiar.TabIndex = 2;
            this.botonLimpiar.Text = "Limpiar";
            this.botonLimpiar.UseVisualStyleBackColor = true;
            this.botonLimpiar.Click += new System.EventHandler(this.botonLimpiar_Click);
            // 
            // botonBuscar
            // 
            this.botonBuscar.Location = new System.Drawing.Point(438, 133);
            this.botonBuscar.Name = "botonBuscar";
            this.botonBuscar.Size = new System.Drawing.Size(93, 34);
            this.botonBuscar.TabIndex = 3;
            this.botonBuscar.Text = "Buscar";
            this.botonBuscar.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Filtros";
            // 
            // botonBaja
            // 
            this.botonBaja.Location = new System.Drawing.Point(223, 416);
            this.botonBaja.Name = "botonBaja";
            this.botonBaja.Size = new System.Drawing.Size(136, 45);
            this.botonBaja.TabIndex = 5;
            this.botonBaja.Text = "Baja";
            this.botonBaja.UseVisualStyleBackColor = true;
            this.botonBaja.Click += new System.EventHandler(this.botonBaja_Click);
            // 
            // botonAlta
            // 
            this.botonAlta.Location = new System.Drawing.Point(21, 415);
            this.botonAlta.Name = "botonAlta";
            this.botonAlta.Size = new System.Drawing.Size(145, 45);
            this.botonAlta.TabIndex = 6;
            this.botonAlta.Text = "Alta";
            this.botonAlta.UseVisualStyleBackColor = true;
            this.botonAlta.Click += new System.EventHandler(this.botonAlta_Click);
            // 
            // botonModificacion
            // 
            this.botonModificacion.Location = new System.Drawing.Point(395, 416);
            this.botonModificacion.Name = "botonModificacion";
            this.botonModificacion.Size = new System.Drawing.Size(136, 44);
            this.botonModificacion.TabIndex = 7;
            this.botonModificacion.Text = "Modificacion";
            this.botonModificacion.UseVisualStyleBackColor = true;
            this.botonModificacion.Click += new System.EventHandler(this.botonModificacion_Click);
            // 
            // listadoGenerico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(550, 470);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Controls.Add(this.botonModificacion);
            this.Controls.Add(this.botonAlta);
            this.Controls.Add(this.botonBaja);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.botonBuscar);
            this.Controls.Add(this.botonLimpiar);
            this.Controls.Add(this.tablaListado);
            this.Name = "listadoGenerico";
            this.Text = "listadoGenerico";
            this.Load += new System.EventHandler(this.listadoGenerico_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tablaListado)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Button botonLimpiar;
        public System.Windows.Forms.Button botonBuscar;
        public System.Windows.Forms.DataGridView tablaListado;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Button botonBaja;
        public System.Windows.Forms.Button botonAlta;
        public System.Windows.Forms.Button botonModificacion;
    }
}