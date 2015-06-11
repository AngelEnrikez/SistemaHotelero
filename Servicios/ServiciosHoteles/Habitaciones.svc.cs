using ServiciosHoteles.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using ServiciosHoteles.Persistencia;
using ServiciosHoteles.Util;

namespace ServiciosHoteles
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Habitaciones" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Habitaciones.svc or Habitaciones.svc.cs at the Solution Explorer and start debugging.
    public class Habitaciones : IHabitaciones
    {
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

        public List<Habitacion> ListarHabitacion()
        {
            return HabitacionDAO.Listar().ToList();
        }
    }
}
