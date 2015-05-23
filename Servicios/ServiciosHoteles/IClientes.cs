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
        Cliente CrearCliente(int idTipoDocumento, string nombres, string apellidoPaterno, string apellidoMaterno, string numeroDocumento, string email, string telefono,int idPais);
        [OperationContract]
        Cliente ModificarCliente(int idCliente, int idTipoDocumento, string nombres, string apellidoPaterno, string apellidoMaterno, string numeroDocumento, string email, string telefono, int idPais);
        [OperationContract]
        void EliminarCliente(int codigo);
        [OperationContract]
        Cliente ObtenerCliente(int codigo);
        [OperationContract]
        List<Cliente> ListarClientes();
        [OperationContract]
        List<Cliente> ListarClientes(string nombre, string numeroDocumento);
    }
}
