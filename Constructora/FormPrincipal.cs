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
    public partial class FormPrincipal : Form
    {
        public FormPrincipal()
        {
            InitializeComponent();
        }

        private void btnArquitecto_Click(object sender, EventArgs e)
        {
            Arquitecto formArqui = new Arquitecto();
            formArqui.Show();
        }

        private void btnCliente_Click(object sender, EventArgs e)
        {
            Cliente formCliente = new Cliente();
            formCliente.Show();
        }

        private void btnProveedor_Click(object sender, EventArgs e)
        {
            Proveedor formProveedor = new Proveedor();
            formProveedor.Show();
        }

        private void btnProyecto_Click(object sender, EventArgs e)
        {
            Proyecto formProyecto = new Proyecto();
            formProyecto.Show();
        }
        private void btnServicio_Click(object sender, EventArgs e)
        {
            Servicio formServicio = new Servicio();
            formServicio.Show();
        }

        private void btnProveedorServicio_Click(object sender, EventArgs e)
        {
            ProveedorServicio formProveedorServicio = new ProveedorServicio();
            formProveedorServicio.Show();
        }
        private void btnDisenio_Click(object sender, EventArgs e)
        {
            Disenio formDisenio = new Disenio();
            formDisenio.Show();
        }

        private void btnGasto_Click(object sender, EventArgs e)
        {
            Gasto formGasto = new Gasto();
            formGasto.Show();
        }

        private void btnPago_Click(object sender, EventArgs e)
        {
            Pago formPago= new Pago();
            formPago.Show();

        }

        private void btnServicio_Disenio_Click(object sender, EventArgs e)
        {
            ServicioPorDisenio formSPD = new ServicioPorDisenio();
            formSPD.Show();
        }
    }
}


