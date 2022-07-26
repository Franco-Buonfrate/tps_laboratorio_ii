using System;
using System.Runtime.Serialization;

namespace Entidades
{
    public class NoSePudoEliminarException : Exception
    {
        /// <summary>
        /// constructor por defecto
        /// </summary>
        public NoSePudoEliminarException()
        {
        }
        /// <summary>
        /// constructor parametrizado
        /// </summary>
        /// <param name="message"></param>
        public NoSePudoEliminarException(string message) : base(message)
        {
        }
        /// <summary>
        /// constructor parametrizado
        /// </summary>
        /// <param name="message"></param>
        /// <param name="innerException"></param>
        public NoSePudoEliminarException(string message, Exception innerException) : base(message, innerException)
        {
        }
        /// <summary>
        /// constructor parametrizado
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        protected NoSePudoEliminarException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
