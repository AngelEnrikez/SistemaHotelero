using ServiciosHoteles.Dominio;
using ServiciosHoteles.Persistencia;
using ServiciosHoteles.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

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
                reservaCheckIn.FechaHoraCheckin = DateTime.Now;
                reservaCheckIn.Estado = (int)EstadosReserva.CheckedIn;

                ServicioReserva.Reserva reservaProxyAModificar = new ServicioReserva.Reserva()
                {
                    IdReserva = reservaCheckIn.IdReserva,
                    Cliente = new ServicioReserva.Cliente()
                    {
                        IdCliente = reservaCheckIn.Cliente.IdCliente
                    },
                    Habitacion = new ServicioReserva.Habitacion() { 
                        IdHabitacion = reservaCheckIn.Habitacion.IdHabitacion
                    },
                    FechaLlegada = reservaCheckIn.FechaLlegada,
                    FechaHoraCheckin = reservaCheckIn.FechaHoraCheckin,
                    ComentarioCheckin = reservaCheckIn.ComentarioCheckin,
                    CodFormaPago = reservaCheckIn.CodFormaPago,
                    Estado = reservaCheckIn.Estado
                };

                
                ServicioReserva.ReservasClient proxy = new ServicioReserva.ReservasClient();
                ServicioReserva.Reserva reservaProxyModificada = proxy.ModificarReserva(reservaProxyAModificar);

                Reserva reserva = new Reserva() {
                    IdReserva = reservaProxyModificada.IdReserva,
                    Cliente = new Cliente()
                    {
                        IdCliente = reservaProxyModificada.Cliente.IdCliente
                    },
                    Habitacion = new Habitacion()
                    {
                        IdHabitacion = reservaProxyModificada.Habitacion.IdHabitacion
                    },
                    FechaLlegada = reservaProxyModificada.FechaLlegada,
                    FechaHoraCheckin = reservaProxyModificada.FechaHoraCheckin,
                    ComentarioCheckin = reservaProxyModificada.ComentarioCheckin,
                    CodFormaPago = reservaProxyModificada.CodFormaPago,
                    Estado = reservaProxyModificada.Estado
                };
                
                return reserva;
            }
            catch (FaultException ex)
            {
                throw ex;
            }
        }
    }
}
