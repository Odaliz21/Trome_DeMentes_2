using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Transporte_Trome;
using static System.Net.Mime.MediaTypeNames;

namespace Transporte_Trome
{
    public partial class frmCliente : System.Web.UI.Page
    {
        // Llamar a la cadena de conexión
        private static string cadena = ConfigurationManager.ConnectionStrings["cadena"].ConnectionString;
        // Llamar al mapeado objeto Relacional 
        private TromeDataContext trome = new TromeDataContext(cadena);

        private void Listar()
        {
            var consulta = from C in trome.Cliente
                           select C;
            gvCliente.DataSource = consulta;
            gvCliente.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Listar();
                btnActualizar.Visible = false; // Ocultar el botón de actualizar inicialmente
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                Cliente nuevoCliente = new Cliente
                {
                    Nombre = txtNombre.Text,
                    Direccion = txtDireccion.Text,
                    Telefono = txtTelefono.Text,
                    CodUsuario = txtCodUsuario.Text,
                    Contrasena = txtContrasena.Text,
                };

                trome.Cliente.InsertOnSubmit(nuevoCliente);
                trome.SubmitChanges();
                Listar();
                lblMensaje.Text = "Cliente agregado correctamente.";
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error al agregar cliente: " + ex.Message;
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                string nombre = txtNombre.Text;
                var cliente = trome.Cliente.SingleOrDefault(c => c.Nombre == nombre);

                if (cliente != null)
                {
                    trome.Cliente.DeleteOnSubmit(cliente);
                    trome.SubmitChanges();
                    Listar();
                    lblMensaje.Text = "Cliente eliminado correctamente.";
                }
                else
                {
                    lblMensaje.Text = "Cliente no encontrado.";
                }
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error al eliminar cliente: " + ex.Message;
            }
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                string nombre = txtNombre.Text;
                var cliente = trome.Cliente.SingleOrDefault(c => c.Nombre == nombre);

                if (cliente != null)
                {
                    cliente.Nombre = txtNombre.Text;
                    cliente.Direccion = txtDireccion.Text;
                    cliente.Telefono = txtTelefono.Text;
                    cliente.CodUsuario = txtCodUsuario.Text;
                    cliente.Contrasena = txtContrasena.Text;

                    trome.SubmitChanges();
                    Listar();
                    lblMensaje.Text = "Cliente actualizado correctamente.";
                }
                else
                {
                    lblMensaje.Text = "Cliente no encontrado.";
                }
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error al actualizar cliente: " + ex.Message;
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                string nombre = txtBuscar.Text;
                var consulta = from C in trome.Cliente
                               where C.Nombre == nombre
                               select C;

                gvCliente.DataSource = consulta.ToList();
                gvCliente.DataBind();

                if (!consulta.Any())
                {
                    lblMensaje.Text = "Cliente no encontrado.";
                }
                else
                {
                    lblMensaje.Text = "";
                }
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error al buscar cliente: " + ex.Message;
            }
        }

        protected void btnVerTodos_Click(object sender, EventArgs e)
        {
            Listar();
        }

        protected void gvCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = gvCliente.SelectedRow;
            txtNombre.Text = row.Cells[2].Text;
            txtDireccion.Text = row.Cells[3].Text;
            txtTelefono.Text = row.Cells[4].Text;
            txtCodUsuario.Text = row.Cells[5].Text;
            txtContrasena.Text = row.Cells[6].Text;

            btnActualizar.Visible = true; // Mostrar el botón de actualizar cuando se selecciona una fila
        }
    }
}
