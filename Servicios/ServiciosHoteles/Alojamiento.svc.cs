using ServiciosHoteles.Dominio;
using ServiciosHoteles.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Messaging;
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

        //obtener reserva 
        public List<Reserva> ObtenerReserva(int codigo, string fechaChekIndel, string fechaChekInAl, string fechaChekOutdel, string fechaChekOutal)
        {
            List<Reserva> lista = new List<Reserva>();
            IReservas reservaServicio = new Reservas();

            lista = reservaServicio.ListaReserva();

            if (lista.Count > 0)
            {

                if (codigo > 0)
                {
                    lista = lista.FindAll(delegate(Reserva r) { return r.IdReserva == codigo; });
                }

                if (fechaChekIndel != "")
                {
                    lista = lista.FindAll(delegate(Reserva r) { return r.FechaHoraCheckin >= Convert.ToDateTime(fechaChekIndel); });
                }

                if (fechaChekInAl != "")
                {
                    lista = lista.FindAll(delegate(Reserva r) { return r.FechaHoraCheckin <= Convert.ToDateTime(fechaChekInAl); });
                }

                if (fechaChekOutdel != "")
                {
                    lista = lista.FindAll(delegate(Reserva r) { return r.FechaHoraCheckout >= Convert.ToDateTime(fechaChekOutdel); });
                }

                if (fechaChekOutal != "")
                {
                    lista = lista.FindAll(delegate(Reserva r) { return r.FechaHoraCheckout >= Convert.ToDateTime(fechaChekOutal); });
                }



                string rutaCola = @".\private$\Reservas";
                if (!MessageQueue.Exists(rutaCola))
                    {
                    MessageQueue.Create(rutaCola);

                    }

                    List<Reserva> listadoReserva = new List<Reserva>();
                    MessageQueue colaRecibe = new MessageQueue(rutaCola);
                    colaRecibe.Formatter = new BinaryMessageFormatter();
                    colaRecibe.MessageReadPropertyFilter.SetAll();

                  //foreach (Message ms in colaRecibe.GetAllMessages())
                  //  { 
                   
                  //  Message mensaje = colaRecibe.Receive();
                  //  mensaje.Formatter = new BinaryMessageFormatter();
                  //  listadoReserva.Add((Reserva)mensaje.Body);
                  //  }


                 // recorrer la lista de la cola recibida 
                 int cantidad = colaRecibe.GetAllMessages().Count();

                  for (int i = 0; i < listadoReserva.Count; i++)
                  {

                    
                      Message mensaje = colaRecibe.Receive();
                      mensaje.Formatter = new BinaryMessageFormatter();
                      Reserva pedido = (Reserva)mensaje.Body;
                      reservaServicio.RegistrarReserva(pedido);         

                  }

            }

            return lista;

        }
    }
}
