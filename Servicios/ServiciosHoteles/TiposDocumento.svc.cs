using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using ServiciosHoteles.Persistencia;

namespace ServiciosHoteles
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "TiposDocumento" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select TiposDocumento.svc or TiposDocumento.svc.cs at the Solution Explorer and start debugging.
    public class TiposDocumento : ITiposDocumento
    {
        private TipoDocumentoDAO tipoDocumentoDAO = null;
        private TipoDocumentoDAO TipoDocumentoDAO
        {
            get
            {
                if (tipoDocumentoDAO == null)
                {
                    tipoDocumentoDAO = new TipoDocumentoDAO();
                }

                return tipoDocumentoDAO;
            }
        }
        public List<Dominio.TipoDocumento> ListarTipoDocumento()
        {
            return TipoDocumentoDAO.Listar().ToList();
        }
    }
}
