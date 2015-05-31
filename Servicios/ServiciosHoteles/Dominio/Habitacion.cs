using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;


namespace ServiciosHoteles.Dominio
{
    [DataContract]
    public class Habitacion
    {
        [DataMember]
        public int IdHabitacion { get; set; }

        [DataMember]
        public int IdTipoHabitacion { get; set; }
        [DataMember]
        public int Numero { get; set; }
        [DataMember]
        public int Piso { get; set; }
        [DataMember]
        public string Descripcion { get; set; }


    }
}