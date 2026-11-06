using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using ConstructoraBD;

namespace Constructora
{
    public partial class ProveedorServicio : Form
    {
        private ProveedorServicioDAO dao = new ProveedorServicioDAO();
        private long idSeleccionado = -1;

        public ProveedorServicio()
        {
            InitializeComponent();
            CargarComboBoxes();
        }

        private void CargarComboBoxes()
        {
            cmbProveedor.DataSource = dao.ObtenerProveedor();
            cmbProveedor.DisplayMember = "NombreProveedor";
            cmbProveedor.ValueMember = "IdProveedor";
            cmbProveedor.SelectedIndex = -1;

            cmbServicio.DataSource = dao.ObtenerServicio();
            cmbServicio.DisplayMember = "NombreServicio";
            cmbServicio.ValueMember = "IdServicio";
            cmbServicio.SelectedIndex = -1;
        }

        private void ProveedorServicio_Load(object sender, EventArgs e)
        {
            try
            {
                cmbProveedor.DisplayMember = "NombreProveedor";
                cmbProveedor.ValueMember = "IdProveedor";
                cmbProveedor.DataSource = new ProveedorDAO().consultarDatos();
                cmbServicio.DisplayMember = "NombreServicio";
                cmbServicio.ValueMember = "IdServicio";
                cmbServicio.DataSource = new ServicioDAO().consultarDatos();
                CargarTabla();
                CargarComboBoxes();
                LimpiarDatos();
            }
            catch (Exception ex) { /*MessageBox.Show("Error al consultar datos: " + ex.Message); */}
        }

        private void CargarTabla()
        {
            dgvProveedorServicio.DataSource = dao.consultarDatos();
            dgvProveedorServicio.Columns["IdProveedorServicio"].HeaderText = "ID Proveedor-Servicio";
            dgvProveedorServicio.Columns["IdProveedor"].Visible = false;
            dgvProveedorServicio.Columns["IdServicio"].Visible = false;
            dgvProveedorServicio.Columns["NombreProveedor"].HeaderText = "Proveedor";
            dgvProveedorServicio.Columns["NombreServicio"].HeaderText = "Servicio";
            dgvProveedorServicio.Columns["CostoBase"].HeaderText = "Costo base";
            dgvProveedorServicio.Columns["CostoBase"].DefaultCellStyle.Format = "N2";

            // Ajustar el tamaño de las columnas.
            dgvProveedorServicio.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgvProveedorServicio.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProveedorServicio.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvProveedorServicio.Columns["IdProveedorServicio"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvProveedorServicio.Columns["IdProveedorServicio"].Width = 45;
            dgvProveedorServicio.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProveedorServicio.MultiSelect = false;

            dgvProveedorServicio.MultiSelect = false;
        }

        private bool ValidarDatos()
        {
            if (cmbProveedor.SelectedValue == null || cmbServicio.SelectedValue == null)
            {
                MessageBox.Show("Seleccione un proveedor y un servicio. Regístrelos primero si las listas están vacías.");
                return false;
            }
            if (dao.ExisteRelacion(Convert.ToInt64(cmbProveedor.SelectedValue), Convert.ToInt64(cmbServicio.SelectedValue), idSeleccionado))
            {
                MessageBox.Show("Este servicio ya está registrado para el proveedor.");
                return false;
            }
            return true;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                idSeleccionado = -1;
                if (!ValidarDatos()) return;
                dao.InsertarProveedorServicio(Convert.ToInt64(cmbProveedor.SelectedValue), Convert.ToInt64(cmbServicio.SelectedValue), nudCostoBase.Value);
                CargarTabla();
                CargarComboBoxes();
                LimpiarDatos();
            }
            catch (Exception ex) { MessageBox.Show("Error al agregar datos.El servicio ya está registrado para el proveedor.");}
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            //if (idSeleccionado == -1) { MessageBox.Show("Seleccione una fila para modificar."); return; }
            try
            {
                if (!ValidarDatos()) return;
                dao.ModificarProveedorServicio(idSeleccionado, Convert.ToInt64(cmbProveedor.SelectedValue), Convert.ToInt64(cmbServicio.SelectedValue), nudCostoBase.Value);
                CargarTabla();
                CargarComboBoxes();
                LimpiarDatos();
            }
            catch (Exception ex) { MessageBox.Show("Error al modificar los datos.El servicio ya está registrado para el proveedor."); }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            //if (idSeleccionado == -1) { MessageBox.Show("Seleccione una fila para eliminar."); return; }
            //if (MessageBox.Show("¿Desea eliminar el registro seleccionado?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
            try
            {
                dao.EliminarProveedorServicio(idSeleccionado);
                CargarTabla();
                CargarComboBoxes();
                LimpiarDatos();
            }
            catch (SqlException ex)
            {
                if (ex.Number == 547) MessageBox.Show("No se puede eliminar porque hay registros relacionados.");
                else MessageBox.Show("Error al eliminar. ");
            }
            catch (Exception ex) { MessageBox.Show("Error al eliminar."); }
        }

        private void dgvProveedorServicio_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || dgvProveedorServicio.Rows[e.RowIndex].IsNewRow) return;
            DataGridViewRow fila = dgvProveedorServicio.Rows[e.RowIndex];
            idSeleccionado = Convert.ToInt64(fila.Cells["IdProveedorServicio"].Value);
            cmbProveedor.SelectedValue = Convert.ToInt64(fila.Cells["IdProveedor"].Value);
            cmbServicio.SelectedValue = Convert.ToInt64(fila.Cells["IdServicio"].Value);
            nudCostoBase.Value = Convert.ToDecimal(fila.Cells["CostoBase"].Value);
        }

        private void LimpiarDatos()
        {
            idSeleccionado = -1;
            cmbProveedor.SelectedIndex = -1;
            cmbServicio.SelectedIndex = -1;
            nudCostoBase.Value = 0;
            dgvProveedorServicio.ClearSelection();
        }

    }
}

