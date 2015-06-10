
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiciosHoteles.Dominio;
using NHibernate;
using NHibernate.Criterion;

namespace ServiciosHoteles.Persistencia
{
    public class HabitacionDAO : BaseDAO<Habitacion, int>
    {


        public ICollection<Habitacion> Buscar(int codigo_habitacion)
        {
            using (ISession sesion = NHibernateHelper.ObtenerSesion())
            {
                ICriteria busqueda = sesion.CreateCriteria(typeof(Habitacion));

                return busqueda.List<Habitacion>();
            }
        }
    }
}