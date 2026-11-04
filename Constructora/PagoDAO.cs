using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;


namespace Constructora
{
    internal class PagoDAO
    {
        private static readonly string cadenaConexion =
            "Server=localhost\\SQLEXPRESS; Database=ConstructoraBD;" +
            "Trusted_Connection=True; TrustServerCertificate=True;";

        public DataTable ConsultarPagos()
        {
            DataTable tabla = new DataTable();

            string consulta =
                "SELECT P.IdPago, P.IdCliente,  " +
                "CONCAT(C.NombreCliente, '--', RIGHT(C.TelefonoC, 3)) AS NombreCliente, "+
                "P.IdProyecto, " +
                "CONCAT(PR.NombreProyecto, '[',A.NombreArquitecto,']') AS NombreProyecto, " +
                "P.FechaPago, P.Monto " +
                "FROM InfoProyecto.Pago P " +
                "INNER JOIN InfoPersona.Cliente C ON P.IdCliente = C.IdCliente " +
                "INNER JOIN InfoProyecto.Proyecto PR ON P.IdProyecto = PR.IdProyecto " +
                "INNER JOIN InfoPersona.Arquitecto A ON PR.IdArquitecto = A.IdArquitecto";

            using (SqlConnection con = new SqlConnection(cadenaConexion))
            using (SqlDataAdapter da = new SqlDataAdapter(consulta, con))
            {
                da.Fill(tabla);
            }

            return tabla;
        }

        public DataTable ConsultarClientes()
        {
            DataTable tabla = new DataTable();

            string consulta =
                "SELECT IdCliente,  "+
                "CONCAT(NombreCliente, '--', RIGHT(TelefonoC, 3)) AS NombreCliente "+
                "FROM InfoPersona.Cliente";

            using (SqlConnection con = new SqlConnection(cadenaConexion))
            using (SqlDataAdapter da = new SqlDataAdapter(consulta, con))
            {
                da.Fill(tabla);
            }

            return tabla;
        }


        public DataTable ConsultarProyectos()
        {
            DataTable tabla = new DataTable();

            string consulta =
                "SELECT IdProyecto, " +
                "CONCAT(PR.NombreProyecto, '[', A.NombreArquitecto, ']') AS NombreProyecto "+
                "FROM InfoProyecto.Proyecto PR "+
                "INNER JOIN InfoPersona.Arquitecto A ON PR.IdArquitecto = A.IdArquitecto";

            using (SqlConnection con = new SqlConnection(cadenaConexion))
            using (SqlDataAdapter da = new SqlDataAdapter(consulta, con))
            {
                da.Fill(tabla);
            }

            return tabla;
        }

        public void InsertarPago(int IdCliente, int IdProyecto,
                                 DateTime fechaPago, decimal monto)
        {
            string consulta =
                "INSERT INTO InfoProyecto.Pago " +
                "(IdCliente, IdProyecto, FechaPago, Monto) " +
                "VALUES (@IdCliente, @IdProyecto, @FechaPago, @Monto)";

            using (SqlConnection con = new SqlConnection(cadenaConexion))
            using (SqlCommand cmd = new SqlCommand(consulta, con))
            {
                con.Open();

                cmd.Parameters.AddWithValue("@IdCliente", IdCliente);
                cmd.Parameters.AddWithValue("@IdProyecto", IdProyecto);
                cmd.Parameters.AddWithValue("@FechaPago", fechaPago);
                cmd.Parameters.AddWithValue("@Monto", monto);

                cmd.ExecuteNonQuery();
            }
        }


        public void ModificarPago(int IdPago, int IdCliente, int IdProyecto,
                                  DateTime fechaPago, decimal monto)
        {
            string consulta =
                "UPDATE InfoProyecto.Pago SET " +
                "IdCliente = @IdCliente, " +
                "IdProyecto = @IdProyecto, " +
                "FechaPago = @FechaPago, " +
                "Monto = @Monto " +
                "WHERE IdPago = @IdPago";

            using (SqlConnection con = new SqlConnection(cadenaConexion))
            using (SqlCommand cmd = new SqlCommand(consulta, con))
            {
                con.Open();

                cmd.Parameters.AddWithValue("@IdPago", IdPago);
                cmd.Parameters.AddWithValue("@IdCliente", IdCliente);
                cmd.Parameters.AddWithValue("@IdProyecto", IdProyecto);
                cmd.Parameters.AddWithValue("@FechaPago", fechaPago);
                cmd.Parameters.AddWithValue("@Monto", monto);

                cmd.ExecuteNonQuery();
            }
        }


        public bool EliminarPago(int idPago)
        {
            using (SqlConnection conexion =
                new SqlConnection(cadenaConexion))
            {
                string consulta = @"
            DELETE FROM InfoProyecto.Pago
            WHERE IdPago = @IdPago";

                SqlCommand comando = new SqlCommand(consulta, conexion);

                comando.Parameters.AddWithValue("@IdPago", idPago);

                try
                {
                    conexion.Open();
                    comando.ExecuteNonQuery();
                    return true;
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 547)
                    {
                        MessageBox.Show(
                            "No se puede eliminar este pago porque está relacionado con otra tabla.",
                            "No se puede eliminar",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);

                        return false;
                    }

                    throw;
                }
            }
        }


        public DataTable ConsultarProyectosPorCliente(int idCliente)
        {
            DataTable tabla = new DataTable();
            
            string consulta =
            "SELECT PR.IdProyecto, " +
            "CONCAT(PR.NombreProyecto, ' [', A.NombreArquitecto, ']') AS NombreProyecto " +
            "FROM InfoProyecto.Proyecto PR " +
            "INNER JOIN InfoPersona.Arquitecto A ON PR.IdArquitecto = A.IdArquitecto " +
            "WHERE PR.IdCliente = @IdCliente";

            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            using (SqlCommand comando = new SqlCommand(consulta, conexion))
            {
                comando.Parameters.AddWithValue("@IdCliente", idCliente);

                using (SqlDataAdapter adaptador = new SqlDataAdapter(comando))
                {
                    adaptador.Fill(tabla);
                }
            }

            return tabla;
        }

        public int ConsultarClientePorProyecto(int idProyecto)
        {
            int idCliente = -1;

            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                string consulta = @"
            SELECT IdCliente
            FROM InfoProyecto.Proyecto
            WHERE IdProyecto = @IdProyecto";

                SqlCommand comando = new SqlCommand(consulta, conexion);
                comando.Parameters.AddWithValue("@IdProyecto", idProyecto);

                conexion.Open();

                object resultado = comando.ExecuteScalar();

                if (resultado != null && resultado != DBNull.Value)
                {
                    idCliente = Convert.ToInt32(resultado);
                }
            }

            return idCliente;
        }  
    }
}
