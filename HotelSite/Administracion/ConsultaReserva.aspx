

<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.master" AutoEventWireup="true" CodeFile="ConsultaReserva.aspx.cs" Inherits="Administracion_ListarReserva" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </cc1:ToolkitScriptManager>
    <div class="panel panel-primary" style="width: 950px">
        <div class="panel-heading">Listado de Reservas</div>

        <div style="margin-left: 15px; margin-top: 5px; margin-bottom: 5px">
           Nro Reserva :
             <input type="text" id="txtCodigo" style="width: 50px; line-height: 1px" runat="server" />
            <asp:Button ID="btnBuscar" OnClick="btnBuscar_Click" class="btn btn-default" runat="server" Text="Buscar" />
        </div>
        <div style="margin-left: 15px; margin-top: 5px; margin-bottom: 5px">
            Buscar Chekin :
                     <asp:TextBox ID="txtChekIndel" runat="server" ReadOnly="true"></asp:TextBox>
                        <asp:ImageButton ID="ImageButton0" ImageUrl="~/Images/fecha.png" ImageAlign="Bottom"
                            runat="server" Height="20px" Width="28px" />
                        <cc1:CalendarExtender ID="CalendarExtender0" PopupButtonID="ImageButton0" runat="server" TargetControlID="txtChekIndel"
                            Format="dd/MM/yyyy">
                        </cc1:CalendarExtender>
            al
                       <asp:TextBox ID="txtChekInal" runat="server" ReadOnly="true"></asp:TextBox>
                        <asp:ImageButton ID="ImageButton1" ImageUrl="~/Images/fecha.png" ImageAlign="Bottom"
                            runat="server" Height="20px" Width="28px" />
                        <cc1:CalendarExtender ID="CalendarExtender1" PopupButtonID="ImageButton1" runat="server" TargetControlID="txtChekInal"
                            Format="dd/MM/yyyy">
                        </cc1:CalendarExtender>
        </div>
       <div style="margin-left: 15px; margin-top: 5px; margin-bottom: 5px">
            Buscar Chekout :
                     <asp:TextBox ID="txtChekOutdel" runat="server" ReadOnly="true"></asp:TextBox>
                        <asp:ImageButton ID="ImageButton2" ImageUrl="~/Images/fecha.png" ImageAlign="Bottom"
                            runat="server" Height="20px" Width="28px" />
                        <cc1:CalendarExtender ID="CalendarExtender2" PopupButtonID="ImageButton2" runat="server" TargetControlID="txtChekOutdel"
                            Format="dd/MM/yyyy">
                        </cc1:CalendarExtender>
                           al   
                       <asp:TextBox ID="txtChekOutal" runat="server" ReadOnly="true"></asp:TextBox>
                        <asp:ImageButton ID="ImageButton3" ImageUrl="~/Images/fecha.png" ImageAlign="Bottom"
                            runat="server" Height="20px" Width="28px" />
                        <cc1:CalendarExtender ID="CalendarExtender3" PopupButtonID="ImageButton3" runat="server" TargetControlID="txtChekOutal"
                            Format="dd/MM/yyyy">
                        </cc1:CalendarExtender>
        </div>

        <asp:GridView ID="gdListado" CssClass="table" runat="server" Width="100%" AutoGenerateColumns="False" OnRowCommand="gdListado_RowCommand">
            <Columns>
                <asp:TemplateField HeaderText="Codigo">
                    <ItemTemplate>
                        <asp:Label ID="lblGridCodigo" runat="server" Text='<%# Eval("IdReserva") %>'></asp:Label>
                        <asp:HiddenField ID="hdGridCodigo" runat="server" Value='<%# Eval("IdReserva") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField HeaderStyle-CssClass="hidden-xs" ItemStyle-CssClass="hidden-xs" HeaderText="Cliente" DataField="Cliente.Nombre">
                    <HeaderStyle CssClass="hidden-xs"></HeaderStyle>

                    <ItemStyle CssClass="hidden-xs"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField HeaderStyle-CssClass="hidden-xs" ItemStyle-CssClass="hidden-xs" HeaderText="Nro. Habitación" DataField="Habitacion.Numero">
                    <HeaderStyle CssClass="hidden-xs"></HeaderStyle>

                    <ItemStyle CssClass="hidden-xs"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="FechaLlegada" HeaderText="Fecha de Llegada" />
                 <asp:BoundField DataField="FechaSalida" HeaderText="Fecha de Salida" />
                <asp:BoundField DataField="FechaLlegada" HeaderText="Fecha de ChekIn" />
                <asp:BoundField DataField="FechaLlegada" HeaderText="Fecha de Check Out" />
                <asp:BoundField DataField="Observaciones" HeaderText="Observaciones" />
                <asp:TemplateField HeaderText="Acciones">
                    <ItemTemplate>
                        <asp:Button ID="btnGridModificar" Width="100px" CommandName="CheckOut" class="btn btn-default btn-xs" runat="server" Text="Check Out" />
                    </ItemTemplate>
                    <ItemStyle Width="50px" />
                </asp:TemplateField>                
            </Columns>
            <RowStyle CssClass="rowStyle" />
            <HeaderStyle CssClass="headerStyle" />
            <FooterStyle CssClass="footerStyle" />
            <PagerStyle HorizontalAlign="Center" />
        </asp:GridView>
        <div class="panel-footer">
            <asp:Button ID="btnAgregar" class="btn btn-default" runat="server" Text="Agregar" OnClick="btnAgregar_Click" />
            <asp:HiddenField ID="hdMaxCodigo" runat="server" />
        </div>
        <div id="divError" class="alert alert-info" role="alert" runat="server" visible="false">Mensaje</div>
    </div>
</asp:Content>

