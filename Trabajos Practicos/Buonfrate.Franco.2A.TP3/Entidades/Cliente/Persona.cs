using System;
using System.Xml.Serialization;

namespace Entidades
{
    [XmlInclude(typeof(Cliente<IProductos>))]

    public abstract class Persona
    {
        protected long dni;
        protected string nombre;
        protected string apellido;

        public Persona()
        {
        }

        public Persona(long dni, string nombre, string apellido)
        {
            this.dni = dni;
            this.nombre = nombre;
            this.apellido = apellido;
        }

        public long Dni 
        { 
            get => dni; 
            set => dni = value; 
        }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }

        public static bool operator ==(Persona a, Persona b)
        {
            return a.dni == b.dni;
        }
        public static bool operator !=(Persona a, Persona b)
        {
            return !(a == b);
        }

    }
}
