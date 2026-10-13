using empresa_inventario;
using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace empresa_inventario
{
    public class ProductsDAO
    {
        // 1. CONSULTAR TODOS LOS PRODUCTOS
        public DataTable GetProducts()
        {
            DataTable tabla = new DataTable();

            Conexion conexion = new Conexion();

            using (MySqlConnection conn =
                   conexion.GetConnection())
            {
                conn.Open();
                string query = @"
                    SELECT ID, Descripcion, created_at AS 'Fecha de Creación',
                    updated_at AS 'Última Modificación'
                    FROM CatProducto
                    ORDER BY ID;";

                using (MySqlDataAdapter adapter =
                       new MySqlDataAdapter(query, conn))
                {
                    adapter.Fill(tabla);
                }
            }

            return tabla;
        }

        // 2. GUARDAR UN PRODUCTO
        public bool Insertar(string descripcion)
        {

            Conexion conexion = new Conexion();

            using (MySqlConnection conn =
                   conexion.GetConnection())
            {
                string query = @"
                    INSERT INTO CatProducto (Descripcion)
                    VALUES (@descripcion);";

                using (MySqlCommand cmd =
                       new MySqlCommand(query, conn))
                {
                    cmd.Parameters.Add(
                        "@descripcion", MySqlDbType.VarChar, 40
                    ).Value = descripcion;

                    conn.Open();

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        // 3. ACTUALIZAR UN PRODUCTO
        public bool Actualizar(int id, string descripcion)
        {

            Conexion conexion = new Conexion();

            using (MySqlConnection conn =
                   conexion.GetConnection())
            {
                string query = @"
                    UPDATE CatProducto
                    SET Descripcion = @descripcion
                    WHERE ID = @id;";

                using (MySqlCommand cmd =
                       new MySqlCommand(query, conn))
                {
                    cmd.Parameters.Add(
                        "@descripcion", MySqlDbType.VarChar, 40
                    ).Value = descripcion;

                    cmd.Parameters.Add(
                        "@id", MySqlDbType.Int32
                    ).Value = id;

                    conn.Open();

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        // 4. ELIMINAR UN PRODUCTO
        public bool Eliminar(int id)
        {

            Conexion conexion = new Conexion();

            using (MySqlConnection conn =
                   conexion.GetConnection())
            {
                string query = @"
                    DELETE FROM CatProducto
                    WHERE ID = @id;";

                using (MySqlCommand cmd =
                       new MySqlCommand(query, conn))
                {
                    cmd.Parameters.Add(
                        "@id", MySqlDbType.Int32
                    ).Value = id;

                    conn.Open();

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }
        // 5. CONSULTAR UN PRODUCTO POR ID
        public DataTable GetProductById(int id)
        {
            DataTable tabla = new DataTable();
            Conexion conexion = new Conexion();

            using (MySqlConnection conn = conexion.GetConnection())
            {
                string query = @"
            SELECT ID, Descripcion, created_at, updated_at
            FROM CatProducto
            WHERE ID = @id
            ORDER BY ID;";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = id;

                    conn.Open();

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                    {
                        adapter.Fill(tabla);
                    }
                }
            }

            return tabla;
        }
    }
}