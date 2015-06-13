using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HotelUnitTests
{
    [TestClass]
    public class UnitTestReservas
    {
        [TestMethod]
        public void TestCrearReserva()
        {
            try
            {
                ServicioAlojamiento.AlojamientoClient objreserva = new ServicioAlojamiento.AlojamientoClient();
                ServicioAlojamiento.Reserva reserva = new ServicioAlojamiento.Reserva();
                reserva.Cliente = new ServicioAlojamiento.Cliente() { IdCliente = 1 };
                reserva.Habitacion = new ServicioAlojamiento.Habitacion() { IdHabitacion = 1 };
                reserva.FechaLlegada = new DateTime(2015, 06, 12, 12, 12, 12);
                reserva.FechaSalida= new DateTime(2015, 06, 12, 12, 12, 12);
                reserva.NumeroTarjeta = "2345655445533";
                reserva.CodFormaPago = "TM";
                reserva.Observaciones = "nueva reserva";

                List<ServicioAlojamiento.Pasajero> pasajeros = new List<ServicioAlojamiento.Pasajero>();
                pasajeros.Add(new ServicioAlojamiento.Pasajero() { NombrePasajero = "Pablo", ApellidoMaterno = "Becerra", ApellidoPaterno = "Ccapa" });
                pasajeros.Add(new ServicioAlojamiento.Pasajero() { NombrePasajero = "Juan", ApellidoMaterno = "Miranda", ApellidoPaterno = "Peña" });

                reserva.Pasajero = pasajeros;

                List< ServicioAlojamiento.Reserva> reservaCreada = objreserva.ReservarHabitacion(ServicioAlojamiento.Constantes.Crear, reserva, 0);
                Assert.IsNotNull(reservaCreada);
            }
            catch (Exception ex)
            {
                Assert.Fail();
                //Assert.AreEqual("Debe haber por lo menos un pasajero.", ex.Message);
            }
        }

        [TestMethod]
        public void TestModificarReserva()
        {
            try
            {
                ServicioAlojamiento.AlojamientoClient objreserva = new ServicioAlojamiento.AlojamientoClient();
                ServicioAlojamiento.Reserva reserva = new ServicioAlojamiento.Reserva();
                reserva.IdReserva = 4;
                reserva.Cliente = new ServicioAlojamiento.Cliente() { IdCliente = 1 };
                reserva.Habitacion = new ServicioAlojamiento.Habitacion() { IdHabitacion = 1 };
                reserva.FechaLlegada = new DateTime(2015, 06, 12, 12, 12, 12);
                reserva.FechaSalida = new DateTime(2015, 06, 12, 12, 12, 12);
                reserva.NumeroTarjeta = "567896544444";
                reserva.CodFormaPago = "TM";
                reserva.Observaciones = "nueva reserva";

                List<ServicioAlojamiento.Pasajero> pasajeros = new List<ServicioAlojamiento.Pasajero>();
                pasajeros.Add(new ServicioAlojamiento.Pasajero() { NombrePasajero = "Pablo", ApellidoMaterno = "Becerra", ApellidoPaterno = "Ccapa" });
                pasajeros.Add(new ServicioAlojamiento.Pasajero() { NombrePasajero = "Juan", ApellidoMaterno = "Miranda", ApellidoPaterno = "Peña" });

                reserva.Pasajero = pasajeros;

                List<ServicioAlojamiento.Reserva> reservaCreada = objreserva.ReservarHabitacion(ServicioAlojamiento.Constantes.Modificar, reserva, 0);
                Assert.IsNotNull(reservaCreada);
                Assert.AreEqual("567896544444", reservaCreada[0].NumeroTarjeta);
            }
            catch (Exception ex)
            {
                Assert.Fail();
                //Assert.AreEqual("Debe haber por lo menos un pasajero.", ex.Message);
            }
        }
    }
}
