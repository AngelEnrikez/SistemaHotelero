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
}