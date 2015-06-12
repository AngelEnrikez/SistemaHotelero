using ServiciosHoteles.Dominio;
using ServiciosHoteles.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Data.SqlClient;


using System.Text;
using System.Messaging;

namespace ServiciosHoteles
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Reservas" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Reservas.svc or Reservas.svc.cs at the Solution Explorer and start debugging.
    public class Reservas : IReservas
    {
        private ClienteDAO clienteDAO = null;
        private ReservaDAO reservaDAO = null;
        private HabitacionDAO habitacionDAO = null;
        private PasajeroDAO pasajeroDAO = null;
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
        private PasajeroDAO PasajeroDAO
        {
            get
            {
                if (pasajeroDAO == null)
                {
                    pasajeroDAO = new PasajeroDAO();
                }

                return pasajeroDAO;
            }
        }

        public Reserva RegistrarReserva(Reserva reservaACrear)
        {
            Reserva reservaCola = new Reserva();
            Reserva reservaCreado = null;
            try
            {
                reservaCola = reservaACrear;

                foreach (Pasajero pa in reservaCola.Pasajero) {
                    pa.Reserva = null;
                }

                if (reservaACrear.CodFormaPago != "EF" && reservaACrear.NumeroTarjeta == "")
                {
                    throw new FaultException("Debe Ingresar el número de tarjeta para el tipo de tarjeta ");
                }
                reservaACrear.Estado = 0;
                reservaACrear.EstadoCuenta = false;
                //Cliente ClienteExistente = ClienteDAO.Obtener(reservaACrear.Cliente.IdCliente);
                //Habitacion tipoDocumentoExistente = HabitacionDAO.Obtener(reservaACrear.Habitacion.IdHabitacion);   

                Pasajeros objPasajero = new Pasajeros();
                IList<Pasajero> pasajeross = reservaACrear.Pasajero;
                reservaACrear.Pasajero = null;

                reservaCreado = ReservaDAO.Crear(reservaACrear);

                if (pasajeross != null)
                {
                    foreach (Pasajero pasajero in pasajeross)
                    {
                        pasajero.Reserva = new Reserva() { IdReserva = reservaACrear.IdReserva };
                        objPasajero.CrearPasajero(pasajero);
                    }
                }

            }
            catch (FaultException ex) { throw ex; }
            catch (Exception e)
            {
                if (e.InnerException != null)
                    if (e.InnerException.GetType() == typeof(SqlException))
                    {
                        string rutaCola = @".\private$\Reservas";
                        if (!MessageQueue.Exists(rutaCola))
                        {
                            MessageQueue.Create(rutaCola);
                        }
                        MessageQueue cola = new MessageQueue(rutaCola);
                        Message mensaje = new Message();
                        mensaje.Recoverable = true;
                        cola.Formatter = new BinaryMessageFormatter();


                        mensaje.Label = "Reservas-Pasajeros";
                        mensaje.Body = reservaCola;

                        mensaje.Formatter = new BinaryMessageFormatter();

                        cola.Send(mensaje);                  
                    }
                throw new Exception(e.InnerException.Message + "</br>" + "Se envió un mensaje con la reserva creada.");
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
                //Cliente ClienteExistente = ClienteDAO.Obtener(reservaAModificar.Cliente.IdCliente);
                //Habitacion tipoDocumentoExistente = HabitacionDAO.Obtener(reservaAModificar.Habitacion.IdHabitacion);

                Pasajeros objPasajero = new Pasajeros();
                IList<Pasajero> pasajeross = reservaAModificar.Pasajero;
                reservaAModificar.Pasajero = null;

                if (pasajeross != null)
                {
                    foreach (Pasajero pasajeroeliminar in objPasajero.ListarPasajeros().Where(h => h.Reserva.IdReserva == reservaAModificar.IdReserva).Select(g => new Pasajero { IdPasajero = g.IdPasajero }).ToList())
                    {
                        pasajeroeliminar.Reserva = null;
                        objPasajero.EliminarPasajero(pasajeroeliminar);
                    }
                }

                reservaModificado = ReservaDAO.Modificar(reservaAModificar);


                if (pasajeross != null)
                {
                    foreach (Pasajero pasajeromodificar in pasajeross)
                    {
                        pasajeromodificar.Reserva = new Reserva() { IdReserva = reservaAModificar.IdReserva };
                        objPasajero.CrearPasajero(pasajeromodificar);
                    }
                }


            }
            catch (FaultException ex) { throw ex; }
            return reservaModificado;
        }

        public Reserva ObtenerReserva(int codigo)
        {
            Reserva x;
            try
            {
                x = ReservaDAO.Obtener(codigo);
                x = new Reserva()
                {
                    IdReserva = x.IdReserva,
                    Cliente = x.Cliente,
                    CodFormaPago = x.CodFormaPago,
                    Habitacion = x.Habitacion,
                    Pasajero = x.Pasajero.Select(pas => new Pasajero
                    {
                        IdPasajero = pas.IdPasajero,
                        NombrePasajero = pas.NombrePasajero,
                        ApellidoPaterno = pas.ApellidoPaterno,
                        ApellidoMaterno = pas.ApellidoMaterno
                    }).ToList(),
                    FechaLlegada = x.FechaLlegada,
                    FechaSalida = x.FechaSalida,
                    FechaHoraCheckin = x.FechaHoraCheckin,
                    ComentarioCheckin = x.ComentarioCheckin,
                    FechaHoraCheckout = x.FechaHoraCheckout,
                    ComentarioCheckout = x.ComentarioCheckout,
                    NumeroTarjeta = x.NumeroTarjeta,
                    MesExpiraTarjeta = x.MesExpiraTarjeta,
                    AnioExpiraTarjeta = x.AnioExpiraTarjeta,
                    RequerimientosEsp = x.RequerimientosEsp,
                    Observaciones = x.Observaciones,
                    EstadoCuenta = x.EstadoCuenta,
                    Estado = x.Estado

                };
            }
            catch (FaultException ex)
            {
                throw ex;
            }
            return x;
        }

        public List<Reserva> ListaReserva()
        {
            try
            {          
                return ReservaDAO.Listar().Select(x => new Reserva
                {
                    IdReserva = x.IdReserva,
                    Cliente = x.Cliente,
                    CodFormaPago = x.CodFormaPago,
                    Habitacion = x.Habitacion,
                    Pasajero = x.Pasajero.Select(pas => new Pasajero
                    {
                        IdPasajero = pas.IdPasajero,
                        NombrePasajero = pas.NombrePasajero,
                        ApellidoPaterno = pas.ApellidoPaterno,
                        ApellidoMaterno = pas.ApellidoMaterno
                    }).ToList(),
                    FechaLlegada = x.FechaLlegada,
                    FechaSalida = x.FechaSalida,
                    FechaHoraCheckin = x.FechaHoraCheckin,
                    ComentarioCheckin = x.ComentarioCheckin,
                    FechaHoraCheckout = x.FechaHoraCheckout,
                    ComentarioCheckout = x.ComentarioCheckout,
                    NumeroTarjeta = x.NumeroTarjeta,
                    MesExpiraTarjeta = x.MesExpiraTarjeta,
                    AnioExpiraTarjeta = x.AnioExpiraTarjeta,
                    RequerimientosEsp = x.RequerimientosEsp,
                    Observaciones = x.Observaciones,
                    EstadoCuenta = x.EstadoCuenta,
                    Estado = x.Estado
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
