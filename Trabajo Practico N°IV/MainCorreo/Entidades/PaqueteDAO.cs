using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Entidades
{
    public static class PaqueteDAO
    {
        public static SqlConnection conexion;
        public static SqlCommand comando;

        static PaqueteDAO()
        {
            string connectionStr = @"Data Source=.\SQLEXPRESS; Initial Catalog=correo-sp-2017; Integrated Security = True";

            try
            {
                conexion = new SqlConnection(connectionStr);
                comando = new SqlCommand();
                comando.CommandType = System.Data.CommandType.Text;
                comando.Connection = conexion;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public static bool Insertar(Paquete paquete)
        {
            bool respuesta = false;

            try
            {
                string consulta = String.Format("INSERT INTO Paquetes (direccionEntrega, trackingID, alumno) VALUES ('{0}','{1}','{2}')",
                                                                     paquete.DireccionEntrega, paquete.TrackingID, "Damián Desario");
                comando.CommandText = consulta;
                conexion.Open();
                comando.ExecuteNonQuery();
                respuesta = true;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
            }
            return respuesta;
        }
    }
}
