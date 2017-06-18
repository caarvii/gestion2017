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
    public abstract partial class ListadoGenerico : Form
    {
        public ListadoGenerico()
        {
            InitializeComponent();
        }

        protected virtual void botonLimpiar_Click(object sender, EventArgs e)
        {
            tablaListado.DataSource = null;
        }

        protected virtual void botonBaja_Click(object sender, EventArgs e)
        {
            // TODO
        }

        protected virtual void botonModificacion_Click(object sender, EventArgs e)
        {
            //TODO
        }

        protected virtual void botonAlta_Click(object sender, EventArgs e)
        {
            //TODO
        }

        private void listadoGenerico_Load(object sender, EventArgs e)
        {

        }
    }
}
