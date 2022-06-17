using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public abstract class Producto
    {
        protected int idProducto;
        protected float precio;

        public int IdProducto { get => idProducto;}
        public float Precio { get => precio;}

        public abstract void GenerarPrecio();
        public abstract void GenerarId(Cliente cliente);
        public abstract string DevolverEnum();

        
        public static bool operator ==(Producto a, Producto b)
        {
            return a.idProducto == b.idProducto;
        }
        public static bool operator !=(Producto a, Producto b)
        {
            return !(a == b);
        }
        public override bool Equals(object obj)
        {
            return obj is Producto && this == (Producto)obj;
        }

    }
}
