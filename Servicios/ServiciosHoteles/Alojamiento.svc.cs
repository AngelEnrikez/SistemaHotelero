using ServiciosHoteles.Dominio;
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

        public List<Reserva> ReservarHabitacion()
        {
            throw new NotImplementedException();
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
