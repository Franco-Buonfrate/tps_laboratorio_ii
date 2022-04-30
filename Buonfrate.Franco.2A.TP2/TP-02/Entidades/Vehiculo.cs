using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// La clase Vehiculo no deberá permitir que se instancien elementos de este tipo.
    /// </summary>
    public abstract class Vehiculo
    {
        #region Enumerados
        public enum EMarca
        {
            Chevrolet, Ford, Renault, Toyota, BMW, Honda, HarleyDavidson
        }
        public enum ETamanio
        {
            Chico, Mediano, Grande
        }
        private EMarca marca;
        private string chasis;
        private ConsoleColor color;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor de la clase Vehiculo, inicaliza los valores de chasis, marca y color con los valores pasados por parametros
        /// </summary>
        /// <param name="chasis">Parametro de tipo string</param>
        /// <param name="marca">Parametro de tipo EMarca</param>
        /// <param name="color">Parametro de tipo ConsoleColor</param>
        protected Vehiculo(string chasis, EMarca marca, ConsoleColor color)
        {
            this.chasis = chasis;
            this.marca = marca;
            this.color = color;
        }
        #endregion

        #region Propiedad
        /// <summary>
        /// ReadOnly: Retornará el tamaño
        /// </summary>
        protected abstract ETamanio Tamanio { get;}
        #endregion

        #region Metodo
        /// <summary>
        /// Publica todos los datos del Vehiculo.
        /// </summary>
        /// <returns></returns>
        public virtual string Mostrar()
        {
            return (string)this;
        }
        #endregion

        #region Sobrecargas

        /// <summary>
        /// sobrecarga de la convercion explicita de Vehiculo a string
        /// </summary>
        /// <param name="p">Parametro de tipo Vehiculo</param>
        ///<returns>Retorna un string con los datos del Vehiculo pasado por parametro</returns>
        public static explicit operator string(Vehiculo p)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("CHASIS: {0}\r\n", p.chasis);
            sb.AppendFormat("MARCA : {0}\r\n", p.marca.ToString());
            sb.AppendFormat("COLOR : {0}\r\n", p.color.ToString());
            sb.AppendLine("---------------------");

            return sb.ToString(); 
        }

        /// <summary>
        /// Dos vehiculos son iguales si comparten el mismo chasis
        /// </summary>
        /// <param name="v1">Parametro de tipo Vehiculo</param>
        /// <param name="v2">Parametro de tipo Vehiculo</param>
        /// <returns>devuelve un bool (true: son iguales / false:no son iguales)</returns>
        public static bool operator ==(Vehiculo v1, Vehiculo v2)
        {
            return v1.chasis == v2.chasis;
        }
        /// <summary>
        /// Dos vehiculos son distintos si su chasis es distinto
        /// </summary>
        /// <param name="v1">Parametro de tipo Vehiculo</param>
        /// <param name="v2">Parametro de tipo Vehiculo</param>
        /// <returns>devuelve un bool (true: no son iguales / false:son iguales)</returns>
        public static bool operator !=(Vehiculo v1, Vehiculo v2)
        {
            return !(v1 == v2);
        }
        #endregion
    }
}
