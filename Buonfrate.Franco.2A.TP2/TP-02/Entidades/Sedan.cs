using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

namespace Entidades
{
    public class Sedan : Vehiculo
    {
        public enum ETipo { CuatroPuertas, CincoPuertas }
        private ETipo tipo;

        #region Constructores
        /// <summary>
        /// Por defecto, TIPO será CuatroPuertas
        /// </summary>
        /// <param name="marca">Parametro de tipo EMarca</param>
        /// <param name="chasis">Parametro de tipo string</param>
        /// <param name="color">Parametro de tipo ConsoleColor</param>
        public Sedan(EMarca marca, string chasis, ConsoleColor color)
            : this(marca, chasis, color, ETipo.CuatroPuertas)
        {
        }
        /// <summary>
        /// Constructor de la clase Sedan
        /// </summary>
        /// <param name="marca">Parametro de tipo EMarca</param>
        /// <param name="chasis">Parametro de tipo string</param>
        /// <param name="color">Parametro de tipo ConsoleColor</param>
        /// <param name="tipo">Parametro de tipo ETipo</param>
        public Sedan(EMarca marca, string chasis, ConsoleColor color, ETipo tipo) : base(chasis, marca, color)
        {
            this.tipo = tipo;
        }
        #endregion

        #region Enumerado
        /// <summary>
        /// Sedan son 'Mediano'
        /// </summary>
        protected override ETamanio Tamanio
        {
            get
            {
                return ETamanio.Mediano;
            }
        }
        #endregion

        #region Metodo
        /// <summary>
        /// Muestra los datos del atributo de clase Sedan
        /// </summary>
        /// <returns>retorna string</returns>
        public override sealed string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("SEDAN");
            sb.AppendLine(base.Mostrar());
            sb.AppendFormat("TAMAÑO : {0}\n", Tamanio.ToString());
            sb.AppendFormat("TIPO :  {0}", this.tipo);
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
        #endregion
    }
}
