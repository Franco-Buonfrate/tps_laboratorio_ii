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
            Cliente<IProductos> cliente = new Cliente<IProductos>("", "", 1, "", "", 12);

            //Act
            List<IProductos> actual = cliente.ListaDeCompras;

            //Assert
            Assert.AreNotEqual(null,actual);
        }
        [TestMethod]
        public void ListaClienteTest_BuscaUnMienbroDeLaListaPorId_RetornaElClienteConElMismoId()
        {
            //Arrange
            Cliente<IProductos> cliente = new Cliente<IProductos>(12);
            List<Cliente<IProductos>> listaCliente = new List<Cliente<IProductos>>();
            Cliente<IProductos> clienteABuscar = new Cliente<IProductos>("", "", 1, "", "", 12);

            //Act
            listaCliente.Add(clienteABuscar);
            int indice = listaCliente.IndexOf(cliente);

            //Assert
            Assert.AreEqual(clienteABuscar, listaCliente[indice]);
        }

        [TestMethod]
        public void GenerarIdTest_CreaUnaListaYLeAgregaUnElemento_RetornaElementoConElIdCorrespondiete()
        {
            //Arrange
            Cliente<IProductos> cliente = new Cliente<IProductos>(12);
            Pintura producto = new Pintura(EColor.Amarillo,1);
            Rodillo producto2 = new Rodillo(ETipoRodillo.Mini, 1);

            //Act
            producto.GenerarId(cliente);
            cliente.ListaDeCompras.Add(producto);
            producto2.GenerarId(cliente);
            cliente.ListaDeCompras.Add(producto2);

            //Assert
            Assert.AreEqual(2, producto2.IdProducto);
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
