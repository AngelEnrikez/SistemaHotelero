<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.master" AutoEventWireup="true" CodeFile="ConsultaReserva.aspx.cs" Inherits="Administracion_ListarReserva" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="panel panel-primary" style="width: 950px">
        <div class="panel-heading">Listado de Reservas</div>

        <div style="margin-left: 15px; margin-top: 5px; margin-bottom: 5px">
            <input type="text" id="txtCodigo" style="width: 50px; line-height: 1px" runat="server" />
            <asp:Button ID="btnBuscar" OnClick="btnBuscar_Click" class="btn btn-default" runat="server" Text="Buscar" />
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
                <asp:BoundField HeaderStyle-CssClass="hidden-xs" ItemStyle-CssClass="hidden-xs" HeaderText="Habitación" DataField="Habitacion.Numero">
                    <HeaderStyle CssClass="hidden-xs"></HeaderStyle>

                    <ItemStyle CssClass="hidden-xs"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="FechaLlegada" HeaderText="Fecha de Llegada" />
                 <asp:BoundField DataField="FechaSalida" HeaderText="Fecha de Salida" />
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

