<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FrmColaborador.aspx.cs" Inherits="Transporte_Trome.FrmColaborador" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h2>Mantenimiento de la tabla Colaborador</h2>
     
        <div class="form-group">
            <label for="txtNombre" class="control-label">Nombre<asp:RequiredFieldValidator ID="rvNombre" runat="server" ControlToValidate="txtNombre" ErrorMessage="obligatorio nombre" ValidationGroup="Agregar">*</asp:RequiredFieldValidator>
            </label>
            &nbsp;<asp:TextBox runat="server" ID="txtNombre" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="txtCargo" class="control-label">Cargo<asp:RequiredFieldValidator ID="rvCargo" runat="server" ControlToValidate="txtCargo" ErrorMessage="obligatorio nombre" ValidationGroup="Agregar">*</asp:RequiredFieldValidator>
            </label>
            &nbsp;<asp:TextBox runat="server" ID="txtCargo" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="txtTelefono" class="control-label">Telefono<asp:RequiredFieldValidator ID="rvTelefono" runat="server" ControlToValidate="txtTelefono" ErrorMessage="obligatorio telefono" ValidationGroup="Agregar">*</asp:RequiredFieldValidator>
            </label>
            &nbsp;<asp:TextBox runat="server" ID="txtTelefono" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="txtCodUsuario" class="control-label">CodUsuario</label>
            <asp:RequiredFieldValidator ID="rvCodUsuario" runat="server" ControlToValidate="txtCodUsuario" ErrorMessage="obligatorio codusuario" ValidationGroup="Agregar">*</asp:RequiredFieldValidator>
            <asp:TextBox runat="server" ID="txtCodUsuario" CssClass="form-control"></asp:TextBox>
        </div>
           <div class="form-group">
       <label for="txtContrasena" class="control-label">Contrasena</label>
               <asp:RequiredFieldValidator ID="rvContrasena" runat="server" ControlToValidate="txtContrasena" ErrorMessage="obligatorio contraseña" ValidationGroup="Agregar">*</asp:RequiredFieldValidator>
       <asp:TextBox runat="server" ID="txtContrasena" CssClass="form-control"></asp:TextBox>
   </div>
     
         <div class="form-group">
     <label for="txtIdVehiculo" class="control-label">IdVehiculo<asp:RequiredFieldValidator ID="rvIdvehiculo" runat="server" ControlToValidate="txtIdVehiculo" ErrorMessage="obligatorio idVehiculo" ValidationGroup="Agregar">*</asp:RequiredFieldValidator>
             </label>
     &nbsp;<label for="txtNombre" class="control-label"><asp:RequiredFieldValidator ID="rvEidvehiculo" runat="server" ControlToValidate="txtIdVehiculo" ErrorMessage="obligatorio idvehiculo" ValidationGroup="Eliminar">*</asp:RequiredFieldValidator>
            </label>
             <asp:TextBox runat="server" ID="txtIdVehiculo" CssClass="form-control"></asp:TextBox>
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
            <asp:RequiredFieldValidator ID="rvBuscar" runat="server" ErrorMessage="obligatorio nombre" ControlToValidate="txtBuscar" ValidationGroup="Buscar">*</asp:RequiredFieldValidator>
            <asp:TextBox runat="server" ID="txtBuscar" CssClass="form-control"></asp:TextBox>
        </div>
        <asp:Button Text="Buscar" runat="server" ID="btnBuscar" CssClass="btn btn-info" OnClick="btnBuscar_Click" ValidationGroup="Buscar"/>
        <asp:Button Text="Ver Todos los Colaborador" runat="server" ID="btnVerTodos" CssClass="btn btn-primary" OnClick="btnVerTodos_Click"/>
        <div class="form-group">
            <asp:GridView runat="server" ID="gvColaborador" CssClass="table table-striped" AutoGenerateSelectButton="True" OnSelectedIndexChanged="gvColaborador_SelectedIndexChanged"></asp:GridView>
        </div>
        <div class="form-group">
            <asp:Label Text="Mensaje" runat="server" ID="lblMensaje" CssClass="alert alert-info"></asp:Label>
        </div>
    </div>
</asp:Content>


