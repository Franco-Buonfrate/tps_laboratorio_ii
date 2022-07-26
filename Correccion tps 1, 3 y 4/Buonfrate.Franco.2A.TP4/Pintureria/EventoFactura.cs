using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pintureria
{
    public class EventoFactura
    {
        public delegate void GeneradorFacturaHandle();
        public event GeneradorFacturaHandle generadorFactura;

        /// <summary>
        /// Invoca el evento luego de validar que este no sea nulo y lo limpia
        /// </summary>
        public void GenerarFactura()
        {
            if (this.generadorFactura is not null)
            {
                this.generadorFactura.Invoke();
                this.generadorFactura = null;
            }
        }
    }
}
