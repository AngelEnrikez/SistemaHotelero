using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using ServiciosHoteles.Dominio;

namespace ServiciosHoteles
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IPasajeros" in both code and config file together.
    [ServiceContract]
    public interface IPasajeros
    {
        [OperationContract]
        Pasajero CrearPasajero(Pasajero pasajeroNuevo);
        [OperationContract]
        Pasajero ModificarPasajero(Pasajero pasajeroModificado);
        [OperationContract]
        void EliminarPasajero(Pasajero pasajeroEliminar);
        [OperationContract]
        Pasajero ObtenerPasajero(int codigo);
        [OperationContract]
        List<Pasajero> ListarPasajeros();
    }
}
