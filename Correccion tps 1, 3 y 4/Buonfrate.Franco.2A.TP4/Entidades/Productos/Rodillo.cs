using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Rodillo:Producto
    {
        private ETipoRodillo tipo;
        private int cantidad;
        protected static float precioUnidad;

        public ETipoRodillo Tipo { get => tipo; set => tipo = value; }
        public int Cantidad { get => cantidad; set => cantidad = value; }
        /// <summary>
        /// Constructor estatico 
        /// </summary>
        static Rodillo()
        {
            precioUnidad = 25.5F;
        }
        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public Rodillo()
        {
        }
        /// <summary>
        /// Constructor parametrizado
        /// </summary>
        /// <param name="tipo"></param>
        /// <param name="cantidad"></param>
        /// <param name="id"></param>
        public Rodillo(ETipoRodillo tipo, int cantidad, int id)
        {
            this.tipo = tipo;
            this.cantidad = cantidad;
            this.id = id;
        }
        

        /// <summary>
        /// Genera el precio de la instancia de Rodillo
        /// </summary>
        public override void GenerarPrecio()
        {
            this.precio = this.cantidad * precioUnidad;
        }
        /// <summary>
        /// Busca el enumera del objeto y lo convierte a string
        /// </summary>
        /// <returns>El valor del enumerado a string</returns>
        public override string DevolverEnum()
        {
            return this.tipo.ToString();
        }
    }
}
