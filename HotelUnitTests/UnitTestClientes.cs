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
            ServicioClientes.TipoDocumento tipoDocumento = new ServicioClientes.TipoDocumento();
            ServicioClientes.Pais pais = new ServicioClientes.Pais();
            ServicioClientes.Cliente clienteNuevo = new Cliente();
            ServicioClientes.ClientesClient proxy = new ServicioClientes.ClientesClient();

            clienteNuevo.Nombre = "Juan Luis";
            clienteNuevo.ApellidoPaterno = "Perez";
            clienteNuevo.ApellidoMaterno = "Rodriguez";
            clienteNuevo.Telefono = "12324212";
            tipoDocumento.IdTipoDocumento = 1;
            clienteNuevo.TipoDocumento = tipoDocumento;
            clienteNuevo.NumeroDocumento = "2133212";
            clienteNuevo.Email = "jperez@contoso.com";
            pais.IdPais = 1;
            clienteNuevo.Pais = pais;

            Cliente cliente = proxy.CrearCliente(clienteNuevo);
            Assert.IsNotNull(clienteNuevo);
        }

        [TestMethod]
        public void TestModificarCliente()
        {
            ServicioClientes.TipoDocumento tipoDocumento = new ServicioClientes.TipoDocumento();
            ServicioClientes.Pais pais = new ServicioClientes.Pais();
            ServicioClientes.Cliente clientModificado = new Cliente();
            ServicioClientes.ClientesClient proxy = new ServicioClientes.ClientesClient();

            clientModificado.IdCliente = 1;
            clientModificado.Nombre = "Juan Luis";
            clientModificado.ApellidoPaterno = "Perez";
            clientModificado.ApellidoMaterno = "Rodriguez";
            clientModificado.Telefono = "12324212";
            tipoDocumento.IdTipoDocumento = 1;
            clientModificado.TipoDocumento = tipoDocumento;
            clientModificado.NumeroDocumento = "423123123";
            clientModificado.Email = "jperez@contoso.com";
            pais.IdPais = 1;
            clientModificado.Pais = pais;
            Cliente cliente = proxy.ModificarCliente(clientModificado);

            Assert.IsNotNull(cliente);
            Assert.AreEqual("423123123", cliente.NumeroDocumento);
        }


        [TestMethod]
        public void TestObtenerCliente()
        {
            ServicioClientes.ClientesClient proxy = new ServicioClientes.ClientesClient();
            Cliente cliente = proxy.ObtenerCliente(1);
            Assert.IsNotNull(cliente);
        }

        [TestMethod]
        public void TestEliminarCliente()
        {
            ServicioClientes.Cliente clientEliminado = new Cliente();
            ServicioClientes.ClientesClient proxy = new ServicioClientes.ClientesClient();

            clientEliminado.IdCliente = 1;
            proxy.EliminarCliente(clientEliminado);
            Cliente cliente = proxy.ObtenerCliente(2);

            Assert.IsNull(cliente);
        }

    }
}
