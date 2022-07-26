using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Productos
{
    public class Compra
    {
        private Cliente cliente;
        private List<Producto> listaDeCompras;

        /// <summary>
        /// contructor por defecto
        /// </summary>
        private Compra()
        {
            this.listaDeCompras = new List<Producto>();
        }
        /// <summary>
        /// constructor parametrizado
        /// </summary>
        /// <param name="cliente"></param>
        public Compra(Cliente cliente):this()
        {
            this.cliente= cliente;
        }

        public List<Producto> ListaDeCompras { get => listaDeCompras;}
        public Cliente Cliente { get => cliente; set => cliente = value; }

        /// <summary>
        /// Genera el Id en funcion del objeto con el id mas grande en la lista
        /// </summary>
        /// <returns>El id mas alto +1</returns>
        public int GenerarId()
        {
            int mayorId = 0;
            foreach (Producto productos in this.listaDeCompras)
            {
                if (productos.Id > mayorId)
                {
                    mayorId = productos.Id;
                }
            }
            return mayorId + 1;
        }
        /// <summary>
        /// cambia el id de todos los elementos de la lista por el id del cliente
        /// </summary>
        public void CambiarId()
        {
            foreach (Producto item in listaDeCompras)
            {
                item.Id = cliente.IdCliente;
            }
        }
    }
}
