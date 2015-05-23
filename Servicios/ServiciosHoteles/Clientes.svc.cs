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
        private PaisDAO paisDAO = null;
        private TipoDocumentoDAO tipoDocumentoDAO = null;
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
        private PaisDAO PaisDAO
        {
            get
            {
                if (paisDAO == null)
                {
                    paisDAO = new PaisDAO();
                }

                return paisDAO;
            }
        }
        private TipoDocumentoDAO TipoDocumentoDAO
        {
            get
            {
                if (tipoDocumentoDAO == null)
                {
                    tipoDocumentoDAO = new TipoDocumentoDAO();
                }

                return tipoDocumentoDAO;
            }
        }
        public Cliente CrearCliente(int idTipoDocumento, string nombres, string apellidoPaterno, string apellidoMaterno, string numeroDocumento, string email, string telefono, int idPais)
        {
            Pais paisExistente = PaisDAO.Obtener(idPais);
            TipoDocumento tipoDocumentoExistente = TipoDocumentoDAO.Obtener(idTipoDocumento);

            Cliente clienteRegistrar = new Cliente()
            {
                TipoDocumento=tipoDocumentoExistente,
                Nombre = nombres,
                ApellidoPaterno = apellidoPaterno,
                ApellidoMaterno = apellidoMaterno,
                NumeroDocumento = numeroDocumento,
                Telefono = telefono,
                Email = email,
                Pais=paisExistente
            };

            return ClienteDAO.Crear(clienteRegistrar);
        }

        public Cliente ModificarCliente(int idCliente, int idTipoDocumento, string nombres, string apellidoPaterno, string apellidoMaterno, string numeroDocumento, string email, string telefono, int idPais)
        {
            Pais paisExistente = PaisDAO.Obtener(idPais);
            TipoDocumento tipoDocumentoExistente = TipoDocumentoDAO.Obtener(idTipoDocumento);

            Cliente clienteAModificar = new Cliente()
            {
                IdCliente = idCliente,
                TipoDocumento = tipoDocumentoExistente,
                Nombre = nombres,
                ApellidoPaterno = apellidoPaterno,
                ApellidoMaterno = apellidoMaterno,
                NumeroDocumento = numeroDocumento,
                Telefono = telefono,
                Email = email,
                Pais = paisExistente
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


        public List<Cliente> ListarClientes(string nombre, string numeroDocumento)
        {   
            Cliente clienteBuscar = new Cliente(){
                Nombre = nombre,
                NumeroDocumento = numeroDocumento
            };

            return ClienteDAO.Buscar(clienteBuscar).ToList();
        }
    }
}
