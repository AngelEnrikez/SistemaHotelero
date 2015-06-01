using ServiciosHoteles.Dominio;
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
    

        public List<Dominio.Cliente> AdminClientes(Constantes valor,Cliente clientes )
        {

            List<Cliente> lista = new List<Cliente>();
            IClientes nombre = new Clientes();

            try
            {
                if (valor == Constantes.Crear) {

                  lista.Add(nombre.CrearCliente(clientes));

                }
                else if (valor == Constantes.Modificar) {

                    lista.Add(nombre.ModificarCliente(clientes));
                }

                else if (valor == Constantes.Eliminar)
                {

                    nombre.EliminarCliente(clientes);
                }

                else if (valor == Constantes.Listar)
                {

                    lista = nombre.ListarClientes();
                }



            }
            catch (FaultException ex) { throw ex; }


            return lista;

        }

        public List<Dominio.TipoDocumento> AdminTDocumentos(Constantes valor)
        {
            List<TipoDocumento> listaTipoDocumento = new List<TipoDocumento>();
            ITiposDocumento nombre2 = new TiposDocumento();

            try
            {

                if (valor == Constantes.Listar)
                {

                    listaTipoDocumento = nombre2.ListarTipoDocumento();

                }

            }
           catch (FaultException ex) { throw ex; }


            return listaTipoDocumento;
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


        public List<TipoDocumento> AdminTDocumentos()
        {
            throw new NotImplementedException();
        }
    }

}
