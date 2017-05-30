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
    public partial class MenuAutomovil : Form
    {
        public MenuAutomovil()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
           ActiveForm.Visible = false;
            AltaAutomovil formAlta = new AltaAutomovil();
            formAlta.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ActiveForm.Visible = false;
            ListadoAutomil listadoForm = new ListadoAutomil();
            listadoForm.ShowDialog();
        }
    }
}
