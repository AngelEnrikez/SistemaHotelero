using AutoMapper;
using ServiciosHoteles.Dominio;
using ServiciosHoteles.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace ServiciosHoteles
{
    public class CheckOut : ICheckOut
    {
        public Reserva RegistrarCheckOut(Reserva reservaCheckedOut)
        {
            //Regla de Negocio 1: La Reserva debe estar en estado CheckedIn
            if (reservaCheckedOut.Estado != (int)EstadosReserva.CheckedIn)
            {
                throw new WebFaultException<string>(
                    "La Reserva debe tener estado CheckedIn", HttpStatusCode.PreconditionFailed);
            }
            //Regla de Negocio 2: La Cuenta debe estar cerrada para poder registrar el CheckOut
            else if (reservaCheckedOut.EstadoCuenta == false)
            {
                throw new WebFaultException<string>(
                    "La Reserva debe tener la Cuenta Cerrada/Confirmada", HttpStatusCode.PreconditionFailed);
            }

            //Se actualiza la Reserva con los datos del CheckOut
            reservaCheckedOut.FechaHoraCheckout = DateTime.Now;
            reservaCheckedOut.Estado = (int)EstadosReserva.CheckedOut;

            ServicioReserva.ReservasClient proxy = new ServicioReserva.ReservasClient();
            Mapper.CreateMap<Reserva, ServicioReserva.Reserva>();
            Mapper.CreateMap<Cliente, ServicioReserva.Cliente>();
            Mapper.CreateMap<Habitacion, ServicioReserva.Habitacion>();
            Mapper.CreateMap<Pais, ServicioReserva.Pais>();
            Mapper.CreateMap<TipoDocumento, ServicioReserva.TipoDocumento>();
            Mapper.CreateMap<TipoHabitacion, ServicioReserva.TipoHabitacion>();
            Mapper.CreateMap<Pasajero, ServicioReserva.Pasajero>();

            ServicioReserva.Reserva reservaAModificar = new ServicioReserva.Reserva();
            Mapper.Map(reservaCheckedOut, reservaAModificar);
            ServicioReserva.Reserva reservaModificada = proxy.ModificarReserva(reservaAModificar);

            Mapper.CreateMap<ServicioReserva.Reserva, Reserva>();
            Mapper.CreateMap<ServicioReserva.Cliente, Cliente>();
            Mapper.CreateMap<ServicioReserva.Pais, Pais>();
            Mapper.CreateMap<ServicioReserva.TipoDocumento, TipoDocumento>();
            Mapper.CreateMap<ServicioReserva.TipoHabitacion, TipoHabitacion>();
            Mapper.CreateMap<ServicioReserva.Habitacion, Habitacion>();

            Reserva reservaRetorno = new Reserva();
            Mapper.Map(reservaModificada, reservaRetorno);

            //Obtenemos los sgtes parámetros de configuración: IGV, Serie y Último Número de comprobante
            decimal igv = 0;
            string serie = "";
            int ultNumero = 0;
            string numeroComp = "";
            ServicioConfig.ParametrosConfClient proxyConfig = new ServicioConfig.ParametrosConfClient();
            List<ServicioConfig.Parametro> parametrosConf = proxyConfig.ListarParametros().ToList();
            foreach (ServicioConfig.Parametro parametro in parametrosConf)
            {
                if (parametro.ClaveConfig == "IGV")
                {
                    igv = Decimal.Parse(parametro.ValorConfig);
                }
                else if (parametro.ClaveConfig == "SERIECOMP")
                {
                    serie = parametro.ValorConfig;
                }
                else if (parametro.ClaveConfig == "ULTNROCOMP")
                {
                    ultNumero = Int32.Parse(parametro.ValorConfig);
                    ultNumero++;
                    parametro.ValorConfig = ultNumero.ToString();
                    proxyConfig.ModificarParametro(parametro);
                    numeroComp = String.Format("{0:0000000}", ultNumero);
                }
            }

            //Obtenemos todos los items de la Cuenta asociada a la Reserva
            decimal importeSinIgv = 0;
            ServicioCuenta.CuentasClient proxyCuenta = new ServicioCuenta.CuentasClient();
            List<ServicioCuenta.Cuenta> listaCuentas = proxyCuenta.ListarCuentasPorReserva(reservaRetorno.IdReserva).ToList();
            foreach (ServicioCuenta.Cuenta cuenta in listaCuentas)
            {
                importeSinIgv = importeSinIgv + (decimal)cuenta.Total;
            }
            decimal importeIgv = importeSinIgv * igv;
            decimal importeTotal = importeSinIgv + importeIgv;

            //Creamos un objeto Comprobante y lo grabamos en la base de datosE:\Workspaces\VisualStudio\GestionHotelera\Servicios\ServiciosHoteles\Persistencia\ClienteDAO.cs
            ServicioComprobante.ComprobantesClient proxyComprobante = new ServicioComprobante.ComprobantesClient();
            ServicioComprobante.Comprobante nuevoComprobante = new ServicioComprobante.Comprobante()
            {
                Reserva = new ServicioComprobante.Reserva() { IdReserva = reservaRetorno.IdReserva },
                Serie = serie,
                Numero = numeroComp,
                FechaEmision = DateTime.Now,
                Importe = importeSinIgv,
                Igv = igv,
                ImporteIgv = importeIgv,
                ImporteTotal = importeTotal,
                Estado = 0
            };
            proxyComprobante.CrearComprobante(nuevoComprobante);

            //Retornar la reserva actualizada con el CheckOut
            return reservaRetorno;
        }
    }
}
