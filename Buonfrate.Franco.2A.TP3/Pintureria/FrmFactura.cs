using Entidades;
using ManejoDeDatos;
using System;
using System.Windows.Forms;

namespace Pintureria
{
    public partial class FrmFactura : Form , IListar<Producto>
    {
        private Cliente clienteAFacturar;
        public FrmFactura(Cliente clienteAFacturar):this()
        {
            this.clienteAFacturar = clienteAFacturar;
            this.Refrescar();
        }
        private FrmFactura()
        {
            InitializeComponent();
        }

        public void Refrescar()
        {
            int row = 0;
            dataGridView1.Rows.Clear();
            foreach (Producto producto in this.clienteAFacturar.ListaDeCompras)
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[row].Cells["Id"].Value = producto.IdProducto;
                dataGridView1.Rows[row].Cells["Tipo"].Value = producto.GetType().Name.ToString();
                dataGridView1.Rows[row].Cells["Especifico"].Value = producto.DevolverEnum();
                dataGridView1.Rows[row].Cells["Precio"].Value = producto.Precio;
                row++;
            }
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
        }
        public Producto RecuperarObjeto()
        {
            if (dataGridView1.SelectedRows is not null)
            {
                Pintura producto = new Pintura(int.Parse(dataGridView1.SelectedRows[0].Cells["Id"].Value.ToString()));
                return producto;
            }
            return null;
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
                Producto productoEliminar = this.RecuperarObjeto();
                if (productoEliminar is not null)
                {
                    clienteAFacturar.ListaDeCompras.Remove(productoEliminar);
                    this.Refrescar();
                }
                else
                {
                    throw new NoSePudoEliminarException("No se pudo borrar");
                }
            }
            catch(NoSePudoEliminarException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ha ocurrido un error inesperado \n");

            }
        }

        
    }
}
