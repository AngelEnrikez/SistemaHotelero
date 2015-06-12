using ServiciosHoteles.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ServiciosHoteles
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ICuentas" in both code and config file together.
    [ServiceContract]
    public interface ICuentas
    {
        [OperationContract]
        Cuenta CrearCuenta(Cuenta cuentaNueva);
        [OperationContract]
        Cuenta ModificarCuenta(Cuenta cuentaModificada);
        [OperationContract]
        void EliminarCuenta(Cuenta cuentaEliminar);
        [OperationContract]
        Cuenta ObtenerCuenta(int codigo);
        [OperationContract]
        List<Cuenta> ListarCuentas();
    }
}
