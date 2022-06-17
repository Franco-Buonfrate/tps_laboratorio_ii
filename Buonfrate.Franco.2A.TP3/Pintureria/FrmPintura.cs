using Entidades;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Pintureria
{
    public partial class Frm_Pintura : Form
    {
        private ProductosForm frmAnterior;
        private  Frm_Pintura()
        {
            InitializeComponent();
        }
        public Frm_Pintura(ProductosForm frm_productos):this()
        {
            this.frmAnterior = frm_productos;
        }

        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void VolverAProductos_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.frmAnterior.Enabled = true;
        }

        private void btn_Agregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.cmb_Color.SelectedIndex >= 0 && !string.IsNullOrEmpty(this.textBox1.Text.ToString()))
                {
                    EColor colorSeleccionado = (EColor)int.Parse(this.cmb_Color.SelectedIndex.ToString());
                    float cantidadLitros = float.Parse(this.textBox1.Text.ToString());
                    Pintura pedido = new Pintura(colorSeleccionado,cantidadLitros);
                    pedido.GenerarId(frmAnterior.clienteActual);
                    pedido.GenerarPrecio();
                    frmAnterior.clienteActual.ListaDeCompras.Add(pedido);
                    this.Close();
                }
                else
                {
                    throw new DatosIncompletosException();
                }
            }
            catch(DatosIncompletosException)
            {
                if (this.cmb_Color.SelectedIndex < 0)
                {
                    lbl_Color.ForeColor = Color.Red;
                }
                if (string.IsNullOrEmpty(this.textBox1.Text.ToString()))
                {
                    lbl_Litros.ForeColor = Color.Red;
                }
            }
        }

        public void SoloNumero(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

    }
}
