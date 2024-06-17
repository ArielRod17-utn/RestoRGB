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
    public partial class PaginaMesero : System.Web.UI.Page
    {
        public List<Mesa> listaMesas { get; set; }
        public List<Reporte> listaReportes { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            int idUsuario = int.Parse(Session["IdUsuario"].ToString());

            ServicioMesa servicioMesa = new ServicioMesa();
            listaMesas = servicioMesa.ListarMesasPorMesero(idUsuario);
            if(listaMesas.Count == 0)
            {
                ltNotify.Text = "No existen mesas asignadas a su usuario.";
            }

            Repetidor.DataSource = listaMesas;
            Repetidor.DataBind();

            if (!IsPostBack)
            {
                dgvReservas.DataSource = servicioMesa.ListarMesasReservadas();
                dgvReservas.DataBind();

                ddlSeleccionMesa.DataSource = servicioMesa.ListarMesas();
                ddlSeleccionMesa.DataValueField = "NumeroMesa";
                ddlSeleccionMesa.DataTextField = "NumeroMesa";
                ddlSeleccionMesa.DataBind();
                ddlSeleccionMesa.Items.Insert(0, new ListItem("Seleccione una mesa", "0"));

            }


           

        }

        protected void btnMesa_Click(object sender, EventArgs e)
        {
            string NumeroMesa = ((Button)sender).CommandArgument;
            Response.Redirect("PedidoMesero.aspx?NumeroMesa=" + NumeroMesa);
        }

        protected void btnReservar_Click(object sender, EventArgs e)
        {

            
            if (txtNombre.Text != string.Empty && txtHora.Text != string.Empty && txtMinutos.Text != string.Empty && ddlSeleccionMesa.SelectedValue != "0")
            {
   
                string Fecha = Calendario.SelectedDate.ToString("dd/MM/yyyy");
                string[] FechaCortada = Fecha.Split('/');
                int dia = int.Parse(FechaCortada[0]);
                int mes = int.Parse(FechaCortada[1]);
                int año = int.Parse(FechaCortada[2]);
                int Hora = int.Parse(txtHora.Text);
                int Minutos = int.Parse(txtMinutos.Text);
                string dniCliente = txtNombre.Text;
              

                int numeroMesa = Convert.ToInt32(ddlSeleccionMesa.SelectedValue);

                if (Hora >= 8 && Hora < 24 && Minutos >= 00 && Minutos < 60)
                {
                    DateTime FechaReserva = new DateTime(año, mes, dia, Hora, Minutos, 0);
                    ServicioMesa servicioMesa = new ServicioMesa();

                    if (!servicioMesa.ExisteReserva(numeroMesa, FechaReserva))
                    {
                        servicioMesa.ReservarMesa(FechaReserva, numeroMesa, dniCliente);
                        ReiniciarControles();
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "Swal.fire('Éxito', '¡La reserva a sido exitosa!', 'success');", true);
                        dgvReservas.DataSource = servicioMesa.ListarMesasReservadas();
                        dgvReservas.DataBind();

                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "Swal.fire('Error', 'No es posible reservar en este horario', 'error');", true);
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "Swal.fire('Error', 'Hora o minutos inválidos', 'error');", true);
                }              
            }
        }

        private void ReiniciarControles()
        {
            txtHora.Text = string.Empty;
            txtMinutos.Text = string.Empty;
            ddlSeleccionMesa.SelectedIndex = 0;
        }
    }
}