using Clientes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Constructora
{
    public partial class Cliente : Form
    {
        ClienteDAO cDAO = new ClienteDAO();
        public Cliente()
        {
            InitializeComponent();
            dataGridView1.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dataGridView1.MultiSelect = false;
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;

            dataGridView1.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.AllCells;

            CalenderFecha.MaxSelectionCount = 1;

            CalenderFecha.SetDate(DateTime.Today.AddYears(-20));
            CalenderFecha.MaxDate = DateTime.Today.AddYears(-20);

            Insertar.Click += Insertar_Click;
            Modificar.Click += Modificar_Click;
            btnEliminar.Click += btnEliminar_Click;

            dataGridView1.SelectionChanged +=
                dataGridView1_SelectionChanged;
        }

        private void Cliente_Load(object sender, EventArgs e)
        {
            CargarTabla();
            LimpiarCampos();
        }

        private void CargarTabla()
        {
            try
            {
                DataTable tabla = cDAO.consultarDatos();
                dataGridView1.AutoGenerateColumns = true;
                dataGridView1.DataSource = tabla;

                // Desactivar el ajuste automático solamente en esta columna.
                dataGridView1.Columns["IdCliente"].AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.None;

                // Ancho en píxeles.
                dataGridView1.Columns["IdCliente"].Width = 65;

                dataGridView1.Columns["IdCliente"].HeaderText =
                    "ID cliente";

                dataGridView1.Columns["NombreCliente"].HeaderText =
                    "Nombre del cliente";

                dataGridView1.Columns["TelefonoC"].HeaderText =
                    "Teléfono del cliente";

                dataGridView1.Columns["DireccionC"].HeaderText =
                    "Dirección del cliente";

                dataGridView1.Columns["FechaNacimientoC"].HeaderText =
                    "Fecha de nacimiento";

                dataGridView1.Columns["FechaNacimientoC"]
                    .DefaultCellStyle.Format = "dd/MM/yyyy";

                dataGridView1.Columns["EdadC"].HeaderText = "Edad del cliente";
                dataGridView1.Columns["EdadC"].Visible = true;
                dataGridView1.Columns["EdadC"].ReadOnly = true;
                dataGridView1.Columns["EdadC"].DefaultCellStyle.Format = "0";
                dataGridView1.Columns["EdadC"].DefaultCellStyle.NullValue = "Sin calcular";


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al consultar datos: " + ex.Message);
            }
        }

        private void LimpiarCampos()
        {
            dataGridView1.ClearSelection();

            txtNombre.Text = "";
            txtTelefono.Text = "";
            txtDireccion.Text = "";

            CalenderFecha.SetDate(DateTime.Today.AddYears(-20));
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtTelefono.Text) ||
                string.IsNullOrWhiteSpace(txtDireccion.Text))
            {
                MessageBox.Show("Por favor rellene los campos...");
                return false;
            }

            if (!Regex.IsMatch(txtTelefono.Text.Trim(), @"^[0-9]{10}$"))
            {
                MessageBox.Show(
                      "El teléfono debe tener 10 dígitos, sin espacios ni guiones.");
                  return false;
            }

            return true;
        }

        private void dataGridView1_SelectionChanged(
            object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
                return;

            if (dataGridView1.SelectedRows[0].DataBoundItem
                is DataRowView fila)
            {
                txtNombre.Text = fila["NombreCliente"].ToString();
                txtTelefono.Text = fila["TelefonoC"].ToString();
                txtDireccion.Text = fila["DireccionC"].ToString();

                CalenderFecha.SetDate(
                    Convert.ToDateTime(fila["FechaNacimientoC"]));
            }
        }

        private void Insertar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
                return;

            if (cDAO.ExisteTelefono(txtTelefono.Text.Trim()))
            {
                MessageBox.Show("Este teléfono ya está registrado.");
                return;
            }

            try
            {
                cDAO.InsertarCliente(
                    txtNombre.Text.Trim(),
                    txtTelefono.Text.Trim(),
                    txtDireccion.Text.Trim(),
                    CalenderFecha.SelectionStart);

                CargarTabla();
                LimpiarCampos();
            }
            catch (SqlException ex)
                when (ex.Number == 2627 || ex.Number == 2601)
            {

                MessageBox.Show(
                    "El teléfono ya está registrado en otro cliente.");
            }
            catch (Exception ex)
            {

                MessageBox.Show(
                    "Error al insertar el cliente: " + ex.Message);
            }
        }

        private void Modificar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {   
                MessageBox.Show("Seleccione un cliente...");
                return;
            }

            if (!ValidarCampos())
                return;

            long idCliente = Convert.ToInt64(
                    dataGridView1.SelectedRows[0]
                        .Cells["IdCliente"].Value);

            if (cDAO.ExisteTelefonoOtroCliente(txtTelefono.Text.Trim(), idCliente))
            {
                MessageBox.Show("El teléfono ya está registrado por otro cliente.");
                return;
            }

            try
            {
                cDAO.ModificarCliente(
                    idCliente,
                    txtNombre.Text.Trim(),
                    txtTelefono.Text.Trim(),
                    txtDireccion.Text.Trim(),
                    CalenderFecha.SelectionStart);

                CargarTabla();
                LimpiarCampos();
            }
            catch (SqlException ex)
                when (ex.Number == 2627 || ex.Number == 2601)
            {

                MessageBox.Show(
                    "El teléfono ya está registrado en otro cliente.");

            }
            catch (Exception ex)
            {

                MessageBox.Show(
                    "Error al modificar el cliente: " + ex.Message);

            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                
                MessageBox.Show("Seleccione un cliente...");
                return;
                
            }

            try
            {
                long idCliente = Convert.ToInt64(
                    dataGridView1.SelectedRows[0]
                        .Cells["IdCliente"].Value);

                cDAO.EliminarCliente(idCliente);

                CargarTabla();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                
                MessageBox.Show(
                    "Error al eliminar el cliente: " + ex.Message);
                
            }
        }

    }
}

