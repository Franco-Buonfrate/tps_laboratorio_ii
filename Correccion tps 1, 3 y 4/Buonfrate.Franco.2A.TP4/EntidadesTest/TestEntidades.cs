using Entidades;
using Entidades.Productos;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace EntidadesTest
{
    [TestClass]
    public class TestEntidades
    {
        [TestMethod]
        public void CambiarIdTest_CreaUnaInstanciaDeCompraYEjecutaElMetodo_RetornaLosProductosConElIdDelCliente()
        {
            //Arrange
            Cliente cliente = new Cliente(5);
            Compra compra = new Compra(cliente);
            compra.ListaDeCompras.Add(new Pintura(1));
            compra.ListaDeCompras.Add(new Pintura(2));
            compra.ListaDeCompras.Add(new Pintura(3));

            //Act
            compra.CambiarId();
            int actual = compra.ListaDeCompras[1].Id;

            //Assert
            Assert.AreEqual(5,actual);
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
        public void ClienteNoEncontradoException_CreaUnaInstancia_RetornaElMensajeDeLaExcepcion()
        {
            //Arrange
            ClienteNoSeleccionadoException exception = new ClienteNoSeleccionadoException();

            //Act
            string actual = exception.Message;
            string expected = "Se debe selecionar un cliente para reealizar esa accion";

            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void DevolverEnumTest_PideElEnumDelProducto_RetornaStringDelEnum()
        {
            //Arrange
            Pintura producto = new Pintura(EColor.Amarillo, 1,1);

            //Act
            string actual=producto.DevolverEnum();

            //Assert
            Assert.AreEqual("Amarillo", actual);
        }
    }
}
