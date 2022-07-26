using Entidades;
using Entidades.Productos;
using System;
using System.Windows.Forms;

namespace Pintureria
{
    public partial class Frm_Vinilos : Form
    {
        private Compra compraActual;
        /// <summary>
        /// constructor por defecto
        /// </summary>
        private Frm_Vinilos()
        {
            InitializeComponent();
        }
        /// <summary>
        /// constructor parametrizado
        /// </summary>
        /// <param name="compraActual"></param>
        public Frm_Vinilos(Compra compraActual) : this()
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
        /// Activa la instancia de frmProductos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Vinilos_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Owner.Enabled = true;
        }
        /// <summary>
        /// si los datos estan completos crea una instancia de Vinilos y la agrega a la lista de compras
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Agregar_Click(object sender, EventArgs e)
        {
            EDisenio opcionElegida = EDisenio.Opcion1;

            if (rb_Opcion2.Checked == true)
                opcionElegida = EDisenio.Opcion2;

            if (rb_Opcion3.Checked == true)
                opcionElegida = EDisenio.Opcion3;

            if (rb_Opcion4.Checked == true)
                opcionElegida = EDisenio.Opcion4;


            Vinilo pedido = new Vinilo(opcionElegida,compraActual.GenerarId());
            pedido.GenerarPrecio();
            compraActual.ListaDeCompras.Add(pedido);
            this.Close();
        }
    }
}
