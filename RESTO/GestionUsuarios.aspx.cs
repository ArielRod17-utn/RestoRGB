using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Manager;
using Dominio;
using System.Drawing;

namespace RESTO
{
    public partial class Gestion_Usuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!ValidarAccesoPagina(int.Parse(Session["IdPerfil"].ToString())))
            {
                Server.Transfer("default.aspx");
            }
            else
            {
                ServicioUsuario servicioUsuario = new ServicioUsuario();
                List<Usuario> lista = servicioUsuario.ListarUsuarios();
                dgvUsuario.DataSource = servicioUsuario.ListarUsuarios();
                dgvUsuario.DataBind();
            }
        }
        public bool ValidarAccesoPagina(int perfil)
        {

            if (perfil == 1)
            {
                return true;
            }
            else
            {
                Response.Write("<script>alert('El usuario no posee el permiso suficiente para acceder a esta pagina.')</script>");
                return false;
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            if ((Session["IdUsuario"] == null))
            {
                Response.Write("<script>alert('No se selecciono usuario para eliminar.')</script>");
            }
            else
            {
                try
                {
                    ServicioUsuario servicioUsuario = new ServicioUsuario();

                    int IdUsuario = int.Parse(Session["IdUsuario"].ToString());
                    servicioUsuario.EliminarUsuario(IdUsuario);
                    Response.Redirect("GestionUsuarios.aspx");
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        protected void dgvUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {
                            
            Session["IdUsuario"] = dgvUsuario.SelectedDataKey.Value.ToString();
            dgvUsuario.SelectedRowStyle.BorderColor = Color.Red;
            if (dgvUsuario.SelectedRow.RowIndex!=0) {
                dgvUsuario.Rows[dgvUsuario.SelectedRow.RowIndex - 1].BorderColor = Color.Red;
            }
            dgvUsuario.SelectedRowStyle.ForeColor= Color.Red;
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Response.Redirect("AgregarUsuario.aspx");
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            if ((Session["IdUsuario"] == null))
            {
                Response.Write("<script>alert('No se selecciono usuario para modificar.')</script>");
            }
            else
            {
                string IdUsuario = Session["IdUsuario"].ToString();
                Response.Redirect("AgregarUsuario.aspx?id=" + IdUsuario);
            }
        }
    }
}
