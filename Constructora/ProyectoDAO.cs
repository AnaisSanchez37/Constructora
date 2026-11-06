using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Constructora
{
    internal class ProyectoDAO
    {
        private static readonly string cadenaConexion = "Server=localhost\\SQLEXPRESS; Database=ConstructoraBD; Trusted_Connection=True; TrustServerCertificate=True;";

        public DataTable ObtenerProyecto()
        {
            string consulta = @"SELECT 
                            P.IdProyecto, 
                            P.IdCliente,      
                            P.IdArquitecto,  
                            CONCAT(C.NombreCliente, '--', RIGHT(C.TelefonoC, 3)) AS Cliente, 
                            CONCAT(A.NombreArquitecto, '-', YEAR(A.FechaNacimientoA), '-') AS Arquitecto, 
                            P.NombreProyecto, 
                            P.FechaInicio, 
                            P.FechaFin, 
                            P.ClaveCatastral, 
                            P.Estado, 
                            P.Presupuesto, 
                            P.CostoTotalProyecto 
                        FROM InfoProyecto.Proyecto P
                        INNER JOIN InfoPersona.Cliente C ON P.IdCliente = C.IdCliente
                        INNER JOIN InfoPersona.Arquitecto A ON P.IdArquitecto = A.IdArquitecto";

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

        public DataTable ObtenerClientes()
        {
            string consulta = "SELECT IdCliente, CONCAT(NombreCliente, '--', RIGHT(TelefonoC, 3)) AS NombreCliente FROM InfoPersona.Cliente";

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

        public DataTable ObtenerArquitectos()
        {
            string consulta = "SELECT IdArquitecto, CONCAT(NombreArquitecto, '-', YEAR(FechaNacimientoA), '-') AS NombreArquitecto FROM InfoPersona.Arquitecto";

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

        public void InsertarProyecto(long idCliente, long idArquitecto, string nombreProyecto, DateTime fechaInicio, DateTime fechaFin, string claveCatastral, string estado)
        {
            string consulta = @"INSERT INTO InfoProyecto.Proyecto (IdCliente, IdArquitecto, NombreProyecto, FechaInicio, FechaFin, ClaveCatastral, Estado) 
                                VALUES (@idCliente, @idArquitecto, @nombreProyecto, @fechaInicio, @fechaFin, @claveCatastral, @estado)";

            using (SqlConnection con = new SqlConnection(cadenaConexion))
            {
                using (SqlCommand cmd = new SqlCommand(consulta, con))
                {
                    cmd.Parameters.AddWithValue("@idCliente", idCliente);
                    cmd.Parameters.AddWithValue("@idArquitecto", idArquitecto);
                    cmd.Parameters.AddWithValue("@nombreProyecto", nombreProyecto);
                    cmd.Parameters.AddWithValue("@fechaInicio", fechaInicio);
                    cmd.Parameters.AddWithValue("@fechaFin", fechaFin);
                    cmd.Parameters.AddWithValue("@claveCatastral", claveCatastral);
                    cmd.Parameters.AddWithValue("@estado", estado);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void ModificarProyecto(int idProyecto, long idCliente, long idArquitecto, string nombreProyecto, DateTime fechaInicio, DateTime fechaFin, string claveCatastral, string estado)
        {
            string consulta = @"UPDATE InfoProyecto.Proyecto 
                                SET IdCliente = @idCliente, IdArquitecto = @idArquitecto, NombreProyecto = @nombreProyecto, 
                                    FechaInicio = @fechaInicio, FechaFin = @fechaFin, ClaveCatastral = @claveCatastral, 
                                    Estado = @estado 
                                WHERE IdProyecto = @idProyecto";

            using (SqlConnection con = new SqlConnection(cadenaConexion))
            {
                using (SqlCommand cmd = new SqlCommand(consulta, con))
                {
                    cmd.Parameters.AddWithValue("@idProyecto", idProyecto);
                    cmd.Parameters.AddWithValue("@idCliente", idCliente);
                    cmd.Parameters.AddWithValue("@idArquitecto", idArquitecto);
                    cmd.Parameters.AddWithValue("@nombreProyecto", nombreProyecto);
                    cmd.Parameters.AddWithValue("@fechaInicio", fechaInicio);
                    cmd.Parameters.AddWithValue("@fechaFin", fechaFin);
                    cmd.Parameters.AddWithValue("@claveCatastral", claveCatastral);
                    cmd.Parameters.AddWithValue("@estado", estado);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void EliminarProyecto(int idProyecto)
        {
            string consulta = "DELETE FROM InfoProyecto.Proyecto WHERE IdProyecto = @idProyecto";

            using (SqlConnection con = new SqlConnection(cadenaConexion))
            {
                using (SqlCommand cmd = new SqlCommand(consulta, con))
                {
                    cmd.Parameters.AddWithValue("@idProyecto", idProyecto);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public bool ExisteNombreProyecto(string nombreProyecto)
        {
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                string consulta = "SELECT COUNT(*) FROM InfoProyecto.Proyecto WHERE NombreProyecto = @nombre";
                using (SqlCommand comando = new SqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("@nombre", nombreProyecto);
                    conexion.Open();
                    int cantidad = Convert.ToInt32(comando.ExecuteScalar());
                    return cantidad > 0;
                }
            }
        }

        public bool ExisteNombreProyectoOtro(string nombreProyecto, int idProyecto)
        {
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                string consulta = @"SELECT COUNT(*) 
                            FROM InfoProyecto.Proyecto 
                            WHERE NombreProyecto = @nombre 
                            AND IdProyecto <> @id";
                using (SqlCommand comando = new SqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("@nombre", nombreProyecto);
                    comando.Parameters.AddWithValue("@id", idProyecto);
                    conexion.Open();
                    int cantidad = Convert.ToInt32(comando.ExecuteScalar());
                    return cantidad > 0;
                }
            }
        }

        public bool ExisteClaveCatastral(string claveCatastral)
        {
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                string consulta = "SELECT COUNT(*) FROM InfoProyecto.Proyecto WHERE ClaveCatastral = @clave";
                using (SqlCommand comando = new SqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("@clave", claveCatastral);
                    conexion.Open();
                    int cantidad = Convert.ToInt32(comando.ExecuteScalar());
                    return cantidad > 0;
                }
            }
        }
        public bool ExisteClaveCatastralOtroProyecto(string claveCatastral, int idProyecto)
        {
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                string consulta = @"SELECT COUNT(*) 
                            FROM InfoProyecto.Proyecto 
                            WHERE ClaveCatastral = @clave 
                            AND IdProyecto <> @id";
                using (SqlCommand comando = new SqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("@clave", claveCatastral);
                    comando.Parameters.AddWithValue("@id", idProyecto);
                    conexion.Open();
                    int cantidad = Convert.ToInt32(comando.ExecuteScalar());
                    return cantidad > 0;
                }
            }
        }

    }
}