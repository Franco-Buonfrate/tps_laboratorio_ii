using Entidades;
using ManejoDeDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pintureria
{
    public partial class FrmClientes : Form , IListar<Cliente>
    {
        /// <summary>
        /// constructor por defecto
        /// </summary>
        public FrmClientes()
        {
            InitializeComponent();
            Refrescar();
        }
        /// <summary>
        /// Metodo asyncrono que refresca la el datagrid con la informacion de la base de datos
        /// </summary>
        public async void Refrescar()
        {
            try
            {
                if (dtgvClientes.InvokeRequired)
                {
                    Action refrescar = Refrescar;
                    dtgvClientes.Invoke(refrescar);
                }
                else
                {
                    dtgvClientes.DataSource = await BaseDeDatos.Leer();
                    dtgvClientes.Refresh();
                    dtgvClientes.Update();
                    dtgvClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dtgvClientes.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("No se encontro la base de datos", "Ha ocurrido un error inesperado \n");
            }
        }

        /// <summary>
        /// recupera los datos de cliente seleccionado en el DataGrid
        /// </summary>
        /// <returns>una nueva isntacia de cliente con los datos pasados por parametros o null en caso de que no se haya seleccionado ninguno</returns>
        public Cliente RecuperarObjeto()
        {
            if (dtgvClientes.SelectedRows.Count > 0)
            {
                Cliente clienteSeleccionado = (Cliente)dtgvClientes.CurrentRow.DataBoundItem;
                return clienteSeleccionado;
            }
            return null;
        }
        /// <summary>
        /// agrega un nuevo item a la base de datos con los respectivos datos en el form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

                BaseDeDatos.Guardar(new Cliente(nombre,apellido,Convert.ToInt64(dni),celular,mail));

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

        /// <summary>
        /// Cierra el formulario 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Salir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Esta seguro que desea salir?", "Advertencia", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
        /// <summary>
        /// ELimina el elemento de la base de datos, retornado por el metodo RecuperaObjeto siempre y cuando este no sea nulo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Eliminar_Click(object sender, EventArgs e)
        {
            try
            {
                Cliente clienteAELiminar = this.RecuperarObjeto();
                if (clienteAELiminar is not null)
                {
                    BaseDeDatos.Eliminar(clienteAELiminar.IdCliente);
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
        /// <summary>
        /// Completa los datos del cliente seleccionado en el datagrid, en su textbox correspondiente
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtgvClientes_CellClick(object sender, DataGridViewCellEventArgs e)
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
        /// <summary>
        /// Crea un instancia de Cliente con los datos del cliente seleccionado e invoca al metodo BaseDeDatos.Modificar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Modificar_Click(object sender, EventArgs e)
        {
            try
            {
                Cliente clienteModificar = this.RecuperarObjeto();
                if (clienteModificar is not null)
                {
                    clienteModificar.Apellido = txt_Apellido.Text.ToString();
                    clienteModificar.Nombre = txt_Nombre.Text.ToString();
                    clienteModificar.Dni = long.Parse(txt_Dni.Text.ToString());
                    clienteModificar.Mail = txt_Mail.Text.ToString();
                    clienteModificar.Celular = txt_Celular.Text.ToString();

                    BaseDeDatos.Modificar(clienteModificar);
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
        /// <summary>
        /// Genera una instancia del form productos pasandole el cliente seleccionado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Productos_Click(object sender, EventArgs e)
        {
            try
            {
                Cliente clienteActual = this.RecuperarObjeto();
                if (clienteActual is not null)
                {
                    ProductosForm frm_productos = new ProductosForm(BaseDeDatos.LeerId(clienteActual.IdCliente));
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

        
    }
}
