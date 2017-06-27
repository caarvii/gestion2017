using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UberFrba.Dao;
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
            if (this.comboBoxNoTienenValores())
            {
                MessageBox.Show("Debe seleccionar un valor en todos los combos", "Error");
            }

            else
            {
                Dictionary<string, int> parameters = new Dictionary<string, int>();
                int anio = Int32.Parse(comboAnio.Text);
                int trimestre = Int32.Parse(comboTrimestre.Text);
                String funcionalidad = comboFuncionalidad.Text;


                SqlDataReader reader = ListadoEstadisticoDAO.consultarListado(funcionalidad, trimestre, anio);
                this.dataGridView1.ReadOnly = true;
                this.dataGridView1.AutoGenerateColumns = true;

                DataTable dt = new DataTable();
                dt.Load(reader);
                this.dataGridView1.DataSource = dt;
            }
            
        }

        private bool comboBoxNoTienenValores()
        {
            if (
            this.comboAnioNoTieneValor() ||
            this.comboTrimestreNoTieneValor() ||
            this.comboFuncionalidadNoTieneValor()){return true;}

            else{return false;}
        }

        private bool comboFuncionalidadNoTieneValor()
        {
            if (comboFuncionalidad.SelectedIndex == -1) { return true; }

            else { return false; }
        }

        private bool comboTrimestreNoTieneValor()
        {
            if (comboTrimestre.SelectedIndex == -1) {return true; }

            else { return false; }
        }

        private bool comboAnioNoTieneValor()
        {
            if (comboAnio.SelectedIndex == -1) { return true; }

            else { return false; }
        }

        private void comboAnio_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.dataGridView1.DataSource = null;
        }

        private void comboTrimestre_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.dataGridView1.DataSource = null;
        }

        private void comboFuncionalidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.dataGridView1.DataSource = null;
        }
    }
}
