using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Entidades
{
    [XmlInclude(typeof(Pintura))]
    [XmlInclude(typeof(Rodillo))]
    [XmlInclude(typeof(Vinilo))]

    public abstract class Producto
    {
        protected int id;
        protected float precio;


        public float Precio { get => precio; set => precio= value; }
        public int Id { get => id; set => id = value; }

        public abstract void GenerarPrecio();
        public abstract string DevolverEnum();

        /// <summary>
        /// Compara dos prosuctos por su id
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns>true si tienen el mismo ID</returns>
        public static bool operator ==(Producto a, Producto b)
        {
            return a.id == b.id;
        }
        /// <summary>
        /// Compara dos prosuctos por su id
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns>false si tienen el mismo ID</returns>
        public static bool operator !=(Producto a, Producto b)
        {
            return !(a == b);
        }
        /// <summary>
        /// Compara una instancia de producto con el objeto pasado por parametro. 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>Devuelve true si son del mismo tipo y comparten ID</returns>
        public override bool Equals(object obj)
        {
            return obj is Producto && this == (Producto)obj;
        }

    }
}
