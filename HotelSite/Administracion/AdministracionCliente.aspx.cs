using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ServicioClientes;
using ServicioPaises;
using ServicioTiposDocumento;

public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!this.IsPostBack)
            {
                hdAgregarActualizar.Value = Request.QueryString["accion"].ToString() ;
                hdCodigo.Value = Request.QueryString["cod"].ToString();
                MostrarItems();
                MostrarRegistro();
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
    private void MostrarItems() {
        try
        {
            using (PaisesClient objPais = new PaisesClient())
            {
                cmbPais.DataSource = objPais.ListarPais();
                cmbPais.DataTextField = "NombrePais";
                cmbPais.DataValueField = "IdPais";
                cmbPais.DataBind();
            }
            using (TiposDocumentoClient objTipoDocumento = new TiposDocumentoClient())
            {
                cmbTipoDocumento.DataSource = objTipoDocumento.ListarTipoDocumento();
                cmbTipoDocumento.DataTextField = "Descripcion";
                cmbTipoDocumento.DataValueField = "IdTipoDocumento";
                cmbTipoDocumento.DataBind();
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
    private void MostrarRegistro() {
        try
        {
            if (hdAgregarActualizar.Value == "A")
            {
                using (ServicioClientes.ClientesClient objCliente = new ClientesClient())
                {
                    ServicioClientes.Cliente cliente;
                    cliente = objCliente.ObtenerCliente(Convert.ToInt32(hdCodigo.Value));
                    txtNombres.Text = cliente.Nombre;
                    txtApellidoPat.Text = cliente.ApellidoPaterno;
                    txtApellidoMat.Text = cliente.ApellidoMaterno;
                    cmbTipoDocumento.SelectedValue = cliente.TipoDocumento.IdTipoDocumento.ToString();
                    txtNumeroDocumento.Text = cliente.NumeroDocumento;
                    txtEmail.Text = cliente.Email;
                    txtTelefono.Text = cliente.Telefono;
                    cmbPais.SelectedValue = cliente.Pais.IdPais.ToString();
                }
            }
        }
        catch (Exception ex)
        {
            throw ex; 
        }
        
    }

    /// <summary>
    /// Guarda los registros
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnGuardar_Click(object sender, EventArgs e)
    {
        string mensaje = null;

        try
        {
            using (ServicioClientes.ClientesClient objCliente = new ClientesClient())
            {
                if (hdAgregarActualizar.Value == "N")
                {
                    mensaje = objCliente.CrearCliente(
                        Convert.ToInt32(cmbTipoDocumento.SelectedValue),
                        txtNombres.Text.Trim(),
                        txtApellidoPat.Text.Trim(),
                        txtApellidoMat.Text.Trim(),
                        txtNumeroDocumento.Text.Trim(),
                        txtEmail.Text.Trim(),
                        txtTelefono.Text.Trim(),
                        Convert.ToInt32(cmbPais.SelectedValue));
                }
                else if (hdAgregarActualizar.Value == "A")
                {
                    mensaje = objCliente.ModificarCliente(
                       Convert.ToInt32(hdCodigo.Value),
                       Convert.ToInt32(cmbTipoDocumento.SelectedValue),
                       txtNombres.Text.Trim(),
                       txtApellidoPat.Text.Trim(),
                       txtApellidoMat.Text.Trim(),
                       txtNumeroDocumento.Text.Trim(),
                       txtEmail.Text.Trim(),
                       txtTelefono.Text.Trim(),
                       Convert.ToInt32(cmbPais.SelectedValue));
                }
            }
        }
        catch (Exception ex)
        {
            divError.InnerHtml = ex.Message;
            divError.Visible = true;
        }

        if (mensaje == "Grabacion Exitosa")
        {
            Response.Redirect("ListarCliente.aspx", true);
        }
        else
        {
            divError.InnerText = mensaje;
            divError.Visible = true;
        }
        

    }

    /// <summary>
    /// Cancela y retorna a la pagina de listado
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        Response.Redirect("ListarCliente.aspx", true);
    }
}