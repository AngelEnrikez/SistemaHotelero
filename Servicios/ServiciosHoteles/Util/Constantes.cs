using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace ServiciosHoteles.Util
{

     [DataContract]
    public class Constantes
    {

       [DataMember]
        enum Days { Sun, Mon, Tue, Wed, Thu, Fri, Sat };

    }
}