using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager
{
    public class ServicioMenu
    {
        public void AgregarElementoMenu(ElementoMenu menu)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearProcedimiento("sp_AgregarElementoMenu");
                datos.setearParametros("@Descripcion", menu.Descripcion);
                datos.setearParametros("@Precio", menu.Precio);
                datos.setearParametros("@IdCategoria", menu.Categoria.IdCategoria);
                datos.setearParametros("@RequiereStock", menu.RequiereStock);
                datos.setearParametros("@Stock", menu.Stock);
                datos.ejecutarAccion();

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void EliminarElementoMenu(int IdMenu)
        {

            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("sp_EliminarElementoMenu");
                datos.setearParametros("@IdMenu", IdMenu);
                datos.ejecutarAccion();



            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public List<ElementoMenu> ListarElementoMenu(int idCategoria)
        {
            List<ElementoMenu> lista = new List<ElementoMenu>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearProcedimiento("sp_ListarElementoMenu");
                datos.setearParametros("@idCategoria", idCategoria);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {

                    ElementoMenu aux = new ElementoMenu();
                    aux.IdMenu = (int)datos.Lector["IdMenu"];                // Mapear
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.Precio= (decimal)datos.Lector["Precio"];
                    aux.Categoria = new Categoria();
                    aux.Categoria.IdCategoria = (int)datos.Lector["IdCategoria"];
                    aux.RequiereStock = (bool)datos.Lector["RequiereStock"];
                    aux.Stock = (int)datos.Lector["Stock"];

                    lista.Add(aux);
                }
                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public List<ElementoMenu> ListarElementoMenuCompleto()
        {
            List<ElementoMenu> lista = new List<ElementoMenu>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearProcedimiento("sp_ListarElementoMenuCompleto");         
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {

                    ElementoMenu aux = new ElementoMenu();
                    aux.IdMenu = (int)datos.Lector["IdMenu"];                // Mapear
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.Precio = (decimal)datos.Lector["Precio"];
                    aux.Categoria = new Categoria();
                    aux.Categoria.IdCategoria = (int)datos.Lector["IdCategoria"];
                    aux.Categoria.Descripcion = (string)datos.Lector["Categoria"];
                    aux.RequiereStock = (bool)datos.Lector["RequiereStock"];
                    aux.Stock = (int)datos.Lector["Stock"];

                    lista.Add(aux);
                }
                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }


        public void ModificarElementoMenu(ElementoMenu menuItem)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearProcedimiento("sp_ModificarElementoMenu");
                datos.setearParametros("@IdMenu", menuItem.IdMenu);
                datos.setearParametros("@Descripcion", menuItem.Descripcion);
                datos.setearParametros("@Precio", menuItem.Precio);
                datos.setearParametros("@IdCategoria", menuItem.Categoria.IdCategoria);
                datos.setearParametros("@RequiereStock", menuItem.RequiereStock);
                datos.setearParametros("@Stock", menuItem.Stock);
                datos.ejecutarAccion();
                
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }


        public ElementoMenu ObtenerElementoMenuPorId(int Id)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearProcedimiento("sp_ObtenerElementoMenuPorId");
                datos.setearParametros("@Id", Id);
                datos.ejecutarLectura();

                datos.Lector.Read();

                ElementoMenu aux = new ElementoMenu();
                aux.IdMenu = (int)datos.Lector["IdMenu"];                // Mapear
                aux.Descripcion = (string)datos.Lector["Descripcion"];
                aux.Precio = (decimal)datos.Lector["Precio"];

                aux.Categoria = new Categoria();
                aux.Categoria.IdCategoria = (int)datos.Lector["IdCategoria"];
                aux.Categoria.Descripcion = (string)datos.Lector["Descripcion"];

                aux.RequiereStock = (Boolean)datos.Lector["RequiereStock"];
                aux.Stock = (int)datos.Lector["Stock"];

                return aux;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public List<ElementoMenu> ListarElementoMenuBuscado(string busqueda)
        {
            AccesoDatos datos = new AccesoDatos();
            List<ElementoMenu> lista = new List<ElementoMenu>();
            try
            {
                datos.setearProcedimiento("sp_BuscarMenu");
                datos.setearParametros("@busqueda", busqueda);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {

                    ElementoMenu aux = new ElementoMenu();
                    aux.IdMenu = (int)datos.Lector["IdMenu"];                // Mapear
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.Precio = (decimal)datos.Lector["Precio"];
                    aux.Categoria = new Categoria();
                    aux.Categoria.IdCategoria = (int)datos.Lector["IdCategoria"];
                    aux.Categoria.Descripcion = (string)datos.Lector["DescripcionCategoria"];
                    aux.RequiereStock = (bool)datos.Lector["RequiereStock"];
                    aux.Stock = (int)datos.Lector["Stock"];

                    lista.Add(aux);
                }
                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }



        public List<ElementoMenu> ListarStock()
        {
            List<ElementoMenu> lista = new List<ElementoMenu>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearProcedimiento("sp_ListarStock");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {

                    ElementoMenu aux = new ElementoMenu();
                    aux.IdMenu = (int)datos.Lector["IdMenu"];                // Mapear
                    aux.Descripcion = (string)datos.Lector["Descripcion"];                
                    aux.Stock = (int)datos.Lector["Stock"];

                    lista.Add(aux);
                }
                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }



    }
}
