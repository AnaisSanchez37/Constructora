using System;
using System.Data;
using System.Data.SqlClient;

namespace Constructora
{
    internal class ServicioDAO
    {
        private static readonly string cadenaConexion = "Server=localhost\\SQLEXPRESS; Database=ConstructoraBD; Trusted_Connection=True; TrustServerCertificate=True;";

        public DataTable consultarDatos()
        {
            DataTable tabla = new DataTable();
            using (SqlConnection con = new SqlConnection(cadenaConexion))
            using (SqlDataAdapter da = new SqlDataAdapter("SELECT IdServicio, NombreServicio FROM InfoProyecto.Servicio ORDER BY IdServicio", con))
            {
                da.Fill(tabla);
            }
            return tabla;
        }

        public void InsertarServicio(string nombre)
        {
            string consulta = "INSERT INTO InfoProyecto.Servicio (NombreServicio) VALUES (@nombre)";
            using (SqlConnection con = new SqlConnection(cadenaConexion))
            using (SqlCommand cmd = new SqlCommand(consulta, con))
            {
                cmd.Parameters.Add("@nombre", SqlDbType.VarChar, 200).Value = nombre;
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void ModificarServicio(long id, string nombre)
        {
            string consulta = "UPDATE InfoProyecto.Servicio SET NombreServicio = @nombre WHERE IdServicio = @id";
            using (SqlConnection con = new SqlConnection(cadenaConexion))
            using (SqlCommand cmd = new SqlCommand(consulta, con))
            {
                cmd.Parameters.Add("@id", SqlDbType.BigInt).Value = id;
                cmd.Parameters.Add("@nombre", SqlDbType.VarChar, 200).Value = nombre;
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void EliminarServicio(long id)
        {
            using (SqlConnection con = new SqlConnection(cadenaConexion))
            using (SqlCommand cmd = new SqlCommand("DELETE FROM InfoProyecto.Servicio WHERE IdServicio = @id", con))
            {
                cmd.Parameters.Add("@id", SqlDbType.BigInt).Value = id;
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

    }
}

