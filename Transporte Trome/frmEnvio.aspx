<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmEnvio.aspx.cs" Inherits="Transporte_Trome.frmEnvio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

          <div class="container">
      <h2>Mantenimiento de la tabla Envio </h2>
 
      <div class="form-group">
          <label for="txtIdClienter" class="control-label">IdCliente<asp:RequiredFieldValidator ID="rvID" runat="server" ControlToValidate="txtIdCliente" ErrorMessage="obligatorio idCliente" ValidationGroup="Agregar">*</asp:RequiredFieldValidator>
          <asp:RequiredFieldValidator ID="rvEID" runat="server" ControlToValidate="txtIdCliente" ErrorMessage="Obligatorio IdCliente" ValidationGroup="Eliminar">*</asp:RequiredFieldValidator>
          </label>
          &nbsp;<asp:TextBox runat="server" ID="txtIdCliente" CssClass="form-control"></asp:TextBox>
      </div>
      <div class="form-group">
          <label for="txtIdServicio" class="control-label">IdServicio<asp:RequiredFieldValidator ID="rvIds" runat="server" ControlToValidate="txtIdServicio" ErrorMessage="obligatorio idServicio" ValidationGroup="Agregar">*</asp:RequiredFieldValidator>
          </label>
          &nbsp;<asp:TextBox runat="server" ID="txtIdServicio" CssClass="form-control"></asp:TextBox>
      </div>
                <div class="form-group">
      <label for="txtFechaEnvio " class="control-label">FechaEnvio<asp:RequiredFieldValidator ID="rvFecha" runat="server" ControlToValidate="txtFechaEnvio" ErrorMessage="obligatorio fecha envio" ValidationGroup="Agregar">*</asp:RequiredFieldValidator>
                    </label>
      &nbsp;<asp:TextBox runat="server" ID="txtFechaEnvio" CssClass="form-control"></asp:TextBox>
  </div>
                <div class="form-group">
      <label for="txtFechaRecojo" class="control-label">FechaRecojo<asp:RequiredFieldValidator ID="rvRecojo" runat="server" ControlToValidate="txtFechaRecojo" ErrorMessage="obligatorio fecha  recojo" ValidationGroup="Agregar">*</asp:RequiredFieldValidator>
                    </label>
      &nbsp;<asp:TextBox runat="server" ID="txtFechaRecojo" CssClass="form-control"></asp:TextBox>

  </div>
   
                <div class="form-group">
      <label for="txtPeso" class="control-label">Peso<asp:RequiredFieldValidator ID="rvPeso" runat="server" ControlToValidate="txtPeso" ErrorMessage="obligatorio peso" ValidationGroup="Agregar">*</asp:RequiredFieldValidator>
                    </label>
      &nbsp;<asp:TextBox runat="server" ID="txtPeso" CssClass="form-control"></asp:TextBox>
  </div>
                <div class="form-group">
      <label for="txtVolumen" class="control-label">Volumen<asp:RequiredFieldValidator ID="rvVolumen" runat="server" ControlToValidate="txtVolumen" ErrorMessage="obligatorio volumen" ValidationGroup="Agregar">*</asp:RequiredFieldValidator>
                    </label>
      &nbsp;<asp:TextBox runat="server" ID="txtVolumen" CssClass="form-control"></asp:TextBox>
  </div>
                <div class="form-group">
      <label for="txtTipoDocumento" class="control-label">TipoDocumento<asp:RequiredFieldValidator ID="rvTipo" runat="server" ControlToValidate="txtTipoDocumento" ErrorMessage="obligatorio tipo documento B o F" ValidationGroup="Agregar">*</asp:RequiredFieldValidator>
                    </label>
      &nbsp;<asp:TextBox runat="server" ID="txtTipoDocumento" CssClass="form-control"></asp:TextBox>
  </div>

                            <div class="form-group">
    <label for="txtTarifaBase" class="control-label">TarifaBase<asp:RequiredFieldValidator ID="rvTarifA" runat="server" ControlToValidate="txtTarifaBase" ErrorMessage="obligatorio tarifa base" ValidationGroup="Agregar">*</asp:RequiredFieldValidator>
                                </label>
    &nbsp;<asp:TextBox runat="server" ID="txtTarifaBase" CssClass="form-control"></asp:TextBox>
</div>
      <div class="form-group">
          <asp:Button Text="Agregar" runat="server" ID="btnAgregar" CssClass="btn btn-primary" OnClick="btnAgregar_Click" ValidationGroup="Agregar"/>
          <asp:Button Text="Eliminar" runat="server" ID="btnEliminar" CssClass="btn btn-warning" OnClick="btnEliminar_Click" OnClientClick="return confirm('¿Está seguro de que desea eliminar este cliente?');" ValidationGroup="Eliminar"/>
          <asp:ValidationSummary ID="vsAgregar" runat="server" ValidationGroup="Agregar" />
          <asp:ValidationSummary ID="VSEliminar" runat="server" ValidationGroup="Eliminar" />
          <asp:ValidationSummary ID="VsBuscar" runat="server" ValidationGroup="Buscar" />
          <asp:Button Text="Actualizar" runat="server" ID="btnActualizar" CssClass="btn btn-success" OnClick="btnActualizar_Click" ValidationGroup="Actualizar"/>
          <br />
      </div>
      <div class="form-group">
          <asp:RequiredFieldValidator ID="rvBuscar" runat="server" ControlToValidate="txtBuscar" ErrorMessage="obligatorio IdCliente" ValidationGroup="Buscar">*</asp:RequiredFieldValidator>
          <asp:TextBox runat="server" ID="txtBuscar" CssClass="form-control"></asp:TextBox>
      </div>
      <asp:Button Text="Buscar" runat="server" ID="btnBuscar" CssClass="btn btn-info" OnClick="btnBuscar_Click" ValidationGroup="Buscar"/>
      <asp:Button Text="Ver Todos los Envio" runat="server" ID="btnVerTodos" CssClass="btn btn-primary" OnClick="btnVerTodos_Click"/>
      <div class="form-group">
          <asp:GridView runat="server" ID="gvEnvio" CssClass="table table-striped" AutoGenerateSelectButton="True" OnSelectedIndexChanged="gvEnvioSelectedIndexChanged"></asp:GridView>
      </div>
      <div class="form-group">
          <asp:Label Text="Mensaje" runat="server" ID="lblMensaje" CssClass="alert alert-info"></asp:Label>
      </div>
  </div>
</asp:Content>
