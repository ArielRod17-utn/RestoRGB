using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Manager;
using Dominio;
namespace RESTO
{
    public partial class AgregarUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    ServicioUsuario servicioUsuario = new ServicioUsuario();
                    int idUsuario = int.Parse(Request.QueryString["id"]);
                    Usuario usuario = servicioUsuario.ObtenerUsuarioPorId(idUsuario);
                    ServicioPerfil servicioPerfil = new ServicioPerfil ();

                    txtNombre.Text = usuario.Nombre;
                    txtApellido.Text = usuario.Apellido;
                    txtDni.Text = usuario.Dni;
                    ddlOpciones.DataSource = servicioPerfil.ListarPerfiles();
                    ddlOpciones.DataTextField = "Descripcion";
                    ddlOpciones.DataValueField = "IdPerfil";
                    ddlOpciones.DataBind();
                    ddlOpciones.SelectedValue = usuario.Perfil.IdPerfil.ToString();
                }
                else
                {
                    ServicioPerfil servicioPerfil = new ServicioPerfil ();

                    ddlOpciones.DataSource = servicioPerfil.ListarPerfiles();
                    ddlOpciones.DataTextField = "Descripcion";
                    ddlOpciones.DataValueField = "IdPerfil";
                    ddlOpciones.DataBind();
                    ddlOpciones.SelectedIndex = 0;
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

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            TextBox[] textBoxs = { txtNombre, txtApellido, txtDni };
            if (ValidarCamposVacios(textBoxs))
            {
                Response.Write("<script>alert('Por favor complete todos los datos para crear el usuario.')</script>");
                return;
            }

            
            ServicioUsuario servicioUsuario = new ServicioUsuario();

            Usuario usuario = new Usuario();

            usuario.Nombre = txtNombre.Text;
            usuario.Apellido = txtApellido.Text;
            int entero;
            if(!Int32.TryParse(txtDni.Text, out entero))
            {
                Response.Write("<script>alert('Por favor verifique el DNI ingresado.')</script>");
                return;
            }
            else
            {
                if (txtDni.Text.Length<7 || txtDni.Text.Length> 8)
                {
                    Response.Write("<script>alert('Por favor verifique el DNI ingresado.')</script>");
                    return;
                }
            }
            usuario.Dni = txtDni.Text;
            usuario.Perfil = new Perfil();
            usuario.Perfil.IdPerfil = int.Parse(ddlOpciones.SelectedValue);
            

            if (Request.QueryString["id"] == null)
            {
                servicioUsuario.AgregarUsuario(usuario);             

            }
            else
            {
                usuario.IdUsuario = int.Parse(Request.QueryString["id"]);
             
                servicioUsuario.ModificarUsuario(usuario);
                
            }
            
            Response.Redirect("GestionUsuarios.aspx"); // sacar esto luego 

        }
    }
}