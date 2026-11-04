using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;


namespace ConstructoraBD
{
    internal class ProveedorDAO
    {
        private static readonly string cadenaConexion =
            "Server=localhost\\SQLEXPRESS; Database=ConstructoraBD;" +
            "Trusted_Connection=True; TrustServerCertificate=True;";

        public DataTable consultarDatos()
        {
            DataTable tabla = new DataTable();
            string consulta = "SELECT * FROM InfoPersona.Proveedor";

            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            using (SqlCommand cmd = new SqlCommand(consulta, conexion))
            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
            {
                da.Fill(tabla);
            }

            return tabla;
        }

        public void InsertarProveedor(string nombreP, string telefonoP, string direccionP, string contacto)
        {
            string consulta = "INSERT INTO InfoPersona.Proveedor" +
                              "(NombreProveedor, TelefonoP, DireccionP, Contacto ) VALUES " +
                              "(@nombreP, @telefonoP, @direccionP, @contacto)";

            using (SqlConnection con = new SqlConnection(cadenaConexion))
            using (SqlCommand cmd = new SqlCommand(consulta, con))
            {
                con.Open();

                cmd.Parameters.AddWithValue("@nombreP", nombreP);
                cmd.Parameters.AddWithValue("@telefonoP", telefonoP);
                cmd.Parameters.AddWithValue("@direccionP", direccionP);
                cmd.Parameters.AddWithValue("@contacto", contacto);

                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void ModificarProveedor(long IdP, string nombreP,string telefonoP, string direccionP,string contacto)
        {
            string consulta = "UPDATE InfoPersona.Proveedor SET " +
                              "NombreProveedor = @nombreP, " +
                              "TelefonoP = @telefonoP, " +
                              "DireccionP = @direccionP, " +
                              "Contacto = @contacto " +
                              "WHERE IdProveedor = @IdP";

            using (SqlConnection con = new SqlConnection(cadenaConexion))
            using (SqlCommand cmd = new SqlCommand(consulta, con))
            {
                con.Open();

                cmd.Parameters.AddWithValue("@IdP", IdP);
                cmd.Parameters.AddWithValue("@nombreP", nombreP);
                cmd.Parameters.AddWithValue("@telefonoP", telefonoP);
                cmd.Parameters.AddWithValue("@direccionP", direccionP);
                cmd.Parameters.AddWithValue("@contacto", contacto);

                cmd.ExecuteNonQuery();

                con.Close();
            }
        }

        public void EliminarProveedor(long IdP)
        {
            string consulta = "DELETE FROM InfoPersona.Proveedor " +
                              "WHERE IdProveedor = @IdP";

            using (SqlConnection con = new SqlConnection(cadenaConexion))
            using (SqlCommand cmd = new SqlCommand(consulta, con))
            {
                con.Open();

                cmd.Parameters.AddWithValue("@IdP", IdP);

                cmd.ExecuteNonQuery();

                con.Close();
            }
        }

        public bool TelefonoExiste(string telefonoP, long IdP = -1)
        {
            string consulta = "SELECT COUNT(*) " +
                              "FROM InfoPersona.Proveedor " +
                              "WHERE TelefonoP = @telefonoP " +
                              "AND IdProveedor <> @IdP";

            using (SqlConnection con = new SqlConnection(cadenaConexion))
            using (SqlCommand cmd = new SqlCommand(consulta, con))
            {
                con.Open();

                cmd.Parameters.AddWithValue("@telefonoP", telefonoP);
                cmd.Parameters.AddWithValue("@IdP", IdP);

                int cantidad = (int)cmd.ExecuteScalar();

                con.Close();

                return cantidad > 0;
            }
        }
    }
}

