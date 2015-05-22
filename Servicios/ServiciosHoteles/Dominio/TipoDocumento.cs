using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace ServiciosHoteles.Dominio
{
    [DataContract]
    public class TipoDocumento
    {
        [DataMember]
        public int IdTipoDocumento { get; set; }
        [DataMember]
        public string Descripcion { get; set; }
    }
}