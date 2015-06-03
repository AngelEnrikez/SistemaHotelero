<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.master" AutoEventWireup="true" CodeFile="ReservarHabitacion.aspx.cs" Inherits="Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="panel panel-primary" style="width: 950px">
        <div class="panel-heading">Mantenimiento de Clientes</div>

        <div class="panel-body">
            <table class="table" style="width: 60%">
                <tr>
                    <td>
                        <asp:Label ID="lblCliente" runat="server" Text="Cliente:"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="cmbCliente" runat="server" Height="16px" Width="200px">
                        </asp:DropDownList>
                    </td>
                </tr>
                 <tr>
                    <td>
                        <asp:Label ID="lblHabitacion" runat="server" Text="Habitación:"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="cmbHbitacion" runat="server" Height="16px" Width="50px">
                        </asp:DropDownList>
                       
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblFechaLlegada" runat="server" Text="Fecha llegada Cliente:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtFechaLlegada" MaxLength="100" class="input-group-addon" runat="server" Width="60px"></asp:TextBox>
                        <asp:Label ID="lblFormatofecha1" runat="server" Text="dd/MM/yyyy HH:mm:ss"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblFechaSalida" runat="server" Text="Fecha salida Cliente:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtFechaSalida" MaxLength="100" class="input-group-addon" runat="server" Width="60px"></asp:TextBox>
                        <asp:Label ID="lblFormatofecha2" runat="server" Text="dd/MM/yyyy HH:mm:ss"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblFormaPago" runat="server" Text="Forma de Pago:"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="cmbFormaPago" runat="server" Height="16px" Width="150px" AutoPostBack="True" OnSelectedIndexChanged="cmbFormaPago_SelectedIndexChanged">
                            <asp:ListItem Value="TM">MasterCard</asp:ListItem>
                            <asp:ListItem Value="TV">Visa</asp:ListItem>
                            <asp:ListItem Value="TA">American Express</asp:ListItem>
                            <asp:ListItem Value="TD">Dinners Club</asp:ListItem>
                            <asp:ListItem Value="EF">Efectivo</asp:ListItem>
                        </asp:DropDownList>
                       
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblNroTarjeta" runat="server" Text="Nro de Tarjeta:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtNroTarjeta" MaxLength="20" class="input-group-addon" runat="server" Width="100px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblObservaciones" runat="server" Text="Observaciones:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtObservaciones" class="input-group-addon" runat="server" MaxLength="20" Width="200px" Height="42px" TextMode="MultiLine"></asp:TextBox>
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
        <div id="divError" class="alert alert-info" runat="server" visible="false" role="alert">Mensaje</div>
    </div>
</asp:Content>

