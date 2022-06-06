using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pintureria
{
    public partial class ProductosForm : Form
    {
        public Cliente<IProductos> clienteActual;
        public ProductosForm(Cliente<IProductos> clienteActual):this()
        {
            this.clienteActual = clienteActual;
            this.clienteActual.ListaDeCompras = new List<IProductos>();
        }
        private ProductosForm()
        {
            InitializeComponent();
        }

        private void btn_Pintura_Click(object sender, EventArgs e)
        {
            Frm_Pintura frm_Pintura = new Frm_Pintura(this);
            frm_Pintura.Show();
            this.Enabled = false;
        }

        private void btn_Vinilos_Click(object sender, EventArgs e)
        {
            Frm_Vinilos frm_vinilo = new Frm_Vinilos(this);
            frm_vinilo.Show();
            this.Enabled = false;
        }

        private void btn_Rodillo_Click(object sender, EventArgs e)
        {
            Frm_Rodillo frm_Rodillo = new Frm_Rodillo(this);
            frm_Rodillo.Show();
            this.Enabled = false;
        }

        private void ProductosForm_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void facturarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Factura facturarCliente = new Factura(this.clienteActual);
            facturarCliente.Owner = this.Owner;
            facturarCliente.Show();
            this.Close();
        }
    }
}
