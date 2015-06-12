using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using System.IO;
using System.Web.Script.Serialization;
using HotelUnitTests.Dominio;

namespace HotelUnitTests
{
    /// <summary>
    /// Pruebas Unitarias del Servicio Web CheckOut (REST)
    /// </summary>
    [TestClass]
    public class UnitTestCheckIn
    {
        [TestMethod]
        public void TestRegistrarCheckIn()
        {
            string postdata = "{\"IdReserva\":1,\"Cliente\":{\"IdCliente\":1},\"Habitacion\":{\"IdHabitacion\":\"1\"},\"FechaLlegada\":\"/Date(62831853071)/\",\"FechaSalida\":\"/Date(62831853071)/\",\"FechaHoraCheckin\":\"/Date(62831853071)/\",\"ComentarioCheckin\":\"CheckIn sin problemas\",\"FechaHoraCheckout\":\"/Date(62831853071)/\",\"ComentarioCheckout\":\"\",\"CodFormaPago\":\"EF\",\"NumeroTarjeta\":\"211221123212\",\"TitularTarjeta\":\"Pedro\",\"MesExpiraTarjeta\":\"8\",\"AnioExpiraTarjeta\":\"2015\",\"RequerimientosEsp\":\"Sin requerimientos\",\"Observaciones\":\"\",\"EstadoCuenta\":true,\"Estado\":0}"; //JSON
            byte[] data = Encoding.UTF8.GetBytes(postdata);
            HttpWebRequest req = (HttpWebRequest)WebRequest
                .Create("http://localhost:49486/CheckIn.svc/CheckIn");
            req.Method = "PUT";
            req.ContentLength = data.Length;
            req.ContentType = "application/json";
            var reqStream = req.GetRequestStream();
            reqStream.Write(data, 0, data.Length);
            try
            {
                HttpWebResponse res = (HttpWebResponse)req.GetResponse();
                StreamReader reader = new StreamReader(res.GetResponseStream());
                string reservaJson = reader.ReadToEnd();
                JavaScriptSerializer js = new JavaScriptSerializer();
                Reserva reservaModificada = js.Deserialize<Reserva>(reservaJson);
                Assert.AreEqual(2, reservaModificada.Estado);
            }
            catch (WebException e)
            {
                HttpStatusCode code = ((HttpWebResponse)e.Response).StatusCode;
                string message = ((HttpWebResponse)e.Response).StatusDescription;
                StreamReader reader = new StreamReader(e.Response.GetResponseStream());
                string error = reader.ReadToEnd();
                JavaScriptSerializer js = new JavaScriptSerializer();
                string mensaje = js.Deserialize<string>(error);
                Assert.AreEqual("La Reserva debe tener estado Pendiente", mensaje);
            }
        }

        [TestMethod]
        public void TestRegistrarCheckInEstadoNoPendiente()
        {
            string postdata = "{\"IdReserva\":1,\"Cliente\":{\"IdCliente\":1},\"Habitacion\":{\"IdHabitacion\":\"1\"},\"FechaLlegada\":\"/Date(62831853071)/\",\"FechaSalida\":\"/Date(62831853071)/\",\"FechaHoraCheckin\":\"/Date(62831853071)/\",\"ComentarioCheckin\":\"CheckIn sin problemas\",\"FechaHoraCheckout\":\"/Date(62831853071)/\",\"ComentarioCheckout\":\"\",\"CodFormaPago\":\"EF\",\"NumeroTarjeta\":\"211221123212\",\"TitularTarjeta\":\"Pedro\",\"MesExpiraTarjeta\":\"8\",\"AnioExpiraTarjeta\":\"2015\",\"RequerimientosEsp\":\"Sin requerimientos\",\"Observaciones\":\"\",\"EstadoCuenta\":true,\"Estado\":2}"; //JSON
            byte[] data = Encoding.UTF8.GetBytes(postdata);
            HttpWebRequest req = (HttpWebRequest)WebRequest
                .Create("http://localhost:49486/CheckIn.svc/CheckIn");
            req.Method = "PUT";
            req.ContentLength = data.Length;
            req.ContentType = "application/json";
            var reqStream = req.GetRequestStream();
            reqStream.Write(data, 0, data.Length);
            try
            {
                HttpWebResponse res = (HttpWebResponse)req.GetResponse();
                StreamReader reader = new StreamReader(res.GetResponseStream());
                string reservaJson = reader.ReadToEnd();
                JavaScriptSerializer js = new JavaScriptSerializer();
                Reserva reservaModificada = js.Deserialize<Reserva>(reservaJson);
                Assert.AreEqual(2, reservaModificada.Estado);
            }
            catch (WebException e)
            {
                HttpStatusCode code = ((HttpWebResponse)e.Response).StatusCode;
                string message = ((HttpWebResponse)e.Response).StatusDescription;
                StreamReader reader = new StreamReader(e.Response.GetResponseStream());
                string error = reader.ReadToEnd();
                JavaScriptSerializer js = new JavaScriptSerializer();
                string mensaje = js.Deserialize<string>(error);
                Assert.AreEqual("La Reserva debe tener estado Pendiente", mensaje);
            }
        }
    }


}
