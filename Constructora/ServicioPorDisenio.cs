using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Constructora
{
    public partial class ServicioPorDisenio : Form
    {
        ServicioPorDisenioDAO logica = new ServicioPorDisenioDAO();
        private long idDisenioSeleccionadoOriginal = 0;
        private long idPSSeleccionadoOriginal = 0;

        public ServicioPorDisenio()
        {
            InitializeComponent();
            dgvServicioPorDisenio.CellClick += dgvServicioPorDisenio_CellClick;
        }

        private void ServicioPorDisenio_Load(object sender, EventArgs e)
        {
            CargarComboBoxes();
            CargarGrid();
        }

        private void CargarComboBoxes()
        {
            cmbDisenio.DataSource = logica.ObtenerDisenios();
            cmbDisenio.DisplayMember = "NombreDisenio";
            cmbDisenio.ValueMember = "IdDisenio";
            cmbDisenio.SelectedIndex = -1;

            cmbProveedorServicio.DataSource = logica.ObtenerProveedorServicios();
            cmbProveedorServicio.DisplayMember = "DescripcionPS";
            cmbProveedorServicio.ValueMember = "IdProveedorServicio";
            cmbProveedorServicio.SelectedIndex = -1;
        }

        private void CargarGrid()
        {
            dgvServicioPorDisenio.DataSource = logica.ObtenerServicioPorDisenio();

            dgvServicioPorDisenio.Columns["IdDisenio"].Visible = false;
            dgvServicioPorDisenio.Columns["IdProveedorServicio"].Visible = false;

            dgvServicioPorDisenio.Columns["NombreDisenio"].HeaderText = "Diseño";
            dgvServicioPorDisenio.Columns["NombreProveedorServicio"].HeaderText = "Proveedor - Servicio";
            dgvServicioPorDisenio.Columns["Fecha"].HeaderText = "Fecha";
            dgvServicioPorDisenio.Columns["Duracion"].HeaderText = "Duración (Semanas)";
            dgvServicioPorDisenio.Columns["CostoServicioDisenio"].HeaderText = "Costo Servicio";

            dgvServicioPorDisenio.Columns["CostoServicioDisenio"].DefaultCellStyle.Format = "N2";

            dgvServicioPorDisenio.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgvServicioPorDisenio.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvServicioPorDisenio.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvServicioPorDisenio.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvServicioPorDisenio.MultiSelect = false;
        }

        private void dgvServicioPorDisenio_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dgvServicioPorDisenio.Rows[e.RowIndex];

                if (fila.Cells["IdDisenio"].Value != DBNull.Value && fila.Cells["IdProveedorServicio"].Value != DBNull.Value)
                {
                    idDisenioSeleccionadoOriginal = Convert.ToInt64(fila.Cells["IdDisenio"].Value);
                    idPSSeleccionadoOriginal = Convert.ToInt64(fila.Cells["IdProveedorServicio"].Value);

                    cmbDisenio.SelectedValue = idDisenioSeleccionadoOriginal;
                    cmbProveedorServicio.SelectedValue = idPSSeleccionadoOriginal;
                    txtDuracion.Text = fila.Cells["Duracion"].Value.ToString();
                }
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            int duracion;
            if (cmbDisenio.SelectedIndex == -1 || cmbProveedorServicio.SelectedIndex == -1 ||
                string.IsNullOrWhiteSpace(txtDuracion.Text) || !int.TryParse(txtDuracion.Text, out duracion) || duracion <= 0)
            {
                MessageBox.Show("Por favor seleccione un diseño, un proveedor/servicio y escriba una duración válida mayor a 0.");
                return;
            }

            try
            {
                long idDisenio = Convert.ToInt64(cmbDisenio.SelectedValue);
                long idPS = Convert.ToInt64(cmbProveedorServicio.SelectedValue);
                DateTime fechaActual = DateTime.Today;

                logica.Insertar(idDisenio, idPS, fechaActual, duracion);

                CargarGrid();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al insertar.Datos duplicados.");
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (idDisenioSeleccionadoOriginal == 0 || idPSSeleccionadoOriginal == 0)
            {
                MessageBox.Show("Seleccione un registro de la tabla para modificar.");
                return;
            }

            int duracion;
            if (string.IsNullOrWhiteSpace(txtDuracion.Text) || !int.TryParse(txtDuracion.Text, out duracion) || duracion <= 0)
            {
                MessageBox.Show("Ingrese una duración válida en número entero.");
                return;
            }

            try
            {
                long idDisenioNuevo = Convert.ToInt64(cmbDisenio.SelectedValue);
                long idPSNuevo = Convert.ToInt64(cmbProveedorServicio.SelectedValue);
                DateTime fechaActual = DateTime.Today;

                logica.Modificar(idDisenioSeleccionadoOriginal, idPSSeleccionadoOriginal, idDisenioNuevo, idPSNuevo, fechaActual, duracion);

                CargarGrid();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al modificar.");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (idDisenioSeleccionadoOriginal == 0 || idPSSeleccionadoOriginal == 0)
            {
                MessageBox.Show("Seleccione un registro de la tabla para eliminar.");
                return;
            }

            try
            {
                logica.Eliminar(idDisenioSeleccionadoOriginal, idPSSeleccionadoOriginal);

                CargarGrid();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar.");
            }
        }

        private void LimpiarCampos()
        {
            cmbDisenio.SelectedIndex = -1;
            cmbProveedorServicio.SelectedIndex = -1;
            txtDuracion.Clear();
            idDisenioSeleccionadoOriginal = 0;
            idPSSeleccionadoOriginal = 0;
            dgvServicioPorDisenio.ClearSelection();
        }

    }
}
