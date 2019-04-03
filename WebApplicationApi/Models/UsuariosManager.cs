using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using WebApplicationApi.Models;

namespace WebApplicationApi.Controllers
{
    public class UsuariosManager
    {
        private static string cadenaConexion =
            @"Server=LAPTOP-V8VFEUF2;Initial Catalog=BDNutricion;Integrated Security=True";

        public Usuarios ObtenerUsuario(string email)
        {
            Usuarios usu = null;

            SqlConnection con = new SqlConnection(cadenaConexion);

            con.Open();

            string sql = "SELECT * FROM Usuarios WHERE email = @email";

            SqlCommand cmd = new SqlCommand(sql, con);

            cmd.Parameters.Add("@email", System.Data.SqlDbType.VarChar).Value = email;
            SqlDataReader reader =
                 cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);


            if (reader.Read())
            {
                usu = new Usuarios();
                usu.email = email;
                usu.password = reader.GetString(1);
                //usu.foto = reader.GetString(2);
            }

            reader.Close();

            return usu;
        }

        public Usuarios Login(string email, string password)
        {
            Usuarios usu = ObtenerUsuario(email);
            System.Diagnostics.Debug.WriteLine(email + password);
            if (usu.password == password)
            {
                usu.password = null;
                return usu;
            }
            else
            {
                return null;
            }
        }

        public List<Usuarios> ObtenerUsuarios()
        {
            List<Usuarios> lista = new List<Usuarios>();

            SqlConnection con = new SqlConnection(cadenaConexion);

            con.Open();

            string sql = "SELECT email, password, foto FROM Usuarios";

            SqlCommand cmd = new SqlCommand(sql, con);

            SqlDataReader reader =
                cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

            while (reader.Read())
            {
                Usuarios usu = new Usuarios();

                usu = new Usuarios();
                usu.email = reader.GetString(0);
                usu.password = reader.GetString(1);
                //usu.foto = reader.GetString(2);

                lista.Add(usu);
            }

            reader.Close();

            return lista;
        }

        public bool EliminarCliente(int id)
        {
            SqlConnection con = new SqlConnection(cadenaConexion);

            con.Open();

            string sql = "DELETE FROM Clientes WHERE IdCliente = @idcliente";

            SqlCommand cmd = new SqlCommand(sql, con);

            cmd.Parameters.Add("@idcliente", System.Data.SqlDbType.Int).Value = id;

            int res = cmd.ExecuteNonQuery();

            con.Close();

            return (res == 1);
        }
    }
}
