using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Mantenimientos_CheckOut : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!this.IsPostBack)
            {
                string codigo = Request.QueryString["cod"].ToString();
                hdCodigo.Value = codigo;
                cargarDatos(codigo);
            }
        }
        catch (Exception ex)
        {
            divError.InnerHtml = ex.Message;
            divError.Visible = true;
        }


    }

    private void cargarDatos(string codigo) {
        ServicioReservas.ReservasClient proxy = new ServicioReservas.ReservasClient();
        ServicioReservas.Reserva reserva = proxy.ObtenerReserva(Int32.Parse(codigo));
        txtCodigo.Text = codigo;
        txtHabitacion.Text = reserva.Habitacion.Numero.ToString() + " - " + reserva.Habitacion.TipoHabitacion.Descripcion;
        txtCliente.Text = reserva.Cliente.Nombre + " " + reserva.Cliente.ApellidoPaterno + " " + reserva.Cliente.ApellidoMaterno;
        txtCheckIn.Text = reserva.FechaHoraCheckin + "";
    }


    protected void btnCheckOut_Click(object sender, EventArgs e)
    {
        try
        {
            ServicioReservas.ReservasClient proxy = new ServicioReservas.ReservasClient();
            string codigo = hdCodigo.Value;
            ServicioReservas.Reserva reserva = proxy.ObtenerReserva(Int32.Parse(codigo));
            reserva.ComentarioCheckout = txtComentario.Text;

            JavaScriptSerializer js = new JavaScriptSerializer();
            string json = js.Serialize(reserva);
            byte[] data = Encoding.UTF8.GetBytes(json);
            HttpWebRequest req = (HttpWebRequest)WebRequest
                .Create("http://localhost:49486/CheckOut.svc/CheckOut");
            req.Method = "PUT";
            req.ContentLength = data.Length;
            req.ContentType = "application/json";
            var reqStream = req.GetRequestStream();
            reqStream.Write(data, 0, data.Length);
        
            HttpWebResponse res = (HttpWebResponse)req.GetResponse();
            StreamReader reader = new StreamReader(res.GetResponseStream());
            string reservaJson = reader.ReadToEnd();
            JavaScriptSerializer js2 = new JavaScriptSerializer();
            ServicioReservas.Reserva reservaModificada = js2.Deserialize<ServicioReservas.Reserva>(reservaJson);

            if (reservaModificada != null) {
                divError.InnerHtml = "Check out registrado correctamente";
                divError.Visible = true;
            }

        }
        catch (WebException ex)
        {
            HttpStatusCode code = ((HttpWebResponse)ex.Response).StatusCode;
            string message = ((HttpWebResponse)ex.Response).StatusDescription;
            StreamReader reader = new StreamReader(ex.Response.GetResponseStream());
            string error = reader.ReadToEnd();
            JavaScriptSerializer js = new JavaScriptSerializer();
            string mensaje = js.Deserialize<string>(error);

            divError.InnerHtml = mensaje;
            divError.Visible = true;
        }

    }
    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        Response.Redirect("ConsultaReserva.aspx", true);
    }
}