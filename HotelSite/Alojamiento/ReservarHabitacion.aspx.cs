using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ServicioAlojamiento;
using ServicioAdministracion;

public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!this.IsPostBack)
            {
                hdAgregarActualizar.Value = Request.QueryString["accion"].ToString();
                hdCodigo.Value = Request.QueryString["cod"].ToString();
                MostrarItems();
                MostrarRegistro();
                btnAgregarCliente.Attributes.Add("OnClick", "OpenPopup('" + Request.Url.GetLeftPart(UriPartial.Authority) + VirtualPathUtility.ToAbsolute("~/") + "Administracion/AdministracionCliente.aspx?cod=0&accion=N&espopup=1" + "',900,900);");
            }
            else
            {
                if (Request["__EVENTARGUMENT"] != null)
                    if (Request["__EVENTARGUMENT"] == "cargarclientes") 
                        CargarClientes();
            }
        }
        catch (Exception ex)
        {
            divError.InnerHtml = ex.Message;
            divError.Visible = true;
        }
    }


    /// <summary>
    /// muestra el listado pais y tipo documento
    /// </summary>
    private void MostrarItems()
    {
        try
        {
            using (AdministracionClient objHabitacion = new AdministracionClient())
            {
                cmbHbitacion.DataSource = objHabitacion.AdminHabitaciones(ServicioAdministracion.Constantes.Listar);
                cmbHbitacion.DataTextField = "Descripcion";
                cmbHbitacion.DataValueField = "IdHabitacion";
                cmbHbitacion.DataBind();
            }
            CargarClientes();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void CargarClientes()
    {
        try
        {

            using (AdministracionClient objCliente = new AdministracionClient())
            {
                cmbCliente.DataSource = objCliente.AdminClientes(ServicioAdministracion.Constantes.Listar, null, 0);
                cmbCliente.DataTextField = "Nombre";
                cmbCliente.DataValueField = "IdCliente";
                cmbCliente.DataBind();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


    /// <summary>
    /// Muestra los registros 
    /// </summary>
    private void MostrarRegistro()
    {
        try
        {
            if (hdAgregarActualizar.Value == "A")
            {
                using (AlojamientoClient objCliente = new AlojamientoClient())
                {
                    ServicioAlojamiento.Reserva reserva;
                    reserva = objCliente.ReservarHabitacion(ServicioAlojamiento.Constantes.Obtener, null, Convert.ToInt32(hdCodigo.Value))[0];
                    cmbCliente.SelectedValue = reserva.Cliente.IdCliente.ToString();
                    cmbHbitacion.SelectedValue = reserva.Habitacion.IdHabitacion.ToString();
                    txtFechaLlegada.Text = reserva.FechaLlegada.ToString("dd/MM/yyyy HH:mm:ss");
                    txtFechaSalida.Text = reserva.FechaSalida.ToString("dd/MM/yyyy HH:mm:ss");
                    cmbFormaPago.SelectedValue = reserva.CodFormaPago;
                    txtNroTarjeta.Text = reserva.NumeroTarjeta;
                    txtObservaciones.Text = reserva.Observaciones;
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }

    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        Response.Redirect("ListadoReserva.aspx", true);
    }
    protected void btnGuardar_Click(object sender, EventArgs e)
    {
        try
        {
            using (AlojamientoClient objReserva = new AlojamientoClient())
            {
                ServicioAlojamiento.Cliente cliente = new ServicioAlojamiento.Cliente();
                ServicioAlojamiento.Habitacion habitacion = new ServicioAlojamiento.Habitacion();
                Reserva reserva = new Reserva();
                if (hdAgregarActualizar.Value == "N")
                {
                    cliente.IdCliente = Convert.ToInt32(cmbCliente.SelectedValue);
                    reserva.Cliente = cliente;
                    habitacion.IdHabitacion = Convert.ToInt32(cmbHbitacion.SelectedValue);
                    reserva.Habitacion = habitacion;
                    reserva.FechaLlegada = DateTime.ParseExact(txtFechaLlegada.Text, "dd/MM/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
                    reserva.FechaSalida = DateTime.ParseExact(txtFechaSalida.Text, "dd/MM/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
                    reserva.CodFormaPago = cmbFormaPago.SelectedValue.ToString();
                    reserva.NumeroTarjeta = txtNroTarjeta.Text;
                    reserva.Observaciones = txtObservaciones.Text;
                    objReserva.ReservarHabitacion(ServicioAlojamiento.Constantes.Crear, reserva, 0);
                }
                else if (hdAgregarActualizar.Value == "A")
                {
                    reserva.IdReserva = Convert.ToInt32(hdCodigo.Value);
                    cliente.IdCliente = Convert.ToInt32(cmbCliente.SelectedValue);
                    reserva.Cliente = cliente;
                    habitacion.IdHabitacion = Convert.ToInt32(cmbHbitacion.SelectedValue);
                    reserva.Habitacion = habitacion;
                    reserva.FechaLlegada = DateTime.ParseExact(txtFechaLlegada.Text, "dd/MM/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
                    reserva.FechaSalida = DateTime.ParseExact(txtFechaSalida.Text, "dd/MM/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
                    reserva.CodFormaPago = cmbFormaPago.SelectedValue.ToString();
                    reserva.NumeroTarjeta = txtNroTarjeta.Text;
                    reserva.Observaciones = txtObservaciones.Text;
                    reserva.Observaciones = txtObservaciones.Text;
                    objReserva.ReservarHabitacion(ServicioAlojamiento.Constantes.Modificar, reserva, 0);
                }
            }
            Response.Redirect("ListadoReserva.aspx", true);
        }
        catch (Exception ex)
        {
            divError.InnerHtml = ex.Message;
            divError.Visible = true;
        }
    }
    protected void cmbFormaPago_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (cmbFormaPago.SelectedValue == "EF") { txtNroTarjeta.Text = ""; txtNroTarjeta.Enabled = false; }
        else { txtNroTarjeta.Text = ""; txtNroTarjeta.Enabled = true; }
    }
}