using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ServiciosHoteles
{
    [ServiceContract]
    public interface ICheckOut
    {
        [OperationContract]
        string RegistrarCheckOut(int idReserva, string comentario);
    }
}
