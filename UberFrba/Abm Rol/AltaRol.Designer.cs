using System.Windows.Forms;
namespace UberFrba.Abm_Rol
{
    partial class AltaRol
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
            this.removeFuncionalidadButton = new System.Windows.Forms.Button();
            this.funcionalidadesDataGridView = new System.Windows.Forms.DataGridView(); 
            this.funcionalidadesColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.addFuncionalidadButton = new System.Windows.Forms.Button();
            this.funcionalidadesComboBox = new System.Windows.Forms.ComboBox();
            this.fucionalidadLabel = new System.Windows.Forms.Label();
            this.habilitadoCheckBox = new System.Windows.Forms.CheckBox();
            this.stateLabel = new System.Windows.Forms.Label();
            this.nombreTextBox = new System.Windows.Forms.TextBox();
            this.nombreLabel = new System.Windows.Forms.Label();
            this.createRolButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.funcionalidadesDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.removeFuncionalidadButton);
            this.groupBox1.Controls.Add(this.funcionalidadesDataGridView);
            this.groupBox1.Controls.Add(this.addFuncionalidadButton);
            this.groupBox1.Controls.Add(this.funcionalidadesComboBox);
            this.groupBox1.Controls.Add(this.fucionalidadLabel);
            this.groupBox1.Controls.Add(this.habilitadoCheckBox);
            this.groupBox1.Controls.Add(this.stateLabel);
            this.groupBox1.Controls.Add(this.nombreTextBox);
            this.groupBox1.Controls.Add(this.nombreLabel);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(426, 280);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Definir el nombre y sus funcionalidades";
            // 
            // removeFuncionalidadButton
            // 
            this.removeFuncionalidadButton.Location = new System.Drawing.Point(18, 186);
            this.removeFuncionalidadButton.Name = "removeFuncionalidadButton";
            this.removeFuncionalidadButton.Size = new System.Drawing.Size(134, 27);
            this.removeFuncionalidadButton.TabIndex = 8;
            this.removeFuncionalidadButton.Text = "Remover Funcionalidad";
            this.removeFuncionalidadButton.UseVisualStyleBackColor = true;
            this.removeFuncionalidadButton.Click += new System.EventHandler(this.removeFuncionalidadButton_Click);
            // 
            // funcionalidadesDataGridView
            // 
            this.funcionalidadesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.funcionalidadesDataGridView.Location = new System.Drawing.Point(172, 116);
            this.funcionalidadesDataGridView.MultiSelect = false;
            this.funcionalidadesDataGridView.Name = "funcionalidadesDataGridView";
            this.funcionalidadesDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.funcionalidadesDataGridView.Size = new System.Drawing.Size(240, 150);
            this.funcionalidadesDataGridView.TabIndex = 7;
            this.funcionalidadesDataGridView.AllowUserToAddRows = false;
            this.funcionalidadesDataGridView.AllowUserToDeleteRows = false;
            this.funcionalidadesDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.funcionalidadesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.funcionalidadesDataGridView.Columns.AddRange(
                new System.Windows.Forms.DataGridViewColumn[] { this.funcionalidadesColumn });

            this.funcionalidadesColumn.HeaderText = "Funcionalidades";
            this.funcionalidadesColumn.Name = "funcionalidadesColumn";
            this.funcionalidadesColumn.ReadOnly = true;
            // 
            // addFuncionalidadButton
            // 
            this.addFuncionalidadButton.Location = new System.Drawing.Point(18, 153);
            this.addFuncionalidadButton.Name = "addFuncionalidadButton";
            this.addFuncionalidadButton.Size = new System.Drawing.Size(134, 27);
            this.addFuncionalidadButton.TabIndex = 6;
            this.addFuncionalidadButton.Text = "Agregar Funcionalidad";
            this.addFuncionalidadButton.UseVisualStyleBackColor = true;
            this.addFuncionalidadButton.Click += new System.EventHandler(this.addFuncionalidadButton_Click);
            // 
            // funcionalidadesComboBox
            // 
            this.funcionalidadesComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.funcionalidadesComboBox.FormattingEnabled = true;
            this.funcionalidadesComboBox.Location = new System.Drawing.Point(18, 116);
            this.funcionalidadesComboBox.Name = "funcionalidadesComboBox";
            this.funcionalidadesComboBox.Size = new System.Drawing.Size(134, 21);
            this.funcionalidadesComboBox.TabIndex = 5;
            // 
            // fucionalidadLabel
            // 
            this.fucionalidadLabel.AutoSize = true;
            this.fucionalidadLabel.Location = new System.Drawing.Point(15, 91);
            this.fucionalidadLabel.Name = "fucionalidadLabel";
            this.fucionalidadLabel.Size = new System.Drawing.Size(73, 13);
            this.fucionalidadLabel.TabIndex = 4;
            this.fucionalidadLabel.Text = "Funcionalidad";
            // 
            // habilitadoCheckBox
            // 
            this.habilitadoCheckBox.AutoSize = true;
            this.habilitadoCheckBox.Location = new System.Drawing.Point(65, 60);
            this.habilitadoCheckBox.Name = "habilitadoCheckBox";
            this.habilitadoCheckBox.Size = new System.Drawing.Size(71, 17);
            this.habilitadoCheckBox.TabIndex = 3;
            this.habilitadoCheckBox.Text = "habilitado";
            this.habilitadoCheckBox.UseVisualStyleBackColor = true;
            // 
            // stateLabel
            // 
            this.stateLabel.AutoSize = true;
            this.stateLabel.Location = new System.Drawing.Point(15, 61);
            this.stateLabel.Name = "stateLabel";
            this.stateLabel.Size = new System.Drawing.Size(40, 13);
            this.stateLabel.TabIndex = 2;
            this.stateLabel.Text = "Estado";
            // 
            // nombreTextBox
            // 
            this.nombreTextBox.Location = new System.Drawing.Point(65, 28);
            this.nombreTextBox.Name = "nombreTextBox";
            this.nombreTextBox.Size = new System.Drawing.Size(100, 20);
            this.nombreTextBox.TabIndex = 1;
            this.nombreTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Nombre_KeyPress);
            // 
            // nombreLabel
            // 
            this.nombreLabel.AutoSize = true;
            this.nombreLabel.Location = new System.Drawing.Point(15, 31);
            this.nombreLabel.Name = "nombreLabel";
            this.nombreLabel.Size = new System.Drawing.Size(44, 13);
            this.nombreLabel.TabIndex = 0;
            this.nombreLabel.Text = "Nombre";
            // 
            // createRolButton
            // 
            this.createRolButton.Location = new System.Drawing.Point(345, 298);
            this.createRolButton.Name = "createRolButton";
            this.createRolButton.Size = new System.Drawing.Size(93, 28);
            this.createRolButton.TabIndex = 1;
            this.createRolButton.Text = "Crear Rol";
            this.createRolButton.UseVisualStyleBackColor = true;
            // 
            // AltaRol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 335);
            this.Controls.Add(this.createRolButton);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "AltaRol";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AltaRol";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.funcionalidadesDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label nombreLabel;
        private System.Windows.Forms.Label stateLabel;
        private System.Windows.Forms.TextBox nombreTextBox;
        private System.Windows.Forms.Label fucionalidadLabel;
        private System.Windows.Forms.CheckBox habilitadoCheckBox;
        private System.Windows.Forms.Button addFuncionalidadButton;
        private System.Windows.Forms.ComboBox funcionalidadesComboBox;
        private System.Windows.Forms.DataGridView funcionalidadesDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn funcionalidadesColumn;
        private System.Windows.Forms.Button removeFuncionalidadButton;
        private System.Windows.Forms.Button createRolButton;

    }
}