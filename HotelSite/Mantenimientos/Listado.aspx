<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.master" AutoEventWireup="true" CodeFile="Listado.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="panel panel-primary" style="width: 700px">
        <div class="panel-heading">Mantenimiento de Clientes</div>

        <asp:GridView ID="GridView2" CssClass="table" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField HeaderStyle-CssClass="hidden-xs" ItemStyle-CssClass="hidden-xs" HeaderText="columna1">
                    <HeaderStyle CssClass="hidden-xs"></HeaderStyle>

                    <ItemStyle CssClass="hidden-xs"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField HeaderStyle-CssClass="hidden-xs" ItemStyle-CssClass="hidden-xs" HeaderText="columna2">
                    <HeaderStyle CssClass="hidden-xs"></HeaderStyle>

                    <ItemStyle CssClass="hidden-xs"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField HeaderStyle-CssClass="hidden-xs" ItemStyle-CssClass="hidden-xs" HeaderText="columna3">
                    <HeaderStyle CssClass="hidden-xs"></HeaderStyle>

                    <ItemStyle CssClass="hidden-xs"></ItemStyle>
                </asp:BoundField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button ID="Button2" class="btn btn-default btn-xs" runat="server" Text="Button" />
                    </ItemTemplate>
                    <ItemStyle Width="50px" />
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button ID="Button3" class="btn btn-default btn-xs" runat="server" Text="Button" />
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
            <asp:Button ID="Button1" class="btn btn-default" runat="server" Text="Agregar" />
        </div>
        <div class="alert alert-danger" role="alert">El registro se guardó correctamente</div>
    </div>

</asp:Content>

