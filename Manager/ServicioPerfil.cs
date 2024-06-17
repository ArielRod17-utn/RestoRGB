using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Manager
{
    public class ServicioPerfil
    {

        public void AgregarPerfil(string Perfil)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearProcedimiento("sp_AltaPerfil");
                datos.setearParametros("@Perfil",Perfil);
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

        public void Eliminar(int Id)
        {

                AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("sp_Eliminar");
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

        public List<Perfil> ListarPerfiles()
        {
            List<Perfil> lista = new List<Perfil>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearProcedimiento("sp_ListarPerfiles");
                datos.ejecutarLectura();
                while ( datos.Lector.Read() ) {

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

        public void ModificarPerfil(Perfil perfil)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearProcedimiento("sp_ModificarPerfil");
                datos.setearParametros("@IdPerfil",perfil.IdPerfil);
                datos.setearParametros("@Descripcion",perfil.Descripcion);
                datos.ejecutarAccion();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }


    }
}
