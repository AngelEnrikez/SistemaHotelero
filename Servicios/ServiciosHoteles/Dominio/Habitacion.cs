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
        public int idHabitacion { get; set; }

        [DataMember]
        public int idTipoHabitacion { get; set; }
        [DataMember]
        public int numero { get; set; }
        [DataMember]
        public int piso { get; set; }
        [DataMember]
        public string descripcion { get; set; }


    }
}