using AutoMapper;
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
            //Regla de Negocio 1: La Reserva debe estar en estado CheckedIn
            if (reservaCheckedOut.Estado != (int)EstadosReserva.CheckedIn)
            {
                throw new WebFaultException<string>(
                    "La Reserva debe tener estado CheckedIn", HttpStatusCode.PreconditionFailed);
            }
            //Regla de Negocio 2: La Cuenta debe estar cerrada para poder registrar el CheckOut
            else if (reservaCheckedOut.EstadoCuenta == false)
            {
                throw new WebFaultException<string>(
                    "La Reserva debe tener la Cuenta Cerrada/Confirmada", HttpStatusCode.PreconditionFailed);
            }

            //Se actualiza la Reserva con los datos del CheckOut
            reservaCheckedOut.FechaHoraCheckout = DateTime.Now;
            reservaCheckedOut.Estado = (int)EstadosReserva.CheckedOut;

            ServicioReserva.ReservasClient proxy = new ServicioReserva.ReservasClient();
            Mapper.CreateMap<Reserva, ServicioReserva.Reserva>();
            Mapper.CreateMap<Cliente, ServicioReserva.Cliente>();
            Mapper.CreateMap<Habitacion, ServicioReserva.Habitacion>();

            ServicioReserva.Reserva reservaAModificar = new ServicioReserva.Reserva();
            Mapper.Map(reservaCheckedOut, reservaAModificar);
            ServicioReserva.Reserva reservaModificada = proxy.ModificarReserva(reservaAModificar);

            Mapper.CreateMap<ServicioReserva.Reserva, Reserva>();
            Mapper.CreateMap<ServicioReserva.Cliente, Cliente>();
            Mapper.CreateMap<ServicioReserva.Habitacion, Habitacion>();
            Reserva reservaRetorno = new Reserva();
            Mapper.Map(reservaModificada, reservaRetorno);

            //Se registra el Comprobante de Pago


            return reservaRetorno;
        }
    }
}
