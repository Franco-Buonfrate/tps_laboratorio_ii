using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Entidades
{
    public class Cliente : Persona 
    {
        [XmlIgnore]
        private List<Producto> listaDeCompras;
        private int idCliente;
        private string celular;
        private string mail;
        private bool clienteActivo;
        /// <summary>
        /// Constructor de Cliente
        /// </summary>
        public Cliente()
        {
            this.ListaDeCompras = new List<Producto>();
        }
        /// <summary>
        /// Constructor parametrizado de cliente
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="celular"></param>
        /// <param name="mail"></param>
        /// <param name="idCliente"></param>
        public Cliente(string nombre, string apellido, long dni, string celular, string mail, int idCliente) : base(dni, nombre, apellido)
        {
            this.idCliente = idCliente;
            this.ListaDeCompras = new List<Producto>();
            this.celular = celular;
            this.mail = mail;
            this.ClienteActivo = true;
        }
        /// <summary>
        /// contructor recibe solo id de la clase cliente para buscar en lista
        /// </summary>
        /// <param name="id"></param>
        public Cliente(int id):base(0,"","")
        {
            this.idCliente = id;
        }

        public int IdCliente { get => idCliente; set => idCliente = value; }
        public string Celular { get => celular; set => celular = value; }
        public string Mail { get => mail; set => mail = value; }
        public bool ClienteActivo { get => clienteActivo; set => clienteActivo = value; }
        [XmlIgnore]
        public List<Producto> ListaDeCompras { get => listaDeCompras; set => listaDeCompras = value; }

        public static bool operator ==(Cliente a, Cliente b)
        {
            return a.idCliente == b.idCliente;
        }
        public static bool operator !=(Cliente a, Cliente b)
        {
            return !(a == b);
        }

        public override bool Equals(object obj)
        {
            return obj is Cliente && this == (Cliente)obj;
        }

    }
}
