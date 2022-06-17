using Entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace EntidadesTest
{
    [TestClass]
    public class TestEntidades
    {
        [TestMethod]
        public void ListaProductosTest_CreaUnaInstanciaDeCliente_RetornaSiSeInstanciaLaListaProducto()
        {
            //Arrange
            Cliente cliente = new Cliente("", "", 1, "", "", 12);

            //Act
            List<Producto> actual = cliente.ListaDeCompras;

            //Assert
            Assert.AreNotEqual(null,actual);
        }
        [TestMethod]
        public void ListaClienteTest_BuscaUnMienbroDeLaListaPorId_RetornaElClienteConElMismoId()
        {
            //Arrange
            Cliente cliente = new Cliente(12);
            List<Cliente> listaCliente = new List<Cliente>();
            Cliente clienteABuscar = new Cliente("", "", 0, "", "", 12);

            //Act
            listaCliente.Add(clienteABuscar);
            int indice = listaCliente.IndexOf(cliente);

            //Assert
            Assert.AreEqual(clienteABuscar, listaCliente[indice]);
        }

        [TestMethod]
        public void EliminarClienteTest_AgregaClientesALaListaYEliminaUno_RetornaLaListaConElELiementoDesactivado()
        {
            //Arrange
            DatosClientes clientes = new DatosClientes("Nombre",null);
            clientes.ListaClientes.Add(new Cliente(1));
            clientes.ListaClientes.Add(new Cliente(2));
            clientes.ListaClientes.Add(new Cliente(3));

            //Act
            clientes.EliminarCliente(new Cliente(1));
            int actual = clientes.ListaClientes.IndexOf(new Cliente(1));

            //Assert
            Assert.AreEqual(false, clientes.ListaClientes[actual].ClienteActivo);          
        }
        [TestMethod]
        public void DevolverEnumTest_PideElEnumDelProducto_RetornaStringDelEnum()
        {
            //Arrange
            Pintura producto = new Pintura(EColor.Amarillo, 1);

            //Act
            string actual=producto.DevolverEnum();

            //Assert
            Assert.AreEqual("Amarillo", actual);
        }
    }
}
