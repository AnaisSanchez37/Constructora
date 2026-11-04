using System;
using System.Data;
using System.Data.SqlClient;

namespace Constructora
{
    internal class ProveedorServicioDAO
    {
        private static readonly string cadenaConexion = "Server=localhost\\SQLEXPRESS; Database=ConstructoraBD; Trusted_Connection=True; TrustServerCertificate=True;";

        public DataTable consultarDatos()
        {
            DataTable tabla = new DataTable();
            using (SqlConnection con = new SqlConnection(cadenaConexion))
            using (SqlDataAdapter da = new SqlDataAdapter("SELECT PS.IdProveedorServicio, PS.IdProveedor, PS.IdServicio, P.NombreProveedor, S.NombreServicio, PS.CostoBase FROM InfoProyecto.ProveedorServicio PS INNER JOIN InfoPersona.Proveedor P ON P.IdProveedor = PS.IdProveedor INNER JOIN InfoProyecto.Servicio S ON S.IdServicio = PS.IdServicio ORDER BY PS.IdProveedorServicio", con))
            {
                da.Fill(tabla);
            }
            return tabla;
        }

        public void InsertarProveedorServicio(long idProveedor, long idServicio, decimal costoBase)
        {
            string consulta = "INSERT INTO InfoProyecto.ProveedorServicio (IdProveedor, IdServicio, CostoBase) VALUES (@idProveedor, @idServicio, @costoBase)";
            using (SqlConnection con = new SqlConnection(cadenaConexion))
            using (SqlCommand cmd = new SqlCommand(consulta, con))
            {
                cmd.Parameters.Add("@idProveedor", SqlDbType.BigInt).Value = idProveedor;
                cmd.Parameters.Add("@idServicio", SqlDbType.BigInt).Value = idServicio;
                cmd.Parameters.Add("@costoBase", SqlDbType.Money).Value = costoBase;
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void ModificarProveedorServicio(long id, long idProveedor, long idServicio, decimal costoBase)
        {
            string consulta = "UPDATE InfoProyecto.ProveedorServicio SET IdProveedor = @idProveedor, IdServicio = @idServicio, CostoBase = @costoBase WHERE IdProveedorServicio = @id";
            using (SqlConnection con = new SqlConnection(cadenaConexion))
            using (SqlCommand cmd = new SqlCommand(consulta, con))
            {
                cmd.Parameters.Add("@id", SqlDbType.BigInt).Value = id;
                cmd.Parameters.Add("@idProveedor", SqlDbType.BigInt).Value = idProveedor;
                cmd.Parameters.Add("@idServicio", SqlDbType.BigInt).Value = idServicio;
                cmd.Parameters.Add("@costoBase", SqlDbType.Money).Value = costoBase;
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void EliminarProveedorServicio(long id)
        {
            using (SqlConnection con = new SqlConnection(cadenaConexion))
            using (SqlCommand cmd = new SqlCommand("DELETE FROM InfoProyecto.ProveedorServicio WHERE IdProveedorServicio = @id", con))
            {
                cmd.Parameters.Add("@id", SqlDbType.BigInt).Value = id;
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public bool ExisteRelacion(long idProveedor, long idServicio, long id = -1)
        {
            using (SqlConnection con = new SqlConnection(cadenaConexion))
            using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM InfoProyecto.ProveedorServicio WHERE IdProveedor = @proveedor AND IdServicio = @servicio AND IdProveedorServicio <> @id", con))
            {
                cmd.Parameters.Add("@proveedor", SqlDbType.BigInt).Value = idProveedor;
                cmd.Parameters.Add("@servicio", SqlDbType.BigInt).Value = idServicio;
                cmd.Parameters.Add("@id", SqlDbType.BigInt).Value = id;
                con.Open();
                return (int)cmd.ExecuteScalar() > 0;
            }
        }

    }
}

