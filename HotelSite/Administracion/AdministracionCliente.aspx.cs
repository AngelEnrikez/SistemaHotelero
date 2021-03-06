﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ServicioAdministracion;

public partial class Default2 : System.Web.UI.Page
{
    protected override void OnPreInit(EventArgs e)
    {
        if (Request.QueryString["espopup"] != null)
            if (Request.QueryString["espopup"] == "1")
                this.MasterPageFile = "~/MasterBlank.master";
        base.OnPreInit(e);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!this.IsPostBack)
            {
                hdAgregarActualizar.Value = Request.QueryString["accion"].ToString();
                hdCodigo.Value = Request.QueryString["cod"].ToString();
                if (Request.QueryString["espopup"] != null)
                    hdEspoup.Value = Request.QueryString["espopup"];

                MostrarItems();
                MostrarRegistro();
            }
            else
            {
                if (hdAccion.Value == "C") Cancelar();
                else if (hdAccion.Value == "G")  Guardar();
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
            using (AdministracionClient objPais = new AdministracionClient())
            {
                cmbPais.DataSource = objPais.AdminPaises(Constantes.Listar);
                cmbPais.DataTextField = "NombrePais";
                cmbPais.DataValueField = "IdPais";
                cmbPais.DataBind();
            }
            using (AdministracionClient objTipoDocumento = new AdministracionClient())
            {
                cmbTipoDocumento.DataSource = objTipoDocumento.AdminTDocumentos(Constantes.Listar);
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
    private void MostrarRegistro()
    {
        try
        {
            if (hdAgregarActualizar.Value == "A")
            {
                using (AdministracionClient objCliente = new AdministracionClient())
                {
                    Cliente cliente;
                    cliente = objCliente.AdminClientes(Constantes.Obtener, null, Convert.ToInt32(hdCodigo.Value))[0];
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
    private void Guardar()
    {
        try
        {
            using (AdministracionClient objCliente = new AdministracionClient())
            {
                TipoDocumento tipoDocumento = new TipoDocumento();
                Pais pais = new Pais();
                Cliente cliente = new Cliente();
                if (hdAgregarActualizar.Value == "N")
                {
                    cliente.Nombre = txtNombres.Text.Trim();
                    cliente.ApellidoPaterno = txtApellidoPat.Text.Trim();
                    cliente.ApellidoMaterno = txtApellidoMat.Text.Trim();
                    cliente.Telefono = txtTelefono.Text.Trim();
                    tipoDocumento.IdTipoDocumento = Convert.ToInt32(cmbTipoDocumento.SelectedValue);
                    cliente.TipoDocumento = tipoDocumento;
                    cliente.NumeroDocumento = txtNumeroDocumento.Text.Trim();
                    cliente.Email = txtEmail.Text.Trim();
                    pais.IdPais = Convert.ToInt32(cmbPais.SelectedValue);
                    cliente.Pais = pais;
                    objCliente.AdminClientes(Constantes.Crear, cliente, 0);
                }
                else if (hdAgregarActualizar.Value == "A")
                {
                    cliente.IdCliente = Convert.ToInt32(hdCodigo.Value);
                    cliente.Nombre = txtNombres.Text.Trim();
                    cliente.ApellidoPaterno = txtApellidoPat.Text.Trim();
                    cliente.ApellidoMaterno = txtApellidoMat.Text.Trim();
                    cliente.Telefono = txtTelefono.Text.Trim();
                    tipoDocumento.IdTipoDocumento = Convert.ToInt32(cmbTipoDocumento.SelectedValue);
                    cliente.TipoDocumento = tipoDocumento;
                    cliente.NumeroDocumento = txtNumeroDocumento.Text.Trim();
                    cliente.Email = txtEmail.Text.Trim();
                    pais.IdPais = Convert.ToInt32(cmbPais.SelectedValue);
                    cliente.Pais = pais;
                    objCliente.AdminClientes(Constantes.Modificar, cliente, 0);
                }
            }
            if (hdAccion.Value == "G"  && hdEspoup.Value =="1")
                ClientScript.RegisterStartupScript(this.GetType(), "cerrar", "<script>window.opener.__doPostBack('','cargarclientes');window.close();</script>");
            else
                Response.Redirect("ListarCliente.aspx", true);

        }
        catch (Exception ex)
        {
            divError.InnerHtml = ex.Message;
            divError.Visible = true;
        }
    }

    /// <summary>
    /// Cancela y retorna a la pagina de listado
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Cancelar() { Response.Redirect("ListarCliente.aspx", true); }
}