<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frm_Servicios.aspx.cs" Inherits="Transporte_Trome.frm_Servicios" %>

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
            <asp:Repeater ID="rptServicios" runat="server" OnItemCommand="rptServicios_ItemCommand">
                <ItemTemplate>
                    <div style="border: 1px solid #ccc; padding: 10px; margin-bottom: 10px;">
                        <h3><%# Eval("Descripcion") %></h3>
                        <p>Tarifa Base: <%# Eval("TarifaBase", "{0:C}") %></p>
                        <!-- Aquí puedes agregar una imagen o cualquier otro detalle -->
                        <asp:Button runat="server" Text="Agregar al Carrito" CommandName="AgregarCarrito" CommandArgument='<%# Eval("IdServicio") %>' />
                    </div>
                </ItemTemplate>
            </asp:Repeater>
            <br />
            <asp:Button runat="server" Text="Ver Carrito de Compras" OnClick="VerCarrito_Click" />
        </div>
    </form>
</body>
</html>
