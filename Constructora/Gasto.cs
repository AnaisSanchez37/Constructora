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
    public partial class Gasto : Form
    {
        GastoDAO gDAO = new GastoDAO();
        private int IdGastoSeleccionado = -1;
        public Gasto()
        {
            InitializeComponent();
            dgvGasto.CellClick += dgvGasto_CellClick;
        }

        private void Gasto_Load(object sender, EventArgs e)
        {
            CargarDisenios();
            CargarTabla();
        }

        private void CargarDisenios()
        {
            cbDisenio.DataSource = gDAO.ConsultarDisenios();
            cbDisenio.DisplayMember = "Disenio";
            cbDisenio.ValueMember = "IdDisenio";
            cbDisenio.SelectedIndex = -1;
        }

        private void CargarTabla()
        {
            dgvGasto.DataSource = gDAO.ConsultarGastos();

            dgvGasto.Columns["IdGasto"].HeaderText = "ID";
            dgvGasto.Columns["NombreDisenio"].HeaderText = "Diseño";
            dgvGasto.Columns["Concepto"].HeaderText = "Concepto";
            dgvGasto.Columns["Monto"].HeaderText = "Monto";
            dgvGasto.Columns["FechaGasto"].HeaderText = "Fecha del gasto";

            dgvGasto.Columns["IdDisenio"].Visible = false;

            // Mostrar el monto con dos decimales.
            dgvGasto.Columns["Monto"].DefaultCellStyle.Format = "N2";

            // Mostrar la fecha registrada.
            dgvGasto.Columns["FechaGasto"].DefaultCellStyle.Format = "dd/MM/yyyy";

            dgvGasto.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvGasto.Columns["IdGasto"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

            dgvGasto.Columns["IdGasto"].Width = 45;

            dgvGasto.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dgvGasto.MultiSelect = false;
        }

        private bool DatosCorrectos(out decimal monto)
        {
            monto = 0;

            if (cbDisenio.SelectedIndex == -1 ||
                cbDisenio.SelectedValue == null ||
                cbDisenio.SelectedValue is DataRowView)
            {
                MessageBox.Show("Selecciona un diseño.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtConcepto.Text))
            {
                MessageBox.Show("Ingresa el concepto del gasto.");
                return false;
            }

            if (txtConcepto.Text.Trim().Length > 200)
            {
                MessageBox.Show(
                    "El concepto no puede tener más de 200 caracteres.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtMonto.Text))
            {
                MessageBox.Show("Ingresa el monto del gasto.");
                return false;
            }

            if (!decimal.TryParse(txtMonto.Text, out monto))
            {
                MessageBox.Show("Ingresa un monto válido.");
                return false;
            }

            if (monto <= 0)
            {
                MessageBox.Show("El monto debe ser mayor a cero.");
                return false;
            }

            if (decimal.Round(monto, 2) != monto)
            {
                MessageBox.Show("El monto no puede tener más de dos decimales.");
                return false;
            }

            return true;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            decimal monto;

            if (!DatosCorrectos(out monto))
                return;

            int idDisenio = Convert.ToInt32(cbDisenio.SelectedValue);

            string concepto = txtConcepto.Text.Trim();

            gDAO.InsertarGasto(
                idDisenio,
                concepto,
                monto);


            CargarTabla();
            LimpiarDatos();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (IdGastoSeleccionado == -1)
            {
                MessageBox.Show(
                    "Selecciona un gasto de la tabla para modificarlo.");

                return;
            }

            decimal monto;

            if (!DatosCorrectos(out monto))
                return;

            int idDisenio = Convert.ToInt32(cbDisenio.SelectedValue);

            string concepto = txtConcepto.Text.Trim();

            gDAO.ModificarGasto(
                IdGastoSeleccionado,
                idDisenio,
                concepto,
                monto);


            CargarTabla();
            LimpiarDatos();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (IdGastoSeleccionado == -1)
            {
                MessageBox.Show("Selecciona un gasto de la tabla para eliminarlo.");

                return;
            }

            if (gDAO.EliminarGasto(IdGastoSeleccionado))
            {
                CargarTabla();
                LimpiarDatos();
            }
        }

        private void dgvGasto_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dgvGasto.Rows[e.RowIndex];

                IdGastoSeleccionado =
                    Convert.ToInt32(fila.Cells["IdGasto"].Value);

                cbDisenio.SelectedValue =
                    Convert.ToInt32(fila.Cells["IdDisenio"].Value);

                txtConcepto.Text =
                    fila.Cells["Concepto"].Value.ToString();

                txtMonto.Text =
                    Convert.ToDecimal(fila.Cells["Monto"].Value)
                    .ToString("0.00");
            }
        }

        private void LimpiarDatos()
        {
            IdGastoSeleccionado = -1;

            cbDisenio.SelectedIndex = -1;
            txtConcepto.Clear();
            txtMonto.Clear();

            dgvGasto.ClearSelection();
        }

    }
}
