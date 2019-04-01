using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using WebApplicationApi.Models;

namespace WebApplicationApi.Controllers
{
    public class CaloriasManager
    {
        private static string cadenaConexion =
             @"Server=HAGINZURIA;Initial Catalog=BDNutricion;Integrated Security=True";
        private static string tabla = "Calorias";

        public bool InsertarCalorias(Calorias cal)
        {
            SqlConnection con = new SqlConnection(cadenaConexion);

            con.Open();

            string sql = "INSERT INTO " + tabla + " (email, fecha, tipoComida, codigoAlimento, cantidad) VALUES (@email, @telfechaefono, @tipoComida, @codigoAlimento, @cantidad)";

            SqlCommand cmd = new SqlCommand(sql, con);

            cmd.Parameters.Add("@email", System.Data.SqlDbType.NVarChar).Value = cal.email;
            cmd.Parameters.Add("@fecha", System.Data.SqlDbType.NVarChar).Value = cal.fecha;
            cmd.Parameters.Add("@tipoComida", System.Data.SqlDbType.Char).Value = cal.tipoComida;
            cmd.Parameters.Add("@codigoAlimento", System.Data.SqlDbType.Int).Value = cal.codigoAlimento;
            cmd.Parameters.Add("@cantidad", System.Data.SqlDbType.Int).Value = cal.cantidad;

            int res = cmd.ExecuteNonQuery();

            con.Close();

            return (res == 1);
        }

        public bool ActualizarCalorias(Calorias cal)
        {
            SqlConnection con = new SqlConnection(cadenaConexion);

            con.Open();

            string sql = "UPDATE " + tabla + " SET email = @email, fecha = @fecha, tipoComida = @tipoComida, codigoAlimento = @codigoAlimento WHERE IdCliente = @idcliente";

            SqlCommand cmd = new SqlCommand(sql, con);

            cmd.Parameters.Add("@email", System.Data.SqlDbType.NVarChar).Value = cal.email;
            cmd.Parameters.Add("@fecha", System.Data.SqlDbType.NVarChar).Value = cal.fecha;
            cmd.Parameters.Add("@tipoComida", System.Data.SqlDbType.Char).Value = cal.tipoComida;
            cmd.Parameters.Add("@codigoAlimento", System.Data.SqlDbType.Int).Value = cal.codigoAlimento;
            cmd.Parameters.Add("@cantidad", System.Data.SqlDbType.Int).Value = cal.cantidad;

            int res = cmd.ExecuteNonQuery();

            con.Close();

            return (res == 1);
        }
        
    }
}