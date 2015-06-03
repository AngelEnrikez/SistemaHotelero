using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelUnitTests.Dominio
{
    public class Reserva
    {
        public int IdReserva { get; set; }
        public Cliente Cliente { get; set; }
        public Habitacion Habitacion { get; set; }
        public DateTime FechaLlegada { get; set; }
        public DateTime FechaSalida { get; set; }
        public DateTime? FechaHoraCheckin { get; set; }
        public string ComentarioCheckin { get; set; }
        public DateTime? FechaHoraCheckout { get; set; }
        public string ComentarioCheckout { get; set; }
        public string CodFormaPago { get; set; }
        public string NumeroTarjeta { get; set; }
        public string TitularTarjeta { get; set; }
        public int MesExpiraTarjeta { get; set; }
        public int AnioExpiraTarjeta { get; set; }
        public string RequerimientosEsp { get; set; }
        public string Observaciones { get; set; }
        public bool EstadoCuenta { get; set; }
        public int Estado { get; set; }
    }
}
