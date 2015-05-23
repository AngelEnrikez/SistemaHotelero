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
        public ICollection<Cliente> Buscar(Cliente cliente)
        {
            using (ISession sesion = NHibernateHelper.ObtenerSesion())
            {
                ICriteria busqueda = sesion.CreateCriteria(typeof(Cliente));
                if (cliente.Nombre != null && cliente.Nombre.Trim().Length > 0)
                {
                    busqueda.Add(Restrictions.Like("Nombre", cliente.Nombre, MatchMode.Anywhere)); 
                }
                if (cliente.NumeroDocumento != null && cliente.NumeroDocumento.Trim().Length > 0)
                {
                    busqueda.Add(Restrictions.Like("NumeroDocumento", cliente.NumeroDocumento, MatchMode.Start));
                }
                
                return busqueda.List<Cliente>();
            }
        }
    }
}