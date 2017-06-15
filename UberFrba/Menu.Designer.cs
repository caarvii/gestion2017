namespace UberFrba
{
    partial class Menu 
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
            this.menuFuncionalidades = new System.Windows.Forms.MenuStrip();
            this.welcomeTitleTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.usernameTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.funcionalidadesTitleTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.abmTitleTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.rolesMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clientesMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.autoMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.turnosMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.choferesMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.operacionesTitleTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.registrarViajeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rendicionViajesMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.facturarClienteMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportesTitleTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.listadoEstadisticoMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.accountTitleTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.cerrarSesionMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFuncionalidades.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuFuncionalidades
            // 
            this.menuFuncionalidades.Dock = System.Windows.Forms.DockStyle.Left;
            this.menuFuncionalidades.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.welcomeTitleTextBox,
            this.usernameTextBox,
            this.funcionalidadesTitleTextBox,
            this.abmTitleTextBox,
            this.rolesMenuItem,
            this.clientesMenuItem,
            this.autoMenuItem,
            this.turnosMenuItem,
            this.choferesMenuItem,
            this.operacionesTitleTextBox,
            this.registrarViajeMenuItem,
            this.rendicionViajesMenuItem,
            this.facturarClienteMenuItem,
            this.reportesTitleTextBox,
            this.listadoEstadisticoMenuItem,
            this.accountTitleTextBox,
            this.cerrarSesionMenuItem});
            this.menuFuncionalidades.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.menuFuncionalidades.Location = new System.Drawing.Point(0, 0);
            this.menuFuncionalidades.Name = "menuFuncionalidades";
            this.menuFuncionalidades.Size = new System.Drawing.Size(141, 473);
            this.menuFuncionalidades.TabIndex = 0;
            this.menuFuncionalidades.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuFuncionalidades_ItemClicked);
            // 
            // welcomeTitleTextBox
            // 
            this.welcomeTitleTextBox.BackColor = System.Drawing.SystemColors.Control;
            this.welcomeTitleTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.welcomeTitleTextBox.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.welcomeTitleTextBox.Margin = new System.Windows.Forms.Padding(2, 5, 1, 0);
            this.welcomeTitleTextBox.Name = "welcomeTitleTextBox";
            this.welcomeTitleTextBox.Size = new System.Drawing.Size(125, 15);
            this.welcomeTitleTextBox.Text = "Bienvenido,";
            this.welcomeTitleTextBox.Click += new System.EventHandler(this.toolStripTextBox6_Click);
            // 
            // usernameTextBox
            // 
            this.usernameTextBox.BackColor = System.Drawing.SystemColors.Control;
            this.usernameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.usernameTextBox.Margin = new System.Windows.Forms.Padding(2, 0, 1, 0);
            this.usernameTextBox.Name = "usernameTextBox";
            this.usernameTextBox.Size = new System.Drawing.Size(125, 16);
            this.usernameTextBox.Text = "david";
            // 
            // funcionalidadesTitleTextBox
            // 
            this.funcionalidadesTitleTextBox.BackColor = System.Drawing.SystemColors.MenuBar;
            this.funcionalidadesTitleTextBox.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.funcionalidadesTitleTextBox.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.funcionalidadesTitleTextBox.Margin = new System.Windows.Forms.Padding(0, 5, 10, 5);
            this.funcionalidadesTitleTextBox.Name = "funcionalidadesTitleTextBox";
            this.funcionalidadesTitleTextBox.Size = new System.Drawing.Size(118, 25);
            this.funcionalidadesTitleTextBox.Text = "Funcionalidades";
            // 
            // abmTitleTextBox
            // 
            this.abmTitleTextBox.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.abmTitleTextBox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.abmTitleTextBox.Name = "abmTitleTextBox";
            this.abmTitleTextBox.Size = new System.Drawing.Size(126, 23);
            this.abmTitleTextBox.Text = "ABMs";
            // 
            // rolesMenuItem
            // 
            this.rolesMenuItem.BackColor = System.Drawing.SystemColors.Control;
            this.rolesMenuItem.Margin = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.rolesMenuItem.Name = "rolesMenuItem";
            this.rolesMenuItem.Size = new System.Drawing.Size(128, 19);
            this.rolesMenuItem.Text = "Roles";
            this.rolesMenuItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // clientesMenuItem
            // 
            this.clientesMenuItem.Margin = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.clientesMenuItem.Name = "clientesMenuItem";
            this.clientesMenuItem.Size = new System.Drawing.Size(128, 19);
            this.clientesMenuItem.Text = "Clientes";
            this.clientesMenuItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // autoMenuItem
            // 
            this.autoMenuItem.Margin = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.autoMenuItem.Name = "autoMenuItem";
            this.autoMenuItem.Size = new System.Drawing.Size(128, 19);
            this.autoMenuItem.Text = "Automoviles";
            this.autoMenuItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.autoMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            // 
            // turnosMenuItem
            // 
            this.turnosMenuItem.Margin = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.turnosMenuItem.Name = "turnosMenuItem";
            this.turnosMenuItem.Size = new System.Drawing.Size(128, 19);
            this.turnosMenuItem.Text = "Turnos";
            this.turnosMenuItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // choferesMenuItem
            // 
            this.choferesMenuItem.Margin = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.choferesMenuItem.Name = "choferesMenuItem";
            this.choferesMenuItem.Size = new System.Drawing.Size(128, 19);
            this.choferesMenuItem.Text = "Choferes";
            this.choferesMenuItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // operacionesTitleTextBox
            // 
            this.operacionesTitleTextBox.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.operacionesTitleTextBox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.operacionesTitleTextBox.Margin = new System.Windows.Forms.Padding(1, 15, 1, 0);
            this.operacionesTitleTextBox.Name = "operacionesTitleTextBox";
            this.operacionesTitleTextBox.Size = new System.Drawing.Size(126, 23);
            this.operacionesTitleTextBox.Text = "Operaciones";
            // 
            // registrarViajeMenuItem
            // 
            this.registrarViajeMenuItem.Margin = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.registrarViajeMenuItem.Name = "registrarViajeMenuItem";
            this.registrarViajeMenuItem.Size = new System.Drawing.Size(128, 19);
            this.registrarViajeMenuItem.Text = "Registrar Viaje";
            this.registrarViajeMenuItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.registrarViajeMenuItem.Click += new System.EventHandler(this.toolStripMenuItem4_Click);
            // 
            // rendicionViajesMenuItem
            // 
            this.rendicionViajesMenuItem.Margin = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.rendicionViajesMenuItem.Name = "rendicionViajesMenuItem";
            this.rendicionViajesMenuItem.Size = new System.Drawing.Size(128, 19);
            this.rendicionViajesMenuItem.Text = "Rendicion de Viajes";
            this.rendicionViajesMenuItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // facturarClienteMenuItem
            // 
            this.facturarClienteMenuItem.Margin = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.facturarClienteMenuItem.Name = "facturarClienteMenuItem";
            this.facturarClienteMenuItem.Size = new System.Drawing.Size(128, 19);
            this.facturarClienteMenuItem.Text = "Facturacion a Clientes";
            this.facturarClienteMenuItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // reportesTitleTextBox
            // 
            this.reportesTitleTextBox.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.reportesTitleTextBox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.reportesTitleTextBox.Margin = new System.Windows.Forms.Padding(1, 15, 1, 0);
            this.reportesTitleTextBox.Name = "reportesTitleTextBox";
            this.reportesTitleTextBox.Size = new System.Drawing.Size(126, 23);
            this.reportesTitleTextBox.Text = "Reportes";
            // 
            // listadoEstadisticoMenuItem
            // 
            this.listadoEstadisticoMenuItem.Margin = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.listadoEstadisticoMenuItem.Name = "listadoEstadisticoMenuItem";
            this.listadoEstadisticoMenuItem.Size = new System.Drawing.Size(128, 19);
            this.listadoEstadisticoMenuItem.Text = "Listado Estadistico";
            this.listadoEstadisticoMenuItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // accountTitleTextBox
            // 
            this.accountTitleTextBox.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.accountTitleTextBox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.accountTitleTextBox.Margin = new System.Windows.Forms.Padding(1, 25, 1, 0);
            this.accountTitleTextBox.Name = "accountTitleTextBox";
            this.accountTitleTextBox.Size = new System.Drawing.Size(126, 23);
            this.accountTitleTextBox.Text = "Cuenta";
            this.accountTitleTextBox.Click += new System.EventHandler(this.toolStripTextBox5_Click);
            // 
            // cerrarSesionMenuItem
            // 
            this.cerrarSesionMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cerrarSesionMenuItem.Margin = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.cerrarSesionMenuItem.Name = "cerrarSesionMenuItem";
            this.cerrarSesionMenuItem.Size = new System.Drawing.Size(128, 19);
            this.cerrarSesionMenuItem.Text = "Cerrar Sesion";
            this.cerrarSesionMenuItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(639, 473);
            this.Controls.Add(this.menuFuncionalidades);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuFuncionalidades;
            this.MaximizeBox = false;
            this.Name = "Menu Funcionalidades";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu";
            this.Load += new System.EventHandler(this.onMenuLoad);
            this.menuFuncionalidades.ResumeLayout(false);
            this.menuFuncionalidades.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
         
        private System.Windows.Forms.MenuStrip menuFuncionalidades;
           

        #endregion

        private System.Windows.Forms.ToolStripMenuItem rolesMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clientesMenuItem;
        private System.Windows.Forms.ToolStripMenuItem autoMenuItem;
        private System.Windows.Forms.ToolStripTextBox abmTitleTextBox;
        private System.Windows.Forms.ToolStripMenuItem turnosMenuItem;
        private System.Windows.Forms.ToolStripMenuItem choferesMenuItem;
        private System.Windows.Forms.ToolStripTextBox operacionesTitleTextBox;
        private System.Windows.Forms.ToolStripMenuItem registrarViajeMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rendicionViajesMenuItem;
        private System.Windows.Forms.ToolStripMenuItem facturarClienteMenuItem;
        private System.Windows.Forms.ToolStripTextBox reportesTitleTextBox;
        private System.Windows.Forms.ToolStripMenuItem listadoEstadisticoMenuItem;
        private System.Windows.Forms.ToolStripTextBox accountTitleTextBox;
        private System.Windows.Forms.ToolStripMenuItem cerrarSesionMenuItem;
        private System.Windows.Forms.ToolStripTextBox funcionalidadesTitleTextBox;
        private System.Windows.Forms.ToolStripTextBox welcomeTitleTextBox;
        private System.Windows.Forms.ToolStripTextBox usernameTextBox;
    }
}