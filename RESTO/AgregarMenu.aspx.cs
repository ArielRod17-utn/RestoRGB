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
    public partial class AgregarMenu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ServicioCategoria servicioCategoria = new ServicioCategoria();
            ServicioMenu servicioMenu = new ServicioMenu();

            if (!IsPostBack)
            {
                ddlOpciones.DataSource = servicioCategoria.ListarCategoria();
                ddlOpciones.DataTextField = "Descripcion";
                ddlOpciones.DataValueField = "IdCategoria";
                ddlOpciones.DataBind();
                ddlOpciones.SelectedIndex = 0;

                if (Request.QueryString["id"] != null)
                {
                    int idMenu = int.Parse(Request.QueryString["id"]);
                    ElementoMenu menu = servicioMenu.ObtenerElementoMenuPorId(idMenu);

                    txtDescripcion.Text = menu.Descripcion;
                    txtPrecio.Text = menu.Precio.ToString();
                    ddlOpciones.SelectedValue = menu.Categoria.IdCategoria.ToString();
                    ddlRequiereStock.SelectedIndex = Convert.ToInt32(menu.RequiereStock);
                    txtStock.Text = menu.Stock.ToString();
                }
            }
        }
        protected bool ValidarCamposVacios(TextBox[] textBox)
        {
            foreach (TextBox txt in textBox)
            {
                if (string.IsNullOrWhiteSpace(txt.Text))
                {
                    return true;
                }
            }
            return false;
        }


        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            TextBox[] textBoxs = { txtDescripcion, txtPrecio };
            if (ValidarCamposVacios(textBoxs))
            {
                Response.Write("<script>alert('Por favor complete todos los datos para crear el menu.')</script>");
                return;
            }
            decimal nro;
            if(!Decimal.TryParse(txtPrecio.Text, out nro))
            {
                Response.Write("<script>alert('Por favor verifique el precio ingresado.')</script>");
                return;
            }


            ServicioMenu servicioMenu = new ServicioMenu();
            ElementoMenu elementoMenu = new ElementoMenu();

            elementoMenu.Descripcion = txtDescripcion.Text;
            elementoMenu.Precio = decimal.Parse(txtPrecio.Text);
            elementoMenu.Categoria = new Categoria();
            elementoMenu.Categoria.IdCategoria = int.Parse(ddlOpciones.SelectedValue);
            elementoMenu.RequiereStock = (bool.Parse(ddlRequiereStock.SelectedValue));
            if (txtStock.Text.Length!=0)
            {
                int entero;
                if(!Int32.TryParse(txtStock.Text, out entero))
                {
                    Response.Write("<script>alert('Por favor verifique el stock ingresado.')</script>");
                    return;
                }
                else
                {
                    elementoMenu.Stock = int.Parse(txtStock.Text);
                }
            }
            else
            {
                elementoMenu.Stock = int.Parse("0");
            }

            if (Request.QueryString["id"] == null)
            {
                servicioMenu.AgregarElementoMenu(elementoMenu);
            }
            else
            {
                elementoMenu.IdMenu = int.Parse(Request.QueryString["id"]);
                servicioMenu.ModificarElementoMenu(elementoMenu);
            }

                Response.Redirect("Gestion_Menu.aspx"); 
 
        }
    }
}