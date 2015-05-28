using ServiciosHoteles.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ServiciosHoteles
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IClientes" in both code and config file together.
    [ServiceContract]
    public interface IClientes
    {
        [OperationContract]
        Cliente CrearCliente(Cliente clienteNuevo);
        [OperationContract]
        Cliente ModificarCliente(Cliente clienteModificado);
        [OperationContract]
        void EliminarCliente(Cliente clienteEliminar);
        [OperationContract]
        Cliente ObtenerCliente(int codigo);
        [OperationContract]
        List<Cliente> ListarClientes();
        [OperationContract]
        List<Cliente> BuscarClientes(Cliente clienteABuscar);
    }
}
