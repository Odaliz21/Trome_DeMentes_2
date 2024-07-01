<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmVehiculo.aspx.cs" Inherits="Transporte_Trome.frmVehiculo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

          <div class="container">
        <h2>Mantenimiento de la tabla Vehiculo</h2>
      
        <div class="form-group">
            <label for="txtMarca" class="control-label">Marca</label>
            <asp:RequiredFieldValidator ID="rvMarca" runat="server" ControlToValidate="txtMarca" ErrorMessage="obligatorio marca" ValidationGroup="Agregar">*</asp:RequiredFieldValidator>
            <asp:RequiredFieldValidator ID="rvEMarca" runat="server" ControlToValidate="txtMarca" ErrorMessage="obligatorio marca" ValidationGroup="Eliminar">*</asp:RequiredFieldValidator>
            <asp:TextBox runat="server" ID="txtMarca" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="txtModelo" class="control-label">Modelo<asp:RequiredFieldValidator ID="rvModelo" runat="server" ControlToValidate="txtModelo" ErrorMessage="obligatorio" ValidationGroup="Agregar">*</asp:RequiredFieldValidator>
            </label>
            &nbsp;<asp:TextBox runat="server" ID="txtModelo" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="txtPlaca" class="control-label">Placa<asp:RequiredFieldValidator ID="rvPlaca" runat="server" ControlToValidate="txtPlaca" ErrorMessage="obligatorio placa" ValidationGroup="Agregar">*</asp:RequiredFieldValidator>
            </label>
            &nbsp;<asp:TextBox runat="server" ID="txtPlaca" CssClass="form-control"></asp:TextBox>
        </div>
                <div class="form-group">
    <label for="txtCapacidadCarga" class="control-label">CapacidadCarga<asp:RequiredFieldValidator ID="rvCapacidad" runat="server" ControlToValidate="txtCapacidadCarga" ErrorMessage="obligatorio Capacidad Carga" ValidationGroup="Agregar">*</asp:RequiredFieldValidator>
                    </label>
    &nbsp;<asp:TextBox runat="server" ID="txtCapacidadCarga" CssClass="form-control"></asp:TextBox>
</div>
     
      
        <div class="form-group">
            <asp:Button Text="Agregar" runat="server" ID="btnAgregar" CssClass="btn btn-primary" OnClick="btnAgregar_Click" ValidationGroup="Agregar"/>
            <asp:Button Text="Eliminar" runat="server" ID="btnEliminar" CssClass="btn btn-warning" OnClick="btnEliminar_Click" OnClientClick="return confirm('¿Está seguro de que desea eliminar este cliente?');" ValidationGroup="Eliminar"/>
            <asp:Button Text="Actualizar" runat="server" ID="btnActualizar" CssClass="btn btn-success" OnClick="btnActualizar_Click" ValidationGroup="Actualizar"/>
            <asp:ValidationSummary ID="vs" runat="server" ValidationGroup="Agregar" />
            <asp:ValidationSummary ID="vsEliminar" runat="server" ValidationGroup="Eliminar" />
            <asp:ValidationSummary ID="vsBuscar" runat="server" ValidationGroup="Buscar" />
            <br />
        </div>
        <div class="form-group">
            <asp:RequiredFieldValidator ID="rvBuscar" runat="server" ControlToValidate="txtBuscar" ErrorMessage="obligatorio marca" ValidationGroup="Buscar">*</asp:RequiredFieldValidator>
            <asp:TextBox runat="server" ID="txtBuscar" CssClass="form-control"></asp:TextBox>
        </div>
        <asp:Button Text="Buscar" runat="server" ID="btnBuscar" CssClass="btn btn-info" OnClick="btnBuscar_Click" ValidationGroup="Buscar"/>
        <asp:Button Text="Ver Todos los Vehiculos" runat="server" ID="btnVerTodos" CssClass="btn btn-primary" OnClick="btnVerTodos_Click"/>
        <div class="form-group">
            <asp:GridView runat="server" ID="gvVehiculo" CssClass="table table-striped" AutoGenerateSelectButton="True" OnSelectedIndexChanged="gvVehiculo_SelectedIndexChanged"></asp:GridView>
        </div>
        <div class="form-group">
            <asp:Label Text="Mensaje" runat="server" ID="lblMensaje" CssClass="alert alert-info"></asp:Label>
        </div>
    </div>
</asp:Content>
