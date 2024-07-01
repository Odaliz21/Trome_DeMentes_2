using System;
using System.Configuration;
using System.Linq;
using System.Web.UI;

namespace Transporte_Trome
{
    public partial class frmLoginCliente : Page
    {
        // Llamar a la cadena de conexión
        private static string cadena = ConfigurationManager.ConnectionStrings["cadena"].ConnectionString;
        // Llamar al mapeado objeto Relacional 
        private TromeDataContext trome = new TromeDataContext(cadena);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["TipoUsuario"] != null && Session["TipoUsuario"].ToString() == "Cliente")
                {
                    lblCliente.Text = $"Bienvenido Cliente: {Session["CodUsuario"]}";
                    CargarEnviosCliente();
                    CargarServicios();
                }
                else
                {
                    Response.Redirect("frmLogin.aspx");
                }
            }
        }


        private void CargarEnviosCliente()
        {
            // Obtener el usuario autenticado de la sesión
            string codUsuario = Session["CodUsuario"] as string;

            // Verificar si el usuario está autenticado
            if (!string.IsNullOrEmpty(codUsuario))
            {
                // Obtener el cliente correspondiente al usuario autenticado
                var cliente = trome.Cliente.FirstOrDefault(c => c.CodUsuario == codUsuario);

                if (cliente != null)
                {
                    // Cargar los envíos del cliente
                    var envios = from e in trome.Envio
                                 where e.IdCliente == cliente.IdCliente
                                 select new
                                 {
                                     e.IdEnvio,
                                     e.FechaEnvio,
                                     e.FechaRecojo,
                                     e.Peso,
                                     e.Volumen,
                                     e.TipoDocumento,
                                     e.TarifaBase,
                                     e.MontoPago
                                 };

                    gvEnvios.DataSource = envios;
                    gvEnvios.DataBind();
                }
                else
                {
                    // Manejar el caso donde el cliente no se encontró
                    lblCliente.Text = "Cliente no encontrado.";
                }
            }
            else
            {
                // Redirigir a la página de inicio de sesión si el usuario no está autenticado
                Response.Redirect("frmLogin.aspx");
            }
        }

        private void CargarServicios()
        {
            // Cargar los servicios disponibles
            var servicios = from s in trome.Servicio
                            select new
                            {
                                s.IdServicio,
                                s.Descripcion,
                                s.TarifaBase
                            };

            gvServicios.DataSource = servicios;
            gvServicios.DataBind();
        }

        protected void btnCerrar_Click(object sender, EventArgs e)
        {
            // Eliminar variables de sesión y redirigir a la página de inicio de sesión
            Session.Remove("TipoUsuario");
            Session.Remove("CodUsuario");
            Response.Redirect("frmLogin.aspx");
        }

        protected void btnFiltrarEnvios_Click(object sender, EventArgs e)
        {
            // Obtener el usuario autenticado de la sesión
            string codUsuario = Session["CodUsuario"] as string;

            // Verificar si el usuario está autenticado
            if (!string.IsNullOrEmpty(codUsuario))
            {
                // Obtener el cliente correspondiente al usuario autenticado
                var cliente = trome.Cliente.FirstOrDefault(c => c.CodUsuario == codUsuario);

                if (cliente != null)
                {
                    DateTime? fechaInicio = string.IsNullOrEmpty(txtFechaInicio.Text) ? (DateTime?)null : DateTime.Parse(txtFechaInicio.Text);
                    DateTime? fechaFin = string.IsNullOrEmpty(txtFechaFin.Text) ? (DateTime?)null : DateTime.Parse(txtFechaFin.Text);

                    // Cargar los envíos del cliente con filtros de fecha
                    var envios = from E in trome.Envio
                                 where E.IdCliente == cliente.IdCliente
                                 && (!fechaInicio.HasValue || E.FechaEnvio >= fechaInicio)
                                 && (!fechaFin.HasValue || E.FechaEnvio <= fechaFin)
                                 select new
                                 {
                                     E.IdEnvio,
                                     E.FechaEnvio,
                                     E.FechaRecojo,
                                     E.Peso,
                                     E.Volumen,
                                     E.TipoDocumento,
                                     E.TarifaBase,
                                     E.MontoPago
                                 };

                    gvEnvios.DataSource = envios;
                    gvEnvios.DataBind();
                }
                else
                {
                    // Manejar el caso donde el cliente no se encontró
                    lblCliente.Text = "Cliente no encontrado.";
                }
            }
            else
            {
                // Redirigir a la página de inicio de sesión si el usuario no está autenticado
                Response.Redirect("frmLogin.aspx");
            }
        }

        protected void btnFiltrarServicios_Click(object sender, EventArgs e)
        {
            int idServicio;
            string descripcion = txtDescripcionServicio.Text.Trim();

            var servicios = from s in trome.Servicio
                            where (string.IsNullOrEmpty(txtIdServicio.Text) || (int.TryParse(txtIdServicio.Text, out idServicio) && s.IdServicio == idServicio))
                            && (string.IsNullOrEmpty(descripcion) || s.Descripcion.Contains(descripcion))
                            select new
                            {
                                s.IdServicio,
                                s.Descripcion,
                                s.TarifaBase
                            };

            gvServicios.DataSource = servicios;
            gvServicios.DataBind();
        }
    }
}
