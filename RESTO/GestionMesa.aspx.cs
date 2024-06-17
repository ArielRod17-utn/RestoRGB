using Manager;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RESTO
{
    public partial class GestionMesa : System.Web.UI.Page
    {
        ServicioMesa servicioMesa = new ServicioMesa();

        protected void Page_Load(object sender, EventArgs e)
        {
                dgvMesa.DataSource = servicioMesa.ListarMesas();
                dgvMesa.DataBind();
        }

        protected void btnAsignarMesa_Click(object sender, EventArgs e)
        {
            if (Session["NumeroMesa"] == null) {
                Response.Write("<script>alert('No se selecciono mesa.')</script>");
            }
            else
            {
                Response.Redirect("GestionMesa_a_Mesero.aspx?NumeroMesa=" + Session["NumeroMesa"].ToString());
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            ServicioMesa servicioMesa = new ServicioMesa();
            servicioMesa.AgregarMesa();
            Response.Redirect("GestionMesa.aspx");
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
          
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            if ((Session["NumeroMesa"] == null))
            {
                Response.Write("<script>alert('No se selecciono usuario para eliminar.')</script>");
            }
            else
            {
                try
                {
                    ServicioMesa servicioMesa = new ServicioMesa();

                    int numeroMesa = int.Parse(Session["NumeroMesa"].ToString());
                    servicioMesa.EliminarMesa(numeroMesa);
                    Response.Redirect("GestionMesa.aspx");
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        protected void dgvMesa_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["NumeroMesa"] = dgvMesa.SelectedDataKey.Value.ToString();         
    
           dgvMesa.SelectedRowStyle.BorderColor = Color.Red;
            if (dgvMesa.SelectedRow.RowIndex!=0) {
                dgvMesa.Rows[dgvMesa.SelectedRow.RowIndex - 1].BorderColor = Color.Red;
            }
            dgvMesa.SelectedRowStyle.ForeColor= Color.Red;
 
        }

        protected void btnDesasignarMesas_Click(object sender, EventArgs e)
        {
            ServicioMesa servicioMesa = new ServicioMesa();
            servicioMesa.desasignarMesas();
            Response.Redirect("GestionMesa.aspx");
        }
        protected void btnDesasignarMesa_Click(object sender, EventArgs e)
        {
            ServicioMesa servicioMesa = new ServicioMesa();
            int numeroMesa = int.Parse(Session["NumeroMesa"].ToString());
            servicioMesa.DesasignarMesa(numeroMesa);
            Response.Redirect("GestionMesa.aspx");
        }

    } 
}