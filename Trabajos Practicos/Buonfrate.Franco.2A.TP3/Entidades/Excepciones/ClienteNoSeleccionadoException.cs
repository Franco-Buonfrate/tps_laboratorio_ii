using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class ClienteNoSeleccionadoException : Exception
    {
        public ClienteNoSeleccionadoException():base("Se debe selecionar un cliente para reealizar esa accion")
        {
        }
        
    }
}
