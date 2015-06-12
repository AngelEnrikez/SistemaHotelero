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
    [ServiceContract]
    public interface ICheckOut
    {
        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "CheckOut", ResponseFormat = WebMessageFormat.Json)]
        Reserva RegistrarCheckOut(Reserva reservaCheckedOut);
    }
}
