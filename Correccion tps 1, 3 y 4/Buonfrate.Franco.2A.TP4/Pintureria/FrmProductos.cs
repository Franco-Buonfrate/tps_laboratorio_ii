using Entidades;
using Entidades.Productos;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Pintureria
{
    public partial class ProductosForm : Form
    {
        public Compra compraActual;
        /// <summary>
        /// Constructor parametrizado
        /// </summary>
        /// <param name="clienteActual"></param>
        public ProductosForm(Cliente clienteActual):this()
        {
            this.compraActual = new Compra(clienteActual);
        }

        /// <summary>
        /// Constructor por defecto
        /// </summary>
        private ProductosForm()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Llama al form frmPintura y le pasa la instancia de Compra
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Pintura_Click(object sender, EventArgs e)
        {
            Frm_Pintura frm_Pintura = new Frm_Pintura(compraActual);
            frm_Pintura.Owner = this;
            frm_Pintura.Show();
            this.Enabled = false;
        }
        /// <summary>
        /// Llama al form frmVinilos y le pasa la instancia de Compra
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Vinilos_Click(object sender, EventArgs e)
        {
            Frm_Vinilos frm_vinilo = new Frm_Vinilos(compraActual);
            frm_vinilo.Owner = this;
            frm_vinilo.Show();
            this.Enabled = false;
        }
        /// <summary>
        /// Llama al form frmRodillo y le pasa la instancia de Compra
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Rodillo_Click(object sender, EventArgs e)
        {
            Frm_Rodillo frm_Rodillo = new Frm_Rodillo(compraActual);
            frm_Rodillo.Owner = this;
            frm_Rodillo.Show();
            this.Enabled = false;
        }
        /// <summary>
        /// Llama al form frmFactura y le pasa la instancia de Compra
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void facturarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmFactura facturarCliente = new FrmFactura(compraActual);
            facturarCliente.Owner = this.Owner;
            facturarCliente.Show();
            this.Close();
        }
    }
}
