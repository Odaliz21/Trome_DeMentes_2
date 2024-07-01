<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmSistemaAdministrador.aspx.cs" Inherits="Transporte_Trome.frmSistemaAdministrador" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Bienvenido Admin al sistema</h1>
    <div class="container mt-5">
        <asp:Button runat="server" ID="btnCerrar" Text="Cerrar sesión" OnClick="btnCerrar_Click" />
    </div>

    <asp:Label ID="lblAdministrador" runat="server"></asp:Label>
    
    <div>
        <asp:Button runat="server" ID="btnCrudCliente" Text="CRUD Cliente" OnClick="btnCrudCliente_Click" />
        <asp:Button runat="server" ID="btnCrudColaborador" Text="CRUD Colaborador" OnClick="btnCrudColaborador_Click" />
        <asp:Button runat="server" ID="btnCrudColaboradorEnvio" Text="CRUD Colaborador Envio" OnClick="btnCrudColaboradorEnvio_Click" />
        <asp:Button runat="server" ID="btnCrudVehiculo" Text="CRUD Vehiculo" OnClick="btnCrudVehiculo_Click" />
        <asp:Button runat="server" ID="btnEnvio" Text="CRUD Envio" OnClick="btnCrudEnvio_Click" />
        <asp:Button runat="server" ID="btnUsuario" Text="CRUD Usuario" OnClick="btnCrudUsuario_Click" />
        <asp:Button runat="server" ID="btnServicio" Text="CRUD Servicio" OnClick="btnCrudServicio_Click" />
        
    </div>
    
</asp:Content>
