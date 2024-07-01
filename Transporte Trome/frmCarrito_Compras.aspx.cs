using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.UI.WebControls;

namespace Transporte_Trome
{
    public partial class Carrito_Compras : System.Web.UI.Page
    {
        private static string cadena = System.Configuration.ConfigurationManager.ConnectionStrings["cadena"].ConnectionString;
        private TromeDataContext trome = new TromeDataContext(cadena);
        private List<CarritoItem> CarritoItems
        {
            get
            {
                if (Session["CarritoItems"] == null)
                {
                    Session["CarritoItems"] = new List<CarritoItem>();
                }
                return (List<CarritoItem>)Session["CarritoItems"];
            }
            set
            {
                Session["CarritoItems"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarCarrito();

            }
        }

        private void CargarCarrito()
        {
            List<int> carritoServicios = Session["CarritoServicios"] as List<int>;

            if (carritoServicios != null && carritoServicios.Any())
            {
                foreach (int idServicio in carritoServicios)
                {
                    var servicio = trome.Servicio.FirstOrDefault(s => s.IdServicio == idServicio);
                    if (servicio != null)
                    {
                        var existingItem = CarritoItems.FirstOrDefault(item => item.IdServicio == idServicio);
                        if (existingItem != null)
                        {
                            // Si ya está en el carrito, actualizar la cantidad y subtotal
                            existingItem.Cantidad = ObtenerCantidadDesdeSesion(idServicio);
                            existingItem.Subtotal = existingItem.Cantidad * servicio.TarifaBase;
                        }
                        else
                        {
                            // Si no está en el carrito, agregarlo
                            CarritoItems.Add(new CarritoItem
                            {
                                IdCarrito = GetNextId(),
                                IdServicio = servicio.IdServicio,
                                Descripcion = servicio.Descripcion,
                                Cantidad = ObtenerCantidadDesdeSesion(idServicio),
                                TarifaBase = servicio.TarifaBase,
                                Subtotal = ObtenerCantidadDesdeSesion(idServicio) * servicio.TarifaBase
                            });
                        }
                    }
                }
            }

            ActualizarGridView();
        }

        private int ObtenerCantidadDesdeSesion(int idServicio)
        {
            // Obtener la cantidad seleccionada desde la sesión
            object cantidad = Session["CantidadServicio_" + idServicio];
            if (cantidad != null && int.TryParse(cantidad.ToString(), out int cantidadSeleccionada))
            {
                return cantidadSeleccionada;
            }
            return 1; // Devolver 1 por defecto si no se encuentra
        }

        private int GetNextId()
        {
            return CarritoItems.Any() ? CarritoItems.Max(item => item.IdCarrito) + 1 : 1;
        }

        protected void gvCarrito_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Eliminar")
            {
                int idCarrito = Convert.ToInt32(e.CommandArgument);
                var itemToRemove = CarritoItems.FirstOrDefault(item => item.IdCarrito == idCarrito);
                if (itemToRemove != null)
                {
                    CarritoItems.Remove(itemToRemove);
                    ActualizarGridView();
                }
            }
        }

        protected void txtCantidad_TextChanged(object sender, EventArgs e)
        {
            TextBox txtCantidad = (TextBox)sender;
            GridViewRow row = (GridViewRow)txtCantidad.NamingContainer;

            if (int.TryParse(txtCantidad.Text, out int cantidad) && row.RowIndex >= 0 && row.RowIndex < gvCarrito.Rows.Count)
            {
                var item = CarritoItems[row.RowIndex];
                item.Cantidad = cantidad;
                item.Subtotal = cantidad * item.TarifaBase;

                ActualizarGridView();
            }
        }


        protected void Pagar_Click(object sender, EventArgs e)
        {
            // Lógica para procesar el pago aquí

            // Actualizar el estado de los servicios pagados
            foreach (var item in CarritoItems)
            {
                item.Estado = "Pagado"; // Aquí puedes establecer el estado como necesario
            }

            // Refrescar el GridView principal
            ActualizarGridView();

            // Llenar el GridView de servicios adquiridos
            gvServiciosAdquiridos.DataSource = CarritoItems.Select(ci => new
            {
                IdServicio = ci.IdServicio,
                Descripcion = ci.Descripcion,
                Estado = ci.Estado
            }).ToList();
            gvServiciosAdquiridos.DataBind();

            // Mensaje de pago exitoso
            string mensaje = "¡Pago exitoso! Sus servicios han sido cargados al carrito de compras.";
            ClientScript.RegisterStartupScript(this.GetType(), "PagoExitoso", $"alert('{mensaje}');", true);

            // Redirección a la página de servicios u otra página relevante
            // Response.Redirect("frm_Servicios.aspx");
        }



        protected void ActualizarGridView()
        {
            gvCarrito.DataSource = CarritoItems;
            gvCarrito.DataBind();

            CalcularTotalCarrito();
        }

        protected void Regresar_Servicios_Click(object sender, EventArgs e)
        {
            GuardarCambiosEnSession();
            Response.Redirect("frm_Servicios.aspx");
        }

        private void GuardarCambiosEnSession()
        {
            // Guardar los cambios en el carrito en la sesión
            List<int> carritoServicios = new List<int>();
            foreach (var item in CarritoItems)
            {
                carritoServicios.Add(item.IdServicio);
                Session["CantidadServicio_" + item.IdServicio] = item.Cantidad;
            }
            Session["CarritoServicios"] = carritoServicios;
        }

        private void CalcularTotalCarrito()
        {
            decimal total = CarritoItems.Sum(item => item.Subtotal);
            lblTotalCarrito.Text = total.ToString("C");
        }

        // Clase para representar un ítem del carrito
        public class CarritoItem
        {
            public int IdCarrito { get; set; }
            public int IdServicio { get; set; }
            public string Descripcion { get; set; }
            public int Cantidad { get; set; }
            public decimal TarifaBase { get; set; }
            public decimal Subtotal { get; set; }
            public string Estado { get; internal set; }
        }
    }
   

}
