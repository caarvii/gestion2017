using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UberFrba.Abm_Chofer;
using UberFrba.Dao;
using UberFrba.Dto;
using UberFrba.Interface;
using UberFrba.Login;
using UberFrba.Repository;

namespace UberFrba.Rendicion_Viajes
{
    public partial class Rendicion : Form, ListadoSeleccionListener
    {
        private TurnoDTO turno;
        private ChoferDTO chofer;
        private DateTime date;

        public Rendicion()
        {
            InitializeComponent();
            this.fechaRendicionDateTimePicker.Value = Config.newInstance.date; 
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        public void onOperationFinishTurno(TurnoDTO turno)
        {
           //Do nothing
        }

        public void onOperationFinishChofer(ChoferDTO chofer)
        {
            this.chofer = chofer;
            this.dniTextBox.Text = chofer.dni.ToString();
            this.nombreApellidoTextBox.Text = chofer.nombre + " " + chofer.apellido;
            
            turnosChoferComboBox.DataSource = RendicionDAO.getTurnosViajesByChofer(chofer);
        }

        private void selectChoferButton_Click(object sender, EventArgs e)
        {
            ListadoChofer listadoSeleccionDeChoferForm = new ListadoChofer(this);
            listadoSeleccionDeChoferForm.ShowDialog();
        }

        private void onTurnosSelectIndexChanged(object sender, System.EventArgs e)
        {
            if (turnosChoferComboBox.SelectedIndex != -1)
            {
                this.turno = (TurnoDTO) turnosChoferComboBox.SelectedItem;
                inicioTurnoTextBox.Text = Convert.ToString(turno.horaInicial);
                finTurnoTextBox.Text = Convert.ToString(turno.horaFinal);
            }
        }

        private void cleanButton_Click(object sender, EventArgs e)
        {
            this.fechaRendicionDateTimePicker.Value = Config.newInstance.date;

            this.chofer = null;
            this.dniTextBox.Text = "";
            this.nombreApellidoTextBox.Text = "";

            turnosChoferComboBox.DataSource = null;

            this.turno = null;
            inicioTurnoTextBox.Text = "";
            finTurnoTextBox.Text = "";
        }
    }
}
