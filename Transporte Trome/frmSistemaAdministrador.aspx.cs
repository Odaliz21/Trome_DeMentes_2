using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Transporte_Trome
{
    public partial class frmSistemaAdministrador : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["TipoUsuario"] != null && Session["TipoUsuario"].ToString() == "Administrador")
                {
                    lblAdministrador.Text = $"Bienvenido Admin: {Session["CodUsuario"]}";
                }
                else
                {
                    Response.Redirect("frmLogin.aspx");
                }
            }
        }


        protected void btnCrudCliente_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmCliente.aspx");
        }

        protected void btnCrudColaborador_Click(object sender, EventArgs e)
        {
            Response.Redirect("FrmColaborador.aspx");
        }

        protected void btnCrudColaboradorEnvio_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmColaboradorEnvio.aspx");
        }

        protected void btnCrudVehiculo_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmVehiculo.aspx");
        }

        protected void btnCerrar_Click(object sender, EventArgs e)
        {
            // Remove session variables and redirect to login page
            Session.Remove("TipoUsuario");
            Session.Remove("CodUsuario");
            Response.Redirect("frmLogin.aspx");
        }

        protected void btnCrudEnvio_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmEnvio.aspx");
        }

        protected void btnCrudUsuario_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmUsuario.aspx");
        }

        protected void btnCrudServicio_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmServicio.aspx");
        }
    }
}