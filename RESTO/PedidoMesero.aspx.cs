using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Manager;

namespace RESTO
{
    public partial class PedidoMesero : System.Web.UI.Page
    {

        public int IdMenuSeleccionado { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                ServicioMenu servicioMenu = new ServicioMenu();
       
                dgvMenuPedidos.DataSource = servicioMenu.ListarElementoMenuCompleto();
                dgvMenuPedidos.DataBind();

                ServicioPedido servicioPedido = new ServicioPedido();
                int NumeroMesa = int.Parse(Request.QueryString["NumeroMesa"].ToString());

                int idPedido = servicioPedido.ObtenerPedidoActual(NumeroMesa);

                if (idPedido == 0) {
                    lblIdPedido.Text = "Mesa sin pedido abierto.";
                }
                else
                {
                    lblIdPedido.Text = idPedido.ToString();
                    List<DetallePedido> lista = servicioPedido.ListaDetallePedido(idPedido);
                    CalcularTotalAPagar(lista);

                    dgvPedido.DataSource = lista;
                    dgvPedido.DataBind();
                }

            }
            
        }

        protected void dgvMenuPedidos_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            dgvMenuPedidos.SelectedRowStyle.ForeColor=System.Drawing.Color.Red;

            ServicioPedido servicioPedido = new ServicioPedido();
            ServicioMenu servicioMenu = new ServicioMenu();
            int NumeroMesa;
            int idPedido;

            if (Request.QueryString["NumeroMesa"] != null)
            {
                NumeroMesa = int.Parse(Request.QueryString["NumeroMesa"].ToString());
                idPedido = servicioPedido.ObtenerPedidoActual(NumeroMesa);


                if (idPedido > 0)
                {
                    int IdMenu = int.Parse(dgvMenuPedidos.SelectedDataKey.Value.ToString());
                    ElementoMenu menu = servicioMenu.ObtenerElementoMenuPorId(IdMenu);

                    if (menu.RequiereStock)
                    {
                        if (menu.Stock > 0)
                        {
                            servicioPedido.AgregarAlPedido(idPedido, IdMenu);

                            menu.Stock--;   // descontamos del stock

                            servicioMenu.ModificarElementoMenu(menu);
                        }
                    }
                    else
                    {
                        servicioPedido.AgregarAlPedido(idPedido, IdMenu);
                    }


                    List<DetallePedido> listaDetallePedidos = servicioPedido.ListaDetallePedido(idPedido);
                    CalcularTotalAPagar(listaDetallePedidos);


                    dgvPedido.DataSource = listaDetallePedidos;
                    dgvPedido.DataBind();

                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "Swal.fire('Error', 'Debes crear un pedido, antes de seleccionar un item.', 'error');", true);
                }
            }

            
        }

        protected void btnCerrarPedido_Click(object sender, EventArgs e)
        {
            int NumeroMesa = int.Parse(Request.QueryString["NumeroMesa"].ToString());

            ServicioPedido servicioPedido = new ServicioPedido();
            int idPedido = servicioPedido.ObtenerPedidoActual(NumeroMesa);
            servicioPedido.CerrarPedido(idPedido);

            ServicioMesa servicioMesa = new ServicioMesa();
            servicioMesa.CambiarEstado(NumeroMesa, (int)EnumEstadosMesa.Libre);

            Response.Redirect("PaginaMesero.aspx");
        }
        
        protected void btnCrearPedido_Click(object sender, EventArgs e)
        {
            ServicioMesa servicioMesa = new ServicioMesa();
            int NumeroMesa = int.Parse(Request.QueryString["NumeroMesa"].ToString());

            Mesa mesa = servicioMesa.ObtenerMesaPorId(NumeroMesa);

            if(mesa.Estado.Descripcion == "Libre")
            {
                DateTime FechaActual = DateTime.Now;

                if (!servicioMesa.ExisteReserva(NumeroMesa, FechaActual)) //si no existe puedo crear
                {

                    ServicioPedido servicioPedido = new ServicioPedido();
                    int idPedido = servicioPedido.CrearPedido(NumeroMesa, mesa.IdUsuario.Value);
                    lblIdPedido.Text = idPedido.ToString();
                    servicioMesa.CambiarEstado(NumeroMesa, (int)EnumEstadosMesa.Ocupada);

                   

                }
                else {

                    string dniCliente = txtDniCliente.Text;

                    if (!string.IsNullOrEmpty(dniCliente)) {

                        if (servicioMesa.CoincideReserva(NumeroMesa, dniCliente))
                        {
                            ServicioPedido servicioPedido = new ServicioPedido();
                            int idPedido = servicioPedido.CrearPedido(NumeroMesa, mesa.IdUsuario.Value);
                            lblIdPedido.Text = idPedido.ToString();
                            servicioMesa.CambiarEstado(NumeroMesa, (int)EnumEstadosMesa.Ocupada);
                        }
                        else
                        {
                            //MENSAJE DE ERROR
                            lblError.Text = "La reserva no coincide. Por favor, verifique la información.";
                        }

                    }
                    else
                    {
                        lblError.Text = "No se puede generar un pedido. En breve tiene una reserva";
                    }

                  


                }
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            string busqueda=txtBuscar.Text;
            ServicioMenu servicioMenu = new ServicioMenu();
            List<ElementoMenu> listaMenusEncontrados = servicioMenu.ListarElementoMenuBuscado(busqueda);
            if (listaMenusEncontrados.Count()>0)
            {
                dgvMenuPedidos.DataSource = listaMenusEncontrados;
                dgvMenuPedidos.DataBind();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "Swal.fire('Error', No se encontraron menus que coincidan con el termino ingresado.', 'error');", true);
            }
        }
        
        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("PaginaMesero.aspx");
        }

        private void CalcularTotalAPagar(List<DetallePedido> listaPedida)
        {
            decimal Total = 0;
            for (int i = 0; i < listaPedida.Count; i++)
            {
                Total += listaPedida[i].Menu.Precio;
            }
            lblTotal.Text = " Total a pagar $ " + Total.ToString();
        }

        protected void dgvPedido_SelectedIndexChanged(object sender, EventArgs e)
        {
            ServicioPedido servicioPedido = new ServicioPedido();
            ServicioMenu servicioMenu = new ServicioMenu();

            int NumeroMesa = int.Parse(Request.QueryString["NumeroMesa"].ToString());

            int idDetallePedido = int.Parse(dgvPedido.SelectedDataKey.Value.ToString());
            int idPedido = servicioPedido.ObtenerPedidoActual(NumeroMesa);

            List<DetallePedido> lista = servicioPedido.ListaDetallePedido(idPedido);

            DetallePedido detallePedidoSeleccionado =  lista.Find(x => x.IdDetallePedido == idDetallePedido);

            if (detallePedidoSeleccionado.Menu.RequiereStock)
            {
                detallePedidoSeleccionado.Menu.Stock++;   // descontamos del stock

                servicioMenu.ModificarElementoMenu(detallePedidoSeleccionado.Menu);
                
            }

            servicioPedido.QuitarDelPedido(idDetallePedido);

            List<DetallePedido> listaDetallePedidos = servicioPedido.ListaDetallePedido(idPedido);
            CalcularTotalAPagar(listaDetallePedidos);

            dgvPedido.DataSource = listaDetallePedidos;
            dgvPedido.DataBind();
        }
    }
}