using ServiciosHoteles.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace ServiciosHoteles
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ICheckIn" in both code and config file together.
    [ServiceContract]
    public interface ICheckIn
    {
        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "CheckIn", ResponseFormat = WebMessageFormat.Json)]
        Reserva RegistrarCheckIn(Reserva reserva);
    }
}
