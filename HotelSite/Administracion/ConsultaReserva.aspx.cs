using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ServicioAlojamiento;

public partial class Administracion_ListarReserva : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!this.IsPostBack)
            {
                txtChekIndel.Attributes.Add("readonly", "readonly");
                txtChekInal.Attributes.Add("readonly", "readonly");
                txtChekOutdel.Attributes.Add("readonly", "readonly");
                txtChekOutal.Attributes.Add("readonly", "readonly");
                Listar(0,string.Empty,string.Empty,string.Empty,string.Empty);
            }
        }
        catch (Exception ex)
        {
            divError.InnerHtml = ex.Message;
            divError.Visible = true;
        }
    }

    /// <summary>
    /// Listar el registro
    /// </summary>
    private void Listar(int codigo, string fechaChekIndel, string fechaChekInAl, string fechaChekOutdel, string fechaChekOutal) // agrego parametros 
    {
        try
        {
            gdListado.DataSource = null;
            gdListado.DataBind();
            using (AlojamientoClient objCliente = new AlojamientoClient())
            {

                List<Reserva> clientes = objCliente.ReservarHabitacion(Constantes.Listar, null, 0);
                if (clientes.Count > 0)
                {

                    if (codigo > 0) 
                    {
                        clientes = clientes.FindAll(delegate(Reserva r) { return r.IdReserva == codigo; });
                    }

                    if (fechaChekIndel != "")
                    {
                        clientes = clientes.FindAll(delegate(Reserva r) { return r.FechaHoraCheckin >= Convert.ToDateTime(fechaChekIndel); });
                    }

                    if (fechaChekInAl != "")
                    {
                        clientes = clientes.FindAll(delegate(Reserva r) { return r.FechaHoraCheckin <= Convert.ToDateTime(fechaChekInAl); });
                    }

                    if (fechaChekOutdel != "")
                    {
                        clientes = clientes.FindAll(delegate(Reserva r) { return r.FechaHoraCheckout >= Convert.ToDateTime(fechaChekOutdel); });
                    }

                    if (fechaChekOutal != "")
                    {
                        clientes = clientes.FindAll(delegate(Reserva r) { return r.FechaHoraCheckout >= Convert.ToDateTime(fechaChekOutal); });
                    }

                    gdListado.DataSource = clientes;
                    gdListado.DataBind();
                }
                else
                {
                    hdMaxCodigo.Value = "1";
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
         /// <summary>
    /// Eliminar el registro
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gdListado_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "DeleteData")
            {
                GridViewRow row = (GridViewRow)(((Button)e.CommandSource).NamingContainer);
                HiddenField hdnDataId = (HiddenField)row.FindControl("hdGridCodigo");
                using (AlojamientoClient objReserva = new AlojamientoClient())
                {
                    objReserva.ReservarHabitacion(Constantes.Eliminar, new Reserva() { IdReserva = Convert.ToInt32(hdnDataId.Value) }, 0);
                }
                Listar(0, string.Empty, string.Empty, string.Empty, string.Empty);
            }
            if (e.CommandName == "ModificarData")
            {
                GridViewRow row = (GridViewRow)(((Button)e.CommandSource).NamingContainer);
                HiddenField hdnDataId = (HiddenField)row.FindControl("hdGridCodigo");
                Response.Redirect("ReservarHabitacion.aspx?cod=" + hdnDataId.Value + "&accion=A", true);
            }
            if (e.CommandName == "CheckOut")
            {
                GridViewRow row = (GridViewRow)(((Button)e.CommandSource).NamingContainer);
                HiddenField hdnDataId = (HiddenField)row.FindControl("hdGridCodigo");
                Response.Redirect("CheckOut.aspx?cod=" + hdnDataId.Value, true);
            }
        }
        catch (Exception ex)
        {
            divError.InnerHtml = ex.Message;
            divError.Visible = true;
        }

    }

    protected void btnAgregar_Click(object sender, EventArgs e)
    {
        Response.Redirect("AdministracionCliente.aspx?cod=0&accion=N", true);
    }

    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        Int32 codigo;
        Int32.TryParse(txtCodigo.Value, out codigo);
        Listar(codigo, txtChekIndel.Text, txtChekInal.Text,txtChekOutdel.Text,txtChekOutal.Text);
    }


    protected void btnLimpiar_Click(object sender, EventArgs e)
    {
        this.txtCodigo.Value = "";
        this.txtChekInal.Text = "";
        this.txtChekIndel.Text = "";

        this.txtChekOutdel.Text = "";
        this.txtChekOutal.Text = "";

        this.txtCodigo.Focus();



    }


    
}