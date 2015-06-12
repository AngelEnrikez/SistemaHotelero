using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace ServiciosHoteles.Dominio
{
    [DataContract]
    [Serializable]
    public class Pais
    {
        [DataMember]
        public int IdPais { get; set; }
        [DataMember]
        public string  NombrePais { get; set; }
    }
}