using Arquitecto;
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
    public partial class Arquitecto : Form
    {
        ArquitectoDAO logica = new ArquitectoDAO();
        private int idSeleccionado = 0;
        public Arquitecto()
        {
            InitializeComponent();
            dgvArquitecto.CellClick += dgvArquitecto_CellClick;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtTelefono.MaxLength = 10;
            dtFecha.MaxDate = DateTime.Today.AddYears(-20);
            dtFecha.Value = DateTime.Today.AddYears(-20);
            CargarGrid();
        }

        private void CargarGrid()
        {
            dgvArquitecto.DataSource = logica.ObtenerArquitectos();

            dgvArquitecto.Columns["IdArquitecto"].HeaderText = "ID Arquitecto";
            dgvArquitecto.Columns["NombreArquitecto"].HeaderText = "Nombre del Arquitecto";
            dgvArquitecto.Columns["TelefonoA"].HeaderText = "Teléfono del arquitecto";
            dgvArquitecto.Columns["FechaNacimientoA"].HeaderText = "Fecha de nacimiento";
            dgvArquitecto.Columns["Sueldo"].HeaderText = "Sueldo";
            dgvArquitecto.Columns["EdadA"].HeaderText = "Edad del arquitecto";

            if (dgvArquitecto.Columns["Sueldo"] != null)
            {
                dgvArquitecto.Columns["Sueldo"].DefaultCellStyle.Format = "N2";
            }

            dgvArquitecto.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgvArquitecto.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvArquitecto.Columns["IdArquitecto"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvArquitecto.Columns["IdArquitecto"].Width = 80;
            dgvArquitecto.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }

        private void dgvArquitecto_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dgvArquitecto.Rows[e.RowIndex];

                if (fila.Cells["IdArquitecto"].Value != DBNull.Value && fila.Cells["IdArquitecto"].Value != null)
                {
                    idSeleccionado = Convert.ToInt32(fila.Cells["IdArquitecto"].Value);
                    txtNombreA.Text = fila.Cells["NombreArquitecto"].Value.ToString();
                    txtTelefono.Text = fila.Cells["TelefonoA"].Value.ToString();

                    if (fila.Cells["FechaNacimientoA"].Value != DBNull.Value)
                    {
                        dtFecha.Value = Convert.ToDateTime(fila.Cells["FechaNacimientoA"].Value);
                    }

                    txtSueldoB.Text = Convert.ToDecimal(fila.Cells["Sueldo"].Value).ToString("0.00");
                }
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombreA.Text) ||
                string.IsNullOrWhiteSpace(txtTelefono.Text) ||
                string.IsNullOrWhiteSpace(txtSueldoB.Text))
            {
                MessageBox.Show("Por favor rellene todos los campos...");
                return;
            }

            if (txtTelefono.Text.Length != 10)
            {
                MessageBox.Show("El campo debe tener exactamente 10 dígitos.");
                return;
            }

            if (logica.ExisteTelefono(txtTelefono.Text))
            {
                MessageBox.Show("Este telefono ya está registrado.");
                return;
            }

            try
            {
                decimal sueldoRedondeado = Math.Round(Convert.ToDecimal(txtSueldoB.Text), 2);

                logica.InsertarArquitecto(
                    txtNombreA.Text,
                    txtTelefono.Text,
                    dtFecha.Value,
                    sueldoRedondeado
                );

                CargarGrid();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al insertar el arquitecto: " + ex.Message);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (idSeleccionado == 0 || string.IsNullOrWhiteSpace(txtNombreA.Text))
            {
                MessageBox.Show("Por favor selecciona un arquitecto de la tabla y modifica los campos necesarios.");
                return;
            }

            if (txtTelefono.Text.Length != 10)
            {
                MessageBox.Show("El campo debe tener exactamente 10 dígitos.");
                return;
            }

            if (logica.ExisteTelefonoOtroArquitecto(txtTelefono.Text, idSeleccionado))
            {
                MessageBox.Show("El teléfono ya está registrado por otro arquitecto.");
                return;
            }

            try
            {
                decimal sueldoRedondeado = Math.Round(Convert.ToDecimal(txtSueldoB.Text), 2);

                logica.ModificarArquitecto(
                    idSeleccionado,
                    txtNombreA.Text,
                    txtTelefono.Text,
                    dtFecha.Value,
                    sueldoRedondeado
                );

                CargarGrid();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al modificar el arquitecto: " + ex.Message);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (idSeleccionado == 0)
            {
                MessageBox.Show("Por favor selecciona un arquitecto de la tabla para eliminar.");
                return;
            }

            try
            {
                logica.EliminarArquitecto(idSeleccionado);
                CargarGrid();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar el arquitecto: " + ex.Message);
            }
        }
        private void LimpiarCampos()
        {
            txtNombreA.Clear();
            txtTelefono.Clear();
            txtSueldoB.Clear();
            dtFecha.Value = DateTime.Today.AddYears(-20);
            idSeleccionado = 0;
        }
    }
}
