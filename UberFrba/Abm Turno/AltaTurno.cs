using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            this.horaInicio.ResetText();
            this.horaFin.ResetText();
            this.comboDescripcion.Text = "";
            this.valorKM.Text = "";
            this.precioBase.Text = "";
            this.checkHabilitado.Text = "";
        }

        // Validaciones

        private void horaInicio_KeyPress(object sender, KeyPressEventArgs e) 
        {
            // TODO
        }

        private void horaFin_KeyPress(object sender, KeyPressEventArgs e)
        {
            // TODO
        }

        private void horaFin_TextChanged(object sender, KeyPressEventArgs e)
        { 
            // Al cambiar el valor.

            MessageBox.Show("ENTRO");

            int mayor = DateTime.Compare(horaInicio.Value, horaFin.Value);

            if (mayor > 0 || mayor == 0)
            {
                MessageBox.Show("La hora de fin debe ser mayor a la inicial dentro del mismo dia.", "Error");
            }
             
        }


        private void comboDescripcion_KeyPress(object sender, KeyPressEventArgs e)
        {
            // TODO
        }

        private void valorKM_KeyPress(object sender, KeyPressEventArgs e)
        {
            // TODO
        }

        private void precioBase_KeyPress(object sender, KeyPressEventArgs e)
        {
            // TODO
        }

        private void checkHabilitado_KeyPress(object sender, KeyPressEventArgs e)
        {
            // TODO
        }

        // Falta validacion de fecha

        private void Agregar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(horaInicio.Text) && !string.IsNullOrWhiteSpace(horaFin.Text) && !string.IsNullOrWhiteSpace(comboDescripcion.Text) && !string.IsNullOrWhiteSpace(valorKM.Text) && !string.IsNullOrWhiteSpace(precioBase.Text) && !string.IsNullOrWhiteSpace(checkHabilitado.Text))
            {
                if (validacionFecha())
                {
                    if (setearVariables())
                    {
                        // Agregar
                        MessageBox.Show("Se agrego correctamente");
                    }

                }
                else
                {
                    MessageBox.Show("El viaje no puede tener una duracion de mas de 24 hs","Error");
                }                
            }
            else
            {
                MessageBox.Show("Debe completar todos los campos", "Error");
            }
        }

        private bool validacionFecha()
        {
            return ( horaInicio.Value.Day == horaFin.Value.Day);
           
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


            turno = new TurnoDTO(horaInicio.Value, horaFin.Value, (string)comboDescripcion.SelectedValue, valor , precio , checkHabilitado.Checked);

            return true;
        }



    }
}
