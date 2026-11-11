using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Constructora
{
    internal class ServicioPorDisenioDAO
    {
        private static readonly string cadenaConexion = "Server=localhost\\SQLEXPRESS; Database=ConstructoraBD; Trusted_Connection=True; TrustServerCertificate=True;";
        public DataTable ObtenerServicioPorDisenio()
        {
            DataTable tabla = new DataTable();
            string query = @"SELECT SPD.IdDisenio, SPD.IdProveedorServicio,
                            CONCAT(D.IdDisenio, ' - ', D.NombreDisenio) AS NombreDisenio,
                            CONCAT(PS.IdProveedorServicio, S.IdServicio, '--->', S.NombreServicio, '[', P.NombreProveedor ,']') AS NombreProveedorServicio, 
                            SPD.Fecha, SPD.Duracion, SPD.CostoServicioDisenio 
                            FROM InfoProyecto.ServicioPorDisenio SPD
                            INNER JOIN InfoProyecto.Disenio D ON D.IdDisenio = SPD.IdDisenio
                            INNER JOIN InfoProyecto.ProveedorServicio PS ON PS.IdProveedorServicio = SPD.IdProveedorServicio
                            INNER JOIN InfoPersona.Proveedor P ON P.IdProveedor = PS.IdProveedor
                            INNER JOIN InfoProyecto.Servicio S ON S.IdServicio = PS.IdServicio";
            using (SqlConnection con = new SqlConnection(cadenaConexion))
            using (SqlDataAdapter da = new SqlDataAdapter(query, con))
            {
                da.Fill(tabla);
            }
            return tabla;
        }

        public DataTable ObtenerDisenios()
        {
            // Concatenacion por modificar
            string consulta = "SELECT IdDisenio, CONCAT(IdDisenio, ' - ', NombreDisenio) AS NombreDisenio FROM InfoProyecto.Disenio";
            using (SqlConnection con = new SqlConnection(cadenaConexion))
            using (SqlDataAdapter da = new SqlDataAdapter(consulta, con))
            {
                DataTable tabla = new DataTable();
                da.Fill(tabla);
                return tabla;
            }
        }
        public DataTable ObtenerProveedorServicios()
        {
            // Concactenacion por modificar
            string consulta = @"SELECT PS.IdProveedorServicio, 
                                CONCAT(PS.IdProveedorServicio, S.IdServicio, '--->', S.NombreServicio, '[', P.NombreProveedor ,']') AS DescripcionPS
                                FROM InfoProyecto.ProveedorServicio PS
                                INNER JOIN InfoPersona.Proveedor P ON P.IdProveedor = PS.IdProveedor
                                INNER JOIN InfoProyecto.Servicio S ON S.IdServicio = PS.IdServicio";
            using (SqlConnection con = new SqlConnection(cadenaConexion))
            using (SqlDataAdapter da = new SqlDataAdapter(consulta, con))
            {
                DataTable tabla = new DataTable();
                da.Fill(tabla);
                return tabla;
            }
        }

        public void Insertar(long idDisenio, long idProveedorServicio, DateTime fecha, decimal duracion)
        {
            string query = "INSERT INTO InfoProyecto.ServicioPorDisenio (IdDisenio, IdProveedorServicio, Fecha, Duracion) VALUES (@idDisenio, @idPS, @fecha, @duracion)";
            using (SqlConnection con = new SqlConnection(cadenaConexion))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.Add("@idDisenio", SqlDbType.BigInt).Value = idDisenio;
                cmd.Parameters.Add("@idPS", SqlDbType.BigInt).Value = idProveedorServicio;
                cmd.Parameters.Add("@fecha", SqlDbType.Date).Value = fecha;
                cmd.Parameters.Add("@duracion", SqlDbType.Decimal).Value = duracion;
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Modificar(long idDisenioOriginal, long idPSOriginal, long idDisenioNuevo, long idPSNuevo, DateTime fecha, decimal duracion)
        {
            string query = @"UPDATE InfoProyecto.ServicioPorDisenio 
                             SET IdDisenio = @idDisenioNuevo, IdProveedorServicio = @idPSNuevo, Fecha = @fecha, Duracion = @duracion 
                             WHERE IdDisenio = @idDisenioOriginal AND IdProveedorServicio = @idPSOriginal";
            using (SqlConnection con = new SqlConnection(cadenaConexion))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.Add("@idDisenioNuevo", SqlDbType.BigInt).Value = idDisenioNuevo;
                cmd.Parameters.Add("@idPSNuevo", SqlDbType.BigInt).Value = idPSNuevo;
                cmd.Parameters.Add("@fecha", SqlDbType.Date).Value = fecha;
                cmd.Parameters.Add("@duracion", SqlDbType.Decimal).Value = duracion;
                cmd.Parameters.Add("@idDisenioOriginal", SqlDbType.BigInt).Value = idDisenioOriginal;
                cmd.Parameters.Add("@idPSOriginal", SqlDbType.BigInt).Value = idPSOriginal;
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Eliminar(long idDisenio, long idProveedorServicio)
        {
            string query = "DELETE FROM InfoProyecto.ServicioPorDisenio WHERE IdDisenio = @idDisenio AND IdProveedorServicio = @idPS";
            using (SqlConnection con = new SqlConnection(cadenaConexion))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.Add("@idDisenio", SqlDbType.BigInt).Value = idDisenio;
                cmd.Parameters.Add("@idPS", SqlDbType.BigInt).Value = idProveedorServicio;
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }


    }
}
