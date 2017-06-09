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
    public partial class listadoGenerico : Form
    {
        public listadoGenerico()
        {
            InitializeComponent();
        }

        protected virtual void botonLimpiar_Click(object sender, EventArgs e)
        {
            tablaListado.DataSource = null;
        }
    }
}
