﻿using ServiciosHoteles.Dominio;
using ServiciosHoteles.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ServiciosHoteles
{
    public class Administracion : IAdministracion
    {
    
        public List<Cliente> AdminClientes(Constantes valor,Cliente clientes,int codigo )
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
                else if (valor == Constantes.Obtener)
                {
                    lista.Add(nombre.ObtenerCliente(codigo));
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

        public List<TipoDocumento> AdminTDocumentos(Constantes valor)
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

        public List<Habitacion> AdminHabitaciones(Constantes valor)
        {
            List<Habitacion> listaHabitaciones = new List<Habitacion>();
            IHabitaciones nombre2 = new Habitaciones();

            try
            {
                if (valor == Constantes.Listar)
                {
                    listaHabitaciones = nombre2.ListarHabitacion();
                }
            }
            catch (FaultException ex) { throw ex; }
            return listaHabitaciones;
        }

        public List<TipoHabitacion> AdminTHabitaciones()
        {
            throw new NotImplementedException();
        }

        public List<Pais> AdminPaises(Constantes valor)
        {
            List<Pais> listaTipoDocumento = new List<Pais>();
            IPaises nombre2 = new Paises();

            try
            {
                if (valor == Constantes.Listar)
                {
                    listaTipoDocumento = nombre2.ListarPais();
                }
            }
            catch (FaultException ex) { throw ex; }
            return listaTipoDocumento;
        }

        public List<Servicio> AdminServicios()
        {
            throw new NotImplementedException();
        }

        public List<Parametro> AdminParametros()
        {
            throw new NotImplementedException();
        }
    }

}
