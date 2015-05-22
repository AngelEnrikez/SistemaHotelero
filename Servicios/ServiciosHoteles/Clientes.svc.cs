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

        public Cliente RegistrarCliente(string nombres, string apellidoPaterno, string apellidoMaterno, string dni, string telefono, string email)
        {
            Cliente clienteRegistrar = new Cliente()
            {
                Nombres = nombres,
                ApellidoPaterno = apellidoPaterno,
                ApellidoMaterno = apellidoMaterno,
                DNI = dni,
                Telefono = telefono,
                Email = email
            };

            return ClienteDAO.Crear(clienteRegistrar);
        }

        public Cliente ModificarCliente(int codigo, string nombres, string apellidoPaterno, string apellidoMaterno, string dni, string telefono, string email)
        {
            Cliente clienteAModificar = new Cliente()
            {
                Codigo = codigo,
                Nombres = nombres,
                ApellidoPaterno = apellidoPaterno,
                ApellidoMaterno = apellidoMaterno,
                DNI = dni,
                Telefono = telefono,
                Email = email
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

        public List<Dominio.Cliente> ListarClientes()
        {
            return ClienteDAO.Listar().ToList();
        }
    }
}
