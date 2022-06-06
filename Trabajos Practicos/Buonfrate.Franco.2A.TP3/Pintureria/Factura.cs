using Entidades;
using ManejoDeDatos;
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
    public partial class Factura : Form , IListar
    {
        private Cliente<IProductos> clienteAFacturar;
        public Factura(Cliente<IProductos> clienteAFacturar):this()
        {
            this.clienteAFacturar = clienteAFacturar;
            this.DibujarTabla();
        }
        private Factura()
        {
            InitializeComponent();
        }

        public void DibujarTabla()
        {
            int indice = 0;
            dataGridView1.Rows.Clear();
            foreach (IProductos producto in this.clienteAFacturar.ListaDeCompras)
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[indice].Cells["Id"].Value = producto.IdProducto;
                dataGridView1.Rows[indice].Cells["Tipo"].Value = producto.GetType().Name.ToString();
                dataGridView1.Rows[indice].Cells["Especifico"].Value = producto.DevolverEnum();
                dataGridView1.Rows[indice].Cells["Precio"].Value = producto.Precio;
                indice++;
            }
        }

        private void btn_GenerarFactura_Click(object sender, EventArgs e)
        {
            string datosCliente;
            string articulos = string.Empty;
            float total = 0;
            datosCliente = clienteAFacturar.Apellido + clienteAFacturar.Nombre;

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                articulos += dataGridView1.Rows[i].Cells["Id"].Value.ToString()
                    + " " + dataGridView1.Rows[i].Cells["Tipo"].Value.ToString()
                    + " " + dataGridView1.Rows[i].Cells["Especifico"].Value.ToString()
                    + "\t\t\t" + dataGridView1.Rows[i].Cells["Precio"].Value.ToString()
                    + Environment.NewLine;

                total += float.Parse(dataGridView1.Rows[i].Cells["Precio"].Value.ToString());
            }

            articulos += $"\nTotal:\t\t\t\t{total}";
            ArchivoTxt.EscribirTicket(articulos , datosCliente);
            this.Owner.Show();
            this.Close();
        }

        private void btn_Eliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows is not null)
                {
                    foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                    {
                        int indiceBorrar = row.Index;
                        dataGridView1.Rows.RemoveAt(indiceBorrar);
                    }
                }
                else
                {
                    throw new Exception("No se pudo borrar");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
