using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UberFrba
{
    public partial class altaGenerica : Form
    {
        public altaGenerica()
        {
            InitializeComponent();
        }

        protected virtual void limpiarBoton_Click(object sender, EventArgs e)
        {
            this.campo1 = null;
            this.campo2 = null;
            this.campo3 = null;
        }

        protected virtual void aceptarBoton_Click(object sender, EventArgs e)
        {
            // TODO

            // Mejorar claramente la forma de validar.
            // Validar por numeros ,etc.

            if (this.campo1.Text == "" | this.campo2.Text == "" | this.campo3.Text == "")
            {
                MessageBox.Show("Usted no ha completado todos los campos requeridos");
            }

        }
    }
}
