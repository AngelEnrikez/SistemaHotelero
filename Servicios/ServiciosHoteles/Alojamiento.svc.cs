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
                else if (valor == Constantes.Obtener)
                {
                    lista.Add(reservaServicio.ObtenerReserva(codigo) );
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
