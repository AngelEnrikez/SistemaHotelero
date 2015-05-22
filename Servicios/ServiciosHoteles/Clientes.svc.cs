using ServiciosHoteles.Dominio;
using ServiciosHoteles.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ServiciosHoteles
{
    public class Clientes : IClientes
    {
        private ClienteDAO clienteDAO = null;

        private ClienteDAO ClienteDAO
        {
            get
            {
                if (clienteDAO == null)
                {
                    clienteDAO = new ClienteDAO();
                }

                return clienteDAO;
            }
        }

        public Cliente CrearCliente(int idCliente, int idTipoDocumento, string nombres, string apellidoPaterno, string apellidoMaterno, string numeroDocumento, string email, string telefono, int idPais)
        {
            Cliente clienteRegistrar = new Cliente()
            {
                IdCliente=idCliente,
                IdTipoDocumento=idTipoDocumento,
                Nombres = nombres,
                ApellidoPaterno = apellidoPaterno,
                ApellidoMaterno = apellidoMaterno,
                NumeroDocumento = numeroDocumento,
                Telefono = telefono,
                Email = email,
                IdPais=idPais
            };

            return ClienteDAO.Crear(clienteRegistrar);
        }

        public Cliente ModificarCliente(int idCliente, int idTipoDocumento, string nombres, string apellidoPaterno, string apellidoMaterno, string numeroDocumento, string email, string telefono, int idPais)
        {
            Cliente clienteAModificar = new Cliente()
            {
                IdCliente = idCliente,
                IdTipoDocumento = idTipoDocumento,
                Nombres = nombres,
                ApellidoPaterno = apellidoPaterno,
                ApellidoMaterno = apellidoMaterno,
                NumeroDocumento = numeroDocumento,
                Telefono = telefono,
                Email = email,
                IdPais = idPais
            };

            return ClienteDAO.Modificar(clienteAModificar);
        }

        public void EliminarCliente(int codigo)
        {
            Cliente clienteAEliminar = ClienteDAO.Obtener(codigo);
            ClienteDAO.Eliminar(clienteAEliminar);
        }

        public Cliente ObtenerCliente(int codigo)
        {
            return ClienteDAO.Obtener(codigo);
        }

        public List<Cliente> ListarClientes()
        {
            return ClienteDAO.Listar().ToList();
        }
    }
}
