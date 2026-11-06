using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace Constructora
{
    public partial class Servicio : Form
    {
        private ServicioDAO dao = new ServicioDAO();
        private long idSeleccionado = -1;

        public Servicio()
        {
            InitializeComponent();
        }

        private void Servicio_Load(object sender, EventArgs e)
        {
            try
            {

                CargarTabla();
                LimpiarDatos();
            }
            catch (Exception ex) { MessageBox.Show("Error al consultar datos: " + ex.Message); }
        }

        private void CargarTabla()
        {
            dgvServicio.DataSource = dao.consultarDatos();
            dgvServicio.Columns["IdServicio"].HeaderText = "ID Servicio";
            dgvServicio.Columns["NombreServicio"].HeaderText = "Nombre del servicio";
        }

        private bool ValidarDatos()
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                //MessageBox.Show("Escriba el nombre del servicio.");
                return false;
            }
            return true;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidarDatos())
                {
                    MessageBox.Show("Error al agregar, ya exixte un servicio con etsre nombre");
                    return;
                }
                dao.InsertarServicio(txtNombre.Text.Trim());
                CargarTabla();
                LimpiarDatos();
            }
            catch (Exception ex) { MessageBox.Show("Error al agregar servicio, ya existe un servicio con este nombre"); }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            //if (idSeleccionado == -1) { MessageBox.Show("Seleccione una fila para modificar."); return; }
            try
            {
                if (!ValidarDatos()) return;
                dao.ModificarServicio(idSeleccionado, txtNombre.Text.Trim());
                CargarTabla();
                LimpiarDatos();
            }
            catch (Exception ex) { MessageBox.Show("Error al agregar servicio, ya existe un servicio con este nombre"); }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            //if (idSeleccionado == -1) { MessageBox.Show("Seleccione una fila para eliminar."); return; }
            //if (MessageBox.Show("¿Desea eliminar el registro seleccionado?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
            try
            {
                dao.EliminarServicio(idSeleccionado);
                CargarTabla();
                LimpiarDatos();
            }
            catch (SqlException ex)
            {
                if (ex.Number == 547) MessageBox.Show("No se puede eliminar porque hay registros relacionados.");
                else MessageBox.Show("Error al eliminar: " + ex.Message);
            }
            catch (Exception ex) { MessageBox.Show("Error al eliminar: " + ex.Message); }
        }

        private void dgvServicio_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || dgvServicio.Rows[e.RowIndex].IsNewRow) return;
            DataGridViewRow fila = dgvServicio.Rows[e.RowIndex];
            idSeleccionado = Convert.ToInt64(fila.Cells["IdServicio"].Value);
            txtNombre.Text = fila.Cells["NombreServicio"].Value.ToString();
        }

        private void LimpiarDatos()
        {
            idSeleccionado = -1;
            txtNombre.Clear();
            dgvServicio.ClearSelection();
        }

        private void dgvServicio_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

