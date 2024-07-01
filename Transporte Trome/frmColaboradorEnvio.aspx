<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmColaboradorEnvio.aspx.cs" Inherits="Transporte_Trome.frmColaboradorEnvio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <div class="container">
        <h2>Mantenimiento de la tabla ColaboradorEnvio </h2>
   
        <div class="form-group">
            <label for="txtIdColaborador" class="control-label">IdColaborador<asp:RequiredFieldValidator ID="rvIDcolaborador" runat="server" ControlToValidate="txtIdColaborador" ErrorMessage="obligatorio idColaborador" ValidationGroup="Agregar">*</asp:RequiredFieldValidator>
            <asp:RequiredFieldValidator ID="rvEiDColaborador" runat="server" ControlToValidate="txtIdColaborador" ErrorMessage="obligatorio IDColaborador " ValidationGroup="Eliminar">*</asp:RequiredFieldValidator>
            </label>
            &nbsp;<asp:TextBox runat="server" ID="txtIdColaborador" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="txtIdEnvio" class="control-label">IdEnvio</label><label for="txtIdColaborador" class="control-label"><asp:RequiredFieldValidator ID="rvEnvio" runat="server" ControlToValidate="txtBuscar" ErrorMessage="obligatorio envio" ValidationGroup="Agregar">*</asp:RequiredFieldValidator>
            </label>
            &nbsp;<asp:TextBox runat="server" ID="txtIdEnvio" CssClass="form-control"></asp:TextBox>
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
            <asp:RequiredFieldValidator ID="rvBuscarI" runat="server" ControlToValidate="txtBuscar" ErrorMessage="obligatorio idColaborador" ValidationGroup="Buscar">*</asp:RequiredFieldValidator>
            <asp:TextBox runat="server" ID="txtBuscar" CssClass="form-control"></asp:TextBox>
        </div>
        <asp:Button Text="Buscar" runat="server" ID="btnBuscar" CssClass="btn btn-info" OnClick="btnBuscar_Click" ValidationGroup="Buscar"/>
        <asp:Button Text="Ver Todos los Colaborador Envio" runat="server" ID="btnVerTodos" CssClass="btn btn-primary" OnClick="btnVerTodos_Click"/>
        <div class="form-group">
            <asp:GridView runat="server" ID="gvColaboradorEnvio" CssClass="table table-striped" AutoGenerateSelectButton="True" OnSelectedIndexChanged="gvColaboradorEnvioSelectedIndexChanged"></asp:GridView>
        </div>
        <div class="form-group">
            <asp:Label Text="Mensaje" runat="server" ID="lblMensaje" CssClass="alert alert-info"></asp:Label>
        </div>

    </div>
</asp:Content>
