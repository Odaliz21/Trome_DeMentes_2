using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Transporte_Trome
{
    public partial class FrmColaborador : System.Web.UI.Page
    {
        // Llamar a la cadena de conexión
        private static string cadena = ConfigurationManager.ConnectionStrings["cadena"].ConnectionString;
        // Llamar al mapeado objeto relacional
        private TromeDataContext trome = new TromeDataContext(cadena);

        private void Listar()
        {
            var consulta = from C in trome.Colaborador
                           select C;
            gvColaborador.DataSource = consulta;
            gvColaborador.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Listar();
                btnActualizar.Visible = false; // Ocultar el botón de actualizar inicialmente
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                int idVehiculo = int.Parse(txtIdVehiculo.Text);

                // Verificar si el vehículo existe en la base de datos
                var vehiculoExistente = trome.Vehiculo.FirstOrDefault(v => v.IdVehiculo == idVehiculo);

                if (vehiculoExistente != null)
                {
                    // El vehículo existe, podemos proceder a agregar el colaborador
                    Colaborador nuevoColaborador = new Colaborador
                    {
                        Nombre = txtNombre.Text,
                        Cargo = txtCargo.Text,
                        Telefono = txtTelefono.Text,
                        CodUsuario = txtCodUsuario.Text,
                        Contrasena = txtContrasena.Text,
                        IdVehiculo = idVehiculo // Asignamos el IdVehiculo validado
                    };

                    trome.Colaborador.InsertOnSubmit(nuevoColaborador);
                    trome.SubmitChanges();
                    Listar();
                    lblMensaje.Text = "Colaborador agregado correctamente.";
                }
                else
                {
                    // El vehículo no existe, mostrar un mensaje de error
                    lblMensaje.Text = "Error: El vehículo con ID " + idVehiculo + " no existe.";
                }
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error al agregar colaborador: " + ex.Message;
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                int idVehiculo = int.Parse(txtIdVehiculo.Text); // Obtener el ID del vehículo desde el campo de texto

                // Buscar los colaboradores asociados al vehículo en la base de datos
                var colaboradores = trome.Colaborador.Where(c => c.IdVehiculo == idVehiculo).ToList();

                if (colaboradores.Any())
                {
                    // Eliminar cada colaborador encontrado
                    trome.Colaborador.DeleteAllOnSubmit(colaboradores);
                    trome.SubmitChanges();
                    Listar();
                    lblMensaje.Text = $"Se eliminaron {colaboradores.Count} colaborador(es) asociado(s) al vehículo con ID {idVehiculo}.";
                }
                else
                {
                    lblMensaje.Text = $"No se encontraron colaboradores asociados al vehículo con ID {idVehiculo} para eliminar.";
                }
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error al eliminar colaboradores: " + ex.Message;
            }
        }


        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                int idVehiculo = int.Parse(txtIdVehiculo.Text);
                int idColaborador = int.Parse(gvColaborador.SelectedRow.Cells[1].Text); // Obtener el ID del colaborador seleccionado

                // Obtener el colaborador desde la base de datos
                var colaborador = trome.Colaborador.FirstOrDefault(c => c.IdColaborador == idColaborador);

                if (colaborador != null)
                {
                    colaborador.Nombre = txtNombre.Text;
                    colaborador.Cargo = txtCargo.Text;
                    colaborador.Telefono = txtTelefono.Text;
                    colaborador.CodUsuario = txtCodUsuario.Text;
                    colaborador.Contrasena= txtContrasena.Text;
                    colaborador.IdVehiculo = idVehiculo;

                    trome.SubmitChanges();
                    Listar();
                    lblMensaje.Text = "Colaborador actualizado correctamente.";
                    btnActualizar.Visible = false; // Ocultar el botón de actualizar después de la operación
                }
                else
                {
                    lblMensaje.Text = "Error: No se encontró el colaborador para actualizar.";
                }
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error al actualizar colaborador: " + ex.Message;
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                string nombre = txtBuscar.Text;
                var consulta = from C in trome.Colaborador
                               where C.Nombre == nombre
                               select C;

                gvColaborador.DataSource = consulta.ToList();
                gvColaborador.DataBind();

                if (!consulta.Any())
                {
                    lblMensaje.Text = "Colaborador no encontrado.";
                }
                else
                {
                    lblMensaje.Text = "";
                }
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error al buscar colaborador: " + ex.Message;
            }
        }

        protected void btnVerTodos_Click(object sender, EventArgs e)
        {
            Listar();
        }

        protected void gvColaborador_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = gvColaborador.SelectedRow;
            txtNombre.Text = row.Cells[2].Text;
            txtCargo.Text = row.Cells[3].Text;
            txtTelefono.Text = row.Cells[4].Text;
            txtCodUsuario.Text = row.Cells[5].Text;
            txtContrasena.Text = row.Cells[6].Text;
            txtIdVehiculo.Text = row.Cells[7].Text;

            btnActualizar.Visible = true; // Mostrar el botón de actualizar cuando se selecciona una fila
        }
    }
}
