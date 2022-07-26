using System;
using System.Runtime.Serialization;

namespace Entidades
{
    public class DatosIncompletosException : Exception
    {
        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public DatosIncompletosException()
        {
        }
        /// <summary>
        /// constructor parametrizado
        /// </summary>
        /// <param name="message"></param>
        public DatosIncompletosException(string message) : base(message)
        {
        }
        /// <summary>
        /// constructor parametrizado
        /// </summary>
        /// <param name="message"></param>
        /// <param name="innerException"></param>
        public DatosIncompletosException(string message, Exception innerException) : base(message, innerException)
        {
        }
        /// <summary>
        /// constructor parametrizado
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        protected DatosIncompletosException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
