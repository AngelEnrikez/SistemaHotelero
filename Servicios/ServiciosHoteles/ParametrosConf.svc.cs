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
    public class ParametrosConf : IParametrosConf
    {
        private ParametroDAO parametroDAO = null;
        private ParametroDAO ParametroDAO
        {
            get
            {
                if (parametroDAO == null)
                    parametroDAO = new ParametroDAO();
                return parametroDAO;
            }
        }
        public Parametro ModificarParametro(Parametro parametroAModificar)
        {
            return ParametroDAO.Modificar(parametroAModificar);
        }

        public Parametro ObtenerParametro(int idParametro)
        {
            return ParametroDAO.Obtener(idParametro);
        }

        public List<Parametro> ListarParametros()
        {
            return ParametroDAO.Listar().ToList();
        }
    }
}
