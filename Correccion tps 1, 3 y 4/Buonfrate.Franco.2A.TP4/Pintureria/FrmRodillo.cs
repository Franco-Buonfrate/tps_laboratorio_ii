using Entidades;
using Entidades.Productos;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Pintureria
{
    public partial class Frm_Rodillo : Form
    {
        private Compra compraActual;
        /// <summary>
        /// constructor por defecto
        /// </summary>
        private Frm_Rodillo()
        {
            InitializeComponent();
        }
        /// <summary>
        /// constructor parametrizado
        /// </summary>
        /// <param name="compraActual"></param>
        public Frm_Rodillo(Compra compraActual) :this()
        {
            this.compraActual = compraActual;
        }
        /// <summary>
        /// cierra el form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// activa el frmProducto cuando se cierre el form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Rodillo_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Owner.Enabled = true;
        }

        /// <summary>
        /// si los datos estan completos crea una instancia de Ridillo y la agrega a la lista de compras
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Agregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(this.textBox1.Text) && this.comboBox1.SelectedIndex >= 0)
                {
                    int cantidadRodillos = int.Parse(this.textBox1.Text.ToString());
                    ETipoRodillo tipo = (ETipoRodillo)int.Parse(this.comboBox1.SelectedIndex.ToString());
                    Rodillo pedido = new Rodillo(tipo, cantidadRodillos, compraActual.GenerarId());
                    pedido.GenerarPrecio();
                    compraActual.ListaDeCompras.Add(pedido);
                    this.Close();
                }
                else
                {
                    throw new DatosIncompletosException();
                }
            }
            catch (DatosIncompletosException)
            {
                if (string.IsNullOrEmpty(this.textBox1.Text))
                {
                    lbl_Cantidad.ForeColor = Color.Red;
                }
                if (this.comboBox1.SelectedIndex < 0)
                {
                    lbl_Tipo.ForeColor = Color.Red;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ha ocurrido un error inesperado \n");
            }
        }

    }
}
