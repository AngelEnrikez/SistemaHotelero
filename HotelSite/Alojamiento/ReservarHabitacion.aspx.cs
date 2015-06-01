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
                cmbHbitacion.DataSource = objHabitacion.AdminHabitaciones(ServicioAdministracion.Constantes.Listar );
                cmbHbitacion.DataTextField = "Descripcion";
                cmbHbitacion.DataValueField = "IdTipoHabitacion";
                cmbHbitacion.DataBind();
            }
            using (AdministracionClient objCliente = new AdministracionClient())
            {
                cmbCliente.DataSource = objCliente.AdminClientes(ServicioAdministracion.Constantes.Listar,null,0);
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


}