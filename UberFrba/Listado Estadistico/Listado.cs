using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UberFrba.Repository;

namespace UberFrba.Listado_Estadistico
{
    public partial class Listado : Form
    {
        public Listado()
        {
            InitializeComponent();

        }

        private void Calcular_Click(object sender, EventArgs e)
        {   
            Dictionary<string, int> parameters = new Dictionary<string, int>();


            /*comboAnio.Text
            SQLManager.executePorcedure("altaTurno", parameters);*/

        }
    }
}
