using Entidades;
using Excepciones;
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
    public partial class Frm_Rodillo : Form
    {
        private ProductosForm frm_Anterior;
        private Frm_Rodillo()
        {
            InitializeComponent();
        }
        public Frm_Rodillo(ProductosForm frm_Productos):this()
        {
            this.frm_Anterior = frm_Productos;
        }

        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Rodillo_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.frm_Anterior.Enabled = true;
        }

        private void btn_Agregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(this.textBox1.Text) && this.comboBox1.SelectedIndex >= 0)
                {
                    int cantidadRodillos = int.Parse(this.textBox1.Text.ToString());
                    ETipoRodillo tipo = (ETipoRodillo)int.Parse(this.comboBox1.SelectedIndex.ToString());
                    Rodillo pedido = new Rodillo(tipo, cantidadRodillos);
                    pedido.GenerarId(frm_Anterior.clienteActual);
                    pedido.GenerarPrecio();
                    frm_Anterior.clienteActual.ListaDeCompras.Add(pedido);
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
            catch (Exception)
            {

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
