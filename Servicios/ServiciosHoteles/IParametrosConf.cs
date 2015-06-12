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
    public interface IParametrosConf
    {
        [OperationContract]
        Parametro ModificarParametro(Parametro parametroAModificar);
        [OperationContract]
        Parametro ObtenerParametro(int idParametro);
        [OperationContract]
        List<Parametro> ListarParametros();
    }
}
