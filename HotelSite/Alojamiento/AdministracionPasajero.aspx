<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.master" AutoEventWireup="true" CodeFile="AdministracionPasajero.aspx.cs" Inherits="Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="panel panel-primary" style="width: 950px">
        <div class="panel-heading">Mantenimiento de Pasajeros</div>

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
                
            </table>
        </div>
        <div class="panel-footer">            
            <input id="btnGuardar"   class="btn btn-default" type="button" value="Guardar" onclick="document.getElementById('ContentPlaceHolder1_hdAccion').value = 'G'; CerrarPopup(document.getElementById('ContentPlaceHolder1_hdEspoup').value, 'G');" />            
            <input id="btnCancelar"   class="btn btn-default" type="button" value="Cancelar" onclick="document.getElementById('ContentPlaceHolder1_hdAccion').value = 'C'; CerrarPopup(document.getElementById('ContentPlaceHolder1_hdEspoup').value, 'C');" />            
            <asp:HiddenField ID="hdAgregarActualizar" runat="server" />
            <asp:HiddenField ID="hdCodigo" runat="server" Value="0" />
            <asp:HiddenField ID="hdAccion" runat="server" />
        </div>
        <div id="divError" class="alert alert-info" runat="server" visible="false" role="alert">Mensaje</div>
    </div>
</asp:Content>

