using ServiciosHoteles.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ServiciosHoteles
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Administracion" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Administracion.svc o Administracion.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Administracion : IAdministracion
    {
    

        public List<Dominio.Cliente> AdminClientes(Constantes valor)
        {
            throw new NotImplementedException();
        }

        public List<Dominio.TipoDocumento> AdminTDocumentos()
        {
            throw new NotImplementedException();
        }

        public List<Dominio.Habitacion> AdminHabitaciones()
        {
            throw new NotImplementedException();
        }

        public List<Dominio.TipoHabitacion> AdminTHabitaciones()
        {
            throw new NotImplementedException();
        }

        public List<Dominio.Pais> AdminPaises()
        {
            throw new NotImplementedException();
        }

        public List<Dominio.Servicio> AdminServicios()
        {
            throw new NotImplementedException();
        }

        public List<Dominio.Parametro> AdminParametros()
        {
            throw new NotImplementedException();
        }
    }

}
