using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Transporte_Trome
{
    public partial class frmUsuario : System.Web.UI.Page
    {
        // Llamar a la cadena de conexión
        private static string cadena = ConfigurationManager.ConnectionStrings["cadena"].ConnectionString;
        // Llamar al mapeado objeto Relacional 
        private TromeDataContext trome = new TromeDataContext(cadena);

        private void Listar()
        {
            var consulta = from U in trome.Usuario
                           select U;
            gvUsuarios.DataSource = consulta;
            gvUsuarios.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Listar();
                btnActualizar.Visible = false; // Ocultar el botón de actualizar inicialmente
            }
        }

        private byte[] ConvertStringToByteArray(string input)
        {
            return System.Text.Encoding.UTF8.GetBytes(input);
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                Usuario nuevoUsuario = new Usuario
                {
                    CodUsuario = txtCodUsuario.Text,
                    Contrasena = ConvertStringToByteArray(txtContrasena.Text) // Convertir contraseña a byte array
                };

                trome.Usuario.InsertOnSubmit(nuevoUsuario);
                trome.SubmitChanges();
                Listar();
                lblMensaje.Text = "Usuario agregado correctamente.";
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error al agregar Usuario: " + ex.Message;
                // Log the exception (ex) for further analysis
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                string codUsuario = txtCodUsuario.Text;
                var usuario = trome.Usuario.SingleOrDefault(u => u.CodUsuario == codUsuario);

                if (usuario != null)
                {
                    trome.Usuario.DeleteOnSubmit(usuario);
                    trome.SubmitChanges();
                    Listar();
                    lblMensaje.Text = "Usuario eliminado correctamente.";
                }
                else
                {
                    lblMensaje.Text = "Usuario no encontrado.";
                }
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error al eliminar Usuario: " + ex.Message;
                // Log the exception (ex) for further analysis
            }
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                string codUsuario = txtCodUsuario.Text;
                var usuario = trome.Usuario.SingleOrDefault(u => u.CodUsuario == codUsuario);

                if (usuario != null)
                {
                    usuario.Contrasena = ConvertStringToByteArray(txtContrasena.Text); // Convertir contraseña a byte array
                    trome.SubmitChanges();
                    Listar();
                    lblMensaje.Text = "Usuario actualizado correctamente.";
                }
                else
                {
                    lblMensaje.Text = "Usuario no encontrado.";
                }
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error al actualizar Usuario: " + ex.Message;
                // Log the exception (ex) for further analysis
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                string codUsuario = txtBuscar.Text;
                var consulta = from U in trome.Usuario
                               where U.CodUsuario == codUsuario
                               select U;

                gvUsuarios.DataSource = consulta.ToList();
                gvUsuarios.DataBind();

                if (!consulta.Any())
                {
                    lblMensaje.Text = "Usuario no encontrado.";
                }
                else
                {
                    lblMensaje.Text = "";
                }
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error al buscar Usuario: " + ex.Message;
                // Log the exception (ex) for further analysis
            }
        }

        protected void btnVerTodos_Click(object sender, EventArgs e)
        {
            Listar();
        }

        protected void gvUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = gvUsuarios.SelectedRow;

            if (row.Cells.Count > 1)
            {
                txtCodUsuario.Text = row.Cells[1].Text;
            }
            else
            {
                txtCodUsuario.Text = string.Empty;
            }

            if (row.Cells.Count > 2)
            {
                txtContrasena.Text = row.Cells[2].Text;
            }
            else
            {
                txtContrasena.Text = string.Empty;
            }

            btnActualizar.Visible = true; // Mostrar el botón de actualizar cuando se selecciona una fila
        }

    }
}
