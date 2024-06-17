using Dominio;
using Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RESTO
{
    public partial class Gestion_Menu : System.Web.UI.Page
    {
        ServicioCategoria servicioCategoria = new ServicioCategoria();
        ServicioMenu servicioMenu = new ServicioMenu();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlCategorias.DataSource = servicioCategoria.ListarCategoria();

                ddlCategorias.DataTextField = "Descripcion";
                ddlCategorias.DataValueField = "IdCategoria";
                ddlCategorias.DataBind();

                ddlCategorias.SelectedIndex = 0;

                try
                {
                    int idCategoriaSeleccionado = Convert.ToInt32(ddlCategorias.SelectedItem.Value);
                    dgvMenu.DataSource = servicioMenu.ListarElementoMenu(idCategoriaSeleccionado);
                    dgvMenu.DataBind();

                    dgvStock.DataSource = servicioMenu.ListarStock();
                    dgvStock.DataBind();
                }
                catch (Exception)
                {
                    Response.Write("<script>alert('No se seleccionó Menú para eliminar.')</script>");
                }

                
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Response.Redirect("AgregarMenu.aspx");
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            if (Session["IdMenu"]!= null) {
                string IdMenu = Session["IdMenu"].ToString();
                Response.Redirect("AgregarMenu.aspx?id=" + IdMenu);
            }
          
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {

            if ((Session["IdMenu"] == null))
            {
                Response.Write("<script>alert('No se seleccionó Menú para eliminar.')</script>");
            }
            else
            {
                try
                {
                    ServicioMenu servicioMenu = new ServicioMenu();

                    int IdMenu = int.Parse(Session["IdMenu"].ToString());
                    servicioMenu.EliminarElementoMenu(IdMenu);
                    Response.Redirect("Gestion_Menu.aspx");
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        protected void dgvMenu_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["IdMenu"] = dgvMenu.SelectedDataKey.Value.ToString();
            dgvMenu.SelectedRowStyle.BorderColor = System.Drawing.Color.Red;
            if (dgvMenu.SelectedRow.RowIndex!=0) {
                dgvMenu.Rows[dgvMenu.SelectedRow.RowIndex - 1].BorderColor = System.Drawing.Color.Red;
            }
            dgvMenu.SelectedRowStyle.ForeColor=System.Drawing.Color.Red;

        }

        protected void ddlCategorias_SelectedIndexChanged(object sender, EventArgs e)
        {
           int idCategoriaSeleccionado = Convert.ToInt32(ddlCategorias.SelectedItem.Value);
           dgvMenu.DataSource = servicioMenu.ListarElementoMenu(idCategoriaSeleccionado);
           dgvMenu.DataBind();
 
        }
    }
}