using ServiciosHoteles.Dominio;
using ServiciosHoteles.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Web.UI.WebControls;

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
        public string CrearCliente(int idTipoDocumento, string nombres, string apellidoPaterno, string apellidoMaterno, string numeroDocumento, string email, string telefono, int idPais)
        {
            string mensaje = null;

            int telefonoEntero;
            bool telefonoValido = int.TryParse(telefono, out telefonoEntero);

            int numerDocEntero;
            bool numeroDocumentoValido = int.TryParse(numeroDocumento, out numerDocEntero);

            if (nombres == string.Empty)
            {
                mensaje = "El campo Nombres debe ser obligatorio";
            }
            else if (apellidoPaterno == string.Empty)
            {
                mensaje = "El campo Apellido Paterno debe ser obligatorio";
            }
            else if (apellidoMaterno == string.Empty)
            {
                mensaje = "El campo Apellido Materno debe ser obligatorio";
            }
            else if (numeroDocumento == string.Empty)
            {
                mensaje = "El campo Nro. Documento Materno debe ser obligatorio";
            }
            else if (!emailValido(email))
            {
                mensaje = "Ingrese Correo Electronico Valido";
            }
            else if (!telefonoValido)
            {
                mensaje = "El campo Teléfono debe ser numérico";
            }
            else if (!numeroDocumentoValido)
            {
                mensaje = "El campo Nro Documento debe ser numérico";
            }
            else
            {
                Pais paisExistente = PaisDAO.Obtener(idPais);
                TipoDocumento tipoDocumentoExistente = TipoDocumentoDAO.Obtener(idTipoDocumento);

                Cliente clienteRegistrar = new Cliente()
                {
                    TipoDocumento = tipoDocumentoExistente,
                    Nombre = nombres,
                    ApellidoPaterno = apellidoPaterno,
                    ApellidoMaterno = apellidoMaterno,
                    NumeroDocumento = numeroDocumento,
                    Telefono = telefono,
                    Email = email,
                    Pais = paisExistente
                };

                Cliente clienteCreado = ClienteDAO.Crear(clienteRegistrar);

                if (clienteCreado != null)
                {
                    mensaje = "Grabacion Exitosa";
                }
            }

            return mensaje;


        }

        public string ModificarCliente(int idCliente, int idTipoDocumento, string nombres, string apellidoPaterno, string apellidoMaterno, string numeroDocumento, string email, string telefono, int idPais)
        {
            string mensaje = null;

            int telefonoEntero;
            bool telefonoValido = int.TryParse(telefono, out telefonoEntero);

            int numerDocEntero;
            bool numeroDocumentoValido = int.TryParse(numeroDocumento, out numerDocEntero);

            if (nombres == string.Empty)
            {
                mensaje = "El campo Nombres debe ser obligatorio";
            }
            else if (apellidoPaterno == string.Empty)
            {
                mensaje = "El campo Apellido Paterno debe ser obligatorio";
            }
            else if (apellidoMaterno == string.Empty)
            {
                mensaje = "El campo Apellido Materno debe ser obligatorio";
            }
            else if (numeroDocumento == string.Empty)
            {
                mensaje = "El campo Nro. Documento Materno debe ser obligatorio";
            }
            if (!emailValido(email))
            {
                mensaje = "Ingrese Correo Electronico Valido";
            }
            else if (!telefonoValido)
            {
                mensaje = "El campo Teléfono debe ser numérico";
            }
            else if (!numeroDocumentoValido)
            {
                mensaje = "El campo Nro Documento debe ser numérico";
            }
            else
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

                Cliente clienteModificado = ClienteDAO.Modificar(clienteAModificar);
                if (clienteModificado != null)
                {
                    mensaje = "Grabacion Exitosa";
                }
            }

            return mensaje;
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


        public List<Cliente> BuscarClientes(string nombre, string numeroDocumento)
        {
            Cliente clienteBuscar = new Cliente()
            {
                Nombre = nombre,
                NumeroDocumento = numeroDocumento
            };

            return ClienteDAO.Buscar(clienteBuscar).ToList();
        }

        bool emailValido(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}
