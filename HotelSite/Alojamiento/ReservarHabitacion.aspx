<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.master" AutoEventWireup="true" CodeFile="ReservarHabitacion.aspx.cs" Inherits="Default2" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="panel panel-primary" style="width: 950px">
        <div class="panel-heading">Mantenimiento de Reservas</div>

        <div class="panel-body">
            <table class="table" style="width: 60%">
                <tr>
                    <td>
                        <asp:Label ID="lblCliente" runat="server" Text="Cliente:"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="cmbCliente" runat="server" Height="25px" Width="200px">
                        </asp:DropDownList>


                        <input id="btnAgregarCliente" runat="server" class="btn btn-default" type="button" value="..." /></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblTipoHabitacion" runat="server" Text="Tipo habitación:"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="cmbTipoHabitacion" runat="server" Height="25px" Width="150px" AutoPostBack="True" OnSelectedIndexChanged="cmbTipoHabitacion_SelectedIndexChanged">
                        </asp:DropDownList>

                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblHabitacion" runat="server" Text="Habitación:"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="cmbHbitacion" runat="server" Height="25px" Width="130px">
                        </asp:DropDownList>

                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblPasajeros" runat="server" Text="Pasajeros"></asp:Label>
                    </td>
                    <td>
                        <asp:Button ID="btnAgregarPasajero" class="btn btn-default" runat="server" Text="Agregar pasajero" OnClick="btnAgregarPasajero_Click" />
                        <br />
                        <asp:Panel ID="pnPasajero" runat="server" Visible="False">
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
                                    <td colspan="2">
                                        <asp:Button ID="btnGuardarPasajero" class="btn btn-default" runat="server" Text="Guardar" OnClick="btnGuardarPasajero_Click" />
                                        <asp:Button ID="btnCancelarPasajero" class="btn btn-default" runat="server" Text="Cancelar" OnClick="btnCancelarPasajero_Click" />
                                    </td>
                                </tr>

                            </table>
                        </asp:Panel>

                        <asp:GridView ID="gdListadoPasajeros" CssClass="table" runat="server" EnableViewState="true" Width="100%" AutoGenerateColumns="False" OnRowCommand="gdListadoPasajeros_RowCommand">
                            <Columns>
                                <asp:BoundField HeaderStyle-CssClass="hidden-xs" ItemStyle-CssClass="hidden-xs" HeaderText="Nombre" DataField="NombrePasajero">
                                    <HeaderStyle CssClass="hidden-xs"></HeaderStyle>

                                    <ItemStyle CssClass="hidden-xs"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField HeaderStyle-CssClass="hidden-xs" ItemStyle-CssClass="hidden-xs" HeaderText="Apellido Paterno" DataField="ApellidoPaterno">
                                    <HeaderStyle CssClass="hidden-xs"></HeaderStyle>

                                    <ItemStyle CssClass="hidden-xs"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="ApellidoMaterno" HeaderText="Apellido Materno" />
                                <asp:TemplateField HeaderText="Eliminar">
                                    <ItemTemplate>
                                        <asp:Button ID="btnGridEliminar" Width="40px" CommandName="EliminarData" class="btn btn-default btn-xs" runat="server" Text="..." />
                                    </ItemTemplate>
                                    <ItemStyle Width="50px" />
                                </asp:TemplateField>
                            </Columns>
                            <RowStyle CssClass="rowStyle" />
                            <HeaderStyle CssClass="headerStyle" />
                            <FooterStyle CssClass="footerStyle" />
                            <PagerStyle HorizontalAlign="Center" />
                        </asp:GridView>

                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblFechaLlegada" runat="server" Text="Fecha llegada Cliente:"></asp:Label>
                    </td>
                    <td>
                        <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
                        </cc1:ToolkitScriptManager>

                        <asp:TextBox ID="txtFechaLlegada" MaxLength="100" ValidationGroup="MKE" class="input-group-addon" runat="server" Width="100px"></asp:TextBox>

                        <asp:TextBox ID="txtHoraLlegada" MaxLength="50" ValidationGroup="MKE" class="input-group-addon" runat="server" Width="80px"></asp:TextBox>

                        <cc1:MaskedEditExtender ID="MaskedEditExtender5" runat="server"
                            TargetControlID="txtFechaLlegada"
                            Mask="99/99/9999"
                            MessageValidatorTip="true"
                            OnFocusCssClass="MaskedEditFocus"
                            OnInvalidCssClass="MaskedEditError"
                            MaskType="Date"
                            DisplayMoney="Left"
                            AcceptNegative="Left"
                            ErrorTooltipEnabled="True" UserDateFormat="DayMonthYear" />
                        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy" TargetControlID="txtFechaLlegada" PopupButtonID="ImgBntCalc" />

                        <cc1:MaskedEditExtender ID="MaskedEditExtender3" runat="server"
                            TargetControlID="txtHoraLlegada"
                            Mask="99:99:99"
                            MessageValidatorTip="true"
                            OnFocusCssClass="MaskedEditFocus"
                            OnInvalidCssClass="MaskedEditError"
                            MaskType="Time"
                            AcceptAMPM="False"
                            ErrorTooltipEnabled="True" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblFechaSalida" runat="server" Text="Fecha salida Cliente:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtFechaSalida" MaxLength="100" class="input-group-addon" runat="server" Width="70px"></asp:TextBox>
                        <asp:TextBox ID="txtHoraSalida" MaxLength="50" ValidationGroup="MKE" class="input-group-addon" runat="server" Width="80px"></asp:TextBox>

                        <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server"
                            TargetControlID="txtFechaSalida"
                            Mask="99/99/9999"
                            MessageValidatorTip="true"
                            OnFocusCssClass="MaskedEditFocus"
                            OnInvalidCssClass="MaskedEditError"
                            MaskType="Date"
                            DisplayMoney="Left"
                            AcceptNegative="Left"
                            ErrorTooltipEnabled="True" UserDateFormat="DayMonthYear" />
                        <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd/MM/yyyy" TargetControlID="txtFechaSalida" PopupButtonID="ImgBntCalc" />

                        <cc1:MaskedEditExtender ID="MaskedEditExtender2" runat="server"
                            TargetControlID="txtHoraSalida"
                            Mask="99:99:99"
                            MessageValidatorTip="true"
                            OnFocusCssClass="MaskedEditFocus"
                            OnInvalidCssClass="MaskedEditError"
                            MaskType="Time"
                            AcceptAMPM="False"
                            ErrorTooltipEnabled="True" />

                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblFormaPago" runat="server" Text="Forma de Pago:"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="cmbFormaPago" runat="server" Height="25px" Width="150px" AutoPostBack="True" OnSelectedIndexChanged="cmbFormaPago_SelectedIndexChanged">
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
                        <asp:TextBox ID="txtNroTarjeta" MaxLength="30" class="input-group-addon" runat="server" Width="100px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblObservaciones" runat="server" Text="Observaciones:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtObservaciones" class="input-group-addon" runat="server" MaxLength="250" Width="200px" Height="42px" TextMode="MultiLine"></asp:TextBox>
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

