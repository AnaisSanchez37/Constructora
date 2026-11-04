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
    public partial class Proyecto : Form
    {
        ProyectoDAO logica = new ProyectoDAO();
        private int idSeleccionado = 0;

        public Proyecto()
        {
            InitializeComponent();
            dgvProyecto.CellClick += dgvProyecto_CellClick;
        }

        private void Proyecto_Load(object sender, EventArgs e)
        {
            CargarComboBoxes();
            CargarGrid();
        }
        private void CargarComboBoxes()
        {
            cmbCliente.DataSource = logica.ObtenerClientes();
            cmbCliente.DisplayMember = "NombreCliente";
            cmbCliente.ValueMember = "IdCliente";
            cmbCliente.SelectedIndex = -1;

            cmbArquitecto.DataSource = logica.ObtenerArquitectos();
            cmbArquitecto.DisplayMember = "NombreArquitecto";
            cmbArquitecto.ValueMember = "IdArquitecto";
            cmbArquitecto.SelectedIndex = -1;

            cmbEstado.Items.Clear();
            cmbEstado.Items.Add("Planeación");
            cmbEstado.Items.Add("En Proceso");
            cmbEstado.Items.Add("Finalizado");
            cmbEstado.SelectedIndex = -1;
        }

        private void CargarGrid()
        {
            dgvProyecto.DataSource = logica.ObtenerProyecto();

            dgvProyecto.Columns["IdProyecto"].HeaderText = "ID Proyecto";
            dgvProyecto.Columns["IdCliente"].HeaderText = "Cliente";
            dgvProyecto.Columns["IdArquitecto"].HeaderText = "Arquitecto";
            dgvProyecto.Columns["NombreProyecto"].HeaderText = "Nombre del Proyecto";
            dgvProyecto.Columns["FechaInicio"].HeaderText = "Fecha de inicio";
            dgvProyecto.Columns["FechaFin"].HeaderText = "Fecha de fin";
            dgvProyecto.Columns["ClaveCatastral"].HeaderText = "Clave catastral";
            dgvProyecto.Columns["Estado"].HeaderText = "Estado";
            dgvProyecto.Columns["Presupuesto"].HeaderText = "Presupuesto";
            dgvProyecto.Columns["CostoTotalProyecto"].HeaderText = "Costo total";

            if (dgvProyecto.Columns["IdCliente"] != null)
                dgvProyecto.Columns["IdCliente"].Visible = false;

            if (dgvProyecto.Columns["IdArquitecto"] != null)
                dgvProyecto.Columns["IdArquitecto"].Visible = false;

            if (dgvProyecto.Columns["Presupuesto"] != null)
                dgvProyecto.Columns["Presupuesto"].DefaultCellStyle.Format = "N2";

            if (dgvProyecto.Columns["CostoTotalProyecto"] != null)
                dgvProyecto.Columns["CostoTotalProyecto"].DefaultCellStyle.Format = "N2";

            dgvProyecto.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgvProyecto.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProyecto.Columns["IdProyecto"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvProyecto.Columns["IdProyecto"].Width = 65;
            dgvProyecto.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvProyecto.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProyecto.MultiSelect = false;
        }

        private void dgvProyecto_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dgvProyecto.Rows[e.RowIndex];

                if (fila.Cells["IdProyecto"].Value != DBNull.Value && fila.Cells["IdProyecto"].Value != null)
                {
                    idSeleccionado = Convert.ToInt32(fila.Cells["IdProyecto"].Value);

                    cmbCliente.SelectedValue = fila.Cells["IdCliente"].Value;
                    cmbArquitecto.SelectedValue = fila.Cells["IdArquitecto"].Value;

                    txtNombre.Text = fila.Cells["NombreProyecto"].Value.ToString();
                    dtFecha_inicio.Value = Convert.ToDateTime(fila.Cells["FechaInicio"].Value);
                    dtFecha_fin.Value = Convert.ToDateTime(fila.Cells["FechaFin"].Value);
                    txtClave.Text = fila.Cells["ClaveCatastral"].Value.ToString();

                    cmbEstado.Text = fila.Cells["Estado"].Value.ToString();
                }
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (cmbCliente.SelectedIndex == -1 || cmbArquitecto.SelectedIndex == -1 || cmbEstado.SelectedIndex == -1 ||
                string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("Por favor rellene todos los campos obligatorios...");
                return;
            }

            if (logica.ExisteNombreProyecto(txtNombre.Text))
            {
                MessageBox.Show("Ya existe un proyecto registrado con ese nombre.");
                return;
            }

            if (logica.ExisteClaveCatastral(txtClave.Text))
            {
                MessageBox.Show("Esta clave catastral ya está registrada en otro proyecto.");
                return;
            }

            if (dtFecha_inicio.Value > dtFecha_fin.Value)
            {
                MessageBox.Show("La fecha de inicio no puede ser posterior a la fecha de fin.");
                return;
            }

            if (txtClave.Text.Length < 18 || txtClave.Text.Length > 24)
            {
                MessageBox.Show("La clave catastral debe tener una longitud de entre 18 y 24 caracteres.");
                return;
            }

            string estadoSeleccionado = cmbEstado.SelectedItem.ToString();
            DateTime hoy = DateTime.Today;
            if (dtFecha_inicio.Value > hoy && (estadoSeleccionado == "En Proceso" || estadoSeleccionado == "Finalizado"))
            {
                MessageBox.Show("Un proyecto no puede estar 'En Proceso' o 'Finalizado' si su fecha de inicio es futura (debe estar en 'Planeacion').");
                return;
            }
            if (estadoSeleccionado == "Finalizado" && dtFecha_fin.Value > hoy)
            {
                MessageBox.Show("Un proyecto no puede estar 'Finalizado' si su fecha de fin es una fecha futura.");
                return;
            }

            try
            {
                long idCliente = Convert.ToInt64(cmbCliente.SelectedValue);
                long idArquitecto = Convert.ToInt64(cmbArquitecto.SelectedValue);

                logica.InsertarProyecto(
                    idCliente,
                    idArquitecto,
                    txtNombre.Text,
                    dtFecha_inicio.Value,
                    dtFecha_fin.Value,
                    txtClave.Text,
                    cmbEstado.SelectedItem.ToString()
                );

                CargarGrid();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al insertar el proyecto: " + ex.Message);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (idSeleccionado == 0)
            {
                MessageBox.Show("Seleccione un proyecto de la tabla para modificar.");
                return;
            }

            if (logica.ExisteNombreProyectoOtro(txtNombre.Text, idSeleccionado))
            {
                MessageBox.Show("Ya existe otro proyecto registrado con ese nombre.");
                return;
            }

            if (logica.ExisteClaveCatastralOtroProyecto(txtClave.Text, idSeleccionado))
            {
                MessageBox.Show("La clave catastral ya pertenece a otro proyecto.");
                return;
            }

            if (dtFecha_inicio.Value > dtFecha_fin.Value)
            {
                MessageBox.Show("La fecha de inicio no puede ser posterior a la fecha de fin.");
                return;
            }

            if (txtClave.Text.Length < 18 || txtClave.Text.Length > 24)
            {
                MessageBox.Show("La clave catastral debe tener una longitud de entre 18 y 24 caracteres.");
                return;
            }

            string estadoSeleccionado = cmbEstado.SelectedItem.ToString();
            DateTime hoy = DateTime.Today;
            if (dtFecha_inicio.Value > hoy && (estadoSeleccionado == "En Proceso" || estadoSeleccionado == "Finalizado"))
            {
                MessageBox.Show("Un proyecto no puede estar 'En Proceso' o 'Finalizado' si su fecha de inicio es futura (debe estar en 'Planeacion').");
                return;
            }
            if (estadoSeleccionado == "Finalizado" && dtFecha_fin.Value > hoy)
            {
                MessageBox.Show("Un proyecto no puede estar 'Finalizado' si su fecha de fin es una fecha futura.");
                return;
            }

            try
            {
                long idCliente = Convert.ToInt64(cmbCliente.SelectedValue);
                long idArquitecto = Convert.ToInt64(cmbArquitecto.SelectedValue);

                logica.ModificarProyecto(
                    idSeleccionado,
                    idCliente,
                    idArquitecto,
                    txtNombre.Text,
                    dtFecha_inicio.Value,
                    dtFecha_fin.Value,
                    txtClave.Text,
                    cmbEstado.SelectedItem.ToString()
                );

                CargarGrid();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al modificar el proyecto: " + ex.Message);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (idSeleccionado == 0)
            {
                MessageBox.Show("Seleccione un proyecto para eliminar.");
                return;
            }

            try
            {
                logica.EliminarProyecto(idSeleccionado);
                CargarGrid();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar el proyecto: " + ex.Message);
            }
        }

        private void LimpiarCampos()
        {
            cmbCliente.SelectedIndex = -1;
            cmbArquitecto.SelectedIndex = -1;
            cmbEstado.SelectedIndex = -1;
            txtNombre.Clear();
            txtClave.Clear();
            dtFecha_inicio.Value = DateTime.Today;
            dtFecha_fin.Value = DateTime.Today;
            idSeleccionado = 0;
        }
    }
}
