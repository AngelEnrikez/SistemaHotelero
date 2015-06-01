using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ServicioAlojamiento;

public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!this.IsPostBack)
            {
                Listar();
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
    private void Listar()
    {
        try
        {
            gdListado.DataSource = null;
            gdListado.DataBind();
            using (AlojamientoClient objReserva = new AlojamientoClient())
            {
                List<Reserva> clientes = objReserva.ReservarHabitacion(Constantes.Listar, null, 0);
                if (clientes.Count > 0)
                {
                    //hdMaxCodigo.Value = (clientes.Max(r => r.IdCliente) + 1).ToString();
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
    protected void btnAgregar_Click(object sender, EventArgs e)
    {
        Response.Redirect("ReservarHabitacion.aspx?cod=0&accion=N", true);
    }
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
                Listar();
            }
            if (e.CommandName == "ModificarData")
            {
                GridViewRow row = (GridViewRow)(((Button)e.CommandSource).NamingContainer);
                HiddenField hdnDataId = (HiddenField)row.FindControl("hdGridCodigo");
                Response.Redirect("ReservarHabitacion.aspx?cod=" + hdnDataId.Value + "&accion=A", true);
            }
        }
        catch (Exception ex)
        {
            divError.InnerHtml = ex.Message;
            divError.Visible = true;
        }
    }
}