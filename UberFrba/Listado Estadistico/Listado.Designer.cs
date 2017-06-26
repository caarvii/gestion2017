using System.Windows.Forms;
namespace UberFrba.Listado_Estadistico
{
    partial class Listado
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
            this.comboAnio = new System.Windows.Forms.ComboBox();
            this.comboTrimestre = new System.Windows.Forms.ComboBox();
            this.Calcular = new System.Windows.Forms.Button();
            this.comboFuncionalidad = new System.Windows.Forms.ComboBox();
            this.labelAnio = new System.Windows.Forms.Label();
            this.labelTrimestre = new System.Windows.Forms.Label();
            this.labelListado = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // comboAnio
            // 
            this.comboAnio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboAnio.FormattingEnabled = true;
            this.comboAnio.Items.AddRange(new object[] {
            "2010",
            "2011",
            "2012",
            "2013",
            "2014",
            "2015",
            "2016",
            "2017"});
            this.comboAnio.Location = new System.Drawing.Point(425, 6);
            this.comboAnio.Name = "comboAnio";
            this.comboAnio.Size = new System.Drawing.Size(121, 21);
            this.comboAnio.TabIndex = 0;
            this.comboAnio.SelectedIndexChanged += new System.EventHandler(this.comboAnio_SelectedIndexChanged);
            // 
            // comboTrimestre
            // 
            this.comboTrimestre.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboTrimestre.FormattingEnabled = true;
            this.comboTrimestre.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4"});
            this.comboTrimestre.Location = new System.Drawing.Point(425, 33);
            this.comboTrimestre.Name = "comboTrimestre";
            this.comboTrimestre.Size = new System.Drawing.Size(121, 21);
            this.comboTrimestre.TabIndex = 1;
            this.comboTrimestre.SelectedIndexChanged += new System.EventHandler(this.comboTrimestre_SelectedIndexChanged);
            // 
            // Calcular
            // 
            this.Calcular.Location = new System.Drawing.Point(465, 87);
            this.Calcular.Name = "Calcular";
            this.Calcular.Size = new System.Drawing.Size(81, 21);
            this.Calcular.TabIndex = 2;
            this.Calcular.Text = "Obtener";
            this.Calcular.UseVisualStyleBackColor = true;
            this.Calcular.Click += new System.EventHandler(this.Calcular_Click);
            // 
            // comboFuncionalidad
            // 
            this.comboFuncionalidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboFuncionalidad.FormattingEnabled = true;
            this.comboFuncionalidad.Items.AddRange(new object[] {
            "Choferes con mayor recaudacion",
            "Choferes con el viaje mas largo realizado",
            "Clientes con mayor consumo",
            "Cliente que utilizo mas veces mismo automovil"});
            this.comboFuncionalidad.Location = new System.Drawing.Point(283, 60);
            this.comboFuncionalidad.Name = "comboFuncionalidad";
            this.comboFuncionalidad.Size = new System.Drawing.Size(263, 21);
            this.comboFuncionalidad.TabIndex = 3;
            this.comboFuncionalidad.SelectedIndexChanged += new System.EventHandler(this.comboFuncionalidad_SelectedIndexChanged);
            // 
            // labelAnio
            // 
            this.labelAnio.AutoSize = true;
            this.labelAnio.Location = new System.Drawing.Point(15, 9);
            this.labelAnio.Name = "labelAnio";
            this.labelAnio.Size = new System.Drawing.Size(28, 13);
            this.labelAnio.TabIndex = 4;
            this.labelAnio.Text = "Anio";
            // 
            // labelTrimestre
            // 
            this.labelTrimestre.AutoSize = true;
            this.labelTrimestre.Location = new System.Drawing.Point(15, 36);
            this.labelTrimestre.Name = "labelTrimestre";
            this.labelTrimestre.Size = new System.Drawing.Size(50, 13);
            this.labelTrimestre.TabIndex = 5;
            this.labelTrimestre.Text = "Trimestre";
            // 
            // labelListado
            // 
            this.labelListado.AutoSize = true;
            this.labelListado.Location = new System.Drawing.Point(18, 63);
            this.labelListado.Name = "labelListado";
            this.labelListado.Size = new System.Drawing.Size(41, 13);
            this.labelListado.TabIndex = 6;
            this.labelListado.Text = "Listado";
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 133);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(534, 222);
            this.dataGridView1.TabIndex = 7;
            // 
            // Listado
            // 
            this.ClientSize = new System.Drawing.Size(558, 367);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.labelListado);
            this.Controls.Add(this.labelTrimestre);
            this.Controls.Add(this.labelAnio);
            this.Controls.Add(this.comboFuncionalidad);
            this.Controls.Add(this.Calcular);
            this.Controls.Add(this.comboTrimestre);
            this.Controls.Add(this.comboAnio);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Listado";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboAnio;
        private System.Windows.Forms.ComboBox comboTrimestre;
        private System.Windows.Forms.Button Calcular;
        private System.Windows.Forms.ComboBox comboFuncionalidad;
        private System.Windows.Forms.Label labelAnio;
        private System.Windows.Forms.Label labelTrimestre;
        private System.Windows.Forms.Label labelListado;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}