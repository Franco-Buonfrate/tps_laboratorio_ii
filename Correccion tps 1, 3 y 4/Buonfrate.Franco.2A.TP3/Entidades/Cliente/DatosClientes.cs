using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class DatosClientes
    {
        private List<Cliente> listaClientes;
        private string nombrePintureria;

        private DatosClientes()
        {
            listaClientes = new List<Cliente>();
        }
        public DatosClientes(string nombre,List<Cliente> Clientes):this()
        {
            this.nombrePintureria = nombre;
            if (Clientes is not null)
            {
                this.listaClientes = Clientes;
            }

        }

        protected string NombrePintureria { get => nombrePintureria;}
        public List<Cliente> ListaClientes { get => listaClientes; set => listaClientes = value; }

        public void AgregarCliente(string nombre, string apellido, long dni, string celular, string mail)
        {
            Cliente nuevoCliente = new Cliente(nombre, apellido, dni, celular, mail, this.GenerarId());
            this.listaClientes.Add(nuevoCliente);
        }

        public void EliminarCliente(Cliente clienteEliminar)
        {
            int indice = this.listaClientes.IndexOf(clienteEliminar);
            if (indice>=0)
            {
                this.listaClientes[indice].ClienteActivo = false;
            }
        }

        public void ModificarCliente(Cliente clienteModificar, string nombre, string apellido, long dni, string celular, string mail)
        {
            int indice = this.listaClientes.IndexOf(clienteModificar);
            if (indice>=0)
            {
                this.listaClientes[indice] = new Cliente(nombre, apellido, dni, celular, mail, clienteModificar.IdCliente);
            }
        }

        public int GenerarId()
        {
            int cantidadClientes = this.ListaClientes.Count();
            int mayorId = 0;
            foreach (Cliente cliente in this.ListaClientes)
            {
                if (cliente.IdCliente > mayorId)
                {
                    mayorId = cliente.IdCliente;
                }
            }
            return mayorId + 1;
        }
    }
}
