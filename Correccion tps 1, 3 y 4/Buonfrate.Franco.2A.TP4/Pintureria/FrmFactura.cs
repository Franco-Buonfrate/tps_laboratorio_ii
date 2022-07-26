using Entidades;
using Entidades.Productos;
using ManejoDeDatos;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Pintureria
{

    public partial class FrmFactura : Form , IListar<Producto>
    {
        private Compra compraAFacturar;
        private EventoFactura eventoFactura = new EventoFactura();
        /// <summary>
        /// Constructor por defecto
        /// </summary>
        private FrmFactura()
        {
            InitializeComponent();
        }
        /// <summary>
        /// constructor parametrizado
        /// </summary>
        /// <param name="compraAFacturar"></param>
        public FrmFactura(Compra compraAFacturar) :this()
        {
            this.compraAFacturar = compraAFacturar;
            this.Refrescar();
        }
        /// <summary>
        /// Actualiza la informacion del Datagrid con la informadcion de la instancia de compra del form
        /// </summary>
        public void Refrescar()
        {
            int row = 0;
            dataGridView1.Rows.Clear();
            foreach (Producto producto in this.compraAFacturar.ListaDeCompras)
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[row].Cells["Id"].Value = producto.Id;
                dataGridView1.Rows[row].Cells["Tipo"].Value = producto.GetType().Name.ToString();
                dataGridView1.Rows[row].Cells["Especifico"].Value = producto.DevolverEnum();
                dataGridView1.Rows[row].Cells["Precio"].Value = producto.Precio;
                row++;
            }
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
        }
        /// <summary>
        /// Recupera el objeto seleccionado del form
        /// </summary>
        /// <returns>Una instancia de Prosducto solo con el id o null si no hay nada seleccionado</returns>
        public Producto RecuperarObjeto()
        {
            if (dataGridView1.SelectedRows.Count>0)
            {
                Pintura producto = new Pintura(int.Parse(dataGridView1.SelectedRows[0].Cells["Id"].Value.ToString()));
                return producto;
            }
            return null;
        }
        
        /// <summary>
        /// Recopila la informacion de los Prosuctos almacenados en la instancia de Compra, asi como los datos del cliente y se lo pasa al metodo ArchivoTxt.EscribirTicket 
        /// y llama a SerializarLaComra. Luego de esto cierrra el form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_GenerarFactura_Click(object sender, EventArgs e)
        {
            this.eventoFactura.generadorFactura += GeneradorDeFactura;
            this.eventoFactura.generadorFactura += SerializarCompra;
            this.eventoFactura.GenerarFactura();
            this.Owner.Show();
            this.Close();
        }

        private void GeneradorDeFactura()
        {
            string datosCliente;
            string articulos = string.Empty;
            float total = 0;
            datosCliente = compraAFacturar.Cliente.Apellido + compraAFacturar.Cliente.Nombre;

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
            ArchivoTxt.EscribirTicket(articulos, datosCliente);
        }

        /// <summary>
        /// Serializa los datos de la instancia de Compra en archivos separdos llamando al metodo generico ArchivoXml.Escribir
        /// </summary>
        public void SerializarCompra()
        {
            List<Pintura> listaPintura = ArchivoXml<List<Pintura>>.Leer("Compras_Pintura");
            List<Rodillo> listaRodillo = ArchivoXml<List<Rodillo>>.Leer("Compras_Rodillo");
            List<Vinilo> listaVinilos = ArchivoXml<List<Vinilo>>.Leer("Compras_Vinilo");

            if (listaPintura is null)
                listaPintura = new List<Pintura>();
            if (listaRodillo is null)
                listaRodillo = new List<Rodillo>();
            if (listaVinilos is null)
                listaVinilos = new List<Vinilo>();

            compraAFacturar.CambiarId();

            foreach (Producto item in compraAFacturar.ListaDeCompras)
            {
                if (item is Pintura)
                {
                    listaPintura.Add((Pintura)item);
                }
                else if (item is Rodillo)
                {
                    listaRodillo.Add((Rodillo)item);
                }
                else if (item is Vinilo)
                {
                    listaVinilos.Add((Vinilo)item);
                }
            }

            ArchivoXml<List<Pintura>>.Escribir(listaPintura, "Compras_Pintura");
            ArchivoXml<List<Rodillo>>.Escribir(listaRodillo, "Compras_Rodillo");
            ArchivoXml<List<Vinilo>>.Escribir(listaVinilos, "Compras_Vinilo");
        }

        /// <summary>
        /// Elimina la de la lista la instancia de cliente con el mismo id que el producto que retorna RecuperarObjeto
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Eliminar_Click(object sender, EventArgs e)
        {
            try
            {
                Producto productoEliminar = this.RecuperarObjeto();
                if (productoEliminar is not null)
                {
                    compraAFacturar.ListaDeCompras.Remove(productoEliminar);
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
