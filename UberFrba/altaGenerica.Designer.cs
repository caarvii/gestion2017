namespace UberFrba
{
    partial class altaGenerica
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
            this.limpiarBoton = new System.Windows.Forms.Button();
            this.aceptarBoton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(16, 15);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(445, 246);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Campos a agregar";
            // 
            // limpiarBoton
            // 
            this.limpiarBoton.Location = new System.Drawing.Point(16, 267);
            this.limpiarBoton.Name = "limpiarBoton";
            this.limpiarBoton.Size = new System.Drawing.Size(225, 27);
            this.limpiarBoton.TabIndex = 1;
            this.limpiarBoton.Text = "Limpiar";
            this.limpiarBoton.UseVisualStyleBackColor = true;
            this.limpiarBoton.Click += new System.EventHandler(this.limpiarBoton_Click);
            // 
            // aceptarBoton
            // 
            this.aceptarBoton.Location = new System.Drawing.Point(247, 267);
            this.aceptarBoton.Name = "aceptarBoton";
            this.aceptarBoton.Size = new System.Drawing.Size(214, 27);
            this.aceptarBoton.TabIndex = 2;
            this.aceptarBoton.Text = "Aceptar";
            this.aceptarBoton.UseVisualStyleBackColor = true;
            this.aceptarBoton.Click += new System.EventHandler(this.aceptarBoton_Click);
            // 
            // altaGenerica
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(467, 303);
            this.Controls.Add(this.aceptarBoton);
            this.Controls.Add(this.limpiarBoton);
            this.Controls.Add(this.groupBox1);
            this.Name = "altaGenerica";
            this.Text = "Alta";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.Button limpiarBoton;
        public System.Windows.Forms.Button aceptarBoton;
    }
}