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
         
        public void RegistrarCheckIn(Reserva reserva)
        {
            Reserva reservaModificada = null;
            try
            {
                reservaModificada = ReservaDAO.Modificar(reserva);
            }
            catch (FaultException ex)
            {
                throw ex;
            }
        }
    }
}
