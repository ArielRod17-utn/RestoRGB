using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
namespace Manager
{
    public class ServicioMesa
    {
        public void AgregarMesa()
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearProcedimiento("sp_CrearMesa");              
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

        public void EliminarMesa(int IdMesa)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("sp_EliminarMesa");
                datos.setearParametros("@IdMesa", IdMesa);
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

        public List<Mesa> ListarMesas()
        {
            List<Mesa> lista = new List<Mesa>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("sp_ListarMesas");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Mesa mesa = new Mesa();
                    mesa.NumeroMesa = (int)datos.Lector["Idmesa"];                // Mapear

                    mesa.Estado = new EstadoMesa();

                    mesa.Estado.idEstadoMesa = (int)datos.Lector["IdEstado"];
                    mesa.Estado.Descripcion = (string)datos.Lector["Descripcion"];
                    mesa.IdUsuario = datos.Lector["IdUsuario"] != DBNull.Value ? (int?)datos.Lector["IdUsuario"] : null;
                    
                   
                    lista.Add(mesa);
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


        public List<Mesa> ListarMesasPorMesero(int IdUsuario)
        {
            List<Mesa> lista = new List<Mesa>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("sp_ListarMesasPorMesero");
                datos.setearParametros("@IdUsuario", IdUsuario);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Mesa mesa = new Mesa();
                    mesa.NumeroMesa = (int)datos.Lector["Idmesa"];                // Mapear

                    mesa.Estado = new EstadoMesa();

                    mesa.Estado.idEstadoMesa = (int)datos.Lector["IdEstado"];
                    mesa.Estado.Descripcion = (string)datos.Lector["Descripcion"];
                    mesa.IdUsuario = datos.Lector["IdUsuario"] != DBNull.Value ? (int?)datos.Lector["IdUsuario"] : null;
                    

                    lista.Add(mesa);
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


        public void AsignarMesa(int IdUsuario, int NumeroMesa)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearProcedimiento("sp_AsignarMesa");

                datos.setearParametros("@idUsuario", IdUsuario);             
                datos.setearParametros("@idMesa", NumeroMesa);
                
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
        public void DesasignarMesa(int NumeroMesa)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("sp_DesasignarMesa");
                datos.setearParametros("idMesa", NumeroMesa);
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


        public void desasignarMesas()
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("sp_DesasignarMesas");              
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


        public Mesa ObtenerMesaPorId(int NumeroMesa)
        {
            
            AccesoDatos datos = new AccesoDatos();
            Mesa mesa = new Mesa();
            try
            {
                datos.setearProcedimiento("sp_ObtenerMesaPorId");
                datos.setearParametros("@NumeroMesa", NumeroMesa);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {

                   
                    mesa.NumeroMesa = (int)datos.Lector["Idmesa"];                // Mapear

                    mesa.Estado = new EstadoMesa();

                    mesa.Estado.idEstadoMesa = (int)datos.Lector["IdEstado"];
                    mesa.Estado.Descripcion = (string)datos.Lector["Descripcion"];
                    mesa.IdUsuario = datos.Lector["IdUsuario"] != DBNull.Value ? (int?)datos.Lector["IdUsuario"] : null;
                    


                }
                    return mesa;
                
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


        public void CambiarEstado(int IdMesa, int IdEstado)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearProcedimiento("sp_CambiarEstado");

                datos.setearParametros("@IdMesa", IdMesa);
                datos.setearParametros("@IdEstado", IdEstado);

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


        public bool ExisteReserva(int IdMesa, DateTime FechaReserva)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("sp_ValidarReserva");
                datos.setearParametros("@NumeroMesa", IdMesa);
                datos.setearParametros("@FechaReserva", FechaReserva);

                datos.ejecutarLectura();
                bool valor = false;
                while (datos.Lector.Read())
                {
                    valor = datos.Lector["NumeroMesa"] != DBNull.Value; 
                }
                return valor;

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


        public void ReservarMesa(DateTime FechaReserva, int numeroMesa, string dniCliente)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("sp_ReservarMesa");
                datos.setearParametros("@FechaReserva", FechaReserva);
                datos.setearParametros("@NumeroMesa", numeroMesa);
                datos.setearParametros("@dniCliente", dniCliente);

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


        public List<Reserva> ListarMesasReservadas()
        {
            List<Reserva> lista = new List<Reserva>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("sp_ListarReservas");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Reserva reserva = new Reserva();

                    reserva.FechaReserva = (DateTime)datos.Lector["FechaReserva"];   // Mapear
                    reserva.NumeroMesa = (int)datos.Lector["NumeroMesa"];                
                    reserva.dniCliente = (string)datos.Lector["dniCliente"];                

                    lista.Add(reserva);
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



        public bool CoincideReserva(int IdMesa, string dniCliente)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("sp_CoincideReserva");
                datos.setearParametros("@NumeroMesa", IdMesa);
                datos.setearParametros("@dniCliente", dniCliente);

                datos.ejecutarLectura();
                bool valor = false; 
                while (datos.Lector.Read())
                {
                    valor = datos.Lector["NumeroMesa"] != DBNull.Value;
                }
                return valor;

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
