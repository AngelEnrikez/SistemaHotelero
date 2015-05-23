using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiciosHoteles.Persistencia
{
    public class ConexionUtil
    {
        public static string ObtenerCadena()
        {
            return "Data Source=(local);Initial Catalog=BDHoteles;Integrated Security=SSPI;";
            //return "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=BDHoteles;Data Source=LP-PCCAPA";
            //return "Data Source=H45-17;Initial Catalog=BD_Clientes;Integrated Security=SSPI;";

        }
    }
}