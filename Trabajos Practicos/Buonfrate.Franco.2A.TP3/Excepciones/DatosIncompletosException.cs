using System;
using System.Runtime.Serialization;

namespace Excepciones
{
    public class DatosIncompletosException : Exception
    {
        public DatosIncompletosException()
        {
        }

        public DatosIncompletosException(string message) : base(message)
        {
        }

        public DatosIncompletosException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected DatosIncompletosException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
