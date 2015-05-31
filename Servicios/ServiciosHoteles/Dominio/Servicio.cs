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
        public int IdServicio { get; set; }

        [DataMember]
        public string Descripcion { get; set; }

        [DataMember]
        public decimal Tarifa { get; set; }
    }
}