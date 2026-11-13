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
    public partial class Pago : Form
    {
        PagoDAO pDAO = new PagoDAO();
        private int IdPagoSeleccionado = -1;
        private bool actualizandoCombos = false;

        public Pago()
        {
            InitializeComponent();
            dgvPago.CellClick += dgvPago_CellClick;
            cbCliente.SelectedIndexChanged += cbCliente_SelectedIndexChanged_1;
            cbProyecto.SelectedIndexChanged += cbProyecto_SelectedIndexChanged_1;
        }

        private void Pago_Load(object sender, EventArgs e)
        {
            CargarClientes();
            CargarProyectos();
            CargarTabla();
        }


        private void CargarTabla()
        {
            dgvPago.DataSource = pDAO.ConsultarPagos();

            dgvPago.Columns["IdPago"].HeaderText = "ID Pago";
            dgvPago.Columns["NombreCliente"].HeaderText = "Cliente";
            dgvPago.Columns["NombreProyecto"].HeaderText = "Proyecto";
            dgvPago.Columns["FechaPago"].HeaderText = "Fecha de pago";
            dgvPago.Columns["Monto"].HeaderText = "Monto";

            dgvPago.Columns["IdCliente"].Visible = false;
            dgvPago.Columns["IdProyecto"].Visible = false;

            // Mostrar el monto con dos decimales.
            dgvPago.Columns["Monto"].DefaultCellStyle.Format = "N2";

            // Mostrar la fecha en formato día/mes/año.
            dgvPago.Columns["FechaPago"].DefaultCellStyle.Format = "dd/MM/yyyy";

            // Ajustar el tamaño de las columnas.
            dgvPago.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgvPago.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPago.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvPago.Columns["IdPago"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgvPago.Columns["IdPago"].Width = 45;
            dgvPago.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPago.MultiSelect = false;

            dgvPago.MultiSelect = false;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            decimal monto;

            if (!DatosCorrectos(out monto))
                return;

            int idCliente = Convert.ToInt32(cbCliente.SelectedValue);
            int idProyecto = Convert.ToInt32(cbProyecto.SelectedValue);

            DateTime fechaPago = DateTime.Today;


            pDAO.InsertarPago(
                idCliente,
                idProyecto,
                fechaPago,
                monto);

            CargarTabla();
            LimpiarDatos();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (IdPagoSeleccionado == -1)
            {
                MessageBox.Show("Selecciona un pago de la tabla para modificarlo.");

                return;
            }

            decimal monto;

            if (!DatosCorrectos(out monto))
                return;

            int idCliente = Convert.ToInt32(cbCliente.SelectedValue);
            int idProyecto = Convert.ToInt32(cbProyecto.SelectedValue);

            DateTime fechaPago = DateTime.Today;


            pDAO.ModificarPago(
                IdPagoSeleccionado,
                idCliente,
                idProyecto,
                fechaPago,
                monto);



            CargarTabla();
            LimpiarDatos();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (IdPagoSeleccionado == -1)
            {
                MessageBox.Show("Selecciona un pago de la tabla para eliminarlo.");
                return;
            }

            if (pDAO.EliminarPago(IdPagoSeleccionado))
            {

                CargarTabla();
                LimpiarDatos();
            }
        }

        private void dgvPago_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dgvPago.Rows[e.RowIndex];

                IdPagoSeleccionado = Convert.ToInt32(fila.Cells["IdPago"].Value);

                cbCliente.SelectedValue = Convert.ToInt32(fila.Cells["IdCliente"].Value);

                cbProyecto.SelectedValue = Convert.ToInt32(fila.Cells["IdProyecto"].Value);

                txtMonto.Text = Convert.ToDecimal(fila.Cells["Monto"].Value).ToString("0.00");
            }
        }

        private void LimpiarDatos()
        {
            IdPagoSeleccionado = -1;

            cbCliente.SelectedIndex = -1;
            cbProyecto.SelectedIndex = -1;


            txtMonto.Clear();

            dgvPago.ClearSelection();
        }


        private void CargarClientes()
        {
            cbCliente.DataSource = pDAO.ConsultarClientes();
            cbCliente.DisplayMember = "NombreCliente";
            cbCliente.ValueMember = "IdCliente";
            cbCliente.SelectedIndex = -1;
        }

        private void CargarProyectos()
        {
            cbProyecto.DataSource = pDAO.ConsultarProyectos();
            cbProyecto.DisplayMember = "NombreProyecto";
            cbProyecto.ValueMember = "IdProyecto";
            cbProyecto.SelectedIndex = -1;
        }

        private bool DatosCorrectos(out decimal monto)
        {
            monto = 0;

            if (cbCliente.SelectedIndex == -1 || cbProyecto.SelectedIndex == -1)
            {
                MessageBox.Show("Selecciona un cliente y un proyecto.");

                return false;
            }

            if (string.IsNullOrWhiteSpace(txtMonto.Text))
            {
                MessageBox.Show("Ingresa el monto del pago.");
                return false;
            }

            if (!decimal.TryParse(txtMonto.Text, out monto))
            {
                MessageBox.Show("Ingresa un monto válido.");
                return false;
            }

            if (monto <= 1000)
            {
                MessageBox.Show("El monto debe ser mayor a $1,000.00.");
                return false;
            }


            if (decimal.Round(monto, 2) != monto)
            {
                MessageBox.Show("El monto no puede tener más de dos decimales.");

                return false;
            }

            return true;
        }


        private void cbProyecto_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (actualizandoCombos || cbProyecto.SelectedValue == null)
                return;

            if (cbProyecto.SelectedValue is DataRowView)
                return;

            try
            {
                actualizandoCombos = true;

                int idProyecto = Convert.ToInt32(cbProyecto.SelectedValue);

                int idCliente = pDAO.ConsultarClientePorProyecto(idProyecto);

                if (idCliente != -1)
                {
                    cbCliente.SelectedValue = idCliente;
                }
            }
            finally
            {
                actualizandoCombos = false;
            }
        }

        private void cbCliente_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (actualizandoCombos || cbCliente.SelectedValue == null)
                return;

            if (cbCliente.SelectedValue is DataRowView)
                return;

            try
            {
                actualizandoCombos = true;

                int idCliente = Convert.ToInt32(cbCliente.SelectedValue);

                cbProyecto.DataSource = pDAO.ConsultarProyectosPorCliente(idCliente);

                cbProyecto.DisplayMember = "NombreProyecto";
                cbProyecto.ValueMember = "IdProyecto";
                cbProyecto.SelectedIndex = -1;
            }
            finally
            {
                actualizandoCombos = false;
            }
        }
    }
}
