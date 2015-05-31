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
        public int idConfiguracion { get; set; }
        [DataMember]
        public string claveConfig { get; set; }
        [DataMember]
        public string valorConfig { get; set; }

    }
}