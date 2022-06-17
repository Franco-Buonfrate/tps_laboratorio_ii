using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Rodillo:Producto
    {
        protected ETipoRodillo tipo;
        protected int cantidad;
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

        public float Cantidad => cantidad;

        public override void GenerarId(Cliente cliente)
        {
            int mayorId = 0;
            foreach (Producto productos in cliente.ListaDeCompras)
            {
                if (productos.IdProducto > mayorId)
                {
                    mayorId = productos.IdProducto;
                }
            }
            this.idProducto = mayorId + 1;
        }

        public override void GenerarPrecio()
        {
            this.precio = this.cantidad * precioUnidad;
        }

        public override string DevolverEnum()
        {
            return this.tipo.ToString();
        }
    }
}
