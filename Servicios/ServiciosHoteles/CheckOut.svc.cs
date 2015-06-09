using ServiciosHoteles.Dominio;
using ServiciosHoteles.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace ServiciosHoteles
{
    public class CheckOut : ICheckOut
    {
        public Reserva RegistrarCheckOut(Reserva reservaCheckedOut)
        {
            //Regla de Negocio: La Reserva debe estar en estado CheckedIn
            if (reservaCheckedOut.Estado != (int)EstadosReserva.CheckedIn)
            {
                throw new WebFaultException<string>(
                    "La Reserva debe tener estado CheckedIn", HttpStatusCode.PreconditionFailed);
            }
            //Regla de Negocio: La Cuenta debe estar cerrada para poder registrar el CheckOut
            else if (reservaCheckedOut.EstadoCuenta == false)
            {
                throw new WebFaultException<string>(
                    "La Reserva debe tener la Cuenta Cerrada/Confirmada", HttpStatusCode.PreconditionFailed);
            }

            reservaCheckedOut.FechaHoraCheckout = DateTime.Now;
            reservaCheckedOut.Estado = (int)EstadosReserva.CheckedOut;
            //WSReservas.ReservasClient proxy = new WSReservas.ReservasClient();
            //return proxy.ModificarReserva(reservaCheckedOut);
            IReservas reserva = new Reservas();
            return reserva.ModificarReserva(reservaCheckedOut);
        }
    }
}
