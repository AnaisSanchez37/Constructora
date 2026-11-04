using System;
using System.Data;
using System.Data.SqlClient;

namespace Clientes
{
    internal class ClienteDAO
    {
        private static readonly string cadenaConexion =
            "Server=localhost\\SQLEXPRESS; Database=ConstructoraBD;" +
            "Trusted_Connection=True; TrustServerCertificate=True;";

        public DataTable consultarDatos()
        {
            DataTable tabla = new DataTable();

            string consulta =
            "SELECT IdCliente, NombreCliente, TelefonoC, " +
            "DireccionC, FechaNacimientoC, EdadC " +
            "FROM InfoPersona.Cliente";



            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            using (SqlCommand cmd = new SqlCommand(consulta, conexion))
            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
            {
                da.Fill(tabla);
            }

            return tabla;
        }

        public void InsertarCliente(string nombre, string telefono,
            string direccion, DateTime fechaNacimiento)
        {
            string consulta =
                "INSERT INTO InfoPersona.Cliente " +
                "(NombreCliente, TelefonoC, DireccionC, FechaNacimientoC) " +
                "VALUES (@nombre, @telefono, @direccion, @fechaNacimiento)";

            using (SqlConnection con = new SqlConnection(cadenaConexion))
            using (SqlCommand cmd = new SqlCommand(consulta, con))
            {
                con.Open();

                cmd.Parameters.AddWithValue("@nombre", nombre);
                cmd.Parameters.AddWithValue("@telefono", telefono);
                cmd.Parameters.AddWithValue("@direccion", direccion);
                cmd.Parameters.Add("@fechaNacimiento", SqlDbType.Date)
                    .Value = fechaNacimiento.Date;

                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void ModificarCliente(long idCliente, string nombre,
            string telefono, string direccion, DateTime fechaNacimiento)
        {
            string consulta =
                "UPDATE InfoPersona.Cliente SET " +
                "NombreCliente = @nombre, " +
                "TelefonoC = @telefono, " +
                "DireccionC = @direccion, " +
                "FechaNacimientoC = @fechaNacimiento " +
                "WHERE IdCliente = @idCliente";

            using (SqlConnection con = new SqlConnection(cadenaConexion))
            using (SqlCommand cmd = new SqlCommand(consulta, con))
            {
                con.Open();

                cmd.Parameters.AddWithValue("@idCliente", idCliente);
                cmd.Parameters.AddWithValue("@nombre", nombre);
                cmd.Parameters.AddWithValue("@telefono", telefono);
                cmd.Parameters.AddWithValue("@direccion", direccion);
                cmd.Parameters.Add("@fechaNacimiento", SqlDbType.Date)
                    .Value = fechaNacimiento.Date;

                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void EliminarCliente(long idCliente)
        {
            string consulta =
                "DELETE FROM InfoPersona.Cliente " +
                "WHERE IdCliente = @idCliente";

            using (SqlConnection con = new SqlConnection(cadenaConexion))
            using (SqlCommand cmd = new SqlCommand(consulta, con))
            {
                con.Open();

                cmd.Parameters.AddWithValue("@idCliente", idCliente);

                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public bool ExisteTelefono(string telefono)
        {
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                string consulta = "SELECT COUNT(*) FROM InfoPersona.Cliente WHERE TelefonoC = @Telefono";

                using (SqlCommand comando = new SqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("@Telefono", telefono);
                    conexion.Open();
                    int cantidad = Convert.ToInt32(comando.ExecuteScalar());
                    return cantidad > 0;
                }
            }
        }

        public bool ExisteTelefonoOtroCliente(string telefono, long idCliente)
        {
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                string consulta = @"SELECT COUNT(*) 
                            FROM InfoPersona.Cliente 
                            WHERE TelefonoC = @Telefono
                            AND IdCliente <> @IdCliente";

                using (SqlCommand comando = new SqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("@Telefono", telefono);
                    comando.Parameters.AddWithValue("@IdCliente", idCliente);
                    conexion.Open();
                    int cantidad = Convert.ToInt32(comando.ExecuteScalar());
                    return cantidad > 0;
                }
            }
        }

    }
}
