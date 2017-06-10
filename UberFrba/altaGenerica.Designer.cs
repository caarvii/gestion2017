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
            this.campo3 = new System.Windows.Forms.TextBox();
            this.campo2 = new System.Windows.Forms.TextBox();
            this.campo1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.limpiarBoton = new System.Windows.Forms.Button();
            this.aceptarBoton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.campo3);
            this.groupBox1.Controls.Add(this.campo2);
            this.groupBox1.Controls.Add(this.campo1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(16, 15);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(445, 143);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Campos a agregar";
            // 
            // campo3
            // 
            this.campo3.Location = new System.Drawing.Point(56, 99);
            this.campo3.Name = "campo3";
            this.campo3.Size = new System.Drawing.Size(169, 20);
            this.campo3.TabIndex = 5;
            // 
            // campo2
            // 
            this.campo2.Location = new System.Drawing.Point(56, 66);
            this.campo2.Name = "campo2";
            this.campo2.Size = new System.Drawing.Size(169, 20);
            this.campo2.TabIndex = 4;
            // 
            // campo1
            // 
            this.campo1.Location = new System.Drawing.Point(53, 31);
            this.campo1.Name = "campo1";
            this.campo1.Size = new System.Drawing.Size(172, 20);
            this.campo1.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "label3";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "label2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // limpiarBoton
            // 
            this.limpiarBoton.Location = new System.Drawing.Point(16, 167);
            this.limpiarBoton.Name = "limpiarBoton";
            this.limpiarBoton.Size = new System.Drawing.Size(225, 27);
            this.limpiarBoton.TabIndex = 1;
            this.limpiarBoton.Text = "Limpiar";
            this.limpiarBoton.UseVisualStyleBackColor = true;
            this.limpiarBoton.Click += new System.EventHandler(this.limpiarBoton_Click);
            // 
            // aceptarBoton
            // 
            this.aceptarBoton.Location = new System.Drawing.Point(247, 167);
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
            this.ClientSize = new System.Drawing.Size(468, 206);
            this.Controls.Add(this.aceptarBoton);
            this.Controls.Add(this.limpiarBoton);
            this.Controls.Add(this.groupBox1);
            this.Name = "altaGenerica";
            this.Text = "Alta";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.TextBox campo3;
        public System.Windows.Forms.TextBox campo2;
        public System.Windows.Forms.TextBox campo1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Button limpiarBoton;
        public System.Windows.Forms.Button aceptarBoton;
    }
}