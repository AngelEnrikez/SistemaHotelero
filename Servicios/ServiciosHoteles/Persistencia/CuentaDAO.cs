using NHibernate;
using NHibernate.Criterion;
using ServiciosHoteles.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiciosHoteles.Persistencia
{
    public class CuentaDAO : BaseDAO<Cuenta, int>
    {
        public ICollection<Cuenta> Buscar(int idReserva)
        {
            using (ISession sesion = NHibernateHelper.ObtenerSesion())
            {
                ICriteria busqueda = sesion.CreateCriteria(typeof(Cuenta));
                if (idReserva != null && idReserva > 0)
                {
                    busqueda.Add(Restrictions.Eq("Reserva", new Reserva() { IdReserva = idReserva }));
                }

                return busqueda.List<Cuenta>();
            }
        }
    }
}