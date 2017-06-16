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

namespace UberFrba.Abm_Turno
{
    public partial class AltaTurno : Form
    {
        TurnoDTO turno;

        private double valor;
        private double precio;
        
        public AltaTurno()
        {
            InitializeComponent();
                   
        }

        private void botonLimpiar_Click(object sender, EventArgs e)
        {
            this.comboInicio.ResetText();
            this.comboFin.ResetText();
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

        private void checkHabilitado_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Validar si es inherente
        }

        

        private void Agregar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(comboInicio.Text) && !string.IsNullOrWhiteSpace(comboFin.Text) && !string.IsNullOrWhiteSpace(txtDescripcion.Text) && !string.IsNullOrWhiteSpace(valorKM.Text) && !string.IsNullOrWhiteSpace(precioBase.Text) && !string.IsNullOrWhiteSpace(checkHabilitado.Text))
            {
                if (validacionFecha())
                {
                    if (setearVariables())
                    {
                        agregarTurno(turno);
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
            return ( (int) comboInicio.SelectedValue < (int) comboFin.SelectedValue );
           
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

            turno = new TurnoDTO((int)comboInicio.SelectedValue, (int)comboFin.SelectedValue, txtDescripcion.Text, valor, precio, checkHabilitado.Checked);

            return true;
        }

        private void agregarTurno(TurnoDTO turno) 
        {
            //Ver si es la validacion correcta
            try
            {
                TurnoDAO.addNewTurno(turno);
            }
            catch (ApplicationException ex)
            {
                Utility.ShowError("Error al agregar el turno", ex);
            }

            MessageBox.Show("Se agrego el turno correctamente");
        }


    }
}
