using ServiciosHoteles.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ServiciosHoteles
{
    [ServiceContract]
    public interface IComprobantes
    {
        [OperationContract]
        Comprobante CrearComprobante(Comprobante comprobanteNuevo);
        [OperationContract]
        Comprobante ObtenerComprobante(int idComprobante);
    }
}
