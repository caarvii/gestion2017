using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UberFrba.Dto;
using UberFrba.Dao;
using UberFrba.Helpers;
using UberFrba.Interface;

namespace UberFrba.Abm_Turno
{
    public partial class AltaTurno : Form
    {
        TurnoDTO turno;
        TurnoDTO turnoEdicion;

        private bool edicion = false;


        private double valor;
        private double precio;

        OnCreateUpdateListener listener;

        public AltaTurno(OnCreateUpdateListener listenerExterno)
        {
            InitializeComponent();
            this.Text = "Alta de Turnos";
            this.Agregar.Text = "Agregar";
            this.edicion = false;
            this.checkHabilitado.Checked = true;
            listener = listenerExterno;
                   
        }

        public AltaTurno(int turnoModificableID, OnCreateUpdateListener listenerExterno)
        {
            InitializeComponent();

            cargarDatosEdicion(turnoModificableID);

            this.Text = "Edicion de Turnos";
            this.Agregar.Text = "Editar";

            this.edicion = true;

            listener = listenerExterno;

        }
        
        private void cargarDatosEdicion(int turnoModificableID)
        {
            turnoEdicion = TurnoDAO.selectTurnoById(turnoModificableID);

            this.turnoEdicion.id = turnoModificableID;

            this.comboInicio.Text = turnoEdicion.horaInicial.ToString();
            this.comboFin.Text = turnoEdicion.horaFinal.ToString();
            this.txtDescripcion.Text = turnoEdicion.descripcion;
            this.valorKM.Text = turnoEdicion.valor.ToString();
            this.precioBase.Text = turnoEdicion.precio.ToString();
            this.checkHabilitado.Checked = turnoEdicion.estado;  

        }

        private void botonLimpiar_Click(object sender, EventArgs e)
        {
            this.comboInicio.SelectedIndex = -1;
            this.comboFin.SelectedIndex = -1;
            this.txtDescripcion.Text = "";
            this.valorKM.Text = "";
            this.precioBase.Text = "";
            this.checkHabilitado.Text = "";
        }

        // Validaciones

        private void txtDescripcion_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.allowAlphanumericOnly(e);
        }

        private void valorKM_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.allowNumericOnly(e);
        }

        private void precioBase_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.allowNumericOnly(e);
        }

        // Botones

        private void Agregar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(comboInicio.Text) && !string.IsNullOrWhiteSpace(comboFin.Text) && !string.IsNullOrWhiteSpace(txtDescripcion.Text) && !string.IsNullOrWhiteSpace(valorKM.Text) && !string.IsNullOrWhiteSpace(precioBase.Text) && !string.IsNullOrWhiteSpace(checkHabilitado.Text))
            {
                if (validacionFecha())
                {
                    if (setearVariables())
                    {
                        agregarEditarTurno(turno); 
                    }
                }
                else
                {
                    MessageBox.Show("La hora de inicio no puede ser mayor a la hora de fin o ser la misma","Error");
                }                
            }
            else
            {
                MessageBox.Show("Debe completar todos los campos", "Error");
            }
        }

        private bool validacionFecha()
        {
            int inicio = Convert.ToInt32(comboInicio.SelectedItem);
            int final = Convert.ToInt32(comboFin.SelectedItem);
            return ( inicio < final);
           
        }
        
        private bool setearVariables()
        {
            
            try
            {
                valor = Convert.ToDouble(valorKM.Text);
            }
            catch { MessageBox.Show("Escriba correctamente el valor del Kilometro", "Validacion"); return false; }
            
            try
            {
                precio = Convert.ToDouble(precioBase.Text);
            }
            catch { MessageBox.Show("Escriba correctamente el precio base", "Validacion"); return false; }

            turno = new TurnoDTO(Convert.ToInt32(comboInicio.SelectedItem), Convert.ToInt32(comboFin.SelectedItem), txtDescripcion.Text, valor, precio, checkHabilitado.Checked);

            return true;
        }

        private void agregarEditarTurno(TurnoDTO turnoActivo) 
        {
            if (this.edicion)
            {
                // Edicion
                try
                {
                    turnoActivo.id = this.turnoEdicion.id;
                    TurnoDAO.updateTurno(turnoActivo);
                    MessageBox.Show("Se edito el turno correctamente");
                    this.Close();
                    listener.onOperationFinish();
                }
                catch (ApplicationException ex)
                {
                    Utility.ShowError("Error al editar el turno", ex);
                }              

            }else
            {
                // Alta 
                try
                {
                    TurnoDAO.addNewTurno(turnoActivo);
                    MessageBox.Show("Se agrego el turno correctamente");
                    this.Close();
                    listener.onOperationFinish();
                }
                catch (ApplicationException ex)
                {
                    Utility.ShowError("Error al agregar el turno", ex);
                }

            }
            
        }

        private void AltaTurno_Load(object sender, EventArgs e)
        {

        }


    }
}
