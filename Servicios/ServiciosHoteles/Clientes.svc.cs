using ServiciosHoteles.Dominio;
using ServiciosHoteles.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Web.UI.WebControls;
using ServiciosHoteles.Util;

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





        public Cliente CrearCliente(Cliente clienteACrear)
        {
            Cliente clienteCreado = null;
            int telefonoEntero;
            bool telefonoValido = int.TryParse(clienteACrear.Telefono, out telefonoEntero);

            int numerDocEntero;
            bool numeroDocumentoValido = int.TryParse(clienteACrear.NumeroDocumento, out numerDocEntero);

            try
            {

                if (clienteACrear.Nombre == string.Empty)
                {
                    FaultReason reason = new FaultReason("El campo Nombres debe ser obligatorio");
                    throw new FaultException(reason);
                }
                else if (clienteACrear.ApellidoPaterno == string.Empty)
                {
                    FaultReason reason = new FaultReason("El campo Apellido Paterno debe ser obligatorio");
                    throw new FaultException(reason);
                }
                else if (clienteACrear.ApellidoMaterno == string.Empty)
                {
                    FaultReason reason = new FaultReason("El campo Apellido Materno debe ser obligatorio");
                    throw new FaultException(reason);
                }
                else if (clienteACrear.NumeroDocumento == string.Empty)
                {
                    FaultReason reason = new FaultReason("El campo Nro. Documento debe ser obligatorio");
                    throw new FaultException(reason);
                }
                else if (!Utilidades.emailValido(clienteACrear.Email))
                {
                    FaultReason reason = new FaultReason("Ingrese Correo Electronico Valido");
                    throw new FaultException(reason);
                }
                else if (!telefonoValido)
                {
                    FaultReason reason = new FaultReason("El campo Teléfono debe ser numérico");
                    throw new FaultException(reason);
                }
                else if (!numeroDocumentoValido)
                {
                    FaultReason reason = new FaultReason("El campo Nro Documento debe ser numérico");
                    throw new FaultException(reason);
                }
                else
                {
                    Pais paisExistente = PaisDAO.Obtener(clienteACrear.Pais.IdPais);
                    TipoDocumento tipoDocumentoExistente = TipoDocumentoDAO.Obtener(clienteACrear.TipoDocumento.IdTipoDocumento);

                    clienteCreado = ClienteDAO.Crear(clienteACrear);
                }
            }
            catch (FaultException ex) { throw ex; }        
            return clienteCreado;
        }

        public Cliente ModificarCliente(Cliente clienteAModificar)
        {
            Cliente clienteModificado = null;

            int telefonoEntero;
            bool telefonoValido = int.TryParse(clienteAModificar.Telefono, out telefonoEntero);

            int numerDocEntero;
            bool numeroDocumentoValido = int.TryParse(clienteAModificar.NumeroDocumento, out numerDocEntero);

            try
            {
                if (clienteAModificar.Nombre == string.Empty)
                {
                    FaultReason reason = new FaultReason("El campo Nombres debe ser obligatorio");
                    throw new FaultException(reason);
                }
                else if (clienteAModificar.ApellidoPaterno == string.Empty)
                {
                    FaultReason reason = new FaultReason("El campo Apellido Paterno debe ser obligatorio");
                    throw new FaultException(reason);
                }
                else if (clienteAModificar.ApellidoMaterno == string.Empty)
                {
                    FaultReason reason = new FaultReason("El campo Apellido Materno debe ser obligatorio");
                    throw new FaultException(reason);
                }
                else if (clienteAModificar.NumeroDocumento == string.Empty)
                {
                    FaultReason reason = new FaultReason("El campo Nro. Documento debe ser obligatorio");
                    throw new FaultException(reason);
                }
                else if (!Utilidades.emailValido(clienteAModificar.Email))
                {
                    FaultReason reason = new FaultReason("Ingrese Correo Electronico Valido");
                    throw new FaultException(reason);
                }
                else if (!telefonoValido)
                {
                    FaultReason reason = new FaultReason("El campo Teléfono debe ser numérico");
                    throw new FaultException(reason);
                }
                else if (!numeroDocumentoValido)
                {
                    FaultReason reason = new FaultReason("El campo Nro Documento debe ser numérico");
                    throw new FaultException(reason);
                }
                else
                {
                    Pais paisExistente = PaisDAO.Obtener(clienteAModificar.Pais.IdPais);
                    TipoDocumento tipoDocumentoExistente = TipoDocumentoDAO.Obtener(clienteAModificar.TipoDocumento.IdTipoDocumento);

                    clienteModificado = ClienteDAO.Modificar(clienteAModificar);
                }
            }
            catch (FaultException ex) { throw ex; }
            return clienteModificado;
        }

        public void EliminarCliente(Cliente clienteAEliminar)
        {
            try
            {
                ClienteDAO.Eliminar(clienteAEliminar);
            }
            catch (FaultException ex)
            {
                throw ex;
            }
        }

        public Cliente ObtenerCliente(int codigo)
        {
            try
            {
                return ClienteDAO.Obtener(codigo);
            }
            catch (FaultException ex)
            {
                throw ex;
            }

        }

        public List<Cliente> ListarClientes()
        {
            try
            {
                return ClienteDAO.Listar().ToList();
            }
            catch (FaultException ex)
            {
                throw ex;
            }

        }

        public List<Cliente> BuscarClientes(Cliente clienteABuscar)
        {
            try
            {
                return ClienteDAO.Buscar(clienteABuscar).ToList();
            }
            catch (FaultException ex)
            {
                throw ex;
            }
        }

    }
}
