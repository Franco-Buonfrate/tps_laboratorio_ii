using System;
using System.Runtime.Serialization;

namespace Entidades
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
