using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ServicioAdministracion;

public partial class Default2 : System.Web.UI.Page
{
    /// <summary>
    /// Inicio
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
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
            using (AdministracionClient objCliente = new AdministracionClient())
            {
                List<Cliente> clientes = objCliente.AdminClientes(Constantes.Listar, null,0);
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
                using (AdministracionClient objCliente = new AdministracionClient())
                {
                    objCliente.AdminClientes(Constantes.Eliminar, new Cliente (){IdCliente=Convert.ToInt32(hdnDataId.Value)},0);
                }
                Listar();
            }
            if (e.CommandName == "ModificarData")
            {
                GridViewRow row = (GridViewRow)(((Button)e.CommandSource).NamingContainer);
                HiddenField hdnDataId = (HiddenField)row.FindControl("hdGridCodigo");
                Response.Redirect("AdministracionCliente.aspx?cod=" + hdnDataId.Value + "&accion=A", true);
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
}