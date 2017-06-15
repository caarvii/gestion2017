using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UberFrba.Dao;
using UberFrba.Dto;

namespace UberFrba.Abm_Turno
{
    public partial class ListadoTurno : UberFrba.listadoGenerico
    {
        public ListadoTurno()
        {
            InitializeComponent();
        }



        private void ListadoTurno_Load(object sender, EventArgs e)
        {
            // Si no existe ningun filtro aplicado.
            // validar filtroDescripcion

            //tablaListado.DataSource = TurnoDAO.getAllTurnos();


        }

        protected override void botonAlta_Click_1(object sender, EventArgs e)
        {
            AltaTurno altaTurnoForm = new AltaTurno();
            altaTurnoForm.ShowDialog();
        }

        protected override void botonBuscar_Click(object sender, EventArgs e)
        {
            tablaListado.DataSource = TurnoDAO.getAllTurnos();

        }

        /*protected override void botonModificacion_Click_1(object sender, EventArgs e)
        {
            if (tablaListado.SelectedRows.Count == 1 && tablaListado.Rows.Count > 0)
            {
                AltaTurno altaTurnoForm = new AltaTurno(this, tablaListado.SelectedRows);
                altaTurnoForm.Show();
                this.Hide();
            }   
        }*/



    }
}
