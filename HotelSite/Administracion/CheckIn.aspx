<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.master" AutoEventWireup="true" CodeFile="CheckIn.aspx.cs" Inherits="Mantenimientos_CheckIn" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </cc1:ToolkitScriptManager>
    <div class="panel panel-primary" style="width: 700px">
        <div class="panel-heading">Realizar Check-In</div>

        <div class="panel-body">
            <table class="table" style="width: 60%">
                <tr>
                    <td>
                        <asp:Label ID="Label1" runat="server" Text="Codigo Reserva"></asp:Label>
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="txtCodigoReserva" class="input-group-addon" runat="server" Width="253px" ReadOnly="true"></asp:TextBox>
                        <asp:HiddenField runat="server" ID="hdfCodigoReserva" Value="-1"/>
                   </td>
                </tr>
                <tr>
                    <td>Nombre</td>
                    <td colspan="2">
                        <asp:TextBox ID="txtCliente" class="input-group-addon" runat="server" Width="253px" ReadOnly="True"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Habitacion</td>
                    <td colspan="2">
                        <asp:TextBox ID="txtHabitacion" class="input-group-addon" runat="server" Width="253px" ReadOnly="true"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Tipo de Habitación </td>
                    <td colspan="2">
                        <asp:TextBox ID="txtTipoHabitacion" class="input-group-addon" runat="server" Width="253px" ReadOnly="true"></asp:TextBox>
                    </td>

                </tr>
                <tr>
                    <td>Fecha Ingreso</td>
                    <td colspan="2">
                        <asp:TextBox ID="txtFechaInicio" class="input-group-addon" runat="server" Width="253px" ReadOnly="true"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Fecha Salida</td>
                    <td colspan="2">
                        <asp:TextBox ID="txtFechaFin" class="input-group-addon" runat="server" Width="253px" ReadOnly="true"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Comentarios </td>
                    <td colspan="2">
                        <asp:TextBox ID="txtComentarios" class="input-group-addon" runat="server" Width="100%" Height="100px" TextMode="MultiLine"></asp:TextBox>
                    </td>

                </tr>
            </table>
        </div>

        <div class="panel-footer">
            <asp:Button ID="btnCheckIn" class="btn btn-default" runat="server" Text="CheckIn" OnClick="btnCheckIn_Click" />
            <asp:Button ID="btnCancelar" class="btn btn-default" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" />
        </div>
        <div id="divError" class="alert alert-info" runat="server" visible="false" role="alert">Mensaje</div>

    </div>


</asp:Content>

