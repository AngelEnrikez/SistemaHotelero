
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiciosHoteles.Dominio;
using NHibernate;
using NHibernate.Criterion;

namespace ServiciosHoteles.Persistencia
{
    public class ReservaDAO : BaseDAO<Reserva, int>
    {
        public ICollection<Reserva> Buscar(int codigo_reserva)
        {
            using (ISession sesion = NHibernateHelper.ObtenerSesion())
            {
                ICriteria busqueda = sesion.CreateCriteria(typeof(Reserva));
               
                return busqueda.List<Reserva>();
            }
        }
    }
}