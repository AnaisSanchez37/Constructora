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
            formArqui.ShowDialog();
        }

        private void btnCliente_Click(object sender, EventArgs e)
        {
            Cliente formCliente = new Cliente();
            formCliente.ShowDialog();
        }

        private void btnProveedor_Click(object sender, EventArgs e)
        {
            Proveedor formProveedor = new Proveedor();
            formProveedor.ShowDialog();
        }

        private void btnProyecto_Click(object sender, EventArgs e)
        {
            Proyecto formProyecto = new Proyecto();
            formProyecto.ShowDialog();
        }
        private void btnServicio_Click(object sender, EventArgs e)
        {
            using (Servicio formServicio = new Servicio())
            {
                formServicio.ShowDialog();
            }
        }

        private void btnProveedorServicio_Click(object sender, EventArgs e)
        {
            using (ProveedorServicio formProveedorServicio = new ProveedorServicio())
            {
                formProveedorServicio.ShowDialog();
            }
        }        private void btnDisenio_Click(object sender, EventArgs e)
        {
            using (Disenio formDisenio = new Disenio())
            {
                formDisenio.ShowDialog();
            }
        }    }
}


