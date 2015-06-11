using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiciosHoteles.Dominio;
using NHibernate;
using NHibernate.Criterion;

namespace ServiciosHoteles.Persistencia
{
    public class PaisDAO : BaseDAO<Pais, int>
    {

        public ICollection<Pais> Buscar(int codigo_pais)
        {
            using (ISession sesion = NHibernateHelper.ObtenerSesion())
            {
                ICriteria busqueda = sesion.CreateCriteria(typeof(Pais));

                return busqueda.List<Pais>();
            }
        }
    }
}