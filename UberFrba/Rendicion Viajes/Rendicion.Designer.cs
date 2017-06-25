using System.Windows.Forms;
namespace UberFrba.Rendicion_Viajes
{
    partial class Rendicion
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
            this.rendicionGroupBox = new System.Windows.Forms.GroupBox();
            this.cleanButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.viajesGroupBox = new System.Windows.Forms.GroupBox();
            this.totalPlataLabel = new System.Windows.Forms.Label();
            this.totalRendicionLabel = new System.Windows.Forms.Label();
            this.viajesParaRendirDataGridView = new System.Windows.Forms.DataGridView();
            this.buscarViajesButton = new System.Windows.Forms.Button();
            this.finTurnoTextBox = new System.Windows.Forms.TextBox();
            this.finTurnoLabel = new System.Windows.Forms.Label();
            this.inicioTurnoLabel = new System.Windows.Forms.Label();
            this.turnosChoferComboBox = new System.Windows.Forms.ComboBox();
            this.inicioTurnoTextBox = new System.Windows.Forms.TextBox();
            this.turnoLabel = new System.Windows.Forms.Label();
            this.selectChoferButton = new System.Windows.Forms.Button();
            this.nombreApellidoTextBox = new System.Windows.Forms.TextBox();
            this.dniTextBox = new System.Windows.Forms.TextBox();
            this.choferLabel = new System.Windows.Forms.Label();
            this.fechaRendicionDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.fechaLabel = new System.Windows.Forms.Label();
            this.rendicionGroupBox.SuspendLayout();
            this.viajesGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.viajesParaRendirDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // rendicionGroupBox
            // 
            this.rendicionGroupBox.Controls.Add(this.cleanButton);
            this.rendicionGroupBox.Controls.Add(this.button1);
            this.rendicionGroupBox.Controls.Add(this.viajesGroupBox);
            this.rendicionGroupBox.Controls.Add(this.buscarViajesButton);
            this.rendicionGroupBox.Controls.Add(this.finTurnoTextBox);
            this.rendicionGroupBox.Controls.Add(this.finTurnoLabel);
            this.rendicionGroupBox.Controls.Add(this.inicioTurnoLabel);
            this.rendicionGroupBox.Controls.Add(this.turnosChoferComboBox);
            this.rendicionGroupBox.Controls.Add(this.inicioTurnoTextBox);
            this.rendicionGroupBox.Controls.Add(this.turnoLabel);
            this.rendicionGroupBox.Controls.Add(this.selectChoferButton);
            this.rendicionGroupBox.Controls.Add(this.nombreApellidoTextBox);
            this.rendicionGroupBox.Controls.Add(this.dniTextBox);
            this.rendicionGroupBox.Controls.Add(this.choferLabel);
            this.rendicionGroupBox.Controls.Add(this.fechaRendicionDateTimePicker);
            this.rendicionGroupBox.Controls.Add(this.fechaLabel);
            this.rendicionGroupBox.Location = new System.Drawing.Point(12, 12);
            this.rendicionGroupBox.Name = "rendicionGroupBox";
            this.rendicionGroupBox.Size = new System.Drawing.Size(526, 446);
            this.rendicionGroupBox.TabIndex = 0;
            this.rendicionGroupBox.TabStop = false;
            this.rendicionGroupBox.Text = "Rendicion";
            // 
            // cleanButton
            // 
            this.cleanButton.Location = new System.Drawing.Point(125, 129);
            this.cleanButton.Name = "cleanButton";
            this.cleanButton.Size = new System.Drawing.Size(75, 23);
            this.cleanButton.TabIndex = 14;
            this.cleanButton.Text = "Limpiar";
            this.cleanButton.UseVisualStyleBackColor = true;
            this.cleanButton.Click += new System.EventHandler(this.cleanButton_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(391, 413);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 13, 3, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(109, 23);
            this.button1.TabIndex = 13;
            this.button1.Text = "Rendir Viajes";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // viajesGroupBox
            // 
            this.viajesGroupBox.Controls.Add(this.totalPlataLabel);
            this.viajesGroupBox.Controls.Add(this.totalRendicionLabel);
            this.viajesGroupBox.Controls.Add(this.viajesParaRendirDataGridView);
            this.viajesGroupBox.Location = new System.Drawing.Point(23, 170);
            this.viajesGroupBox.Name = "viajesGroupBox";
            this.viajesGroupBox.Size = new System.Drawing.Size(477, 235);
            this.viajesGroupBox.TabIndex = 2;
            this.viajesGroupBox.TabStop = false;
            this.viajesGroupBox.Text = "Viajes para rendir";
            this.viajesGroupBox.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // totalPlataLabel
            // 
            this.totalPlataLabel.Location = new System.Drawing.Point(375, 205);
            this.totalPlataLabel.Name = "totalPlataLabel";
            this.totalPlataLabel.Size = new System.Drawing.Size(79, 13);
            this.totalPlataLabel.TabIndex = 3;
            this.totalPlataLabel.Text = "$ 156.67";
            this.totalPlataLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // totalRendicionLabel
            // 
            this.totalRendicionLabel.AutoSize = true;
            this.totalRendicionLabel.Location = new System.Drawing.Point(284, 205);
            this.totalRendicionLabel.Name = "totalRendicionLabel";
            this.totalRendicionLabel.Size = new System.Drawing.Size(85, 13);
            this.totalRendicionLabel.TabIndex = 2;
            this.totalRendicionLabel.Text = "Total Rendicion:";
            this.totalRendicionLabel.Click += new System.EventHandler(this.label2_Click);
            // 
            // viajesParaRendirDataGridView
            // 
            this.viajesParaRendirDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.viajesParaRendirDataGridView.Location = new System.Drawing.Point(22, 28);
            this.viajesParaRendirDataGridView.Name = "viajesParaRendirDataGridView";
            this.viajesParaRendirDataGridView.Size = new System.Drawing.Size(432, 165);
            this.viajesParaRendirDataGridView.TabIndex = 1;
            this.viajesParaRendirDataGridView.MultiSelect = false;
            this.viajesParaRendirDataGridView.ReadOnly = true;
            this.viajesParaRendirDataGridView.AllowUserToAddRows = false;
            this.viajesParaRendirDataGridView.AllowUserToDeleteRows = false;
            this.viajesParaRendirDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            // buscarViajesButton
            // 
            this.buscarViajesButton.Location = new System.Drawing.Point(23, 129);
            this.buscarViajesButton.Name = "buscarViajesButton";
            this.buscarViajesButton.Size = new System.Drawing.Size(96, 23);
            this.buscarViajesButton.TabIndex = 12;
            this.buscarViajesButton.Text = "Buscar Viajes";
            this.buscarViajesButton.UseVisualStyleBackColor = true;
            this.buscarViajesButton.Click += new System.EventHandler(this.buscarViajesButton_Click);
            // 
            // finTurnoTextBox
            // 
            this.finTurnoTextBox.Enabled = false;
            this.finTurnoTextBox.Location = new System.Drawing.Point(312, 92);
            this.finTurnoTextBox.Name = "finTurnoTextBox";
            this.finTurnoTextBox.Size = new System.Drawing.Size(30, 20);
            this.finTurnoTextBox.TabIndex = 11;
            // 
            // finTurnoLabel
            // 
            this.finTurnoLabel.AutoSize = true;
            this.finTurnoLabel.Location = new System.Drawing.Point(285, 95);
            this.finTurnoLabel.Name = "finTurnoLabel";
            this.finTurnoLabel.Size = new System.Drawing.Size(21, 13);
            this.finTurnoLabel.TabIndex = 10;
            this.finTurnoLabel.Text = "Fin";
            this.finTurnoLabel.Click += new System.EventHandler(this.label1_Click);
            // 
            // inicioTurnoLabel
            // 
            this.inicioTurnoLabel.AutoSize = true;
            this.inicioTurnoLabel.Location = new System.Drawing.Point(211, 95);
            this.inicioTurnoLabel.Name = "inicioTurnoLabel";
            this.inicioTurnoLabel.Size = new System.Drawing.Size(32, 13);
            this.inicioTurnoLabel.TabIndex = 9;
            this.inicioTurnoLabel.Text = "Inicio";
            // 
            // turnosChoferComboBox
            // 
            this.turnosChoferComboBox.DisplayMember = "descripcion";
            this.turnosChoferComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.turnosChoferComboBox.FormattingEnabled = true;
            this.turnosChoferComboBox.Location = new System.Drawing.Point(78, 92);
            this.turnosChoferComboBox.Name = "turnosChoferComboBox";
            this.turnosChoferComboBox.Size = new System.Drawing.Size(121, 21);
            this.turnosChoferComboBox.TabIndex = 8;
            this.turnosChoferComboBox.ValueMember = "id";
            this.turnosChoferComboBox.SelectedIndexChanged += new System.EventHandler(this.onTurnosSelectIndexChanged);
            // 
            // inicioTurnoTextBox
            // 
            this.inicioTurnoTextBox.Enabled = false;
            this.inicioTurnoTextBox.Location = new System.Drawing.Point(249, 92);
            this.inicioTurnoTextBox.Name = "inicioTurnoTextBox";
            this.inicioTurnoTextBox.Size = new System.Drawing.Size(30, 20);
            this.inicioTurnoTextBox.TabIndex = 7;
            // 
            // turnoLabel
            // 
            this.turnoLabel.AutoSize = true;
            this.turnoLabel.Location = new System.Drawing.Point(20, 95);
            this.turnoLabel.Name = "turnoLabel";
            this.turnoLabel.Size = new System.Drawing.Size(35, 13);
            this.turnoLabel.TabIndex = 6;
            this.turnoLabel.Text = "Turno";
            // 
            // selectChoferButton
            // 
            this.selectChoferButton.Location = new System.Drawing.Point(323, 58);
            this.selectChoferButton.Name = "selectChoferButton";
            this.selectChoferButton.Size = new System.Drawing.Size(75, 23);
            this.selectChoferButton.TabIndex = 5;
            this.selectChoferButton.Text = "Seleccionar";
            this.selectChoferButton.UseVisualStyleBackColor = true;
            this.selectChoferButton.Click += new System.EventHandler(this.selectChoferButton_Click);
            // 
            // nombreApellidoTextBox
            // 
            this.nombreApellidoTextBox.Enabled = false;
            this.nombreApellidoTextBox.Location = new System.Drawing.Point(161, 60);
            this.nombreApellidoTextBox.Name = "nombreApellidoTextBox";
            this.nombreApellidoTextBox.Size = new System.Drawing.Size(156, 20);
            this.nombreApellidoTextBox.TabIndex = 4;
            // 
            // dniTextBox
            // 
            this.dniTextBox.Enabled = false;
            this.dniTextBox.Location = new System.Drawing.Point(78, 60);
            this.dniTextBox.Name = "dniTextBox";
            this.dniTextBox.Size = new System.Drawing.Size(77, 20);
            this.dniTextBox.TabIndex = 3;
            // 
            // choferLabel
            // 
            this.choferLabel.AutoSize = true;
            this.choferLabel.Location = new System.Drawing.Point(20, 63);
            this.choferLabel.Name = "choferLabel";
            this.choferLabel.Size = new System.Drawing.Size(38, 13);
            this.choferLabel.TabIndex = 2;
            this.choferLabel.Text = "Chofer";
            // 
            // fechaRendicionDateTimePicker
            // 
            this.fechaRendicionDateTimePicker.Location = new System.Drawing.Point(78, 31);
            this.fechaRendicionDateTimePicker.Name = "fechaRendicionDateTimePicker";
            this.fechaRendicionDateTimePicker.Size = new System.Drawing.Size(239, 20);
            this.fechaRendicionDateTimePicker.TabIndex = 1;
            // 
            // fechaLabel
            // 
            this.fechaLabel.AutoSize = true;
            this.fechaLabel.Location = new System.Drawing.Point(20, 31);
            this.fechaLabel.Name = "fechaLabel";
            this.fechaLabel.Size = new System.Drawing.Size(37, 13);
            this.fechaLabel.TabIndex = 0;
            this.fechaLabel.Text = "Fecha";
            // 
            // Rendicion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(550, 470);
            this.Controls.Add(this.rendicionGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Rendicion";
            this.Text = "Rendicion de Viajes";
            this.rendicionGroupBox.ResumeLayout(false);
            this.rendicionGroupBox.PerformLayout();
            this.viajesGroupBox.ResumeLayout(false);
            this.viajesGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.viajesParaRendirDataGridView)).EndInit();
            this.ResumeLayout(false);

        }


        #endregion

        private System.Windows.Forms.GroupBox rendicionGroupBox;
        private System.Windows.Forms.DateTimePicker fechaRendicionDateTimePicker;
        private System.Windows.Forms.Label fechaLabel;
        private System.Windows.Forms.Button selectChoferButton;
        private System.Windows.Forms.TextBox nombreApellidoTextBox;
        private System.Windows.Forms.TextBox dniTextBox;
        private System.Windows.Forms.Label choferLabel;
        private System.Windows.Forms.Label turnoLabel;
        private System.Windows.Forms.TextBox inicioTurnoTextBox;
        private System.Windows.Forms.Label inicioTurnoLabel;
        private System.Windows.Forms.ComboBox turnosChoferComboBox;
        private System.Windows.Forms.Label finTurnoLabel;
        private System.Windows.Forms.GroupBox viajesGroupBox;
        private System.Windows.Forms.DataGridView viajesParaRendirDataGridView;
        private System.Windows.Forms.Button buscarViajesButton;
        private System.Windows.Forms.TextBox finTurnoTextBox;
        private System.Windows.Forms.Label totalRendicionLabel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label totalPlataLabel;
        private Button cleanButton;
    }
}