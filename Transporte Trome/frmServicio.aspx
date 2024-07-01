<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Servicios.aspx.cs" Inherits="Transporte_Trome.Servicios" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Catálogo de Servicios</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Catálogo de Servicios</h2>
            <asp:GridView ID="gvServicios" runat="server" AutoGenerateColumns="False" OnRowCommand="gvServicios_RowCommand">
                <Columns>
                    <asp:BoundField DataField="IdServicio" HeaderText="ID" />
                    <asp:BoundField DataField="Descripcion" HeaderText="Descripción" />
                    <asp:BoundField DataField="TarifaBase" HeaderText="Tarifa Base" DataFormatString="{0:C}" />
                    <asp:TemplateField HeaderText="Acciones">
                        <ItemTemplate>
                            <asp:Button runat="server" Text="Agregar al Carrito" CommandName="AgregarCarrito" CommandArgument='<%# Eval("IdServicio") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <br />
            <asp:Label ID="lblMensaje" runat="server" Text=""></asp:Label>
            <br />
            <asp:Button runat="server" Text="Ver Carrito" OnClick="VerCarrito_Click" />
        </div>
    </form>
</body>
</html>
