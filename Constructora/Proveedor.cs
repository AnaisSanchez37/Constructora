using ConstructoraBD;
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
    public partial class Proveedor : Form
    {
        ProveedorDAO pDAO = new ProveedorDAO();
        private long IdProveedorSeleccionado = -1;

        public Proveedor()
        {
            InitializeComponent();
        }
        private void Proveedor_Load(object sender, EventArgs e)
        {
            CargarTabla();
            txtTelefono.MaxLength = 10;
            dgvProveedor.CellClick += dgvProveedor_CellClick;
        }

        private void CargarTabla()
        {
            try
            {
                DataTable tabla = pDAO.consultarDatos();

                dgvProveedor.DataSource = tabla;

                dgvProveedor.Columns["IdProveedor"].HeaderText = "ID Proveedor";
                dgvProveedor.Columns["NombreProveedor"].HeaderText = "Nombre del Proveedor";
                dgvProveedor.Columns["TelefonoP"].HeaderText = "Teléfono del Proveedor";
                dgvProveedor.Columns["DireccionP"].HeaderText = "Dirección del Proveedor";
                dgvProveedor.Columns["Contacto"].HeaderText = "Contacto";


                dgvProveedor.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                dgvProveedor.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvProveedor.Columns["IdProveedor"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dgvProveedor.Columns["IdProveedor"].Width = 65;
                dgvProveedor.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

                dgvProveedor.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvProveedor.MultiSelect = false;
                dgvProveedor.ReadOnly = true;
                dgvProveedor.AllowUserToAddRows = false;
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Error al consultar datos: " + ex.Message);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtTelefono.Text) ||
                string.IsNullOrWhiteSpace(txtDireccion.Text) ||
                string.IsNullOrWhiteSpace(txtContacto.Text))
            {
                //MessageBox.Show("Por favor rellene todos los campos.");
                return;
            }

            try
            {

                if (pDAO.TelefonoExiste(txtTelefono.Text))
                {
                    MessageBox.Show("El teléfono ya está registrado.");
                    return;
                }

                if (txtTelefono.Text.Length != 10 || !txtTelefono.Text.All(char.IsDigit))
                {
                    MessageBox.Show("El campo debe de tener 10 dígitos");
                    return;
                }

                pDAO.InsertarProveedor(
                    txtNombre.Text,
                    txtTelefono.Text,
                    txtDireccion.Text,
                    txtContacto.Text
                );


                CargarTabla();

                LimpiarDatos();
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Error al agregar el proveedor: " + ex.Message);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (IdProveedorSeleccionado == -1)
            {
                //MessageBox.Show("Seleccione una fila de la tabla para modificar.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtTelefono.Text) ||
                string.IsNullOrWhiteSpace(txtDireccion.Text) ||
                string.IsNullOrWhiteSpace(txtContacto.Text))
            {
                //MessageBox.Show("Por favor complete todos los campos.");
                return;
            }

            try
            {

                if (pDAO.TelefonoExiste(txtTelefono.Text, IdProveedorSeleccionado))
                {
                    MessageBox.Show("El teléfono ya está registrado para otro proveedor.");
                    return;
                }

                if (txtTelefono.Text.Length != 10 || !txtTelefono.Text.All(char.IsDigit))
                {
                    MessageBox.Show("El campo debe de tener 10 dígitos");
                    return;
                }

                pDAO.ModificarProveedor(
                    IdProveedorSeleccionado,
                    txtNombre.Text,
                    txtTelefono.Text,
                    txtDireccion.Text,
                    txtContacto.Text
                );


                CargarTabla();

                LimpiarDatos();

                IdProveedorSeleccionado = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al modificar el proveedor: " + ex.Message);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (IdProveedorSeleccionado == -1)
            {
                //MessageBox.Show("Seleccione primero una fila de la tabla para eliminar.");
                return;
            }

            try
            {
                pDAO.EliminarProveedor(IdProveedorSeleccionado);



                CargarTabla();

                LimpiarDatos();

                IdProveedorSeleccionado = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar el proveedor: " + ex.Message);
            }

        }

        private void dgvProveedor_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && !dgvProveedor.Rows[e.RowIndex].IsNewRow)
            {
                DataGridViewRow fila = dgvProveedor.Rows[e.RowIndex];

                IdProveedorSeleccionado = Convert.ToInt64(fila.Cells["IdProveedor"].Value);

                txtNombre.Text = fila.Cells["NombreProveedor"].Value.ToString();

                txtTelefono.Text = fila.Cells["TelefonoP"].Value.ToString();

                txtDireccion.Text = fila.Cells["DireccionP"].Value.ToString();

                txtContacto.Text = fila.Cells["Contacto"].Value.ToString();
            }
        }

        private void LimpiarDatos()
        {
            IdProveedorSeleccionado = -1;
            txtNombre.Text = "";
            txtTelefono.Text = "";
            txtDireccion.Text = "";
            txtContacto.Text = "";
        }

    }
}

