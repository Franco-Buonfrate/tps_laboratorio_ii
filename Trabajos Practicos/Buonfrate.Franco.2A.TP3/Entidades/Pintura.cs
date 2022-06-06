using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Pintura:IProductos
    {
        private EColor color;
        protected float litros;
        protected int idProducto;
        protected float precio;
        private static float precioPorLitro;

        static Pintura()
        {
            precioPorLitro = 69;
        }

        public Pintura(EColor color, float litros)
        {
            this.color = color;
            this.litros = litros;
        }

        public int IdProducto { get => idProducto; set => idProducto = value; }
        public float Precio { get => precio; set => precio = value; }

        public float Cantidad 
        { 
            get
            {
                return this.litros;
            }
 
        }

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
            this.precio = (float)this.litros * precioPorLitro;
        }

        public string DevolverEnum()
        {
            return this.color.ToString();
        }
    }
}
