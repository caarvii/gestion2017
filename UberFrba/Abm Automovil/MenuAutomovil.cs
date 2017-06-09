using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UberFrba.Abm_Automovil
{
    public partial class MenuAutomovil : UberFrba.menuGenerico
    {
        public MenuAutomovil()
        {
            InitializeComponent();
            this.Text = this.Text + " de Automoviles";
        }

        
        protected override void altaBoton_Click(object sender, EventArgs e) 
        {
            //ActiveForm.Visible = false;
            AltaAutomovil formAlta = new AltaAutomovil();
            formAlta.setPadre(Form.ActiveForm); // No me funca bien
            formAlta.ShowDialog();
        }

        protected override void listadoBoton_Click(object sender, EventArgs e)
        {
            // ActiveForm.Visible = false;
            ListadoAutomovilesReal listadoForm = new ListadoAutomovilesReal();
            listadoForm.ShowDialog();
        }

        // TODO
        // Falta baja y modificacion



    }
}
