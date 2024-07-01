<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Carrito_Compras.aspx.cs" Inherits="Transporte_Trome.Carrito_Compras" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Carrito de Compras</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Carrito de Compras</h2>
            <asp:GridView ID="gvCarrito" runat="server" AutoGenerateColumns="False" OnRowCommand="gvCarrito_RowCommand" DataKeyNames="IdCarrito,IdServicio,TarifaBase">
    <Columns>
        <asp:BoundField DataField="IdCarrito" HeaderText="ID Carrito" />
        <asp:BoundField DataField="IdServicio" HeaderText="ID Servicio" />
        <asp:BoundField DataField="Descripcion" HeaderText="Descripción" />
        <asp:TemplateField HeaderText="Cantidad">
            <ItemTemplate>
                <asp:TextBox runat="server" ID="txtCantidad" Text='<%# Bind("Cantidad") %>' AutoPostBack="True" OnTextChanged="txtCantidad_TextChanged" />
            </ItemTemplate>
        </asp:TemplateField>
        <asp:BoundField DataField="TarifaBase" HeaderText="Tarifa Base" DataFormatString="{0:C}" />
        <asp:TemplateField HeaderText="Subtotal">
            <ItemTemplate>
                <asp:Label runat="server" ID="lblSubtotal" Text='<%# Eval("Subtotal", "{0:C}") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Acciones">
            <ItemTemplate>
                <asp:Button runat="server" Text="Eliminar" CommandName="Eliminar" CommandArgument='<%# Eval("IdCarrito") %>' CssClass="btnEliminar" />
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>

            <br />
            <asp:Button runat="server" Text="Pagar" OnClick="Pagar_Click" CssClass="btnPagar" style="height: 26px" />
            <asp:Button runat="server" Text="Volver a Servicios" CssClass="btnVolver" OnClick="Regresar_Servicios_Click" />
            <br />
            <h2>Total del Carrito: <asp:Label runat="server" ID="lblTotalCarrito" Text="0.00" /></h2>
            <h2>Seguimiento de Servicios adquiridos</h2>
            
                <asp:GridView ID="gvServiciosAdquiridos" runat="server" AutoGenerateColumns="False">
                    <Columns>
                        <asp:BoundField DataField="IdServicio" HeaderText="ID Servicio" />
                        <asp:BoundField DataField="Descripcion" HeaderText="Descripción" />
                        <asp:BoundField DataField="Estado" HeaderText="Estado" />
                    </Columns>
                </asp:GridView>

            

                
        </div>
    </form>
</body>
</html>
