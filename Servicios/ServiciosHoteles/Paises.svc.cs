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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Paises" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Paises.svc or Paises.svc.cs at the Solution Explorer and start debugging.
    public class Paises : IPaises
    {
        private PaisDAO paisDAO = null;
        private PaisDAO PaisDAO
        {
            get
            {
                if (paisDAO == null)
                {
                    paisDAO = new PaisDAO();
                }

                return paisDAO;
            }
        }
        public List<Pais> ListarPais()
        {
            return PaisDAO.Listar().ToList();
        }
    }
}
