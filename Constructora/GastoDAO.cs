using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;

namespace Constructora
{
    internal class GastoDAO
    {
        private static readonly string cadenaConexion =
            "Server=localhost\\SQLEXPRESS; Database=ConstructoraBD;" +
            "Trusted_Connection=True; TrustServerCertificate=True;";

        public DataTable ConsultarGastos()
        {
            DataTable tabla = new DataTable();

            using (SqlConnection conexion =
                new SqlConnection(cadenaConexion))
            {
                string consulta = @"
                    SELECT
                        G.IdGasto,
                        G.IdDisenio,
                        D.NombreDisenio,
                        G.Concepto,
                        G.Monto,
                        G.FechaGasto
                    FROM InfoProyecto.Gasto G
                    INNER JOIN InfoProyecto.Disenio D
                        ON G.IdDisenio = D.IdDisenio";

                SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion);

                adaptador.Fill(tabla);
            }

            return tabla;
        }

        public DataTable ConsultarDisenios()
        {
            DataTable tabla = new DataTable();

            using (SqlConnection conexion =
                new SqlConnection(cadenaConexion))
            {
                string consulta = @"
                    SELECT
                        IdDisenio,
                        CONCAT(IdDisenio, ' - ', NombreDisenio)
                            AS Disenio
                    FROM InfoProyecto.Disenio";

                SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion);

                adaptador.Fill(tabla);
            }

            return tabla;
        }

        public void InsertarGasto(
            int idDisenio,
            string concepto,
            decimal monto)
        {
            using (SqlConnection conexion =
                new SqlConnection(cadenaConexion))
            {
                string consulta = @"
                    INSERT INTO InfoProyecto.Gasto
                    (IdDisenio, Concepto, Monto, FechaGasto)
                    VALUES
                    (@IdDisenio, @Concepto, @Monto, @FechaGasto)";

                SqlCommand comando = new SqlCommand(consulta, conexion);

                comando.Parameters.AddWithValue("@IdDisenio", idDisenio);

                comando.Parameters.AddWithValue("@Concepto", concepto);

                comando.Parameters.AddWithValue("@Monto", monto);

                comando.Parameters.AddWithValue("@FechaGasto", DateTime.Today);

                conexion.Open();
                comando.ExecuteNonQuery();
            }
        }

        public void ModificarGasto(
            int idGasto,
            int idDisenio,
            string concepto,
            decimal monto)
        {
            using (SqlConnection conexion =
                new SqlConnection(cadenaConexion))
            {
                string consulta = @"
                    UPDATE InfoProyecto.Gasto
                    SET IdDisenio = @IdDisenio,
                        Concepto = @Concepto,
                        Monto = @Monto
                    WHERE IdGasto = @IdGasto";

                SqlCommand comando =
                    new SqlCommand(consulta, conexion);

                comando.Parameters.AddWithValue(
                    "@IdGasto", idGasto);

                comando.Parameters.AddWithValue(
                    "@IdDisenio", idDisenio);

                comando.Parameters.AddWithValue(
                    "@Concepto", concepto);

                comando.Parameters.AddWithValue(
                    "@Monto", monto);

                conexion.Open();
                comando.ExecuteNonQuery();
            }
        }

        public bool EliminarGasto(int idGasto)
        {
            using (SqlConnection conexion =
                new SqlConnection(cadenaConexion))
            {
                string consulta = @"
                    DELETE FROM InfoProyecto.Gasto
                    WHERE IdGasto = @IdGasto";

                SqlCommand comando =
                    new SqlCommand(consulta, conexion);

                comando.Parameters.AddWithValue(
                    "@IdGasto", idGasto);

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
                            "No se puede eliminar este gasto porque está relacionado con otra tabla.",
                            "No se puede eliminar",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);

                        return false;
                    }

                    throw;
                }
            }
        }
    }
}
