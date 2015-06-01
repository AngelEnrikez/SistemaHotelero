<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.master" AutoEventWireup="true" CodeFile="ListadoReserva.aspx.cs" Inherits="Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="panel panel-primary" style="width: 950px">
        <div class="panel-heading">Listado de Reservas</div>

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
                <asp:BoundField DataField="Observaciones" HeaderText="Observaciones" />
                <asp:TemplateField HeaderText="Modificar">
                    <ItemTemplate>
                        <asp:Button ID="btnGridModificar" CommandName="ModificarData" class="btn btn-default btn-xs" runat="server" Text="..." />
                    </ItemTemplate>
                    <ItemStyle Width="50px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Eliminar">
                    <ItemTemplate>
                        <asp:Button ID="btnGridEliminar" CommandName="DeleteData" class="btn btn-default btn-xs" runat="server" OnClientClick="if( !confirm('Está seguro de eliminar el registro?') ) return false;" Text="..." />
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

