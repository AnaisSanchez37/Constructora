using System;
using System.Data;
using System.Data.SqlClient;

namespace Constructora
{
    internal class DisenioDAO
    {
        private static readonly string cadenaConexion = "Server=localhost\\SQLEXPRESS; Database=ConstructoraBD; Trusted_Connection=True; TrustServerCertificate=True;";

        public DataTable consultarDatos()
        {
            string consulta = @"SELECT D.IdDisenio, D.IdArquitecto, D.IdProyecto,
                CONCAT(A.NombreArquitecto, ' - ', YEAR(A.FechaNacimientoA)) AS NombreArquitecto,
                CONCAT(P.NombreProyecto, ' [', A.NombreArquitecto, ']') AS NombreProyecto,
                D.NombreDisenio, D.FechaCreacion, D.Descripcion, D.CostoDisenio
                FROM InfoProyecto.Disenio D
                INNER JOIN InfoPersona.Arquitecto A ON D.IdArquitecto = A.IdArquitecto
                INNER JOIN InfoProyecto.Proyecto P ON D.IdProyecto = P.IdProyecto
                ORDER BY D.IdDisenio";

            DataTable tabla = new DataTable();
            using (SqlConnection con = new SqlConnection(cadenaConexion))
            using (SqlDataAdapter da = new SqlDataAdapter(consulta, con))
            {
                da.Fill(tabla);
            }
            return tabla;
        }

        public DataTable ObtenerArquitectos()
        {
            DataTable tabla = new DataTable();
            using (SqlConnection con = new SqlConnection(cadenaConexion))
            using (SqlDataAdapter da = new SqlDataAdapter("SELECT IdArquitecto, CONCAT(NombreArquitecto, ' - ', YEAR(FechaNacimientoA)) AS NombreArquitecto FROM InfoPersona.Arquitecto ORDER BY NombreArquitecto", con))
            {
                da.Fill(tabla);
            }
            return tabla;
        }

        public DataTable ObtenerProyectos()
        {
            DataTable tabla = new DataTable();
            using (SqlConnection con = new SqlConnection(cadenaConexion))
            using (SqlDataAdapter da = new SqlDataAdapter("SELECT P.IdProyecto, CONCAT(P.NombreProyecto, ' [', A.NombreArquitecto, ']') AS NombreProyecto FROM InfoProyecto.Proyecto P INNER JOIN InfoPersona.Arquitecto A ON P.IdArquitecto = A.IdArquitecto ORDER BY P.NombreProyecto", con))
            {
                da.Fill(tabla);
            }
            return tabla;
        }

        public void InsertarDisenio(long idArquitecto, long idProyecto, string nombre, DateTime fecha, string descripcion, decimal costo)
        {
            string consulta = @"INSERT INTO InfoProyecto.Disenio
                (IdArquitecto, IdProyecto, NombreDisenio, FechaCreacion, Descripcion, CostoDisenio)
                VALUES (@arquitecto, @proyecto, @nombre, @fecha, @descripcion, @costo)";
            using (SqlConnection con = new SqlConnection(cadenaConexion))
            using (SqlCommand cmd = new SqlCommand(consulta, con))
            {
                cmd.Parameters.Add("@arquitecto", SqlDbType.BigInt).Value = idArquitecto;
                cmd.Parameters.Add("@proyecto", SqlDbType.BigInt).Value = idProyecto;
                cmd.Parameters.Add("@nombre", SqlDbType.VarChar, 200).Value = nombre;
                cmd.Parameters.Add("@fecha", SqlDbType.Date).Value = fecha.Date;
                cmd.Parameters.Add("@descripcion", SqlDbType.VarChar, -1).Value = descripcion;
                cmd.Parameters.Add("@costo", SqlDbType.Money).Value = costo;
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void ModificarDisenio(long id, long idArquitecto, long idProyecto, string nombre, DateTime fecha, string descripcion, decimal costo)
        {
            string consulta = @"UPDATE InfoProyecto.Disenio SET IdArquitecto = @arquitecto,
                IdProyecto = @proyecto, NombreDisenio = @nombre, FechaCreacion = @fecha,
                Descripcion = @descripcion, CostoDisenio = @costo WHERE IdDisenio = @id";
            using (SqlConnection con = new SqlConnection(cadenaConexion))
            using (SqlCommand cmd = new SqlCommand(consulta, con))
            {
                cmd.Parameters.Add("@id", SqlDbType.BigInt).Value = id;
                cmd.Parameters.Add("@arquitecto", SqlDbType.BigInt).Value = idArquitecto;
                cmd.Parameters.Add("@proyecto", SqlDbType.BigInt).Value = idProyecto;
                cmd.Parameters.Add("@nombre", SqlDbType.VarChar, 200).Value = nombre;
                cmd.Parameters.Add("@fecha", SqlDbType.Date).Value = fecha.Date;
                cmd.Parameters.Add("@descripcion", SqlDbType.VarChar, -1).Value = descripcion;
                cmd.Parameters.Add("@costo", SqlDbType.Money).Value = costo;
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void EliminarDisenio(long id)
        {
            using (SqlConnection con = new SqlConnection(cadenaConexion))
            using (SqlCommand cmd = new SqlCommand("DELETE FROM InfoProyecto.Disenio WHERE IdDisenio = @id", con))
            {
                cmd.Parameters.Add("@id", SqlDbType.BigInt).Value = id;
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}

