using Entidades;
using ManejoDeDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Pintureria
{
    public partial class FrmClientes : Form , IListar<Cliente>
    {
        private static DatosClientes datosClientes;

        static FrmClientes()
        {
            datosClientes = new DatosClientes("REX", ArchivoXml<List<Cliente>>.Leer("DatosClientes"));
        }
        public FrmClientes()
        {
            InitializeComponent();
            this.Refrescar();
        }

        public void Refrescar()
        {
            List<Cliente> clientesFiltrados = new List<Cliente>();

            foreach (Cliente item in datosClientes.ListaClientes)
            {
                if (item.ClienteActivo == true)
                {
                    clientesFiltrados.Add(item);
                }
            }
            dataGridView1.DataSource = clientesFiltrados;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
        }
        public Cliente RecuperarObjeto()
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                Cliente clienteSeleccionado = (Cliente)dataGridView1.CurrentRow.DataBoundItem;
                return clienteSeleccionado;
            }
            return null;
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

                datosClientes.AgregarCliente(nombre, apellido, long.Parse(dni), celular, mail);

                ArchivoXml<List<Cliente>>.Escribir(datosClientes.ListaClientes, "DatosClientes");

                this.Refrescar();
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
                Cliente clienteAELiminar = this.RecuperarObjeto();
                if (clienteAELiminar is not null)
                {
                    datosClientes.EliminarCliente(clienteAELiminar);
                    ArchivoXml<List<Cliente>>.Escribir(datosClientes.ListaClientes, "DatosClientes");
                    this.Refrescar();
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
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Cliente cliente = this.RecuperarObjeto();
            if (cliente is not null)
            {
                this.txt_Apellido.Text = cliente.Apellido;
                this.txt_Nombre.Text = cliente.Nombre;
                this.txt_Dni.Text = cliente.Dni.ToString();
                this.txt_Mail.Text = cliente.Mail;
                this.txt_Celular.Text = cliente.Celular;
            }
            else
            {
                this.txt_Apellido.Text = string.Empty;
                this.txt_Nombre.Text = string.Empty;
                this.txt_Dni.Text = string.Empty;
                this.txt_Mail.Text = string.Empty;
                this.txt_Celular.Text = string.Empty;
            }
        }
        private void btn_Modificar_Click(object sender, EventArgs e)
        {
            try
            {
                Cliente clienteModificar = this.RecuperarObjeto();
                if (clienteModificar is not null)
                {
                    string apellido = txt_Apellido.Text.ToString();
                    string nombre = txt_Nombre.Text.ToString();
                    long dni = long.Parse(txt_Dni.Text.ToString());
                    string mail = txt_Mail.Text.ToString();
                    string celular = txt_Celular.Text.ToString();

                    datosClientes.ModificarCliente(clienteModificar, nombre, apellido, dni, celular, mail);
                    ArchivoXml<List<Cliente>>.Escribir(datosClientes.ListaClientes, "DatosClientes");
                    this.Refrescar();
                }
                else
                {
                    throw new ClienteNoSeleccionadoException();
                }

            }
            catch (ClienteNoSeleccionadoException ex)
            {
                MessageBox.Show(ex.Message, "Ha ocurrido un error\n");

            }
            catch (FormatException)
            {
                MessageBox.Show("Ingrese datos validos", "Ha ocurrido un error\n");
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
                Cliente clienteActual = this.RecuperarObjeto();
                if (clienteActual is not null)
                {
                    int indiceEnLista = datosClientes.ListaClientes.IndexOf(clienteActual);
                    ProductosForm frm_productos = new ProductosForm(datosClientes.ListaClientes[indiceEnLista]);
                    frm_productos.Owner = this;
                    frm_productos.Show();
                    this.Hide();
                }
                else
                {
                    throw new ClienteNoSeleccionadoException();
                }
            }
            catch (ClienteNoSeleccionadoException ex)
            {
                MessageBox.Show(ex.Message, "Ha ocurrido un error\n");
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
