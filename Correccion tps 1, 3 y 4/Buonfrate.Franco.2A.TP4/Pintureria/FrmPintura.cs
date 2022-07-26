using Entidades;
using Entidades.Productos;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Pintureria
{
    public partial class Frm_Pintura : Form
    {
        private Compra compraActual;
        /// <summary>
        /// Constructor por defecto
        /// </summary>
        private  Frm_Pintura()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Constructor parametrizado
        /// </summary>
        /// <param name="compraActual"></param>
        public Frm_Pintura(Compra compraActual) :this()
        {
            this.compraActual = compraActual;
        }

        /// <summary>
        /// Cierra el form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Vuelve a activar el frmProducto cuando se cierra por cualquier motivo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void VolverAProductos_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Owner.Enabled = true;
        }

        /// <summary>
        /// si los datos estan completos crea una instancia de pintura y la agrega a la lista de compras
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Agregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.cmb_Color.SelectedIndex >= 0 && !string.IsNullOrEmpty(this.textBox1.Text.ToString()))
                {
                    EColor colorSeleccionado = (EColor)int.Parse(this.cmb_Color.SelectedIndex.ToString());
                    float cantidadLitros = float.Parse(this.textBox1.Text.ToString());
                    Pintura pedido = new Pintura(colorSeleccionado,cantidadLitros, compraActual.GenerarId());
                    pedido.GenerarPrecio();
                    compraActual.ListaDeCompras.Add(pedido);
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

    }
}
