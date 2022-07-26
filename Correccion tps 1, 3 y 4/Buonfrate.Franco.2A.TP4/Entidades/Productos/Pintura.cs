using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Entidades
{
    public class Pintura:Producto
    {
        private EColor color;
        private float litros;
        private static float precioPorLitro;
        /// <summary>
        /// Constructor estatico
        /// </summary>
        static Pintura()
        {
            precioPorLitro = 69;
        }
        /// <summary>
        /// Constructor por Defecto
        /// </summary>
        public Pintura()
        {
        }
        /// <summary>
        /// Constructor parametrizado para comparar objetos por su Id
        /// </summary>
        /// <param name="id"></param>
        public Pintura(int id)
        {
            this.id = id;
        }
        /// <summary>
        /// constructor parametrizado
        /// </summary>
        /// <param name="color"></param>
        /// <param name="litros"></param>
        /// <param name="id"></param>
        public Pintura(EColor color, float litros, int id)
        {
            this.color = color;
            this.litros = litros;
            this.id = id;
        }

        public float Cantidad 
        { 
            get
            {
                return this.litros;
            }
 
        }

        public EColor Color { get => color; set => color = value; }
        public float Litros { get => litros; set => litros = value; }
        /// <summary>
        /// Genera el precio de la instancia de pintura
        /// </summary>
        public override void GenerarPrecio()
        {
            this.precio = (float)this.litros * precioPorLitro;
        }
        /// <summary>
        /// Busca el enumera del objeto y lo convierte a string
        /// </summary>
        /// <returns>El valor del enumerado a string</returns>
        public override string DevolverEnum()
        {
            return this.color.ToString();
        }
    }
}
