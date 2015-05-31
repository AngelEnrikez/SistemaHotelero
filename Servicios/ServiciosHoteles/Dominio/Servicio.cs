using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace ServiciosHoteles.Dominio
{

    [DataContract]
    public class Servicio
    {

        [DataMember]
        public int idServicio { get; set; }

        [DataMember]
        public string descripcion { get; set; }

        [DataMember]
        public decimal tarifa { get; set; }
    }
}