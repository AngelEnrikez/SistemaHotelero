using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using ServiciosHoteles.Dominio;
using ServiciosHoteles.Persistencia;

namespace ServiciosHoteles
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Pasajeros" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Pasajeros.svc or Pasajeros.svc.cs at the Solution Explorer and start debugging.
    public class Pasajeros : IPasajeros
    {

        private PasajeroDAO asajeroDAO = null;
        private PasajeroDAO PasajeroDAO
        {
            get
            {
                if (asajeroDAO == null)
                {
                    asajeroDAO = new PasajeroDAO();
                }

                return asajeroDAO;
            }
        }
        public Pasajero CrearPasajero(Pasajero pasajeroNuevo)
        {
            Pasajero pasajeroCreado;
            try
            {
                pasajeroCreado = PasajeroDAO.Crear(pasajeroNuevo);
            }
            catch (FaultException ex) { throw ex; }           
            return pasajeroCreado;
        }

        public Pasajero ModificarPasajero(Pasajero pasajeroAModificar)
        {
            Pasajero pasajeroModificado;
            try
            {
                pasajeroModificado = PasajeroDAO.Modificar(pasajeroAModificar);
            }
            catch (FaultException ex) { throw ex; }
            return pasajeroModificado;
        }

        public void EliminarPasajero(Pasajero pasajeroEliminar)
        {
            try
            {
                 PasajeroDAO.Eliminar(pasajeroEliminar);
            }
            catch (FaultException ex) { throw ex; }
        }

        public Pasajero ObtenerPasajero(int codigo)
        {
            Pasajero pasajero;
            try
            {
                pasajero = PasajeroDAO.Obtener(codigo);
            }
            catch (FaultException ex) { throw ex; }
            return pasajero;
        }

        public List<Pasajero> ListarPasajeros()
        {
            List<Pasajero> pasajero;
            try
            {
                pasajero = PasajeroDAO.Listar().ToList();
                foreach(Pasajero lista in  pasajero ){
                    lista.Reserva.Pasajero = null;
                }
            }
            catch (FaultException ex) { throw ex; }
            return pasajero;
        }
    }
}
