<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmUsuario.aspx.cs" Inherits="Transporte_Trome.frmUsuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <div class="container">
        <h2>Mantenimiento de la tabla Usuario</h2>
      
      
        <div class="form-group">
            <label for="txtCodUsuario" class="control-label">CodUsuario<asp:RequiredFieldValidator ID="rvUsuario" runat="server" ControlToValidate="txtCodUsuario" ErrorMessage="obligatorio usuario" ValidationGroup="Agregar">*</asp:RequiredFieldValidator>
            <asp:RequiredFieldValidator ID="rvEUsuario" runat="server" ControlToValidate="txtCodUsuario" ErrorMessage="obligatorio codusuario" ValidationGroup="Eliminar">*</asp:RequiredFieldValidator>
            </label>
            &nbsp;<asp:TextBox runat="server" ID="txtCodUsuario" CssClass="form-control"></asp:TextBox>
        </div>
                <div class="form-group">
    <label for="txtContrasena" class="control-label">Contrasena<asp:RequiredFieldValidator ID="rvContraseña" runat="server" ControlToValidate="txtContrasena" ErrorMessage="obligatorio contraseña" ValidationGroup="Agregar">*</asp:RequiredFieldValidator>
                    </label>
    &nbsp;<asp:TextBox runat="server" ID="txtContrasena" CssClass="form-control"></asp:TextBox>
</div>
     
      
        <div class="form-group">
            <asp:Button Text="Agregar" runat="server" ID="btnAgregar" CssClass="btn btn-primary" OnClick="btnAgregar_Click" ValidationGroup="Agregar"/>
            <asp:Button Text="Eliminar" runat="server" ID="btnEliminar" CssClass="btn btn-warning" OnClick="btnEliminar_Click" OnClientClick="return confirm('¿Está seguro de que desea eliminar este cliente?');" ValidationGroup="Eliminar"/>
            <asp:Button Text="Actualizar" runat="server" ID="btnActualizar" CssClass="btn btn-success" OnClick="btnActualizar_Click" ValidationGroup="Actualizar"/>
            <asp:ValidationSummary ID="vsAgregar" runat="server" ValidationGroup="Agregar" />
            <asp:ValidationSummary ID="vsEliminar" runat="server" ValidationGroup="Eliminar" />
            <asp:ValidationSummary ID="vsBuscar" runat="server" ValidationGroup="Buscar" />
            <br />
        </div>
        <div class="form-group">
            <asp:RequiredFieldValidator ID="rvBuscar" runat="server" ControlToValidate="txtCodUsuario" ErrorMessage="requiere codusuario" ValidationGroup="Buscar">*</asp:RequiredFieldValidator>
            <asp:TextBox runat="server" ID="txtBuscar" CssClass="form-control"></asp:TextBox>
        </div>
        <asp:Button Text="Buscar" runat="server" ID="btnBuscar" CssClass="btn btn-info" OnClick="btnBuscar_Click" ValidationGroup="Buscar"/>
        <asp:Button Text="Ver Todos los Usuarios" runat="server" ID="btnVerTodos" CssClass="btn btn-primary" OnClick="btnVerTodos_Click"/>
        <div class="form-group">
            <asp:GridView runat="server" ID="gvUsuarios" CssClass="table table-striped" AutoGenerateSelectButton="True" OnSelectedIndexChanged="gvUsuarios_SelectedIndexChanged"></asp:GridView>
        </div>
        <div class="form-group">
            <asp:Label Text="Mensaje" runat="server" ID="lblMensaje" CssClass="alert alert-info"></asp:Label>
        </div>
    </div>
</asp:Content>
