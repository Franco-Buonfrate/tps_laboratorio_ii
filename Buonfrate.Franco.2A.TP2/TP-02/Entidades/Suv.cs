using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Suv:Vehiculo
    {
        #region Constructor
        /// <summary>
        /// Constructor de la clase Suv
        /// </summary>
        /// <param name="marca">Parametro de tipo EMarca</param>
        /// <param name="chasis">Parametro de tipo string</param>
        /// <param name="color">Parametro de tipo ConsoleColor</param>
        public Suv(EMarca marca, string chasis, ConsoleColor color)
            : base(chasis, marca, color)
        {
        }
        #endregion

        #region Enumerado
        /// <summary>
        /// SUV son 'Grande'
        /// </summary>
        protected override ETamanio Tamanio
        {
            get
            {
                return ETamanio.Grande;
            }
        }
        #endregion 

        #region Metodo
        /// <summary>
        /// Retorna los datos de el atributo de clase Suv
        /// </summary>
        /// <returns>retorna un string</returns>
        public override sealed string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("SUV");
            sb.AppendLine(base.Mostrar());
            sb.AppendFormat("TAMAÑO : {0}\n", Tamanio.ToString());
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
        #endregion
    }
}
