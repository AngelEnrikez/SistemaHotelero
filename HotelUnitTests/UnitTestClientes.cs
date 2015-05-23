using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HotelUnitTests.ServicioClientes;

namespace HotelUnitTests
{
    [TestClass]
    public class UnitTestClientes
    {
        [TestMethod]
        public void validarRegistro()
        {
            ServicioClientes.ClientesClient proxy = new ServicioClientes.ClientesClient();
            string mensaje = proxy.CrearCliente(1, "Juan Luis", "Perez", "Rodriguez", "12324212", "jperez@contoso.com", "2133212", 1);
            Assert.AreEqual("Grabacion Exitosa", mensaje);
        }

        [TestMethod]
        public void validarModificacion()
        {
            ServicioClientes.ClientesClient proxy = new ServicioClientes.ClientesClient();
            string mensaje = proxy.ModificarCliente(2,1, "Juan Luis", "Perez", "Rodriguez", "12324212", "jperez@contoso.com", "2133212", 1);
            Cliente cliente = proxy.ObtenerCliente(2);

            Assert.AreEqual("Grabacion Exitosa", mensaje);
            Assert.IsNotNull(cliente);
            Assert.AreEqual("Perez", cliente.ApellidoPaterno);
        }
    }
}
