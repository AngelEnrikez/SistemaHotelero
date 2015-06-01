using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace ServiciosHoteles.Util
{

    [DataContract]
    public enum Constantes
    {
        [EnumMember]
        Crear,
        [EnumMember]
        Modificar,
        [EnumMember]
        Eliminar,
        [EnumMember]
        Listar,
        [EnumMember]
        Obtener
    }

}