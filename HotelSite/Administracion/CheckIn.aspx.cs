using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ServicioReservas;
using System.Web.Script.Serialization;
using System.Text;
using System.Net;
using System.IO;

public partial class Mantenimientos_CheckIn : System.Web.UI.Page
{

    //Acá se implementará el código de búsqueda y checkin de huéspedes
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!this.IsPostBack)
            {
                string codigo = Request.QueryString["cod"].ToString();
                hdfCodigoReserva.Value = codigo;
                cargarDatos(codigo);
            }
        }
        catch (Exception ex)
        {
            divError.InnerHtml = ex.Message;
            divError.Visible = true;
        }
    }

    private void cargarDatos(string codigo)
    {
        ServicioReservas.ReservasClient proxy = new ServicioReservas.ReservasClient();
        ServicioReservas.Reserva reserva = proxy.ObtenerReserva(Int32.Parse(codigo));
        txtCodigoReserva.Text = codigo;
        txtHabitacion.Text = reserva.Habitacion.Numero.ToString();
        txtCliente.Text = reserva.Cliente.Nombre + " " + reserva.Cliente.ApellidoPaterno + " " + reserva.Cliente.ApellidoMaterno;
        txtTipoHabitacion.Text = reserva.Habitacion.TipoHabitacion.Descripcion;
        txtFechaInicio.Text = reserva.FechaLlegada.ToString("dd'/'MM'/'yyyy");
        txtFechaFin.Text = reserva.FechaLlegada.ToString("dd'/'MM'/'yyyy");
    }
    

    protected void btnCheckIn_Click(object sender, EventArgs e)
    {
        try
        {
            ServicioReservas.ReservasClient proxy = new ServicioReservas.ReservasClient();
            string codigo = hdfCodigoReserva.Value;
            ServicioReservas.Reserva reserva = proxy.ObtenerReserva(Int32.Parse(codigo));
            reserva.ComentarioCheckin = txtComentarios.Text;

            JavaScriptSerializer js = new JavaScriptSerializer();
            string json = js.Serialize(reserva);
            byte[] data = Encoding.UTF8.GetBytes(json);
            HttpWebRequest req = (HttpWebRequest)WebRequest
                .Create("http://localhost:49486/CheckIn.svc/CheckIn");
            req.Method = "PUT";
            req.ContentLength = data.Length;
            req.ContentType = "application/json";
            var reqStream = req.GetRequestStream();
            reqStream.Write(data, 0, data.Length);

            HttpWebResponse res = (HttpWebResponse)req.GetResponse();
            StreamReader reader = new StreamReader(res.GetResponseStream());
            string reservaJson = reader.ReadToEnd();
            JavaScriptSerializer js2 = new JavaScriptSerializer();
            Reserva reservaModificada = js2.Deserialize<Reserva>(reservaJson);

            if (reservaModificada != null)
            {
                divError.InnerHtml = "Check In registrado correctamente";
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