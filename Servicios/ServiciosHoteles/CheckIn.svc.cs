using ServiciosHoteles.Dominio;
using ServiciosHoteles.Persistencia;
using ServiciosHoteles.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using AutoMapper;
using System.Net;
using System.ServiceModel.Web;

namespace ServiciosHoteles
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "CheckIn" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select CheckIn.svc or CheckIn.svc.cs at the Solution Explorer and start debugging.
    public class CheckIn : ICheckIn
    {
        private ReservaDAO reservaDAO = null;

        private ReservaDAO ReservaDAO
        {
            get
            {
                if (reservaDAO == null)
                {
                    reservaDAO = new ReservaDAO();
                }

                return reservaDAO;
            }
        }
         
        public Reserva RegistrarCheckIn(Reserva reservaCheckIn)
        {
            try
            {
                if (reservaCheckIn.Estado != (int)EstadosReserva.Pendiente)
                {
                    throw new WebFaultException<string>(
                        "La Reserva debe tener estado Pendiente", HttpStatusCode.PreconditionFailed);
                }

                DateTime horaCheckIn = DateTime.Now;
                int hora = Int32.Parse(horaCheckIn.ToString("HH"));
               
                if(hora < 15){
                    throw new WebFaultException<string>(
                        "La hora minima para hacer checkin es 3:00 pm", HttpStatusCode.PreconditionFailed);
                }
                
                
                reservaCheckIn.FechaHoraCheckin = horaCheckIn;
                reservaCheckIn.Estado = (int)EstadosReserva.CheckedIn;

                Mapper.CreateMap<Reserva, ServicioReserva.Reserva>();
                Mapper.CreateMap<Cliente, ServicioReserva.Cliente>();
                Mapper.CreateMap<Pais, ServicioReserva.Pais>();
                Mapper.CreateMap<TipoDocumento, ServicioReserva.TipoDocumento>();
                Mapper.CreateMap<TipoHabitacion, ServicioReserva.TipoHabitacion>();
                Mapper.CreateMap<Habitacion, ServicioReserva.Habitacion>();
                Mapper.CreateMap<Pasajero, ServicioReserva.Pasajero>();
               
                ServicioReserva.Reserva reservaProxyAModificar = new ServicioReserva.Reserva();

                Mapper.Map(reservaCheckIn, reservaProxyAModificar);
                
                ServicioReserva.ReservasClient Reservaproxy = new ServicioReserva.ReservasClient();
                ServicioReserva.Reserva reservaProxyModificada = Reservaproxy.ModificarReserva(reservaProxyAModificar);

                Mapper.CreateMap<ServicioReserva.Reserva, Reserva>();
                Mapper.CreateMap<ServicioReserva.Cliente, Cliente>();
                Mapper.CreateMap<ServicioReserva.Pais, Pais>();
                Mapper.CreateMap<ServicioReserva.TipoDocumento, TipoDocumento>();
                Mapper.CreateMap<ServicioReserva.TipoHabitacion, TipoHabitacion>();
                Mapper.CreateMap<ServicioReserva.Habitacion, Habitacion>();
                
                Reserva reserva = new Reserva();
                Mapper.Map(reservaProxyModificada, reserva);

                ServicioCuenta.Cuenta cuenta = new ServicioCuenta.Cuenta()
                {
                    Reserva = new ServicioCuenta.Reserva() 
                    { 
                        IdReserva = reserva.IdReserva
                    },
                    Servicio = new ServicioCuenta.Servicio()
                    {
                        IdServicio = 1
                    },
                    Cantidad = 1,
                    CostoUnitario = (double)reserva.Habitacion.TipoHabitacion.Tarifa,
                    Total = (double) reserva.Habitacion.TipoHabitacion.Tarifa
                };

                ServicioCuenta.CuentasClient cuentaProxy = new ServicioCuenta.CuentasClient();
                cuentaProxy.CrearCuenta(cuenta);

                return reserva;
            }
            catch (FaultException ex)
            {
                throw ex;
            }
        }
    }
}
