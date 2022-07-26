using Entidades;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Pintureria
{
    public partial class ProductosForm : Form
    {
        public Cliente clienteActual;
        public ProductosForm(Cliente clienteActual):this()
        {
            this.clienteActual = clienteActual;
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
        private void facturarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmFactura facturarCliente = new FrmFactura(this.clienteActual);
            facturarCliente.Owner = this.Owner;
            facturarCliente.Show();
            this.Close();
        }
    }
}
