using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace ServiciosHoteles.Dominio
{
    [DataContract]
    public class Pasajero
    {
        [DataMember]
        public int IdPasajero { get; set; }
        [DataMember]
        public string NombrePasajero { get; set; }
        [DataMember]
        public string ApellidoPaterno { get; set; }
        [DataMember]
        public string ApellidoMaterno { get; set; }
        [DataMember]
        public Reserva Reserva { get; set; }
    }
}