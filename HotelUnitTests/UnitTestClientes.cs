using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HotelUnitTests.ServicioClientes;

namespace HotelUnitTests
{
    [TestClass]
    public class UnitTestClientes
    {
        [TestMethod]
        public void TestCrearCliente()
        {
            ServicioClientes.ClientesClient proxy = new ServicioClientes.ClientesClient();
            string mensaje = proxy.CrearCliente(2, "Juan Luis", "Perez", "Rodriguez", "12324212", "jperez@contoso.com", "2133212", 1);
            Cliente cliente = proxy.ObtenerCliente(2);
            Assert.AreEqual("Grabacion Exitosa", mensaje);
            Assert.IsNotNull(cliente);
        }

        [TestMethod]
        public void TestModificarCliente()
        {
            ServicioClientes.ClientesClient proxy = new ServicioClientes.ClientesClient();
            string mensaje = proxy.ModificarCliente(1,1, "Juan Luis", "Perez", "Rodriguez", "12324212", "jperez@contoso.com", "2133212", 1);
            Cliente cliente = proxy.ObtenerCliente(1);

            Assert.AreEqual("Grabacion Exitosa", mensaje);
            Assert.IsNotNull(cliente);
            Assert.AreEqual("Perez", cliente.ApellidoPaterno);
        }


        [TestMethod]
        public void TestObtenerCliente()
        {
            ServicioClientes.ClientesClient proxy = new ServicioClientes.ClientesClient();
            Cliente cliente = proxy.ObtenerCliente(2);

            Assert.IsNotNull(cliente);
        }

        [TestMethod]
        public void TestEliminarCliente()
        {
            ServicioClientes.ClientesClient proxy = new ServicioClientes.ClientesClient();
             proxy.EliminarCliente(2);
            Cliente cliente = proxy.ObtenerCliente(2);

            Assert.IsNull(cliente);
        }

    }
}
