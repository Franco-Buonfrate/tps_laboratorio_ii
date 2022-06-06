using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Vinilo:IProductos
    {
        protected EDisenio disenio;
        protected float precio;
        protected int idProducto;

        public Vinilo(EDisenio disenio)
        {
            this.disenio = disenio;
        }

        public int IdProducto { get => idProducto; set => idProducto = value; }
        public float Precio { get => precio; set => precio = value; }
        public float Cantidad => 1;

        public string DevolverEnum()
        {
            return this.disenio.ToString();
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
