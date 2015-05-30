using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiciosHoteles.Dominio;
using NHibernate;
using NHibernate.Criterion;

namespace ServiciosHoteles.Persistencia
{
    public class ClienteDAO : BaseDAO<Cliente, int>
    {
        public ICollection<Cliente> Buscar(string nombre, string numeroDocumento)
        {
            using (ISession sesion = NHibernateHelper.ObtenerSesion())
            {
                ICriteria busqueda = sesion.CreateCriteria(typeof(Cliente));
                if (nombre != null && nombre.Trim().Length > 0)
                {
                    busqueda.Add(Restrictions.Like("Nombre", nombre, MatchMode.Anywhere)); 
                }
                if (numeroDocumento != null && numeroDocumento.Trim().Length > 0)
                {
                    busqueda.Add(Restrictions.Like("NumeroDocumento", numeroDocumento, MatchMode.Start));
                }
                
                return busqueda.List<Cliente>();
            }
        }
    }
}