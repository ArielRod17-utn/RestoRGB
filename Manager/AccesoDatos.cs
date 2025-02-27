﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Manager
{
    public class AccesoDatos
    {
        private SqlConnection conexion;
        private SqlCommand comando;
        private SqlDataReader lector;
        public SqlDataReader Lector
        {
            get { return lector; }
        }

        public AccesoDatos()
        {
            //conexion = new SqlConnection("server=.\\SQLEXPRESS; database=Resto; integrated security=true");
            conexion = new SqlConnection("server=DESKTOP-2360JBV\\SQLEXPRESS1; database=Resto; integrated security=true");
            //conexion = new SqlConnection("server=localhost; database=Resto; integrated security=false; user=sa; password=123456");

            comando = new SqlCommand();
        }

        public void setearConsulta(string consulta)
        {
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = consulta;
        }
        public void ejecutarLectura()
        {
            comando.Connection = conexion;
            try
            {
            conexion.Open();
            lector = comando.ExecuteReader();
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ejecutarAccion()
        {
            comando.Connection = conexion;
            try
            {
                conexion.Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public void cerrarConexion()
        {
            if (conexion != null)
            {
               
                conexion.Close();
            }
            if (lector != null)
            {
                lector.Close();
                
            }

        }


        public void setearProcedimiento(string sp)
        {
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.CommandText = sp;
        }


        public void setearParametros(string nombre, object valor)
        {
            comando.Parameters.AddWithValue(nombre, valor);
        }

    }
}
