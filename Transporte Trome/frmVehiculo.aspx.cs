using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Transporte_Trome
{
    public partial class frmVehiculo : System.Web.UI.Page
    {
        // Llamar a la cadena de conexión
        private static string cadena = ConfigurationManager.ConnectionStrings["cadena"].ConnectionString;
        // Llamar al mapeado objeto Relacional 
        private TromeDataContext trome = new TromeDataContext(cadena);

        private void Listar()
        {
            var consulta = from V in trome.Vehiculo
                           select V;
            gvVehiculo.DataSource = consulta;
            gvVehiculo.DataBind();
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
                decimal capacidadCarga;
                if (!decimal.TryParse(txtCapacidadCarga.Text, out capacidadCarga))
                {
                    lblMensaje.Text = "Capacidad de carga inválida.";
                    return;
                }

                Vehiculo nuevoVehiculo = new Vehiculo
                {
                    Marca = txtMarca.Text,
                    Modelo = txtModelo.Text,
                    Placa = txtPlaca.Text,
                    CapacidadCarga = capacidadCarga,
                };

                trome.Vehiculo.InsertOnSubmit(nuevoVehiculo);
                trome.SubmitChanges();
                Listar();
                lblMensaje.Text = "Vehiculo agregado correctamente.";
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error al agregar vehiculo: " + ex.Message;
            }
        }


        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                string marca = txtMarca.Text;
                var vehiculo = trome.Vehiculo.SingleOrDefault(v => v.Marca == marca);

                if (vehiculo != null)
                {
                    trome.Vehiculo.DeleteOnSubmit(vehiculo);
                    trome.SubmitChanges();
                    Listar();
                    lblMensaje.Text = "Vehiculo eliminado correctamente.";
                }
                else
                {
                    lblMensaje.Text = "Vehiculo no encontrado.";
                }
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error al eliminar vehiculo: " + ex.Message;
            }
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                string marca = txtMarca.Text;
                var vehiculo = trome.Vehiculo.SingleOrDefault(v => v.Marca == marca);

                if (vehiculo != null)
                {
                    decimal capacidadCarga;
                    if (!decimal.TryParse(txtCapacidadCarga.Text, out capacidadCarga))
                    {
                        lblMensaje.Text = "Capacidad de carga inválida.";
                        return;
                    }

                    vehiculo.Marca = txtMarca.Text;
                    vehiculo.Modelo = txtModelo.Text;
                    vehiculo.Placa = txtPlaca.Text;
                    vehiculo.CapacidadCarga = capacidadCarga;

                    trome.SubmitChanges();
                    Listar();
                    lblMensaje.Text = "Vehiculo actualizado correctamente.";
                }
                else
                {
                    lblMensaje.Text = "Vehiculo no encontrado.";
                }
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error al actualizar vehiculo: " + ex.Message;
            }
        }


        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                string Marca = txtBuscar.Text;
                var consulta = from V in trome.Vehiculo
                               where V.Marca == Marca
                               select V;

                gvVehiculo.DataSource = consulta.ToList();
                gvVehiculo.DataBind();

                if (!consulta.Any())
                {
                    lblMensaje.Text = "Vehiculo no encontrado.";
                }
                else
                {
                    lblMensaje.Text = "";
                }
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error al buscar vehiculo: " + ex.Message;
            }
        }

        protected void btnVerTodos_Click(object sender, EventArgs e)
        {
            Listar();
        }

        protected void gvVehiculo_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = gvVehiculo.SelectedRow;
            txtMarca.Text = row.Cells[2].Text;
            txtModelo.Text = row.Cells[3].Text;
            txtPlaca.Text = row.Cells[4].Text;
            txtCapacidadCarga.Text = row.Cells[5].Text;

            btnActualizar.Visible = true; // Mostrar el botón de actualizar cuando se selecciona una fila

        }
    }
}