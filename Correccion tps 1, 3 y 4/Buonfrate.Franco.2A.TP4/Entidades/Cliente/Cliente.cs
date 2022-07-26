using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Entidades
{
    public class Cliente 
    {
        private int idCliente;
        private string celular;
        private string mail;
        private long dni;
        private string nombre;
        private string apellido;
        /// <summary>
        /// Constructor vacio Cliente
        /// </summary>
        public Cliente()
        {

        }
        /// <summary>
        /// Constructor parametrizado de cliente sin id
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="celular"></param>
        /// <param name="mail"></param>
        /// <param name="idCliente"></param>
        public Cliente(string nombre, string apellido, long dni, string celular, string mail) 
        {
            this.celular = celular;
            this.mail = mail;
            this.dni = dni;
            this.nombre = nombre;
            this.apellido = apellido;
        }
        /// <summary>
        /// cliente parametrizado de cliente
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="celular"></param>
        /// <param name="mail"></param>
        /// <param name="idCliente"></param>
        public Cliente(string nombre, string apellido, long dni, string celular, string mail,int idCliente)
        {
            this.idCliente = idCliente;
            this.celular = celular;
            this.mail = mail;
            this.dni = dni;
            this.nombre = nombre;
            this.apellido = apellido;
        }
        /// <summary>
        /// contructor recibe solo id de la clase cliente para buscar en lista
        /// </summary>
        /// <param name="id"></param>
        public Cliente(int id)
        {
            this.idCliente = id;
        }
        
        public int IdCliente { get => idCliente; set => idCliente = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public long Dni { get => dni; set => dni = value; }
        public string Celular { get => celular; set => celular = value; }
        public string Mail { get => mail; set => mail = value; }

        /// <summary>
        /// Compara dos clientes por su id 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns>devuelve true si son iguales</returns>
        public static bool operator ==(Cliente a, Cliente b)
        {
            return a.idCliente == b.idCliente;
        }
        /// <summary>
        /// Compara dos clientes por su id 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns>devuelve false si son iguales</returns>
        public static bool operator !=(Cliente a, Cliente b)
        {
            return !(a == b);
        }
        /// <summary>
        /// Compara una instancia de CLiente con el objeto pasado por parametro. 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>Devuelve true si son del mismo tipo y comparten ID</returns>
        public override bool Equals(object obj)
        {
            return obj is Cliente && this == (Cliente)obj;
        }

    }
}
