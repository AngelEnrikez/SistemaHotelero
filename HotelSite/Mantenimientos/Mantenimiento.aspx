<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.master" AutoEventWireup="true" CodeFile="Mantenimiento.aspx.cs" Inherits="Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="panel panel-primary" style="width: 700px">
        <div class="panel-heading">Mantenimiento de Clientes</div>

        <div class="panel-body">
            <table class="table" style="width:60%">
                <tr>
                    <td>
                        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox1" class="input-group-addon" runat="server" Width="253px"></asp:TextBox>
                    </td>
                </tr>
              
                <tr>
                    <td>
                        <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="DropDownList1" runat="server" Height="16px" Width="194px">
                        </asp:DropDownList>
                    </td>
                </tr>
              
                <tr>
                    <td>
                        <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
                    </td>
                    <td>
                        <asp:CheckBox ID="CheckBox1"   runat="server"/>
                    </td>
                </tr>
              
            </table>
        </div>
        <div class="panel-footer">
            <asp:Button ID="Button1" class="btn btn-default" runat="server" Text="Guardar" />
            <asp:Button ID="Button4" class="btn btn-default" runat="server" Text="Cancelar" />
        </div>
        <div class="alert alert-success" role="alert">El registro se guardó correctamente</div>
    </div>
</asp:Content>

