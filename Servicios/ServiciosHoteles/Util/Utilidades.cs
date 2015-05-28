using System;
using System.Collections.Generic;
using System.Web;
using System.Net.Mail;

namespace ServiciosHoteles.Util
{
    public  static  class Utilidades
    {
        public static bool emailValido(string email)
        {
            try
            {
                var addr = new MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}