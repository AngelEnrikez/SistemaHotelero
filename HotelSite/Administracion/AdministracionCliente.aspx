<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.master" AutoEventWireup="true" CodeFile="AdministracionCliente.aspx.cs" Inherits="Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="panel panel-primary" style="width: 950px">
        <div class="panel-heading">Mantenimiento de Clientes</div>

        <div class="panel-body">
            <table class="table" style="width: 60%">
                <tr>
                    <td>
                        <asp:Label ID="lblNombres" runat="server" Text="Nombres:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtNombres" class="input-group-addon" MaxLength="80" runat="server" Width="300px"></asp:TextBox>
                    </td>
                </tr>
                 <tr>
                    <td>
                        <asp:Label ID="lblApellidoPat" runat="server" Text="Apellido Paterno:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtApellidoPat" class="input-group-addon" MaxLength="100" runat="server" Width="300px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblApellidoMat" runat="server" Text="Apellido Materno:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtApellidoMat" MaxLength="100" class="input-group-addon" runat="server" Width="300px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblTipoDocumento" runat="server" Text="Tipo Documento:"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="cmbTipoDocumento" runat="server" Height="16px" Width="200px">
                        </asp:DropDownList>
                    </td>
                </tr>
                 <tr>
                    <td>
                        <asp:Label ID="lblNumeroDocumento" runat="server" Text="Nro Documento:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtNumeroDocumento" class="input-group-addon" MaxLength="20" runat="server" Width="100px"></asp:TextBox>
                    </td>
                </tr>
                 <tr>
                    <td>
                        <asp:Label ID="lblEmail" runat="server" Text="Email:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtEmail" class="input-group-addon" runat="server" MaxLength="50" Width="200px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblTelefono" runat="server" Text="Teléfono:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtTelefono" class="input-group-addon" runat="server" MaxLength="20" Width="100px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblPais" runat="server" Text="Pais:"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="cmbPais" runat="server" Height="16px" Width="250px">
                        </asp:DropDownList>
                    </td>
                </tr>

            </table>
        </div>
        <div class="panel-footer">
            <asp:Button ID="btnGuardar" class="btn btn-default" runat="server" Text="Guardar" OnClick="btnGuardar_Click" />
            <asp:Button ID="btnCancelar" class="btn btn-default" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" />
            <asp:HiddenField ID="hdAgregarActualizar" runat="server" />
            <asp:HiddenField ID="hdCodigo" runat="server" Value="0" />
        </div>
        <div id="divError" class="alert alert-danger" runat="server" visible="false" role="alert">Error</div>
    </div>
</asp:Content>

