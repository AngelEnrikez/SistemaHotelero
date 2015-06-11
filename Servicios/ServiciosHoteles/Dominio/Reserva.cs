using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace ServiciosHoteles.Dominio
{
    [DataContract]
    public class Reserva
    {
        [DataMember]
        public int IdReserva { get; set; }
        [DataMember]
        public Cliente Cliente { get; set; }
        [DataMember]
        public Habitacion Habitacion { get; set; }
        [DataMember]
        public IList<Pasajero> Pasajero { get; set; }
        [DataMember]
        public DateTime FechaLlegada { get; set; }
        [DataMember]
        public DateTime FechaSalida { get; set; }
        [DataMember]
        public DateTime? FechaHoraCheckin { get; set; }
        [DataMember]
        public string ComentarioCheckin { get; set; }
        [DataMember]
        public DateTime? FechaHoraCheckout { get; set; }
        [DataMember]
        public string ComentarioCheckout { get; set; }
        [DataMember]
        public string CodFormaPago { get; set; }
        [DataMember]
        public string NumeroTarjeta { get; set; }
        [DataMember]
        public string TitularTarjeta { get; set; }
        [DataMember]
        public int MesExpiraTarjeta { get; set; }
        [DataMember]
        public int AnioExpiraTarjeta { get; set; }
        [DataMember]
        public string RequerimientosEsp { get; set; }
        [DataMember]
        public string Observaciones { get; set; }
        [DataMember]
        public bool EstadoCuenta { get; set; }
        [DataMember]
        public int Estado { get; set; }
    }
}
