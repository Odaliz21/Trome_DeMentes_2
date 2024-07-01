using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.UI;

namespace Transporte_Trome
{
    public partial class frmLoginColaborador : Page
    {
        // Cadena de conexión obtenida del archivo Web.config
        private static string cadena = ConfigurationManager.ConnectionStrings["cadena"].ConnectionString;
        private SqlConnection conexion = new SqlConnection(cadena);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["TipoUsuario"] != null && Session["TipoUsuario"].ToString() == "Colaborador")
                {
                    lblColaborador.Text = $"Bienvenido Colaborador: {Session["CodUsuario"]}";
                    CargarEnviosColaborador(); // Método para cargar los envíos del colaborador
                }
                else
                {
                    Response.Redirect("frmLogin.aspx");
                }
            }
        }


        private void CargarEnviosColaborador()
        {
            // Obtener el usuario autenticado de la sesión
            string codUsuario = Session["CodUsuario"] as string;

            // Verificar si el usuario está autenticado
            if (!string.IsNullOrEmpty(codUsuario))
            {
                try
                {
                    // Abrir la conexión a la base de datos
                    conexion.Open();

                    // Consulta para obtener el ID del colaborador a través de la relación en ColaboradorEnvio
                    SqlCommand cmdColaborador = new SqlCommand("SELECT ce.IdColaborador FROM ColaboradorEnvio ce INNER JOIN TColaborador c ON ce.IdColaborador = c.IdColaborador WHERE c.CodUsuario = @CodUsuario", conexion);
                    cmdColaborador.Parameters.AddWithValue("@CodUsuario", codUsuario);
                    int idColaborador = (int)cmdColaborador.ExecuteScalar();

                    // Consulta para obtener los envíos realizados por el colaborador
                    SqlCommand cmdEnvios = new SqlCommand("SELECT e.IdEnvio, e.FechaEnvio, e.FechaRecojo, e.Peso, e.Volumen, e.TipoDocumento, e.TarifaBase, e.MontoPago FROM TEnvio e INNER JOIN ColaboradorEnvio ce ON e.IdEnvio = ce.IdEnvio WHERE ce.IdColaborador = @IdColaborador", conexion);
                    cmdEnvios.Parameters.AddWithValue("@IdColaborador", idColaborador);
                    SqlDataReader reader = cmdEnvios.ExecuteReader();

                    gvEnvios.DataSource = reader;
                    gvEnvios.DataBind();
                    reader.Close();
                }
                catch (Exception ex)
                {
                    lblMensajeContrasena.Text = "Error al cargar los envíos: " + ex.Message;
                }
                finally
                {
                    // Cerrar la conexión a la base de datos
                    if (conexion.State == System.Data.ConnectionState.Open)
                        conexion.Close();
                }
            }
            else
            {
                // Redirigir a la página de inicio de sesión si el usuario no está autenticado
                Response.Redirect("frmLogin.aspx");
            }
        }

        protected void btnCerrar_Click(object sender, EventArgs e)
        {
            // Eliminar variables de sesión y redirigir a la página de inicio de sesión
            Session.Remove("TipoUsuario");
            Session.Remove("CodUsuario");
            Response.Redirect("frmLogin.aspx");
        }

        protected void btnCambiarContrasena_Click(object sender, EventArgs e)
        {
            // Obtener el usuario autenticado de la sesión
            string codUsuario = Session["CodUsuario"] as string;

            // Verificar si el usuario está autenticado
            if (!string.IsNullOrEmpty(codUsuario))
            {
                try
                {
                    // Abrir la conexión a la base de datos
                    conexion.Open();

                    // Crear comando para ejecutar el procedimiento almacenado
                    SqlCommand cmdCambiarContrasena = new SqlCommand("spCambiarContrasenaColaborador", conexion);
                    cmdCambiarContrasena.CommandType = CommandType.StoredProcedure;

                    // Parámetros del procedimiento almacenado
                    cmdCambiarContrasena.Parameters.AddWithValue("@CodUsuario", codUsuario);
                    cmdCambiarContrasena.Parameters.AddWithValue("@ContrasenaActual", txtContrasenaActual.Text);
                    cmdCambiarContrasena.Parameters.AddWithValue("@NuevaContrasena", txtNuevaContrasena.Text);

                    // Ejecutar el procedimiento almacenado y obtener el resultado
                    SqlDataReader reader = cmdCambiarContrasena.ExecuteReader();
                    if (reader.Read())
                    {
                        lblMensajeContrasena.Text = reader["Mensaje"].ToString();
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    lblMensajeContrasena.Text = "Error al cambiar la contraseña: " + ex.Message;
                }
                finally
                {
                    // Cerrar la conexión a la base de datos
                    if (conexion.State == System.Data.ConnectionState.Open)
                        conexion.Close();
                }
            }
            else
            {
                Response.Redirect("frmLogin.aspx");
            }
        }



        protected void btnFiltrarEnvios_Click(object sender, EventArgs e)
        {
            // Obtener el usuario autenticado de la sesión
            string codUsuario = Session["CodUsuario"] as string;

            // Verificar si el usuario está autenticado
            if (!string.IsNullOrEmpty(codUsuario))
            {
                try
                {
                    // Abrir la conexión a la base de datos
                    conexion.Open();

                    // Consulta para obtener el ID del colaborador a través de la relación en ColaboradorEnvio
                    SqlCommand cmdColaborador = new SqlCommand("SELECT ce.IdColaborador FROM ColaboradorEnvio ce INNER JOIN TColaborador c ON ce.IdColaborador = c.IdColaborador WHERE c.CodUsuario = @CodUsuario", conexion);
                    cmdColaborador.Parameters.AddWithValue("@CodUsuario", codUsuario);
                    int idColaborador = (int)cmdColaborador.ExecuteScalar();

                    // Obtener las fechas de inicio y fin para filtrar los envíos
                    DateTime? fechaInicio = string.IsNullOrEmpty(txtFechaInicio.Text) ? (DateTime?)null : DateTime.Parse(txtFechaInicio.Text);
                    DateTime? fechaFin = string.IsNullOrEmpty(txtFechaFin.Text) ? (DateTime?)null : DateTime.Parse(txtFechaFin.Text);

                    // Consulta para obtener los envíos del colaborador con filtros de fecha
                    SqlCommand cmdEnviosFiltrados = new SqlCommand("SELECT e.IdEnvio, e.FechaEnvio, e.FechaRecojo, e.Peso, e.Volumen, e.TipoDocumento, e.TarifaBase, e.MontoPago FROM TEnvio e INNER JOIN ColaboradorEnvio ce ON e.IdEnvio = ce.IdEnvio WHERE ce.IdColaborador = @IdColaborador AND (@FechaInicio IS NULL OR e.FechaEnvio >= @FechaInicio) AND (@FechaFin IS NULL OR e.FechaEnvio <= @FechaFin)", conexion);
                    cmdEnviosFiltrados.Parameters.AddWithValue("@IdColaborador", idColaborador);
                    cmdEnviosFiltrados.Parameters.AddWithValue("@FechaInicio", fechaInicio ?? (object)DBNull.Value);
                    cmdEnviosFiltrados.Parameters.AddWithValue("@FechaFin", fechaFin ?? (object)DBNull.Value);

                    SqlDataReader reader = cmdEnviosFiltrados.ExecuteReader();

                    gvEnvios.DataSource = reader;
                    gvEnvios.DataBind();
                    reader.Close();
                }
                catch (Exception ex)
                {
                    lblMensajeContrasena.Text = "Error al filtrar los envíos: " + ex.Message;
                }
                finally
                {
                    // Cerrar la conexión a la base de datos
                    if (conexion.State == System.Data.ConnectionState.Open)
                        conexion.Close();
                }
            }
            else
            {
                Response.Redirect("frmLogin.aspx");
            }
        }
    }
}
