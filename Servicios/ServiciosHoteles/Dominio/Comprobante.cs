using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace ServiciosHoteles.Dominio
{
    [DataContract]
    public class Comprobante
    {
        [DataMember]
        public int IdComprobante { get; set; }
        [DataMember]
        public Reserva Reserva { get; set; }
        [DataMember]
        public string Serie { get; set; }
        [DataMember]
        public string Numero { get; set; }
        [DataMember]
        public DateTime FechaEmision { get; set; }
        [DataMember]
        public decimal Importe { get; set; }
        [DataMember]
        public decimal Igv { get; set; }
        [DataMember]
        public decimal ImporteIgv { get; set; }
        [DataMember]
        public decimal ImporteTotal { get; set; }
        [DataMember]
        public int Estado { get; set; }
    }
}