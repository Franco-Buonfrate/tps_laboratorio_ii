using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Vinilo:Producto
    {
        private EDisenio disenio;
        /// <summary>
        /// constructor por defecto
        /// </summary>
        public Vinilo()
        {
        }
        /// <summary>
        /// constructor parametrizado
        /// </summary>
        /// <param name="disenio"></param>
        /// <param name="id"></param>
        public Vinilo(EDisenio disenio,int id)
        {
            this.disenio = disenio;
            this.id = id;
        }

        public EDisenio Disenio { get => disenio; set => disenio = value; }

        /// <summary>
        /// Busca el enumera del objeto y lo convierte a string
        /// </summary>
        /// <returns>El valor del enumerado a string</returns>
        public override string DevolverEnum()
        {
            return this.disenio.ToString();
        }
        /// <summary>
        /// Genera el precio de la instancia de Vinilo
        /// </summary>
        public override void GenerarPrecio()
        {
            switch (this.disenio)
            {
                case EDisenio.Opcion1:
                    this.precio = 30;           
                    break;
                case EDisenio.Opcion2:
                    this.precio = 35;
                    break;
                case EDisenio.Opcion3:
                    this.precio = 35.5F;
                    break;
                case EDisenio.Opcion4:
                    this.precio = 42.42F;
                    break;
            }
        }
    }
}
