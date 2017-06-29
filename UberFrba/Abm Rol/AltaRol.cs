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

        private static string ALTA_NAME = "Crear Rol";
        private static string MODIFICACION_NAME = "Modificar Rol";

        private List<FuncionalidadDTO> funcionalidadesXRol;
        private OnCreateUpdateListener createUpdateListener;
        private RolDTO rol;
        private ListadoRol listadoRol;
        private bool editMode { get; set; } 

        public AltaRol()
        {
            InitializeComponent();
            editMode = false;
        }

        public AltaRol(OnCreateUpdateListener createUpdateListener)
            : this()
        {
            this.createUpdateListener = createUpdateListener;
        }

        public AltaRol(RolDTO rol, OnCreateUpdateListener createUpdateListener) :
            this(createUpdateListener)
        {
            this.rol = rol;
            this.editMode = true;
        }

        private void onAltaLoad(object sender, System.EventArgs e)
        {
            loadFuncionalidades();
            funcionalidadesXRol = new List<FuncionalidadDTO>();
            habilitadoCheckBox.CheckState = CheckState.Checked;
            
            stateLabel.Visible = editMode;
            habilitadoCheckBox.Visible = editMode;

            if (editMode && rol != null)
            {
                loadFieldsWithRol();
                this.Text = MODIFICACION_NAME;
                this.createUpdateRolButton.Text = MODIFICACION_NAME;
            }
        }

        private void loadFieldsWithRol()
        {
            nombreTextBox.Text = rol.nombre;
            habilitadoCheckBox.CheckState = rol.activo ? CheckState.Checked : CheckState.Unchecked;
            foreach (FuncionalidadDTO func in rol.funcionalidadesList)
            {
                funcionalidadesXRol.Add(func);
                funcionalidadesDataGridView.Rows.Add(func.id, func.descripcion);
            }
        }

        private void loadFuncionalidades()
        {
            funcionalidadesComboBox.DataSource = FuncionalidadDAO.getFuncionalidades();
            funcionalidadesComboBox.SelectedIndex = -1;
        }

        private void Nombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.allowAlphanumericOnly(e);
            if (e.KeyChar != 8) this.allowMaxLenght(nombreTextBox, 30, e);
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
            funcionalidadesDataGridView.Rows.Add(funcionalidad.id, funcionalidad.descripcion);
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

        private void createUpdateRolButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(nombreTextBox.Text))
            {
                Utility.ShowInfo(editMode ? MODIFICACION_NAME : ALTA_NAME,
                    "Debe ingresar un nombre para el rol");
                return;
            }

            if (funcionalidadesXRol.Count == 0)
            {
                Utility.ShowInfo(editMode ? MODIFICACION_NAME : ALTA_NAME,
                    "El rol debe tener al menos una funcionalidad");
                return;
            }

            try
            {
                if (editMode && rol != null)
                {
                    RolDAO.updateRol(rol.id, nombreTextBox.Text, 
                        habilitadoCheckBox.CheckState == CheckState.Checked, funcionalidadesXRol);
                }
                else
                {
                    RolDAO.createRol(nombreTextBox.Text, funcionalidadesXRol);
                }

                this.Close();
                createUpdateListener.onOperationFinish();
            }
            catch (ApplicationException excep)
            {
                Utility.ShowError(editMode ? MODIFICACION_NAME : ALTA_NAME, excep.Message);
            }


        }


       
    }
}
