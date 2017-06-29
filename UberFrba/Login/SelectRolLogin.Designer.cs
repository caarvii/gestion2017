using System.Windows.Forms;
namespace UberFrba.Login
{
    partial class SelectRolLogin
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
            this.rolTitle = new System.Windows.Forms.Label();
            this.comboBoxRoles = new System.Windows.Forms.ComboBox();
            this.buttonIngresar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // rolTitle
            // 
            this.rolTitle.AutoSize = true;
            this.rolTitle.Location = new System.Drawing.Point(12, 18);
            this.rolTitle.Name = "rolTitle";
            this.rolTitle.Size = new System.Drawing.Size(23, 13);
            this.rolTitle.TabIndex = 0;
            this.rolTitle.Text = "Rol";
            // 
            // comboBoxRoles
            // 
            this.comboBoxRoles.FormattingEnabled = true;
            this.comboBoxRoles.Location = new System.Drawing.Point(41, 15);
            this.comboBoxRoles.Name = "comboBoxRoles";
            this.comboBoxRoles.Size = new System.Drawing.Size(168, 21);
            this.comboBoxRoles.TabIndex = 1;
            this.comboBoxRoles.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboBoxRoles.KeyDown += new KeyEventHandler(txtPass_KeyDown);
            this.comboBoxRoles.SelectedIndexChanged += new System.EventHandler(this.comboBoxRoles_SelectedIndexChanged);
            // 
            // buttonIngresar
            // 
            this.buttonIngresar.Location = new System.Drawing.Point(81, 56);
            this.buttonIngresar.Name = "buttonIngresar";
            this.buttonIngresar.Size = new System.Drawing.Size(75, 23);
            this.buttonIngresar.TabIndex = 2;
            this.buttonIngresar.Text = "Ingresar";
            this.buttonIngresar.UseVisualStyleBackColor = true;
            this.buttonIngresar.Click += new System.EventHandler(this.buttonIngresar_Click);
            // 
            // SelectRolLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(227, 91);
            this.Controls.Add(this.buttonIngresar);
            this.Controls.Add(this.comboBoxRoles);
            this.Controls.Add(this.rolTitle);
            this.Name = "SelectRolLogin";
            this.Text = "Selecciona tu rol";
            this.ResumeLayout(false);
            this.MaximizeBox = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.onLoadForm);
            this.PerformLayout();

        }

        

        #endregion

        private System.Windows.Forms.Label rolTitle;
        private System.Windows.Forms.ComboBox comboBoxRoles;
        private System.Windows.Forms.Button buttonIngresar;
    }
}