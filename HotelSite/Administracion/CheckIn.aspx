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
                    <td>
                        <asp:TextBox ID="TextBox1" class="input-group-addon" runat="server" Width="253px"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Button ID="btnConsultarReserva" class="btn btn-default" runat="server" Text="Consultar" />
                    </td>

                    
                </tr>

                <tr>
                    <td>Nombre</td>
                    <td colspan="2">
                        <asp:TextBox ID="TextBox2" class="input-group-addon" runat="server" Width="253px" ReadOnly="True"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Apellido Paterno</td>
                    <td colspan="2">
                        <asp:TextBox ID="TextBox3" class="input-group-addon" runat="server" Width="253px"></asp:TextBox>
                    </td>

                </tr>
                <tr>
                    <td>Apellido Materno</td>
                    <td colspan="2">
                        <asp:TextBox ID="TextBox4" class="input-group-addon" runat="server" Width="253px"></asp:TextBox>
                    </td>

                </tr>
                <tr>
                    <td>Tipo de Habitación </td>
                    <td colspan="2">
                        <asp:TextBox ID="TextBox5" class="input-group-addon" runat="server" Width="253px"></asp:TextBox>
                    </td>

                </tr>
                <tr>
                    <td>Fecha Ingreso</td>
                    <td>
                        <asp:TextBox ID="txtDate" runat="server" ReadOnly="true"></asp:TextBox>
                        <asp:ImageButton ID="imgPopup" ImageUrl="~/Images/text_calendar.png" ImageAlign="Bottom"
                            runat="server" Height="20px" Width="28px" />
                        <cc1:CalendarExtender ID="Calendar1" PopupButtonID="imgPopup" runat="server" TargetControlID="txtDate"
                            Format="dd/MM/yyyy">
                        </cc1:CalendarExtender>
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td>Fecha Salida</td>
                    <td>
                        <asp:TextBox ID="txtDate0" runat="server" ReadOnly="true"></asp:TextBox>
                        <cc1:CalendarExtender ID="txtDate0_CalendarExtender" PopupButtonID="imgPopup" runat="server" TargetControlID="txtDate0"
                            Format="dd/MM/yyyy">
                        </cc1:CalendarExtender>
                        <asp:ImageButton ID="imgPopup0" ImageUrl="~/Images/text_calendar.png" ImageAlign="Bottom"
                            runat="server" Height="20px" Width="28px" />
                    </td>
                    <td></td>
                </tr>

            </table>
        </div>




        <div class="panel-footer">
            <asp:Button ID="Button1" class="btn btn-default" runat="server" Text="Agregar" />
        </div>
        <div class="alert alert-info" role="alert">El check-in se ha realizado con éxito</div>

    </div>


</asp:Content>

