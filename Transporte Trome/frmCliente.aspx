<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmCliente.aspx.cs" Inherits="Transporte_Trome.frmCliente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h2>Mantenimiento de la tabla Cliente</h2>
      
        <div class="form-group">
            <label for="txtNombre" class="control-label">Nombre</label>
            <asp:RequiredFieldValidator ID="rvNombre" runat="server" ControlToValidate="txtNombre" ErrorMessage="obligatorio nombre" ValidationGroup="Agregar">*</asp:RequiredFieldValidator>
            <asp:RequiredFieldValidator ID="rvENombre" runat="server" ControlToValidate="txtNombre" ErrorMessage="obligatorio nombre" ValidationGroup="Eliminar">*</asp:RequiredFieldValidator>
            <asp:TextBox runat="server" ID="txtNombre" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="txtDireccion" class="control-label">Direccion<asp:RequiredFieldValidator ID="rvDirecccion" runat="server" ControlToValidate="txtDireccion" ErrorMessage="obligatorio direccion" ValidationGroup="Agregar">*</asp:RequiredFieldValidator>
            </label>
            &nbsp;<asp:TextBox runat="server" ID="txtDireccion" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="txtTelefono" class="control-label">Telefono</label>
            <asp:RequiredFieldValidator ID="rvTelefono" runat="server" ControlToValidate="txtTelefono" ErrorMessage="obligatorio telefono" ValidationGroup="Agregar">*</asp:RequiredFieldValidator>
            <asp:TextBox runat="server" ID="txtTelefono" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="txtCodUsuario" class="control-label">CodUsuario</label>
            <asp:RequiredFieldValidator ID="rvCodUsuario" runat="server" ControlToValidate="txtCodUsuario" Display="None" ErrorMessage="obligatorio codusuario" ValidationGroup="Agregar">*</asp:RequiredFieldValidator>
            <asp:TextBox runat="server" ID="txtCodUsuario" CssClass="form-control"></asp:TextBox>
        </div>
                <div class="form-group">
    <label for="txtContrasena" class="control-label">Contrasena<asp:RequiredFieldValidator ID="rvContrasena" runat="server" ControlToValidate="txtContrasena" ErrorMessage="obligatorio contrasena" ValidationGroup="Agregar">*</asp:RequiredFieldValidator>
                    </label>
    &nbsp;<asp:TextBox runat="server" ID="txtContrasena" CssClass="form-control"></asp:TextBox>
</div>
     
      
        <div class="form-group">
            <asp:Button Text="Agregar" runat="server" ID="btnAgregar" CssClass="btn btn-primary" OnClick="btnAgregar_Click" ValidationGroup="Agregar"/>
            <asp:Button Text="Eliminar" runat="server" ID="btnEliminar" CssClass="btn btn-warning" OnClick="btnEliminar_Click" OnClientClick="return confirm('¿Está seguro de que desea eliminar este cliente?');" ValidationGroup="Eliminar"/>
            <asp:Button Text="Actualizar" runat="server" ID="btnActualizar" CssClass="btn btn-success" OnClick="btnActualizar_Click" ValidationGroup="Actualizar"/>
            <br />
        </div>
        <div class="form-group">
            <asp:ValidationSummary ID="vsEliminar" runat="server" ValidationGroup="Eliminar" />
            <asp:ValidationSummary ID="vsBuscar" runat="server" ValidationGroup="Buscar" />
            <asp:ValidationSummary ID="VSAgregar" runat="server" ValidationGroup="Agregar" />
            <asp:RequiredFieldValidator ID="rvBNombre" runat="server" ControlToValidate="txtBuscar" ErrorMessage="requiere nombre" ValidationGroup="Buscar">*</asp:RequiredFieldValidator>
            <asp:TextBox runat="server" ID="txtBuscar" CssClass="form-control"></asp:TextBox>
        </div>
        <asp:Button Text="Buscar" runat="server" ID="btnBuscar" CssClass="btn btn-info" OnClick="btnBuscar_Click" ValidationGroup="Buscar"/>
        <asp:Button Text="Ver Todos los Clientes" runat="server" ID="btnVerTodos" CssClass="btn btn-primary" OnClick="btnVerTodos_Click"/>
        <div class="form-group">
            <asp:GridView runat="server" ID="gvCliente" CssClass="table table-striped" AutoGenerateSelectButton="True" OnSelectedIndexChanged="gvCliente_SelectedIndexChanged"></asp:GridView>
        </div>
        <div class="form-group">
            <asp:Label Text="Mensaje" runat="server" ID="lblMensaje" CssClass="alert alert-info"></asp:Label>
        </div>
    </div>
</asp:Content>

