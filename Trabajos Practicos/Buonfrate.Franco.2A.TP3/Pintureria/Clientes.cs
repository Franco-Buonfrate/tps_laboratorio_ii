using Entidades;
using Excepciones;
using ManejoDeDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Pintureria
{
    public partial class Clientes : Form , IListar
    {
        private static List<Cliente<IProductos>> listaClientes;

        static Clientes()
        {
            Clientes.listaClientes = ArchivoXml<List<Cliente<IProductos>>>.Leer("DatosClientes");
            if (listaClientes is null)
            {
                listaClientes = new List<Cliente<IProductos>>(); 
            }
        }
        public Clientes()
        {
            InitializeComponent();
            this.DibujarTabla();
        }

        public void DibujarTabla()
        {
            int indice = 0;
            dataGridView1.Rows.Clear();
            foreach (Cliente<IProductos> cliente in listaClientes)
            {
                if (cliente.ClienteActivo == true)
                {
                    dataGridView1.Rows.Add();
                    dataGridView1.Rows[indice].Cells["Id"].Value = cliente.IdCliente;
                    dataGridView1.Rows[indice].Cells["Apellido"].Value = cliente.Apellido;
                    dataGridView1.Rows[indice].Cells["Nombre"].Value = cliente.Nombre;
                    dataGridView1.Rows[indice].Cells["Dni"].Value = cliente.Dni;
                    dataGridView1.Rows[indice].Cells["Mail"].Value = cliente.Mail;
                    dataGridView1.Rows[indice].Cells["Celular"].Value = cliente.Celular;
                    indice++;
                }
            }
        }
        public int GenerarId()
        {
            int cantidadClientes = listaClientes.Count();
            int mayorId=0;
            foreach (Cliente<IProductos> cliente in listaClientes)
            {
                if (cliente.IdCliente > mayorId)
                {
                    mayorId = cliente.IdCliente;
                }
            }
            return mayorId + 1;
        }

        private void btn_Crear_Click(object sender, EventArgs e)
        {
            string nombre = this.txt_Nombre.Text;
            string apellido = this.txt_Apellido.Text;
            string dni = this.txt_Dni.Text;
            string celular = this.txt_Celular.Text;
            string mail = this.txt_Mail.Text;

            try
            {
                if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(apellido) || string.IsNullOrEmpty(dni) || string.IsNullOrEmpty(celular) || string.IsNullOrEmpty(mail))
                {
                    throw new DatosIncompletosException("Se deben completar todos los campos");
                }

                Cliente<IProductos> nuevoRegistro = new Cliente<IProductos>(nombre, apellido, long.Parse(dni), celular, mail, this.GenerarId());

                listaClientes.Add(nuevoRegistro);

                ArchivoXml<List<Cliente<IProductos>>>.Escribir(listaClientes, "DatosClientes");

                this.DibujarTabla();
            }
            catch (DatosIncompletosException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ha ocurrido un error inesperado \n");
            }
        }

        private void btn_Salir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Esta seguro que desea salir?", "Advertencia", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btn_Eliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.CurrentRow is not null)
                {
                    int indice = dataGridView1.CurrentRow.Index;
                    string id = dataGridView1.Rows[indice].Cells["Id"].Value.ToString();
                    Cliente<IProductos> cliente = new Cliente<IProductos>(int.Parse(id));
                    int indiceEnLista = listaClientes.IndexOf(cliente);
                    listaClientes[indiceEnLista].ClienteActivo = false;
                    this.DibujarTabla();
                    ArchivoXml<List<Cliente<IProductos>>>.Escribir(listaClientes, "DatosClientes");
                }
                else
                {
                    throw new NoSePudoEliminarException();
                }
            }
            catch (NoSePudoEliminarException)
            {
                MessageBox.Show("No se puedo eliminar");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ha ocurrido un error inesperado \n");
            }
        }

        private void btn_Productos_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.CurrentRow is not null)
                {
                    int indice = dataGridView1.CurrentRow.Index;
                    string id = dataGridView1.Rows[indice].Cells["Id"].Value.ToString();
                    Cliente<IProductos> clienteSeleccionado = new Cliente<IProductos>(int.Parse(id));
                    int indiceEnLista = listaClientes.IndexOf(clienteSeleccionado);
                    ProductosForm frm_productos = new ProductosForm(listaClientes[indiceEnLista]);
                    frm_productos.Owner = this;
                    frm_productos.Show();
                    this.Hide();
                }
                else
                {
                    throw new Exception();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ha ocurrido un error inesperado \n");
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                this.txt_Apellido.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                this.txt_Nombre.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                this.txt_Dni.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                this.txt_Mail.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                this.txt_Celular.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            }
        }
        private void btn_Modificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.CurrentRow is not null)
                {
                    int id = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                    string apellido = txt_Apellido.Text.ToString();
                    string nombre = txt_Nombre.Text.ToString();
                    long dni = long.Parse(txt_Dni.Text.ToString());
                    string mail = txt_Mail.Text.ToString();
                    string celular = txt_Celular.Text.ToString();
                    Cliente<IProductos> cliente = new Cliente<IProductos>(nombre, apellido, dni, celular, mail, id);

                    int indice = listaClientes.IndexOf(new Cliente<IProductos>(id));
                    listaClientes[indice] = cliente;
                    ArchivoXml<List<Cliente<IProductos>>>.Escribir(listaClientes, "DatosClientes");
                    DibujarTabla();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ha ocurrido un error inesperado \n");
            }
        }

        public void SoloTexto(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && (e.KeyChar != (char)Keys.Space && e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
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
