using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Arquitecto
{
    internal class ArquitectoDAO
    {
        private static readonly string cadenaConexion = "Server=localhost\\SQLEXPRESS; Database=ConstructoraBD; Trusted_Connection=True; TrustServerCertificate=True;";

        public DataTable ObtenerArquitectos()
        {
            string consulta = "SELECT IdArquitecto, NombreArquitecto, TelefonoA, FechaNacimientoA, EdadA, Sueldo FROM InfoPersona.Arquitecto";

            using (SqlConnection con = new SqlConnection(cadenaConexion))
            {
                using (SqlDataAdapter da = new SqlDataAdapter(consulta, con))
                {
                    DataTable tabla = new DataTable();
                    da.Fill(tabla);
                    return tabla;
                }
            }
        }


        public void InsertarArquitecto(string nombre, string telefono, DateTime fechaNacimiento, decimal sueldo)
        {
            string consulta = @"INSERT INTO InfoPersona.Arquitecto (NombreArquitecto, TelefonoA, FechaNacimientoA, Sueldo) 
                                VALUES (@nombre, @telefono, @fechaNac, @sueldo)";

            using (SqlConnection con = new SqlConnection(cadenaConexion))
            {
                using (SqlCommand cmd = new SqlCommand(consulta, con))
                {
                    cmd.Parameters.AddWithValue("@nombre", nombre);
                    cmd.Parameters.AddWithValue("@telefono", telefono);
                    cmd.Parameters.AddWithValue("@fechaNac", fechaNacimiento);
                    cmd.Parameters.AddWithValue("@sueldo", sueldo);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void ModificarArquitecto(int idArquitecto, string nombre, string telefono, DateTime fechaNacimiento, decimal sueldo)
        {
            string consulta = @"UPDATE InfoPersona.Arquitecto 
                                SET NombreArquitecto = @nombre, TelefonoA = @telefono, 
                                    FechaNacimientoA = @fechaNac, Sueldo = @sueldo 
                                WHERE IdArquitecto = @id";

            using (SqlConnection con = new SqlConnection(cadenaConexion))
            {
                using (SqlCommand cmd = new SqlCommand(consulta, con))
                {
                    cmd.Parameters.AddWithValue("@id", idArquitecto);
                    cmd.Parameters.AddWithValue("@nombre", nombre);
                    cmd.Parameters.AddWithValue("@telefono", telefono);
                    cmd.Parameters.AddWithValue("@fechaNac", fechaNacimiento);
                    cmd.Parameters.AddWithValue("@sueldo", sueldo);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void EliminarArquitecto(int idArquitecto)
        {
            string consulta = "DELETE FROM InfoPersona.Arquitecto WHERE IdArquitecto = @id";

            using (SqlConnection con = new SqlConnection(cadenaConexion))
            {
                using (SqlCommand cmd = new SqlCommand(consulta, con))
                {
                    cmd.Parameters.AddWithValue("@id", idArquitecto);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public bool ExisteTelefono(string telefono)
        {
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                string consulta = "SELECT COUNT(*) FROM InfoPersona.Arquitecto WHERE TelefonoA = @Telefono";

                using (SqlCommand comando = new SqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("@Telefono", telefono);

                    conexion.Open();

                    int cantidad = Convert.ToInt32(comando.ExecuteScalar());

                    return cantidad > 0;
                }
            }
        }

        public bool ExisteTelefonoOtroArquitecto(string telefono, int idArquitecto)
        {
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                string consulta = @"SELECT COUNT(*) 
                            FROM InfoPersona.Arquitecto 
                            WHERE TelefonoA = @Telefono
                            AND IdArquitecto <> @IdArquitecto";

                using (SqlCommand comando = new SqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("@Telefono", telefono);
                    comando.Parameters.AddWithValue("@IdArquitecto", idArquitecto);

                    conexion.Open();

                    int cantidad = Convert.ToInt32(comando.ExecuteScalar());

                    return cantidad > 0;
                }
            }
        }

    }

}

