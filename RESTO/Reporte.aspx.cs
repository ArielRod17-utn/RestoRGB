using Dominio;
using Manager;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RESTO
{
    public partial class Reporte : System.Web.UI.Page
    {
        ServicioPedido servicioPedido = new ServicioPedido();
        ServicioUsuario servicioUsuario = new ServicioUsuario();
        ServicioMesa servicioMesa = new ServicioMesa();

        

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
                var listaIdMeseros = servicioUsuario.ListarMeseros();
                var listaIdMesas = servicioMesa.ListarMesas();

                ddlReporte.DataSource = listaIdMeseros;
                ddlReporte.DataValueField = "IdUsuario";
                ddlReporte.DataTextField = "Nombre"; 
                ddlReporte.DataBind();
                ddlReporte.Items.Insert(0, new ListItem("Seleccione un mesero", "0"));

                ddlReporteMesa.DataSource = listaIdMesas;
                ddlReporteMesa.DataValueField = "NumeroMesa";
                ddlReporteMesa.DataTextField = "NumeroMesa"; 
                ddlReporteMesa.DataBind();
                ddlReporteMesa.Items.Insert(0, new ListItem("Seleccione una mesa", "0"));

                lblTotalFacturacion.Text = "Facturación total del dia $: " + servicioPedido.ObtenerTotalFacturado(DateTime.Now);
            }
        }

        protected void ddlReporteTimelapse_SelectedIndexChanged(object sender, EventArgs e)
        {
            if((ddlReporte.SelectedIndex == 0)&&(ddlReporteMesa.SelectedIndex == 0))
            {
                //Nada.
            }
            else
            {
                if(ddlReporte.SelectedIndex == 0)
                {
                    ddlReporteMesa.SelectedIndex = 0;
                    MostrarPedidosMesa();
                    CalcularTotal();
                }
                else
                {
                    ddlReporte.SelectedIndex = 0;
                    MostrarPedidos();
                    CalcularTotal();
                }
            }

        }
        
        protected void ddlReporteMesa_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlReporte.SelectedIndex = 0;
            MostrarPedidosMesa();
            CalcularTotal();
        }


        protected void ddlReporte_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlReporteMesa.SelectedIndex = 0;
            MostrarPedidos();
            CalcularTotal();
        }

        public void MostrarPedidos()
        {
            try
            {
                int IdUsuario = Convert.ToInt32(ddlReporte.SelectedValue);

                if (IdUsuario != 0) 
                {
                    if (ddlReporteTimelapse.SelectedValue == "0")
                    {
                        dgvReporte.DataSource = servicioPedido.ListaReportePorMesero(IdUsuario);
                    }
                    else
                    {
                        dgvReporte.DataSource = servicioPedido.FiltrarPedidosDelDia(servicioPedido.ListaReportePorMesero(IdUsuario));
                    }
                    dgvReporte.DataBind();
                    //RemoveRepeatedIdPedidosOnGrid();
                }
                else
                {
                    
                    dgvReporte.DataSource = null;
                    dgvReporte.DataBind();
                }
            }
            catch (Exception ex)
            {
                
                Response.Write("<script>alert('Error al mostrar los pedidos: " + ex.Message + "')</script>");
            }
        }

        public void MostrarPedidosMesa()
        {
            try
            {
                int NumeroMesa = Convert.ToInt32(ddlReporteMesa.SelectedValue);

                if (NumeroMesa != 0) 
                {
                    if (ddlReporteTimelapse.SelectedValue == "0")
                    {
                        dgvReporte.DataSource = servicioPedido.ListaReportePorMesa(NumeroMesa);
                    }
                    else
                    {

                        dgvReporte.DataSource = servicioPedido.FiltrarPedidosDelDia(servicioPedido.ListaReportePorMesa(NumeroMesa));
                    }
                    dgvReporte.DataBind();
                    //RemoveRepeatedIdPedidosOnGrid();
                }
                else
                {
                    dgvReporte.DataSource = null;
                    dgvReporte.DataBind();
                }
            }
            catch (Exception ex)
            {
                
                Response.Write("<script>alert('Error al mostrar los pedidos: " + ex.Message + "')</script>");
            }
        }



        public void CalcularTotal()
        {
            decimal total = 0;

            foreach (GridViewRow row in dgvReporte.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    decimal precio;
                    if (decimal.TryParse(row.Cells[1].Text, out precio)) 
                    {
                        total += precio;
                    }
                }
            }
            lblTotal.Text = "Total facturacion de pedidos: $" + total.ToString();
        }

        public void RemoveRepeatedIdPedidosOnGrid()
        {
            string CurrentPedido="";
            int flag = 0;
            foreach (GridViewRow row in dgvReporte.Rows)
            {
                if(flag == 0)
                {
                    CurrentPedido = row.Cells[2].Text;
                    flag = 1;
                    continue;
                }
                if (string.Compare(CurrentPedido, row.Cells[2].Text)==0)
                {
                    CurrentPedido = row.Cells[2].Text; 
                    row.Cells[2].Text = " ";
                }
                else
                {
                    CurrentPedido = row.Cells[2].Text; 
                }
            }
        }

            

    }
}
