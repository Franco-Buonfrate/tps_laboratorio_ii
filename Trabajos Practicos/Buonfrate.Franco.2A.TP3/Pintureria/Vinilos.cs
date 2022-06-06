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
    public partial class Frm_Vinilos : Form
    {
        private ProductosForm frm_Anterior;
        private Frm_Vinilos()
        {
            InitializeComponent();
        }
        public Frm_Vinilos(ProductosForm frm_Productos) : this()
        {
            this.frm_Anterior = frm_Productos;
        }

        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Vinilos_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.frm_Anterior.Enabled = true;
        }

        private void btn_Agregar_Click(object sender, EventArgs e)
        {
            EDisenio opcionElegida = EDisenio.Opcion1;

            if (rb_Opcion2.Checked == true)
                opcionElegida = EDisenio.Opcion2;

            if (rb_Opcion3.Checked == true)
                opcionElegida = EDisenio.Opcion3;

            if (rb_Opcion4.Checked == true)
                opcionElegida = EDisenio.Opcion4;


            Vinilo pedido = new Vinilo(opcionElegida);
            pedido.GenerarId(frm_Anterior.clienteActual);
            pedido.GenerarPrecio();
            frm_Anterior.clienteActual.ListaDeCompras.Add(pedido);
            this.Close();
        }
    }
}
