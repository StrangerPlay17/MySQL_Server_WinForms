using empresa_inventario;
using MySql.Data.MySqlClient;
using System.Data;

namespace empresa_inventario
{
    public class InventoryDAO
    {
        // 1. CONSULTAR INVENTARIO
        public DataTable GetInventory()
        {
            DataTable tabla = new DataTable();

            Conexion conexion = new Conexion();

            using (MySqlConnection conn =
                   conexion.GetConnection())
            {
                conn.Open();
                string query = @"
                    SELECT
                        i.ID,
                        i.FechaAlta,
                        i.IDProducto,
                        p.Descripcion AS Producto,
                        i.IDPersonal,
                        s.Nombre AS Personal,
                        i.Cantidad
                    FROM tblInventario i
                    INNER JOIN CatProducto p
                        ON i.IDProducto = p.ID
                    INNER JOIN CatPersonal s
                        ON i.IDPersonal = s.ID
                    ORDER BY i.ID;";

                using (MySqlDataAdapter adapter =
                       new MySqlDataAdapter(query, conn))
                {
                    adapter.Fill(tabla);
                }
            }

            return tabla;
        }

        // 2. CARGAR PRODUCTOS PARA EL COMBOBOX
        public DataTable ObtenerProductos()
        {
            DataTable tabla = new DataTable();

            Conexion conexion = new Conexion();

            using (MySqlConnection conn =
                   conexion.GetConnection())
            {
                string query = @"
                    SELECT ID, Descripcion
                    FROM CatProducto
                    ORDER BY Descripcion;";

                using (MySqlDataAdapter adapter =
                       new MySqlDataAdapter(query, conn))
                {
                    adapter.Fill(tabla);
                }
            }

            return tabla;
        }

        // 3. CARGAR PERSONAL PARA EL COMBOBOX
        public DataTable ObtenerPersonal()
        {
            DataTable tabla = new DataTable();

            Conexion conexion = new Conexion();

            using (MySqlConnection conn =
                   conexion.GetConnection())
            {
                string query = @"
                    SELECT ID, Nombre
                    FROM CatPersonal
                    ORDER BY Nombre;";

                using (MySqlDataAdapter adapter =
                       new MySqlDataAdapter(query, conn))
                {
                    adapter.Fill(tabla);
                }
            }

            return tabla;
        }

        // 4. INSERTAR REGISTRO DE INVENTARIO
        public bool Insertar(
            int idProducto, int idPersonal, int cantidad)
        {
            Conexion conexion = new Conexion();

            using (MySqlConnection conn =
                   conexion.GetConnection())
            {
                string query = @"
                    INSERT INTO tblInventario
                        (IDProducto, IDPersonal, Cantidad)
                    VALUES
                        (@idProducto, @idPersonal, @cantidad);";

                using (MySqlCommand cmd =
                       new MySqlCommand(query, conn))
                {
                    cmd.Parameters.Add(
                        "@idProducto", MySqlDbType.Int32
                    ).Value = idProducto;

                    cmd.Parameters.Add(
                        "@idPersonal", MySqlDbType.Int32
                    ).Value = idPersonal;

                    cmd.Parameters.Add(
                        "@cantidad", MySqlDbType.Int32
                    ).Value = cantidad;

                    conn.Open();

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        // 5. ACTUALIZAR REGISTRO DE INVENTARIO
        public bool Actualizar(
            int id, int idProducto,
            int idPersonal, int cantidad)
        {
            Conexion conexion = new Conexion();

            using (MySqlConnection conn =
                   conexion.GetConnection())
            {
                string query = @"
                    UPDATE tblInventario
                    SET IDProducto = @idProducto,
                        IDPersonal = @idPersonal,
                        Cantidad = @cantidad
                    WHERE ID = @id;";

                using (MySqlCommand cmd =
                       new MySqlCommand(query, conn))
                {
                    cmd.Parameters.Add(
                        "@id", MySqlDbType.Int32
                    ).Value = id;

                    cmd.Parameters.Add(
                        "@idProducto", MySqlDbType.Int32
                    ).Value = idProducto;

                    cmd.Parameters.Add(
                        "@idPersonal", MySqlDbType.Int32
                    ).Value = idPersonal;

                    cmd.Parameters.Add(
                        "@cantidad", MySqlDbType.Int32
                    ).Value = cantidad;

                    conn.Open();

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        // 6. ELIMINAR REGISTRO DE INVENTARIO
        public bool Eliminar(int id)
        {
            Conexion conexion = new Conexion();

            using (MySqlConnection conn =
                   conexion.GetConnection())
            {
                string query = @"
                    DELETE FROM tblInventario
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
        // 5. CONSULTAR INVENTARIO POR ID
        public DataTable GetInventoryById(int id)
        {
            DataTable tabla = new DataTable();
            Conexion conexion = new Conexion();

            using (MySqlConnection conn = conexion.GetConnection())
            {
                string query = @"
            SELECT
                i.ID,
                i.FechaAlta,
                i.IDProducto,
                p.Descripcion AS Producto,
                i.IDPersonal,
                s.Nombre AS Personal,
                i.Cantidad
            FROM tblInventario i
            INNER JOIN CatProducto p
                ON i.IDProducto = p.ID
            INNER JOIN CatPersonal s
                ON i.IDPersonal = s.ID
            WHERE i.ID = @id;";

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