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
    public class Comprobantes : IComprobantes
    {
        private ComprobanteDAO comprobanteDAO = null;
        private ComprobanteDAO ComprobanteDAO
        {
            get
            {
                if (comprobanteDAO == null)
                    comprobanteDAO = new ComprobanteDAO();
                return comprobanteDAO;
            }
        }
        public Comprobante CrearComprobante(Comprobante comprobanteNuevo)
        {
            return ComprobanteDAO.Crear(comprobanteNuevo);
        }

        public Comprobante ObtenerComprobante(int idComprobante)
        {
            return ComprobanteDAO.Obtener(idComprobante);
        }
    }
}
