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
using UberFrba.Helpers;
using UberFrba.Interface;
using UberFrba.Login;
using UberFrba.Repository;

namespace UberFrba.Rendicion_Viajes
{
    public partial class Rendicion : Form, ListadoSeleccionListener
    {
        private TurnoDTO turno;
        private ChoferDTO chofer;
        private double importeTotal;
        private List<int> viajesParaRendirList;

        public Rendicion()
        {
            InitializeComponent();
            this.importeTotal = 0;
            this.viajesParaRendirList = new List<int>();
            this.fechaRendicionDateTimePicker.Value = Config.newInstance.date;
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
            ListadoChofer listadoSeleccionDeChoferForm = new ListadoChofer(this , true);
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
            cleanFields();
        }

        private void cleanFields()
        {
            this.fechaRendicionDateTimePicker.Value = Config.newInstance.date;

            this.chofer = null;
            this.dniTextBox.Text = "";
            this.nombreApellidoTextBox.Text = "";

            turnosChoferComboBox.DataSource = null;

            this.turno = null;
            inicioTurnoTextBox.Text = "";
            finTurnoTextBox.Text = "";

            viajesParaRendirDataGridView.DataSource = null;

            viajesParaRendirList.Clear();

            importeTotal = 0;
            totalRendicionMontoLabel.Text = "";
        }

        private void buscarViajesButton_Click(object sender, EventArgs e)
        {
            if (chofer == null || turno == null)
            {
                Utility.ShowInfo("Rendicion", "Debe seleccionar un chofer y un turno para buscar los viajes");
                return;
            }

            DataTable dt = new DataTable();
            dt.Load(RendicionDAO.getViajesNoRendidos(chofer, turno, fechaRendicionDateTimePicker.Value));


            if (dt.Rows.Count == 0)
            {
                Utility.ShowInfo("Rendicion", "No hay viajes sin rendir para los datos ingresados");
                return;
            }

            viajesParaRendirDataGridView.DataSource = dt;

            List<double> valorRendiciones = dt.AsEnumerable().Select(x => 
                Convert.ToDouble(x[x.Table.Columns["valor_rendicion"].Ordinal])).ToList();

            viajesParaRendirList.AddRange(dt.AsEnumerable().Select(x =>
               Convert.ToInt32(x[x.Table.Columns["viaje_id"].Ordinal])).ToList());

            importeTotal = valorRendiciones.Sum();

            totalRendicionMontoLabel.Text = "$ " + importeTotal;
        }

        private void generarRendicionButton_Click(object sender, EventArgs e)
        {
            if (chofer == null || turno == null)
            {
                Utility.ShowInfo("Rendicion", "Debe seleccionar un chofer y un turno para buscar los viajes");
                return;
            }

            if (viajesParaRendirList.Count == 0)
            {
                Utility.ShowInfo("Rendicion", "Seleccione Buscar Viajes para encontrar los viajes del chofer");
                return;
            }

            try
            {
                RendicionDAO.generarRendicion(chofer, turno, fechaRendicionDateTimePicker.Value, importeTotal, viajesParaRendirList);
                Utility.ShowInfo("Rendicion", "Rendicion creada con exito");
                cleanFields();
            }
            catch (ApplicationException ex)
            {
                Utility.ShowError("Rendicion", ex.Message);
            }

           
        }
    }
}
