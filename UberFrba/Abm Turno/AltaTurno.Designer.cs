using System.Windows.Forms;
namespace UberFrba.Abm_Turno
{
    partial class AltaTurno
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
            this.comboFin = new System.Windows.Forms.ComboBox();
            this.comboInicio = new System.Windows.Forms.ComboBox();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.checkHabilitado = new System.Windows.Forms.CheckBox();
            this.precioBase = new System.Windows.Forms.TextBox();
            this.valorKM = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.botonLimpiar = new System.Windows.Forms.Button();
            this.Agregar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboFin);
            this.groupBox1.Controls.Add(this.comboInicio);
            this.groupBox1.Controls.Add(this.txtDescripcion);
            this.groupBox1.Controls.Add(this.checkHabilitado);
            this.groupBox1.Controls.Add(this.precioBase);
            this.groupBox1.Controls.Add(this.valorKM);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(14, 16);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(303, 217);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Atributos";

            var itemsHours = new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23"};

            // 
            // comboFin
            // 
            this.comboFin.FormattingEnabled = true;
            this.comboFin.Items.AddRange(itemsHours);
            this.comboFin.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboFin.Location = new System.Drawing.Point(135, 61);
            this.comboFin.Name = "comboFin";
            this.comboFin.Size = new System.Drawing.Size(155, 21);
            this.comboFin.TabIndex = 16;
            // 
            // comboInicio
            // 
            this.comboInicio.FormattingEnabled = true;
            this.comboInicio.Items.AddRange(itemsHours);
            this.comboInicio.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboInicio.Location = new System.Drawing.Point(135, 32);
            this.comboInicio.Name = "comboInicio";
            this.comboInicio.Size = new System.Drawing.Size(155, 21);
            this.comboInicio.TabIndex = 15;
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(136, 87);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(155, 20);
            this.txtDescripcion.TabIndex = 14;
            // 
            // checkHabilitado
            // 
            this.checkHabilitado.AutoSize = true;
            this.checkHabilitado.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkHabilitado.Location = new System.Drawing.Point(19, 183);
            this.checkHabilitado.Name = "checkHabilitado";
            this.checkHabilitado.Size = new System.Drawing.Size(73, 17);
            this.checkHabilitado.TabIndex = 11;
            this.checkHabilitado.Text = "Habilitado";
            this.checkHabilitado.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.checkHabilitado.UseVisualStyleBackColor = true;
            // 
            // precioBase
            // 
            this.precioBase.Location = new System.Drawing.Point(136, 150);
            this.precioBase.Name = "precioBase";
            this.precioBase.Size = new System.Drawing.Size(155, 20);
            this.precioBase.TabIndex = 10;
            // 
            // valorKM
            // 
            this.valorKM.Location = new System.Drawing.Point(135, 117);
            this.valorKM.Name = "valorKM";
            this.valorKM.Size = new System.Drawing.Size(157, 20);
            this.valorKM.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 151);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(107, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Precio base del turno";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 120);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Valor del Kilometro";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Descripción";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Hora de Finalización";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Hora de inicio";
            // 
            // botonLimpiar
            // 
            this.botonLimpiar.Location = new System.Drawing.Point(14, 240);
            this.botonLimpiar.Name = "botonLimpiar";
            this.botonLimpiar.Size = new System.Drawing.Size(107, 29);
            this.botonLimpiar.TabIndex = 0;
            this.botonLimpiar.Text = "Limpiar";
            this.botonLimpiar.UseVisualStyleBackColor = true;
            this.botonLimpiar.Click += new System.EventHandler(this.botonLimpiar_Click);
            // 
            // Agregar
            // 
            this.Agregar.Location = new System.Drawing.Point(202, 239);
            this.Agregar.Name = "Agregar";
            this.Agregar.Size = new System.Drawing.Size(115, 29);
            this.Agregar.TabIndex = 1;
            this.Agregar.Text = "Agregar";
            this.Agregar.UseVisualStyleBackColor = true;
            this.Agregar.Click += new System.EventHandler(this.Agregar_Click);
            // 
            // AltaTurno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.MaximizeBox = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ClientSize = new System.Drawing.Size(326, 281);
            this.Controls.Add(this.Agregar);
            this.Controls.Add(this.botonLimpiar);
            this.Controls.Add(this.groupBox1);
            this.Name = "AltaTurno";
            this.Text = "Alta de Turnos";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button botonLimpiar;
        private System.Windows.Forms.Button Agregar;
        private System.Windows.Forms.CheckBox checkHabilitado;
        private System.Windows.Forms.TextBox precioBase;
        private System.Windows.Forms.TextBox valorKM;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.ComboBox comboFin;
        private System.Windows.Forms.ComboBox comboInicio;
    }
}