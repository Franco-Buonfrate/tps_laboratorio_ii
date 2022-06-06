using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public interface IProductos
    {
        int IdProducto { get; set; }
        float Precio { get; set; }
        float Cantidad { get; }
        

        void GenerarPrecio();
        void GenerarId(Cliente<IProductos> cliente);
        string DevolverEnum();

    }
}
