using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Transporte_Trome
{
    public partial class frmColaboradorEnvio : System.Web.UI.Page
    {
        // Llamar a la cadena de conexión
        private static string cadena = ConfigurationManager.ConnectionStrings["cadena"].ConnectionString;
        // Llamar al mapeado objeto Relacional 
        private TromeDataContext trome = new TromeDataContext(cadena);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Listar();
                btnActualizar.Visible = false; // Ocultar el botón de actualizar inicialmente
            }
        }

        private void Listar()
        {
            var consulta = from C in trome.ColaboradorEnvio
                           select C;
            gvColaboradorEnvio.DataSource = consulta.ToList();
            gvColaboradorEnvio.DataBind();
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                // Verificar que los campos no estén vacíos
                if (string.IsNullOrEmpty(txtIdColaborador.Text) || string.IsNullOrEmpty(txtIdEnvio.Text))
                {
                    lblMensaje.Text = "Por favor complete todos los campos.";
                    return;
                }

                // Crear un nuevo objeto de ColaboradorEnvio
                ColaboradorEnvio nuevoColaboradorEnvio = new ColaboradorEnvio
                {
                    IdColaborador = int.Parse(txtIdColaborador.Text),
                    IdEnvio = int.Parse(txtIdEnvio.Text)
                };

                // Agregar y guardar cambios en la base de datos
                trome.ColaboradorEnvio.InsertOnSubmit(nuevoColaboradorEnvio);
                trome.SubmitChanges();

                // Actualizar la lista y mostrar mensaje de éxito
                Listar();
                lblMensaje.Text = "Colaborador envío agregado correctamente.";
            }
            catch (Exception ex)
            {
                // Manejar errores y mostrar mensaje al usuario
                lblMensaje.Text = "Error al agregar colaborador envío: " + ex.Message;
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                int IdColaborador = int.Parse(txtIdColaborador.Text);
                var colaboradorEnvio = trome.ColaboradorEnvio.SingleOrDefault(c => c.IdColaborador == IdColaborador);

                if (colaboradorEnvio != null)
                {
                    trome.ColaboradorEnvio.DeleteOnSubmit(colaboradorEnvio);
                    trome.SubmitChanges();
                    Listar();
                    lblMensaje.Text = "Colaborador envío eliminado correctamente.";
                }
                else
                {
                    lblMensaje.Text = "Colaborador envío no encontrado.";
                }
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error al eliminar colaborador envío: " + ex.Message;
            }
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                int IdColaborador = int.Parse(txtIdColaborador.Text);
                var colaboradorEnvio = trome.ColaboradorEnvio.SingleOrDefault(c => c.IdColaborador == IdColaborador);

                if (colaboradorEnvio != null)
                {
                    // Actualizar solo si hay cambios
                    colaboradorEnvio.IdEnvio = int.Parse(txtIdEnvio.Text);

                    trome.SubmitChanges();
                    Listar();
                    lblMensaje.Text = "Colaborador envío actualizado correctamente.";
                }
                else
                {
                    lblMensaje.Text = "Colaborador envío no encontrado.";
                }
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error al actualizar colaborador envío: " + ex.Message;
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                int IdColaborador = int.Parse(txtBuscar.Text);
                var consulta = from C in trome.ColaboradorEnvio
                               where C.IdColaborador == IdColaborador
                               select C;

                gvColaboradorEnvio.DataSource = consulta.ToList();
                gvColaboradorEnvio.DataBind();

                if (!consulta.Any())
                {
                    lblMensaje.Text = "Colaborador envío no encontrado.";
                }
                else
                {
                    lblMensaje.Text = "";
                }
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error al buscar colaborador envío: " + ex.Message;
            }
        }

        protected void btnVerTodos_Click(object sender, EventArgs e)
        {
            Listar();
        }


        protected void gvColaboradorEnvioSelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = gvColaboradorEnvio.SelectedRow;
            txtIdColaborador.Text = row.Cells[1].Text;
            txtIdEnvio.Text = row.Cells[2].Text;

            btnActualizar.Visible = true; // Mostrar el botón de actualizar cuando se selecciona una fila
        }
    }
}
