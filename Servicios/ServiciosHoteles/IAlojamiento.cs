using ServiciosHoteles.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using ServiciosHoteles.Util;

namespace ServiciosHoteles
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IAlojamiento" in both code and config file together.
    [ServiceContract]
    public interface IAlojamiento
    {
        [OperationContract]
        List<Reserva> ReservarHabitacion( Constantes valor, Reserva reserva,int codigo );

        [OperationContract]
        List<Reserva> RegistrarCheckin();

        [OperationContract]
        List<Reserva> RegistrarCheckout();

        [OperationContract]
        void CancelarReserva();

        [OperationContract]
        bool ValidarCancelacion();


        [OperationContract]
        List<Reserva> ObtenerReserva(int codigo, string fechaChekIndel, string fechaChekInAl, string fechaChekOutdel, string fechaChekOutal);

    }
}
