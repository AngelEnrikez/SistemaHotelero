using ServiciosHoteles.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ServiciosHoteles
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IReservas" in both code and config file together.
    [ServiceContract]
    public interface IReservas
    {
        [OperationContract]
        Reserva RegistrarReserva(Reserva reservaACrear);
        [OperationContract]
        Reserva ModificarReserva(Reserva reservaAModificar);        
        [OperationContract]
        Reserva ObtenerReserva(int codigo);
        [OperationContract]
        List<Reserva> ListaReserva();
        [OperationContract]
        List<Reserva> BuscarClientes(Cliente cliente, Habitacion habitacion);

    }
}
