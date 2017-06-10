namespace UberFrba
{
    partial class menuGenerico
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
            this.listadoBoton = new System.Windows.Forms.Button();
            this.modificacionBoton = new System.Windows.Forms.Button();
            this.bajaBoton = new System.Windows.Forms.Button();
            this.altaBoton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.listadoBoton);
            this.groupBox1.Controls.Add(this.modificacionBoton);
            this.groupBox1.Controls.Add(this.bajaBoton);
            this.groupBox1.Controls.Add(this.altaBoton);
            this.groupBox1.Location = new System.Drawing.Point(18, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(255, 317);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Acciones";
            // 
            // listadoBoton
            // 
            this.listadoBoton.Location = new System.Drawing.Point(24, 245);
            this.listadoBoton.Name = "listadoBoton";
            this.listadoBoton.Size = new System.Drawing.Size(201, 42);
            this.listadoBoton.TabIndex = 3;
            this.listadoBoton.Text = "Listado";
            this.listadoBoton.UseVisualStyleBackColor = true;
            this.listadoBoton.Click += new System.EventHandler(this.listadoBoton_Click);
            // 
            // modificacionBoton
            // 
            this.modificacionBoton.Location = new System.Drawing.Point(24, 176);
            this.modificacionBoton.Name = "modificacionBoton";
            this.modificacionBoton.Size = new System.Drawing.Size(201, 37);
            this.modificacionBoton.TabIndex = 2;
            this.modificacionBoton.Text = "Modificacion";
            this.modificacionBoton.UseVisualStyleBackColor = true;
            this.modificacionBoton.Click += new System.EventHandler(this.modificacionBoton_Click);
            // 
            // bajaBoton
            // 
            this.bajaBoton.Location = new System.Drawing.Point(27, 100);
            this.bajaBoton.Name = "bajaBoton";
            this.bajaBoton.Size = new System.Drawing.Size(198, 45);
            this.bajaBoton.TabIndex = 1;
            this.bajaBoton.Text = "Baja";
            this.bajaBoton.UseVisualStyleBackColor = true;
            this.bajaBoton.Click += new System.EventHandler(this.bajaBoton_Click);
            // 
            // altaBoton
            // 
            this.altaBoton.Location = new System.Drawing.Point(30, 30);
            this.altaBoton.Name = "altaBoton";
            this.altaBoton.Size = new System.Drawing.Size(195, 45);
            this.altaBoton.TabIndex = 0;
            this.altaBoton.Text = "Alta";
            this.altaBoton.UseVisualStyleBackColor = true;
            this.altaBoton.Click += new System.EventHandler(this.altaBoton_Click);
            // 
            // menuGenerico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(281, 335);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "menuGenerico";
            this.Text = "Menu";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.Button listadoBoton;
        public System.Windows.Forms.Button modificacionBoton;
        public System.Windows.Forms.Button bajaBoton;
        public System.Windows.Forms.Button altaBoton;
    }
}