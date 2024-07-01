using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Net.Mime.MediaTypeNames;

namespace Transporte_Trome
{
    public partial class frmEnvio : System.Web.UI.Page
    {
        // Llamar a la cadena de conexión
        private static string cadena = ConfigurationManager.ConnectionStrings["cadena"].ConnectionString;
        // Llamar al mapeado objeto Relacional 
        private TromeDataContext trome = new TromeDataContext(cadena);

        private void Listar()
        {
            var consulta = from E in trome.Envio
                           select E;
            gvEnvio.DataSource = consulta;
            gvEnvio.DataBind();
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
                Envio nuevoEnvio = new Envio
                {
                    IdCliente = int.Parse(txtIdCliente.Text),
                    IdServicio = int.Parse(txtIdServicio.Text),
                    FechaEnvio = DateTime.Parse(txtFechaEnvio.Text),
                    FechaRecojo = DateTime.Parse(txtFechaRecojo.Text),
                    Peso = decimal.Parse(txtPeso.Text),
                    Volumen = decimal.Parse(txtVolumen.Text),
                    TipoDocumento = txtTipoDocumento.Text[0], // Suponiendo que txtTipoDocumento tiene un solo caracter
                    TarifaBase = decimal.Parse(txtTarifaBase.Text)
                };

                trome.Envio.InsertOnSubmit(nuevoEnvio);
                trome.SubmitChanges();
                Listar();
                lblMensaje.Text = "Envio agregado correctamente.";
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error al agregar Envio: " + ex.Message;
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                int IdCliente = int.Parse(txtIdCliente.Text);
                var envio = trome.Envio.SingleOrDefault(c => c.IdCliente == IdCliente);

                if (envio != null)
                {
                    trome.Envio.DeleteOnSubmit(envio);
                    trome.SubmitChanges();
                    Listar();
                    lblMensaje.Text = "Envio eliminado correctamente.";
                }
                else
                {
                    lblMensaje.Text = "Envio no encontrado.";
                }
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error al eliminar envio: " + ex.Message;
            }
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                int IdCliente = int.Parse(txtIdCliente.Text);
                var envio = trome.Envio.SingleOrDefault(c => c.IdCliente == IdCliente);

                if (envio != null)
                {
                    envio.IdServicio = int.Parse(txtIdServicio.Text);
                    envio.FechaEnvio = DateTime.Parse(txtFechaEnvio.Text);
                    envio.FechaRecojo = DateTime.Parse(txtFechaRecojo.Text);
                    envio.Peso = decimal.Parse(txtPeso.Text);
                    envio.Volumen = decimal.Parse(txtVolumen.Text);
                    envio.TipoDocumento = txtTipoDocumento.Text[0]; // Suponiendo que txtTipoDocumento tiene un solo caracter
                    envio.TarifaBase = decimal.Parse(txtTarifaBase.Text);

                    trome.SubmitChanges();
                    Listar();
                    lblMensaje.Text = "Envio actualizado correctamente.";
                }
                else
                {
                    lblMensaje.Text = "Envio no encontrado.";
                }
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error al actualizar envio: " + ex.Message;
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                int IdCliente = int.Parse(txtBuscar.Text);
                var consulta = from E in trome.Envio
                               where E.IdCliente == IdCliente
                               select E;

                gvEnvio.DataSource = consulta.ToList();
                gvEnvio.DataBind();

                if (!consulta.Any())
                {
                    lblMensaje.Text = "Envio no encontrado.";
                }
                else
                {
                    lblMensaje.Text = "";
                }
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error al buscar Envio: " + ex.Message;
            }
        }

        protected void btnVerTodos_Click(object sender, EventArgs e)
        {
            Listar();
        }

       

        protected void gvEnvioSelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = gvEnvio.SelectedRow;
            txtIdCliente.Text = row.Cells[2].Text;
            txtIdServicio.Text = row.Cells[3].Text;
            txtFechaEnvio.Text = row.Cells[4].Text;
            txtFechaRecojo.Text = row.Cells[5].Text;
            txtPeso.Text = row.Cells[6].Text;
            txtVolumen.Text = row.Cells[7].Text;
            txtTipoDocumento.Text = row.Cells[8].Text;
            txtTarifaBase.Text = row.Cells[9].Text;

            btnActualizar.Visible = true; // Mostrar el botón de actualizar cuando se selecciona una fila
        }
    }
}
