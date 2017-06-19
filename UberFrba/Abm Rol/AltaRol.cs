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
using UberFrba.Helpers;
using UberFrba.Interface;

namespace UberFrba.Abm_Rol
{
    public partial class AltaRol : Form
    {
        private List<FuncionalidadDTO> funcionalidadesXRol;
        private OnCreateUpdateListener createUpdateListener;

        public AltaRol()
        {
            InitializeComponent();
            loadFuncionalidades();
            funcionalidadesXRol = new List<FuncionalidadDTO>();
            habilitadoCheckBox.CheckState = CheckState.Checked;
        }

        public AltaRol(OnCreateUpdateListener createUpdateListener) : this()
        {
            this.createUpdateListener = createUpdateListener;
        }

        private void loadFuncionalidades()
        {
            funcionalidadesComboBox.DataSource = FuncionalidadDAO.getFuncionalidades();
            funcionalidadesComboBox.SelectedIndex = -1;
        }

        private void Nombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.allowAlphanumericOnly(e);
        }

        private void addFuncionalidadButton_Click(object sender, EventArgs e)
        {
            if (funcionalidadesComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione alguna funcionalidad para agregar");
                return;
            }

            FuncionalidadDTO funcionalidad = (FuncionalidadDTO)funcionalidadesComboBox.SelectedItem;

            if (funcionalidadesXRol.Contains(funcionalidad))
            {
                MessageBox.Show("Ya ha agregado esta funcionalidad");
                return;
            }

            funcionalidadesXRol.Add(funcionalidad);
            funcionalidadesDataGridView.Rows.Add(funcionalidad.descripcion);
            funcionalidadesComboBox.SelectedIndex = -1;
            
        }

        private void removeFuncionalidadButton_Click(object sender, EventArgs e)
        {
            if (funcionalidadesDataGridView.RowCount == 0)
            {
                MessageBox.Show("Debe haber agregar y seleccionar una funcionalidad para removerla");
            }

            if (funcionalidadesDataGridView.RowCount > 0)
            {
                int index = funcionalidadesDataGridView.SelectedRows[0].Index;
                funcionalidadesXRol.RemoveAt(index);
                funcionalidadesDataGridView.Rows.RemoveAt(index);
            }
        }

        private void createRolButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(nombreTextBox.Text))
            {
                Utility.ShowInfo("Alta Rol", "Debe ingresar un nombre para el rol");
                return;
            }

            if (funcionalidadesXRol.Count == 0)
            {
                Utility.ShowInfo("Alta Rol", "Debe agregar al menos una funcionalidad");
                return;
            }

            try
            {
                RolDAO.createRol(nombreTextBox.Text, funcionalidadesXRol);
                this.Close();
                createUpdateListener.onOperationFinish();
            }
            catch (ApplicationException excep)
            {
                Utility.ShowError("Alta Rol", excep.Message);
            }


        }

    }
}
