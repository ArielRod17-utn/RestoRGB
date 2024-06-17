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
    public partial class GestionMesa_a_Mesero : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           

            if (!IsPostBack)
            {
                ServicioUsuario servicioUsuario = new ServicioUsuario();
                dgvMeseros.DataSource = servicioUsuario.ObtenerUsuariosPorPerfil(2);
                dgvMeseros.DataBind();
            }
        }

        protected void dgvMeseros_SelectedIndexChanged(object sender, EventArgs e)
        {
            ServicioMesa servicioMesa = new ServicioMesa();
            int IdUsuarioMesero = int.Parse(dgvMeseros.SelectedDataKey.Value.ToString());
           if (dgvMeseros.SelectedRow.RowIndex!=0) {
                dgvMeseros.Rows[dgvMeseros.SelectedRow.RowIndex - 1].BorderColor = Color.Red;
            }
            dgvMeseros.SelectedRowStyle.ForeColor= Color.Red;
 

            if (Request.QueryString["NumeroMesa"] != null)
            {
                int numeroMesa = int.Parse(Request.QueryString["NumeroMesa"].ToString());

                servicioMesa.AsignarMesa(IdUsuarioMesero, numeroMesa);
            }

            Response.Redirect("GestionMesa.aspx");

        }
    }
}