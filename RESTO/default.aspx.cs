using Manager;
using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RESTO
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            Manager.ServicioUsuario servicioUsuario = new Manager.ServicioUsuario();
            Usuario usuario = servicioUsuario.Loguear(TxtUsuario.Text,TxtPassword.Text);

            if (usuario != null) {

                Session.Add("DNI", usuario.Dni);
                Session.Add("IdUsuario", usuario.IdUsuario);
                Session.Add("IdPerfil", usuario.Perfil.IdPerfil);
                Session.Add("Nombre", usuario.Nombre + " " + usuario.Apellido);

                switch(usuario.Perfil.IdPerfil) 
                {
                    case 1:
                        Response.Redirect("PaginaGerente.aspx");
                    break;
                    case 2:
                        List<Pedido> pedidosPersistidos = new List<Pedido>();
                        Session.Add("PedidosPersistidos", pedidosPersistidos);
                        Response.Redirect("PaginaMesero.aspx");
                    break;
                    default:
                        // code block
                    break;}
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "Swal.fire('Error', 'Contraseña o usuario incorrecto, verifique los datos nuevamente', 'error');", true);
            }
        }

              
    }
}