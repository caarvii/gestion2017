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
using UberFrba.Interface;
using UberFrba.Helpers;
using UberFrba.Abm_Automovil;

namespace UberFrba.Abm_Turno
{
    public partial class ListadoTurno : UberFrba.ListadoGenerico, OnCreateUpdateListener
    {

        ListadoSeleccionListener listener;
        bool seleccionDeTurno = false;
        List<TurnoDTO> turnos;
        Dictionary<string, object> filtrosTurnoList = new Dictionary<string, object>();

        public ListadoTurno()
        {
            InitializeComponent();
        }

        public void onOperationFinish()
        {

            cargarListadoTurnos();

        }

        private void cargarListadoTurnos()
        {

            tablaListado.DataSource = TurnoDAO.getAllTurnos();

		}
        public ListadoTurno(ListadoSeleccionListener _listener)
        {
            InitializeComponent();
            listener = _listener;
            botonAlta.Visible = false;
            botonBaja.Visible = false;
            botonModificacion.Text = "Seleccionar";
            seleccionDeTurno = true;

        }

        


        private void filtroDescripcion_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.allowAlphanumericOnly(e);
        }

        protected  void botonAlta_Click_1(object sender, EventArgs e)
        {
            AltaTurno altaTurnoForm = new AltaTurno(this);
            altaTurnoForm.ShowDialog();
        }

        protected  void botonBuscar_Click(object sender, EventArgs e)
        {
            filtrosTurnoList = new Dictionary<string, object>();
            
            if (!string.IsNullOrWhiteSpace(filtroDescripcion.Text))
            {
                filtrosTurnoList.Add("turno_descripcion", filtroDescripcion.Text);
            }

            //if check todos los filtros 

            if (filtrosTurnoList.Count > 0)
            {
                //Tiene filtros
                turnos = TurnoDAO.getTurnosFilter(filtrosTurnoList);
            }
            else
            {
                turnos = TurnoDAO.getAllTurnos();
            }
            tablaListado.DataSource = turnos;
			tablaListado.Columns["estado"].Visible = false
        }

        protected  void botonBaja_Click_1(object sender, EventArgs e)
        {
            // Selecciono solo uno
            if (tablaListado.SelectedRows.Count == 1 && tablaListado.RowCount != 0)
            {
                DataGridViewRow row = this.tablaListado.SelectedRows[0];

                int id = Convert.ToInt32(row.Cells["id"].Value);

                if (TurnoDAO.deleteTurno(id) == 1)
                {
                    MessageBox.Show("Turno dado de baja correctamente");
                    cargarListadoTurnos();
                }
            
            }


        }

        private void botonLimpiar_Click_1(object sender, EventArgs e)
        {
            tablaListado.DataSource = null;
            filtroDescripcion.Text = null;
        }

        private void botonModificacion_Click_2(object sender, EventArgs e)
        {

            if (seleccionDeTurno ==false)
            {

                if (tablaListado.SelectedRows.Count == 1 && tablaListado.RowCount != 0)
                {
                    DataGridViewRow row = this.tablaListado.SelectedRows[0];

                    int id = Convert.ToInt32(row.Cells["id"].Value);


                AltaTurno altaTurno = new AltaTurno(id , this);
                altaTurno.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Debe seleccionar el turno a modificar");

                }
            }
            else
            {

                //verificar q tenga 1 columna seleccionada
                int index = tablaListado.SelectedRows[0].Index;
                listener.onOperationFinish(turnos.ElementAt(index));
                this.Close();

            }
        }

        private void ListadoTurno_Load(object sender, EventArgs e)
        {

        }



    }
}
