using ServiciosHoteles.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ServiciosHoteles
{
    public class Cuentas : ICuentas
    {
        private CuentaDAO cuentaDAO = null;

        private CuentaDAO CuentaDAO
        {
            get
            {
                if (cuentaDAO == null)
                {
                    cuentaDAO = new CuentaDAO();
                }

                return cuentaDAO;
            }
        }

        public Dominio.Cuenta CrearCuenta(Dominio.Cuenta cuentaNueva)
        {
            try 
            {
                return CuentaDAO.Crear(cuentaNueva);
            }
            catch (FaultException ex) 
            { 
                throw ex; 
            }
        }

        public Dominio.Cuenta ModificarCuenta(Dominio.Cuenta cuentaModificada)
        {
            try
            {
                return CuentaDAO.Modificar(cuentaModificada);
            }
            catch (FaultException ex)
            {
                throw ex;
            }
        }

        public void EliminarCuenta(Dominio.Cuenta cuentaEliminar)
        {
            try
            {
                CuentaDAO.Eliminar(cuentaEliminar);
            }
            catch (FaultException ex)
            {
                throw ex;
            }
        }

        public Dominio.Cuenta ObtenerCuenta(int codigo)
        {
            try
            {
                return CuentaDAO.Obtener(codigo);
            }
            catch (FaultException ex)
            {
                throw ex;
            }
        }

        public List<Dominio.Cuenta> ListarCuentas()
        {
            return CuentaDAO.Listar().ToList();
        }
        public List<Dominio.Cuenta> ListarCuentasPorReserva(int idReserva)
        {
            List<Dominio.Cuenta> cuentas = CuentaDAO.Buscar(idReserva).ToList();
            return cuentas;
        }
    }
}
