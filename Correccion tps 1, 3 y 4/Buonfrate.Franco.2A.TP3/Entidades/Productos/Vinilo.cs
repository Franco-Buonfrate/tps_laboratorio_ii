using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Vinilo:Producto
    {
        protected EDisenio disenio;

        public Vinilo(EDisenio disenio)
        {
            this.disenio = disenio;
        }

        public override string DevolverEnum()
        {
            return this.disenio.ToString();
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
            switch (this.disenio)
            {
                case EDisenio.Opcion1:
                    this.precio = 30;           
                    break;
                case EDisenio.Opcion2:
                    this.precio = 35;
                    break;
                case EDisenio.Opcion3:
                    this.precio = 35.5F;
                    break;
                case EDisenio.Opcion4:
                    this.precio = 42.42F;
                    break;
            }
        }
    }
}
