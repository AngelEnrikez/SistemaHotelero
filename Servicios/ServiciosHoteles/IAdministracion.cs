using ServiciosHoteles.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using ServiciosHoteles.Util;

namespace ServiciosHoteles
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IAdministracion" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IAdministracion
    {
        [OperationContract]
        List<Cliente> AdminClientes(Constantes valor, Cliente cliente );

        [OperationContract]
        List<TipoDocumento> AdminTDocumentos();

        [OperationContract]
        List<Habitacion> AdminHabitaciones();

        [OperationContract]
        List<TipoHabitacion> AdminTHabitaciones();

        [OperationContract]
        List<Pais> AdminPaises();

        [OperationContract]
        List<Servicio> AdminServicios();

        [OperationContract]
        List<Parametro> AdminParametros();


    }
}
