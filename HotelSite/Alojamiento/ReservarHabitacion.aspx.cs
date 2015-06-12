using System;
using System.Collections.Generic;
using System.Collections;
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
            divError.InnerHtml = "";
            divError.Visible = false;
            if (!this.IsPostBack)
            {
                hdAgregarActualizar.Value = Request.QueryString["accion"].ToString();
                hdCodigo.Value = Request.QueryString["cod"].ToString();
                MostrarItems();
                MostrarRegistro();
                btnAgregarCliente.Attributes.Add("OnClick", "OpenPopup('" + Request.Url.GetLeftPart(UriPartial.Authority) + VirtualPathUtility.ToAbsolute("~/") + "Administracion/AdministracionCliente.aspx?cod=0&accion=N&espopup=1" + "',900,900);");
                //btnAgregarPasajero.Attributes.Add("OnClick", "OpenPopup('" + Request.Url.GetLeftPart(UriPartial.Authority) + VirtualPathUtility.ToAbsolute("~/") + "Alojamiento/AdministracionPasajero.aspx?cod=0&accion=N&espopup=1" + "',900,650);");
            }
            else
            {
                if (Request["__EVENTARGUMENT"] != null)
                    if (Request["__EVENTARGUMENT"] == "cargarclientes")
                        CargarClientes();

                //if (Request["__EVENTTARGET"] != null)
                //    if (Request["__EVENTTARGET"] == "GuardarPasajero")
                //        CargarPasajeros(Request["__EVENTARGUMENT"].ToString());
            }
        }
        catch (Exception ex)
        {
            divError.InnerHtml = ex.Message;
            divError.Visible = true;
        }
    }


    /// <summary>
    /// muestra el listado pais, tipo documento, habitaciones
    /// </summary>
    private void MostrarItems()
    {
        try
        {
            using (AdministracionClient objHabitacion = new AdministracionClient())
            {
                List<ServicioAdministracion.TipoHabitacion> listatipohabitacion = new List<ServicioAdministracion.TipoHabitacion>();
                List<ServicioAdministracion.Habitacion> listahabitacion = objHabitacion.AdminHabitaciones(ServicioAdministracion.Constantes.Listar);

                foreach (ServicioAdministracion.Habitacion habi in listahabitacion)
                {
                    if (habi.TipoHabitacion != null)
                    {
                        if (listatipohabitacion.Where(g => g.IdTipoHabitacion == habi.TipoHabitacion.IdTipoHabitacion).Count() == 0)
                            listatipohabitacion.Add(habi.TipoHabitacion);
                    }
                }

                cmbTipoHabitacion.DataSource = listatipohabitacion;
                cmbTipoHabitacion.DataTextField = "Descripcion";
                cmbTipoHabitacion.DataValueField = "IdTipoHabitacion";
                cmbTipoHabitacion.DataBind();
                cmbTipoHabitacion.SelectedIndex = 0;

                cmbHbitacion.DataSource = listahabitacion.Where(f => f.TipoHabitacion.IdTipoHabitacion == Convert.ToInt32(cmbTipoHabitacion.SelectedValue)).ToList();
                cmbHbitacion.DataTextField = "Numero";
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
    private void CargarPasajeros(string nombre, string apellidopaterno, string apellidomaterno)
    {
        try
        {
            List<Pasajero> listaPasajeros = new List<Pasajero>();
            if (ViewState["Pasajeros"] != null)
                listaPasajeros = (List<Pasajero>)ViewState["Pasajeros"];

            if (listaPasajeros.Where(f => f.NombrePasajero == nombre && f.ApellidoMaterno == apellidomaterno && f.ApellidoPaterno == apellidopaterno).Count() > 0) throw new Exception("Los pasajeros no se deben repetir");

            Pasajero pasajero = new Pasajero()
            {
                NombrePasajero = nombre,
                ApellidoPaterno = apellidopaterno,
                ApellidoMaterno = apellidomaterno
            };            
            listaPasajeros.Add(pasajero);
            gdListadoPasajeros.DataSource = listaPasajeros;
            gdListadoPasajeros.DataBind();
            ViewState["Pasajeros"] = listaPasajeros;

            pnPasajero.Visible = false;
            txtNombres.Text = "";
            txtApellidoMat.Text = "";
            txtApellidoPat.Text = "";
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
                using (AlojamientoClient objReserva = new AlojamientoClient())
                {
                    ServicioAlojamiento.Reserva reserva;
                    reserva = objReserva.ReservarHabitacion(ServicioAlojamiento.Constantes.Obtener, null, Convert.ToInt32(hdCodigo.Value))[0];
                    cmbCliente.SelectedValue = reserva.Cliente.IdCliente.ToString();                  
                    txtFechaLlegada.Text = reserva.FechaLlegada.ToString("dd/MM/yyyy");
                    txtHoraLlegada.Text = reserva.FechaLlegada.ToString("HH:mm:ss");
                    txtFechaSalida.Text = reserva.FechaSalida.ToString("dd/MM/yyyy");
                    txtHoraSalida.Text = reserva.FechaSalida.ToString("HH:mm:ss");
                    cmbFormaPago.SelectedValue = reserva.CodFormaPago;
                    txtNroTarjeta.Text = reserva.NumeroTarjeta;
                    txtObservaciones.Text = reserva.Observaciones;
                    cmbTipoHabitacion.SelectedValue = reserva.Habitacion.TipoHabitacion.IdTipoHabitacion.ToString();                    

                    using (AdministracionClient objHabitacion = new AdministracionClient())
                    {
                        cmbHbitacion.DataSource = objHabitacion.AdminHabitaciones(ServicioAdministracion.Constantes.Listar).Where(f => f.TipoHabitacion.IdTipoHabitacion == Convert.ToInt32(cmbTipoHabitacion.SelectedValue)).ToList();
                        cmbHbitacion.DataTextField = "Numero";
                        cmbHbitacion.DataValueField = "IdHabitacion";
                        cmbHbitacion.DataBind();
                    }
                    cmbHbitacion.SelectedValue = reserva.Habitacion.IdHabitacion.ToString();


                    if (cmbFormaPago.SelectedValue == "EF") { txtNroTarjeta.Enabled = false; }
                    else {  txtNroTarjeta.Enabled = true; }

                    if (reserva.Pasajero != null)
                    {
                        ViewState["Pasajeros"] = reserva.Pasajero;
                        gdListadoPasajeros.DataSource = (List<Pasajero>)ViewState["Pasajeros"];
                        gdListadoPasajeros.DataBind();
                    }
                                          
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
            List<Pasajero> listapasajeros = new List<Pasajero>();
            if (ViewState["Pasajeros"] != null)
                listapasajeros = (List<Pasajero>)ViewState["Pasajeros"];

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
                    reserva.Pasajero = listapasajeros;
                    reserva.FechaLlegada = DateTime.ParseExact(txtFechaLlegada.Text +" "+ txtHoraLlegada.Text, "dd/MM/yyyy HH:mm:ss" , System.Globalization.CultureInfo.InvariantCulture);
                    reserva.FechaSalida = DateTime.ParseExact(txtFechaSalida.Text+" " + txtHoraSalida.Text , "dd/MM/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
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
                    reserva.Pasajero = listapasajeros;
                    reserva.FechaLlegada = DateTime.ParseExact(txtFechaLlegada.Text + " " + txtHoraLlegada.Text, "dd/MM/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
                    reserva.FechaSalida = DateTime.ParseExact(txtFechaSalida.Text + " " + txtHoraSalida.Text, "dd/MM/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
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

    protected void cmbTipoHabitacion_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            using (AdministracionClient objHabitacion = new AdministracionClient())
            {
                List<ServicioAdministracion.Habitacion> listahabitacion = objHabitacion.AdminHabitaciones(ServicioAdministracion.Constantes.Listar);

                cmbHbitacion.DataSource = listahabitacion.Where(f => f.TipoHabitacion.IdTipoHabitacion == Convert.ToInt32(cmbTipoHabitacion.SelectedValue)).ToList();
                cmbHbitacion.DataTextField = "Numero";
                cmbHbitacion.DataValueField = "IdHabitacion";
                cmbHbitacion.DataBind();

            }
        }
        catch (Exception ex)
        {
            divError.InnerHtml = ex.Message;
            divError.Visible = true;
        }
    }
    protected void btnAgregarPasajero_Click(object sender, EventArgs e)
    {
        pnPasajero.Visible = true;
        txtNombres.Text = "";
        txtApellidoMat.Text = "";
        txtApellidoPat.Text = "";
    }
    protected void btnCancelarPasajero_Click(object sender, EventArgs e)
    {
        pnPasajero.Visible = false;
        txtNombres.Text = "";
        txtApellidoMat.Text = "";
        txtApellidoPat.Text = "";
    }
    protected void btnGuardarPasajero_Click(object sender, EventArgs e)
    {
        try
        {
            CargarPasajeros(txtNombres.Text, txtApellidoPat.Text, txtApellidoMat.Text);
        }
        catch (Exception ex)
        {
            divError.InnerHtml = ex.Message;
            divError.Visible = true;
        }
    }
    protected void gdListadoPasajeros_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "EliminarData")
            {
                GridViewRow row = (GridViewRow)(((Button)e.CommandSource).NamingContainer);
                //gdListadoPasajeros.DeleteRow(row.RowIndex);
                //ViewState["Pasajeros"] = (List<Pasajero>) gdListadoPasajeros.DataSource;
                List<Pasajero> lista = (List<Pasajero>)ViewState["Pasajeros"];
                lista.Remove(  lista.Where( f=> f.NombrePasajero==row.Cells[0].Text && f.ApellidoPaterno==row.Cells[1].Text && f.ApellidoMaterno==row.Cells[2].Text  ).First() );
                ViewState["Pasajeros"] = lista;
                gdListadoPasajeros.DataSource = lista;
                gdListadoPasajeros.DataBind();
            }
        }
        catch (Exception ex)
        {
            divError.InnerHtml = ex.Message;
            divError.Visible = true;
        }
    }

}