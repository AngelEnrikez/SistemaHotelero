using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelUnitTests.Dominio
{
    public class Habitacion
    {
        public int IdHabitacion { get; set; }
        public TipoHabitacion TipoHabitacion { get; set; }
        public int Numero { get; set; }
        public int Piso { get; set; }
        public string Descripcion { get; set; }
    }
}
