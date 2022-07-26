using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Pintura:Producto
    {
        private EColor color;
        protected float litros;
        private static float precioPorLitro;

        static Pintura()
        {
            precioPorLitro = 69;
        }

        public Pintura(int id)
        {
            this.idProducto = id;
        }

        public Pintura(EColor color, float litros)
        {
            this.color = color;
            this.litros = litros;
        }

        public float Cantidad 
        { 
            get
            {
                return this.litros;
            }
 
        }

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
            this.precio = (float)this.litros * precioPorLitro;
        }

        public override string DevolverEnum()
        {
            return this.color.ToString();
        }
    }
}
