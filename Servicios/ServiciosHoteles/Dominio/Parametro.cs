using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace ServiciosHoteles.Dominio
{
    [DataContract]
    public class Parametro
    {
        [DataMember]
        public int IdConfiguracion { get; set; }
        [DataMember]
        public string ClaveConfig { get; set; }
        [DataMember]
        public string ValorConfig { get; set; }

    }
}