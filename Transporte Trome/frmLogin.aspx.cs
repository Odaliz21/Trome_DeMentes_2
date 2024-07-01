using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Web.UI;

namespace Transporte_Trome
{
    public partial class frmLogin : Page
    {
        private static string cadena = ConfigurationManager.ConnectionStrings["cadena"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnIniciar_Click(object sender, EventArgs e)
        {
            string username = txtUsuario.Text;
            string password = txtPassword.Text;

            // Llamar al procedimiento almacenado spLogin para autenticación
            string userType = AuthenticateUser(username, password);

            if (!string.IsNullOrEmpty(userType))
            {
                // Establecer sesión para el tipo de usuario
                Session["TipoUsuario"] = userType;
                Session["CodUsuario"] = username;

                // Redirigir según el tipo de usuario
                switch (userType)
                {
                    case "Administrador":
                        Response.Redirect("frmSistemaAdministrador.aspx");
                        break;
                    case "Colaborador":
                        Response.Redirect("frmSistemaColaborador.aspx");
                        break;
                    case "Cliente":
                        Response.Redirect("frmSistemaCliente.aspx");
                        break;
                    default:
                        lblMensaje.Text = "Tipo de usuario no reconocido. Consulte al administrador.";
                        break;
                }
            }
            else
            {
                lblMensaje.Text = "Usuario y/o contraseña incorrectos.";
            }
        }

        private string AuthenticateUser(string username, string password)
        {
            string userType = null;

            using (SqlConnection conn = new SqlConnection(cadena))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("spLogin", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CodUsuario", username);
                cmd.Parameters.AddWithValue("@Contrasena", password);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        int codError = Convert.ToInt32(reader["CodError"]);
                        if (codError == 0)
                        {
                            userType = reader["Mensaje"].ToString();
                        }
                    }
                }
            }

            return userType;
        }

    }
}
