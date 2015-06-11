using ServiciosHoteles.Dominio;
using ServiciosHoteles.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Data.SqlClient;


using System.Text;

namespace ServiciosHoteles
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Reservas" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Reservas.svc or Reservas.svc.cs at the Solution Explorer and start debugging.
    public class Reservas : IReservas
    {
        private ClienteDAO clienteDAO = null;
        private ReservaDAO reservaDAO = null;
        private HabitacionDAO habitacionDAO = null;
        private HabitacionDAO HabitacionDAO
        {
            get
            {
                if (habitacionDAO == null)
                {
                    habitacionDAO = new HabitacionDAO();
                }

                return habitacionDAO;
            }
        }
        private ClienteDAO ClienteDAO
        {
            get
            {
                if (clienteDAO == null)
                {
                    clienteDAO = new ClienteDAO();
                }

                return clienteDAO;
            }
        }
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

        public Reserva RegistrarReserva(Reserva reservaACrear)
        {
            Reserva reservaCreado = null;
            try
            {
                if (reservaACrear.CodFormaPago != "EF" && reservaACrear.NumeroTarjeta == "")
                {
                    throw new FaultException("Debe Ingresar el número de tarjeta para el tipo de tarjeta ");
                }
                reservaACrear.Estado = 0;
                reservaACrear.EstadoCuenta = false;
                Cliente ClienteExistente = ClienteDAO.Obtener(reservaACrear.Cliente.IdCliente);
                Habitacion tipoDocumentoExistente = HabitacionDAO.Obtener(reservaACrear.Habitacion.IdHabitacion);

                reservaCreado = ReservaDAO.Crear(reservaACrear);
            }
            catch (FaultException ex) { throw ex; }
            catch (Exception e)
            {
                if (e.InnerException != null)
                    if (e.InnerException.GetType() == typeof(SqlException)) {

                        throw e.InnerException; 
                    }

            }
            return reservaCreado;
        }

        public Reserva ModificarReserva(Reserva reservaAModificar)
        {
            Reserva reservaModificado = null;
            try
            {
                if (reservaAModificar.CodFormaPago != "EF" && reservaAModificar.NumeroTarjeta == "")
                {
                    throw new FaultException("Debe Ingresar el número de tarjeta para el tipo de tarjeta ");
                }
                //reservaAModificar.Estado = 0;
                //reservaAModificar.EstadoCuenta = false;
                Cliente ClienteExistente = ClienteDAO.Obtener(reservaAModificar.Cliente.IdCliente);
                Habitacion tipoDocumentoExistente = HabitacionDAO.Obtener(reservaAModificar.Habitacion.IdHabitacion);

                reservaModificado = ReservaDAO.Modificar(reservaAModificar);
            }
            catch (FaultException ex) { throw ex; }
            return reservaModificado;
        }

        public Reserva ObtenerReserva(int codigo)
        {
            try
            {
                return ReservaDAO.Obtener(codigo);
            }
            catch (FaultException ex)
            {
                throw ex;
            }
        }

        public List<Reserva> ListaReserva()
        {
            try
            {
                return ReservaDAO.Listar().Select(x => new Reserva
                {
                    IdReserva = x.IdReserva,
                    Cliente=x.Cliente,
                    CodFormaPago = x.CodFormaPago,
                    Habitacion=x.Habitacion,
                    Pasajero = x.Pasajero.Select(pas => new Pasajero
                    {
                        IdPasajero = pas.IdPasajero,
                        NombrePasajero=pas.NombrePasajero,
                        ApellidoPaterno=pas.ApellidoPaterno,
                        ApellidoMaterno=pas.ApellidoMaterno
                    }).ToList(),
                    FechaLlegada=x.FechaLlegada,
                    FechaSalida=x.FechaSalida,
                    FechaHoraCheckin=x.FechaHoraCheckin,
                    ComentarioCheckin=x.ComentarioCheckin,
                    FechaHoraCheckout=x.FechaHoraCheckout,
                    ComentarioCheckout=x.ComentarioCheckout,
                    NumeroTarjeta=x.NumeroTarjeta,
                    MesExpiraTarjeta=x.MesExpiraTarjeta,
                    AnioExpiraTarjeta=x.AnioExpiraTarjeta,
                    RequerimientosEsp=x.RequerimientosEsp,
                    Observaciones=x.Observaciones,
                    EstadoCuenta=x.EstadoCuenta,
                    Estado=x.Estado
                }).ToList();
            }
            catch (FaultException ex)
            {
                throw ex;
            }
        }

        // buscar reserva 
        public List<Reserva> BuscarReserva(int codigo_reserva)
        {

            try
            {
                return ReservaDAO.Buscar(codigo_reserva).ToList();
            }
            catch (FaultException ex)
            {
                throw ex;
            }



        }
    }
}
