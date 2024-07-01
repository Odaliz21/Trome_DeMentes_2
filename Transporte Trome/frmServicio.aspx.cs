using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace Transporte_Trome
{
    public partial class Servicios : System.Web.UI.Page
    {
        private static string cadena = ConfigurationManager.ConnectionStrings["cadena"].ConnectionString;
        private SqlConnection conexion = new SqlConnection(cadena);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarServicios();
            }
        }

        protected void CargarServicios()
        {
            try
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("SELECT IdServicio, Descripcion, TarifaBase FROM TServicio", conexion);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                gvServicios.DataSource = dt;
                gvServicios.DataBind();
            }
            catch (Exception ex)
            {
                lblMensaje.Text = $"Error al cargar los servicios: {ex.Message}";
            }
            finally
            {
                if (conexion.State == ConnectionState.Open)
                    conexion.Close();
            }
        }

        protected void gvServicios_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "AgregarCarrito")
            {
                int idServicio = Convert.ToInt32(e.CommandArgument);
                // Aquí podrías implementar la lógica para agregar el servicio al carrito
                // Por ejemplo, redirigir a la página de carrito con el ID del servicio
                Response.Redirect($"Carrito_Compras.aspx?idServicio={idServicio}");
            }
        }

        protected void VerCarrito_Click(object sender, EventArgs e)
        {
            Response.Redirect("Carrito_Compras.aspx");
        }
    }
}
