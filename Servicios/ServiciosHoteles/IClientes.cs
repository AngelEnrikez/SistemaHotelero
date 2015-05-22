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
        Cliente RegistrarCliente(string nombres, string apellidoPaterno, string apellidoMaterno, string dni, string telefono, string email);
        [OperationContract]
        Cliente ModificarCliente(int codigo, string nombres, string apellidoPaterno, string apellidoMaterno, string dni, string telefono, string email);
        [OperationContract]
        void EliminarCliente(int codigo);
        [OperationContract]
        Cliente ObtenerCliente(int codigo);
        [OperationContract]
        List<Cliente> ListarClientes();
    }
}
