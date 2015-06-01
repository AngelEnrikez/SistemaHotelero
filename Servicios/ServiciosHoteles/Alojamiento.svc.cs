using ServiciosHoteles.Dominio;
using ServiciosHoteles.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ServiciosHoteles
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Alojamiento" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Alojamiento.svc or Alojamiento.svc.cs at the Solution Explorer and start debugging.
    public class Alojamiento : IAlojamiento
    {
        public List<Reserva> ReservarHabitacion( Constantes valor, Reserva reserva,int codigo )
        {
            List<Reserva> lista = new List<Reserva>();
            IReservas reservaServicio = new Reservas();

            try
            {
                if (valor == Constantes.Crear)
                {
                    lista.Add(reservaServicio.RegistrarReserva(reserva));
                }
                else if (valor == Constantes.Modificar)
                {
                    lista.Add(reservaServicio.ModificarReserva(reserva));
                }
                else if (valor == Constantes.Listar)
                {
                    lista = reservaServicio.ListaReserva();
                }
            }
            catch (FaultException ex) { throw ex; }
            return lista;
        }

        public List<Reserva> RegistrarCheckin()
        {
            throw new NotImplementedException();
        }

        public List<Reserva> RegistrarCheckout()
        {
            throw new NotImplementedException();
        }

        public void CancelarReserva()
        {
            throw new NotImplementedException();
        }

        public bool ValidarCancelacion()
        {
            throw new NotImplementedException();
        }
    }
}
