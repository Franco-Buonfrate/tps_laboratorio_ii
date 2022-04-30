using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Ciclomotor : Vehiculo
    {
        #region Constructor
        /// <summary>
        /// Constructor de la clase Ciclomotor
        /// </summary>
        /// <param name="marca">Parametro de tipo EMarca</param>
        /// <param name="chasis">Parametro de tipo string</param>
        /// <param name="color">Parametro de tipo ConsoleColor</param>
        public Ciclomotor(EMarca marca, string chasis, ConsoleColor color):base(chasis, marca, color)
        {
        }
        #endregion

        #region Enumerado
        /// <summary>
        /// Ciclomotor son 'Chico'
        /// </summary>
        protected override ETamanio Tamanio
        {
            get
            {
                return ETamanio.Chico;
            }
        }
        #endregion

        #region Metodo
        /// <summary>
        /// retorna los datos del atributo de clase Ciclomotor
        /// </summary>
        /// <returns>retorna string</returns>
        public override sealed string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("CICLOMOTOR");
            sb.AppendLine(base.Mostrar());
            sb.AppendFormat("TAMAÑO : {0}", this.Tamanio);
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
        #endregion
    }
}
