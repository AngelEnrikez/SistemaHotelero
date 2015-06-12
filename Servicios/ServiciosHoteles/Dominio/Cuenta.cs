using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace ServiciosHoteles.Dominio
{
    [DataContract]
    public class Cuenta
    {
        [DataMember]
        public int IdCuenta { get; set; }
        [DataMember]
        public Reserva Reserva { get; set; }
        [DataMember]
        public Servicio Servicio { get; set; }
        [DataMember]
        public int Cantidad { get; set; }
        [DataMember]
        public double CostoUnitario { get; set; }
        [DataMember]
        public double Total { get; set; }
    }
}