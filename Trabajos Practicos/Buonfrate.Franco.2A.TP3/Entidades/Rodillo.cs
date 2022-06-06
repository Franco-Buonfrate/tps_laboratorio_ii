using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Rodillo:IProductos
    {
        protected ETipoRodillo tipo;
        protected int cantidad;
        protected float precio;
        protected int idProducto;
        protected static float precioUnidad;
        
        static Rodillo()
        {
            precioUnidad = 25.5F;
        }
        public Rodillo(ETipoRodillo tipo, int cantidad)
        {
            this.tipo = tipo;
            this.cantidad = cantidad;
        }

        public float Precio { get => precio; set => precio = value; }
        public int IdProducto { get => idProducto; set => idProducto = value; }

        public float Cantidad => cantidad;

        public void GenerarId(Cliente<IProductos> cliente)
        {
            int mayorId = 0;
            foreach (IProductos productos in cliente.ListaDeCompras)
            {
                if (productos.IdProducto > mayorId)
                {
                    mayorId = productos.IdProducto;
                }
            }
            this.idProducto = mayorId + 1;
        }

        public void GenerarPrecio()
        {
            this.precio = this.cantidad * precioUnidad;
        }

        public string DevolverEnum()
        {
            return this.tipo.ToString();
        }
    }
}
