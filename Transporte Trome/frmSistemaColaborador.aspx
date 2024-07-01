<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmSistemaColaborador.aspx.cs" Inherits="Transporte_Trome.frmLoginColaborador" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-5">
        <h1 class="text-center">Bienvenido Colaborador al sistema</h1>
        <asp:Button runat="server" ID="btnCerrar" Text="Cerrar sesión" OnClick="btnCerrar_Click" />
    </div>

    <asp:Label ID="lblColaborador" runat="server"></asp:Label>
    <h2>Cambiar Contraseña</h2>
    <div class="form-group">
        <asp:Label ID="lblContrasenaActual" runat="server" Text="Contraseña Actual:"></asp:Label>
        <asp:TextBox ID="txtContrasenaActual" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
    </div>
    <div class="form-group">
        <asp:Label ID="lblNuevaContrasena" runat="server" Text="Nueva Contraseña:"></asp:Label>
        <asp:TextBox ID="txtNuevaContrasena" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
    </div>
    <asp:Button ID="btnCambiarContrasena" runat="server" Text="Cambiar Contraseña" OnClick="btnCambiarContrasena_Click" CssClass="btn btn-primary" />
    <asp:Label ID="lblMensajeContrasena" runat="server" Text="" CssClass="text-danger"></asp:Label>

    <h2 class="mt-4">Gestionar Envíos</h2>
    <div class="form-group">
        <label for="txtFechaInicio">Fecha Inicio:</label>
        <asp:TextBox ID="txtFechaInicio" runat="server" TextMode="Date" CssClass="form-control"></asp:TextBox>
    </div>
    <div class="form-group">
        <label for="txtFechaFin">Fecha Fin:</label>
        <asp:TextBox ID="txtFechaFin" runat="server" TextMode="Date" CssClass="form-control"></asp:TextBox>
    </div>
    <asp:Button runat="server" ID="btnFiltrarEnvios" Text="Filtrar Envíos" OnClick="btnFiltrarEnvios_Click" CssClass="btn btn-primary" />

    <asp:GridView ID="gvEnvios" runat="server" AutoGenerateColumns="false" CssClass="table table-bordered mt-3">
        <Columns>
            <asp:BoundField DataField="IdEnvio" HeaderText="ID Envío" />
            <asp:BoundField DataField="FechaEnvio" HeaderText="Fecha de Envío" />
            <asp:BoundField DataField="FechaRecojo" HeaderText="Fecha de Recojo" />
            <asp:BoundField DataField="Peso" HeaderText="Peso" />
            <asp:BoundField DataField="Volumen" HeaderText="Volumen" />
            <asp:BoundField DataField="TipoDocumento" HeaderText="Tipo Documento" />
            <asp:BoundField DataField="TarifaBase" HeaderText="Tarifa Base" />
            <asp:BoundField DataField="MontoPago" HeaderText="Monto Pago" />
        </Columns>
    </asp:GridView>
</asp:Content>
