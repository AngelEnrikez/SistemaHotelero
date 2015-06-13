<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.master" AutoEventWireup="true" CodeFile="CheckOut.aspx.cs" Inherits="Mantenimientos_CheckOut" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </cc1:ToolkitScriptManager>
    <div class="panel panel-primary" style="width: 700px">
        <div class="panel-heading">Realizar Check-Out</div>

        <div class="panel-body">
            <table class="table" style="width: 60%">
                <tr>
                    <td>C&oacute;digo Reserva</td>
                    <td colspan="2">
                        <asp:TextBox ID="txtCodigo" class="input-group-addon" runat="server" Width="253px" ReadOnly="true"></asp:TextBox>
                    </td>
                </tr>

                <tr>
                    <td>Habitaci&oacute;n</td>
                    <td colspan="2">
                        <asp:TextBox ID="txtHabitacion" class="input-group-addon" runat="server" Width="253px" ReadOnly="true"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Cliente</td>
                    <td colspan="2">
                        <asp:TextBox ID="txtCliente" class="input-group-addon" runat="server" Width="253px" ReadOnly="true"></asp:TextBox>
                    </td>

                </tr>
                <tr>
                    <td>Fecha/Hora Check-In</td>
                    <td>
                        <asp:TextBox ID="txtCheckIn" class="input-group-addon" runat="server" Width="253px" ReadOnly="true"></asp:TextBox>
                    </td>
                </tr>

                <tr>
                    <td>Comentarios</td>
                    <td colspan="2">
                        <asp:TextBox ID="txtComentario" class="input-group-addon" runat="server" Width="253px" Height="62px" TextMode="MultiLine"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </div>




        <div class="panel-footer">
            <asp:Button ID="btnCheckOut" class="btn btn-default" runat="server" Text="Check-Out" OnClick="btnCheckOut_Click" />
            <asp:Button ID="btnCancelar" class="btn btn-default" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" />
        </div>

        <asp:HiddenField ID="hdCodigo" runat="server" Value="0" />
        <div id="divError" class="alert alert-info" runat="server" visible="false" role="alert">Mensaje</div>
    </div>


</asp:Content>

