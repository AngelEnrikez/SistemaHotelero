using ServiciosHoteles.Dominio;
using ServiciosHoteles.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
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
                Cliente ClienteExistente = ClienteDAO.Obtener(reservaACrear.Cliente.IdCliente);
                Habitacion tipoDocumentoExistente = HabitacionDAO.Obtener(reservaACrear.Habitacion.IdHabitacion);

                reservaCreado = ReservaDAO.Crear(reservaACrear);
            }
            catch (FaultException ex) { throw ex; }
            return reservaCreado;
        }

        public Reserva ModificarReserva(Reserva reservaAModificar)
        {
            Reserva reservaModificado = null;
            try
            {
                Cliente ClienteExistente = ClienteDAO.Obtener(reservaAModificar.Cliente.IdCliente);
                Habitacion tipoDocumentoExistente = HabitacionDAO.Obtener(reservaAModificar.Habitacion.IdHabitacion);

                reservaModificado = ReservaDAO.Crear(reservaAModificar);
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
                return ReservaDAO.Listar().ToList();
            }
            catch (FaultException ex)
            {
                throw ex;
            }
        }

        public List<Reserva> BuscarClientes(Cliente cliente, Habitacion habitacion)
        {
            throw new NotImplementedException();
        }
    }
}
