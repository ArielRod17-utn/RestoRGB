using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager
{
    public class ServicioUsuario
    {
        public void AgregarUsuario(Usuario usuario) // recordar que cambio el sp de agregarUsuario
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearProcedimiento("sp_AgregarUsuario");
                datos.setearParametros("@Nombre", usuario.Nombre);
                datos.setearParametros("@Apellido",usuario.Apellido);
                datos.setearParametros("@Dni",usuario.Dni);
                datos.setearParametros("@IdPerfil",usuario.Perfil.IdPerfil);   
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

        public void EliminarUsuario(int Id)
        {

            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("sp_EliminarUsuario");
                datos.setearParametros("@Id", Id);
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

        public Usuario ObtenerUsuarioPorId(int Id)
        {
            AccesoDatos datos = new AccesoDatos();
            
            try
            {
                datos.setearProcedimiento("sp_ObtenerUsuarioPorId");
                datos.setearParametros("@Id",Id);
                datos.ejecutarLectura();

                datos.Lector.Read();

                Usuario aux = new Usuario();
                aux.IdUsuario = (int)datos.Lector["IdUsuario"];                // Mapear
                aux.Nombre = (string)datos.Lector["Nombre"];
                aux.Apellido = (string)datos.Lector["Apellido"];
                aux.Dni = (string)datos.Lector["Dni"];
                aux.Contrasenia = (string)datos.Lector["Contrasenia"];
                aux.FechaCreacion = (DateTime)datos.Lector["FechaCreacion"];

                aux.Perfil = new Perfil();
                aux.Perfil.IdPerfil = (int)datos.Lector["IdPerfil"];
                aux.Perfil.Descripcion = (string)datos.Lector["Descripcion"];


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

        public List<Perfil> ListarPerfiles()
        {
            List<Perfil> lista = new List<Perfil>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearProcedimiento("sp_ListarPerfiles");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {

                    Perfil aux = new Perfil();
                    aux.IdPerfil = (int)datos.Lector["IdPerfil"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];

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

        public List<Usuario> ListarUsuarios()
        {
            List<Usuario> lista = new List<Usuario>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearProcedimiento("sp_ListarUsuarios");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {

                    Usuario aux = new Usuario();
                    aux.IdUsuario = (int)datos.Lector["IdUsuario"];                // Mapear
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Apellido = (string)datos.Lector["Apellido"];
                    aux.Dni = (string)datos.Lector["Dni"];
                    aux.Contrasenia = (string)datos.Lector["Contrasenia"];
                    aux.FechaCreacion = (DateTime)datos.Lector["FechaCreacion"];

                    aux.Perfil = new Perfil();
                    aux.Perfil.IdPerfil = (int)datos.Lector["IdPerfil"];
                    aux.Perfil.Descripcion = (string)datos.Lector["Descripcion"];

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

        public void ModificarUsuario(Usuario usuario)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearProcedimiento("sp_ModificarUsuario");
                datos.setearParametros("@IdUsuario",usuario.IdUsuario);
                datos.setearParametros("@Nombre",usuario.Nombre);
                datos.setearParametros("@Apellido",usuario.Apellido);
                datos.setearParametros("@Dni",usuario.Dni);                        
                datos.setearParametros("@IdPerfil",usuario.Perfil.IdPerfil);               
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
        public void ModificarContrasenia(int Id, string contrasenia)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearProcedimiento("sp_ModificarContrasenia");
                datos.setearParametros("@IdUsuario",Id);
                datos.setearParametros("@Contrasenia",contrasenia);          
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
        public Usuario Loguear(string dni, string contrasenia)
        {
            AccesoDatos datos = new AccesoDatos();
           
            try
            {
                datos.setearConsulta("SELECT * FROM Usuarios WHERE Dni=@Dni AND Contrasenia=@Contrasenia");
                datos.setearParametros("@Dni",dni);
                datos.setearParametros("@Contrasenia",contrasenia);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Usuario aux = new Usuario();
                    aux.IdUsuario = (int)datos.Lector["IdUsuario"];                // Mapear
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Apellido = (string)datos.Lector["Apellido"];
                    aux.Dni = (string)datos.Lector["Dni"];
                    aux.Contrasenia = (string)datos.Lector["Contrasenia"];
                    aux.FechaCreacion = (DateTime)datos.Lector["FechaCreacion"];

                    aux.Perfil = new Perfil();
                    aux.Perfil.IdPerfil = (int)datos.Lector["IdPerfil"];

                    return aux;
                }

                return null;
                
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

        public int ObtenerIdUsuario(string dni)
        {
            AccesoDatos datos = new AccesoDatos();
            int id= 0;
            try
            {
                datos.setearConsulta("SELECT * FROM Usuarios WHERE Dni=@Dni");
                datos.setearParametros("@Dni",dni);
                datos.ejecutarLectura();
                if (datos.Lector.Read())
                {
                    id=(int)datos.Lector["IdUsuario"];
                }
                else
                {
                    return id;
                }
                return id;
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


         public int ObtenerTipoDeUsuario(string Dni, string Contrasenia)
        {
            int valorPerfil = 1;

            return valorPerfil;
        }


        public List<Usuario> ObtenerUsuariosPorPerfil(int IdPerfil)
        {
            List<Usuario> lista = new List<Usuario>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearProcedimiento("sp_ObtenerUsuariosPorPerfil");
                datos.setearParametros("IdPerfil", IdPerfil);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {

                    Usuario aux = new Usuario();
                    aux.IdUsuario = (int)datos.Lector["IdUsuario"];                // Mapear
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Apellido = (string)datos.Lector["Apellido"];
                    aux.Dni = (string)datos.Lector["Dni"];
                    aux.Contrasenia = (string)datos.Lector["Contrasenia"];
                    aux.FechaCreacion = (DateTime)datos.Lector["FechaCreacion"];

                    aux.Perfil = new Perfil();
                    aux.Perfil.IdPerfil = (int)datos.Lector["IdPerfil"];
                    aux.Perfil.Descripcion = (string)datos.Lector["Descripcion"];

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


        public List<Usuario> ListarMeseros()
        {
            List<Usuario> lista = new List<Usuario>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearProcedimiento("sp_ListarIdMeseros");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {

                    Usuario aux = new Usuario();
                    aux.IdUsuario = (int)datos.Lector["IdUsuario"];
                    aux.Nombre = (string)datos.Lector["Nombre"];   // Mapear
                   

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
