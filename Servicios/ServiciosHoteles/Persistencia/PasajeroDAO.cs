using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiciosHoteles.Dominio;
using NHibernate;
using NHibernate.Criterion;

namespace ServiciosHoteles.Persistencia
{
    public class PasajeroDAO : BaseDAO<Pasajero, int>
    {
    }
}