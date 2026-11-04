using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Constructora
{
    public partial class Disenio : Form
    {
        private DisenioDAO dao = new DisenioDAO();
        private long idSeleccionado = -1;

        public Disenio()
        {
            InitializeComponent();
        }

        private void Disenio_Load(object sender, EventArgs e)
        {
            try
            {
                cmbArquitecto.DisplayMember = "NombreArquitecto";
                cmbArquitecto.ValueMember = "IdArquitecto";
                cmbArquitecto.DataSource = dao.ObtenerArquitectos();
                cmbProyecto.DisplayMember = "NombreProyecto";
                cmbProyecto.ValueMember = "IdProyecto";
                cmbProyecto.DataSource = dao.ObtenerProyectos();
                CargarTabla();
                LimpiarDatos();
            }
            catch (Exception ex) { /* MessageBox.Show("Error al consultar datos: " + ex.Message); */ }
        }

        private void CargarTabla()
        {
            dgvDisenio.DataSource = dao.consultarDatos();
            dgvDisenio.Columns["IdDisenio"].HeaderText = "ID";
            dgvDisenio.Columns["IdArquitecto"].Visible = false;
            dgvDisenio.Columns["IdProyecto"].Visible = false;
            dgvDisenio.Columns["NombreArquitecto"].HeaderText = "Arquitecto";
            dgvDisenio.Columns["NombreProyecto"].HeaderText = "Proyecto";
            dgvDisenio.Columns["NombreDisenio"].HeaderText = "Nombre del diseño";
            dgvDisenio.Columns["FechaCreacion"].HeaderText = "Fecha de creación";
            dgvDisenio.Columns["FechaCreacion"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvDisenio.Columns["Descripcion"].HeaderText = "Descripción";
            dgvDisenio.Columns["CostoDisenio"].HeaderText = "Costo del diseño";
            dgvDisenio.Columns["CostoDisenio"].DefaultCellStyle.Format = "N2";
        }

        private bool ValidarDatos()
        {
            if (cmbArquitecto.SelectedValue == null || cmbProyecto.SelectedValue == null ||
                string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtDescripcion.Text))
            {
                //MessageBox.Show("Seleccione arquitecto y proyecto y complete el nombre y la descripción.");
                return false;
            }
            return true;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidarDatos()) return;
                dao.InsertarDisenio(Convert.ToInt64(cmbArquitecto.SelectedValue),
                    Convert.ToInt64(cmbProyecto.SelectedValue), txtNombre.Text.Trim(),
                    dtpFechaCreacion.Value, txtDescripcion.Text.Trim(), nudCostoDisenio.Value);
                CargarTabla();
                LimpiarDatos();
            }
            catch (Exception ex) { /* MessageBox.Show("Error al agregar el diseño: " + ex.Message); */ }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            //if (idSeleccionado == -1) { MessageBox.Show("Seleccione una fila para modificar."); return; }
            try
            {
                if (!ValidarDatos()) return;
                dao.ModificarDisenio(idSeleccionado, Convert.ToInt64(cmbArquitecto.SelectedValue),
                    Convert.ToInt64(cmbProyecto.SelectedValue), txtNombre.Text.Trim(),
                    dtpFechaCreacion.Value, txtDescripcion.Text.Trim(), nudCostoDisenio.Value);
                CargarTabla();
                LimpiarDatos();
            }
            catch (Exception ex) { MessageBox.Show("Error al modificar el diseño: " + ex.Message); }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            //if (idSeleccionado == -1) { MessageBox.Show("Seleccione una fila para eliminar."); return; }
            /* if (MessageBox.Show("¿Desea eliminar el diseño seleccionado?", "Confirmar",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return; */
            try
            {
                dao.EliminarDisenio(idSeleccionado);
                CargarTabla();
                LimpiarDatos();
            }
            catch (SqlException ex)
            {
                if (ex.Number == 547) MessageBox.Show("No se puede eliminar el diseño porque tiene registros relacionados.");
                else MessageBox.Show("Error al eliminar el diseño: " + ex.Message);
            }
            catch (Exception ex) { MessageBox.Show("Error al eliminar el diseño: " + ex.Message); }
        }

        private void dgvDisenio_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || dgvDisenio.Rows[e.RowIndex].IsNewRow) return;
            DataGridViewRow fila = dgvDisenio.Rows[e.RowIndex];
            idSeleccionado = Convert.ToInt64(fila.Cells["IdDisenio"].Value);
            cmbArquitecto.SelectedValue = Convert.ToInt64(fila.Cells["IdArquitecto"].Value);
            cmbProyecto.SelectedValue = Convert.ToInt64(fila.Cells["IdProyecto"].Value);
            txtNombre.Text = fila.Cells["NombreDisenio"].Value.ToString();
            dtpFechaCreacion.Value = Convert.ToDateTime(fila.Cells["FechaCreacion"].Value);
            txtDescripcion.Text = fila.Cells["Descripcion"].Value.ToString();
            nudCostoDisenio.Value = Convert.ToDecimal(fila.Cells["CostoDisenio"].Value);
        }

        private void LimpiarDatos()
        {
            idSeleccionado = -1;
            cmbArquitecto.SelectedIndex = -1;
            cmbProyecto.SelectedIndex = -1;
            txtNombre.Clear();
            dtpFechaCreacion.Value = DateTime.Today;
            txtDescripcion.Clear();
            nudCostoDisenio.Value = 0;
            dgvDisenio.ClearSelection();
        }
    }
}

