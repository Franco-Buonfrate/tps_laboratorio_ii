using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class NoSePudoEliminarException : Exception
    {
        public NoSePudoEliminarException()
        {
        }

        public NoSePudoEliminarException(string message) : base(message)
        {
        }

        public NoSePudoEliminarException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NoSePudoEliminarException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
