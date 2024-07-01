using System;
using System.Collections.Generic;
using System.Linq;

namespace Transporte_Trome
{
    public partial class frm_Servicios : System.Web.UI.Page
    {
        private static string cadena = System.Configuration.ConfigurationManager.ConnectionStrings["cadena"].ConnectionString;
        private TromeDataContext trome = new TromeDataContext(cadena);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarCatalogoServicios();
            }
        }

        protected void CargarCatalogoServicios()
        {
            var servicios = from s in trome.Servicio
                            select new
                            {
                                s.IdServicio,
                                s.Descripcion,
                                s.TarifaBase
                            };

            rptServicios.DataSource = servicios.ToList();
            rptServicios.DataBind();
        }

        protected void rptServicios_ItemCommand(object source, System.Web.UI.WebControls.RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "AgregarCarrito")
            {
                int idServicio = Convert.ToInt32(e.CommandArgument);
                // Obtener el carrito de servicios desde la sesión o inicializar si es null
                var carritoServicios = Session["CarritoServicios"] as List<int> ?? new List<int>();

                if (!carritoServicios.Contains(idServicio))
                {
                    carritoServicios.Add(idServicio);
                    Session["CarritoServicios"] = carritoServicios;
                }

                Response.Redirect("frmCarrito_Compras.aspx"); // Redirige al carrito de compras después de agregar
            }
        }

        protected void VerCarrito_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmCarrito_Compras.aspx");
        }
    }
}
