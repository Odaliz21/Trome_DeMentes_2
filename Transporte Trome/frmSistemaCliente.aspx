<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmSistemaCliente.aspx.cs" Inherits="Transporte_Trome.frmLoginCliente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-5">
        <h1 class="text-center">Bienvenido Cliente al sistema</h1>
        <asp:Button runat="server" ID="btnCerrar" Text="Cerrar sesión" OnClick="btnCerrar_Click" />
    </div>

    <asp:Label ID="lblCliente" runat="server"></asp:Label>

    <div>
        <h2>Consultar Envíos</h2>
        
        <div class="form-group">
            <label for="txtFechaInicio">Fecha Inicio:</label>
            <asp:TextBox ID="txtFechaInicio" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="txtFechaFin">Fecha Fin:</label>
            <asp:TextBox ID="txtFechaFin" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
        </div>
        <asp:Button runat="server" ID="btnFiltrarEnvios" Text="Filtrar Envíos" OnClick="btnFiltrarEnvios_Click" CssClass="btn btn-primary" />
        
        <asp:GridView ID="gvEnvios" runat="server" AutoGenerateColumns="false">
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
        
        <h2 class="mt-4">Servicios Disponibles</h2>
        
        <div class="form-group">
            <label for="txtIdServicio">ID Servicio:</label>
            <asp:TextBox ID="txtIdServicio" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="txtDescripcionServicio">Descripción:</label>
            <asp:TextBox ID="txtDescripcionServicio" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <asp:Button runat="server" ID="btnFiltrarServicios" Text="Filtrar Servicios" OnClick="btnFiltrarServicios_Click" CssClass="btn btn-primary" />
        
        <asp:GridView ID="gvServicios" runat="server" AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField DataField="IdServicio" HeaderText="ID Servicio" />
                <asp:BoundField DataField="Descripcion" HeaderText="Descripción" />
                <asp:BoundField DataField="TarifaBase" HeaderText="Tarifa Base" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
