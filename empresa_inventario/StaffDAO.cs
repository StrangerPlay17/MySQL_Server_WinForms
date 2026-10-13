using empresa_inventario;
using MySql.Data.MySqlClient;
using System.Data;

namespace empresa_inventario
{
    public class StaffDAO
    {
        // 1. CONSULTAR TODO EL PERSONAL
        public DataTable GetStaff()
        {
            DataTable tabla = new DataTable();

            Conexion conexion = new Conexion();

            using (MySqlConnection conn =
                   conexion.GetConnection())
            {
                conn.Open();
                string query = @"
                    SELECT ID, Nombre, Cargo,  created_at AS 'Fecha de Creación',
                    updated_at AS 'Última Modificación'
                    FROM CatPersonal
                    ORDER BY ID;";

                using (MySqlDataAdapter adapter =
                       new MySqlDataAdapter(query, conn))
                {
                    adapter.Fill(tabla);
                }
            }

            return tabla;
        }

        // 2. INSERTAR PERSONAL
        public bool Insertar(string nombre, string cargo)
        {
            Conexion conexion = new Conexion();

            using (MySqlConnection conn =
                   conexion.GetConnection())
            {
                string query = @"
                    INSERT INTO CatPersonal (Nombre, Cargo)
                    VALUES (@nombre, @cargo);";

                using (MySqlCommand cmd =
                       new MySqlCommand(query, conn))
                {
                    cmd.Parameters.Add(
                        "@nombre", MySqlDbType.VarChar, 80
                    ).Value = nombre;

                    cmd.Parameters.Add(
                        "@cargo", MySqlDbType.VarChar, 80
                    ).Value = cargo;

                    conn.Open();

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        // 3. ACTUALIZAR PERSONAL
        public bool Actualizar(int id, string nombre, string cargo)
        {
            Conexion conexion = new Conexion();

            using (MySqlConnection conn =
                   conexion.GetConnection())
            {
                string query = @"
                    UPDATE CatPersonal
                    SET Nombre = @nombre,
                        Cargo = @cargo
                    WHERE ID = @id;";

                using (MySqlCommand cmd =
                       new MySqlCommand(query, conn))
                {
                    cmd.Parameters.Add(
                        "@id", MySqlDbType.Int32
                    ).Value = id;

                    cmd.Parameters.Add(
                        "@nombre", MySqlDbType.VarChar, 80
                    ).Value = nombre;

                    cmd.Parameters.Add(
                        "@cargo", MySqlDbType.VarChar, 80
                    ).Value = cargo;

                    conn.Open();

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        // 4. ELIMINAR PERSONAL
        public bool Eliminar(int id)
        {
            Conexion conexion = new Conexion();

            using (MySqlConnection conn =
                   conexion.GetConnection())
            {
                string query = @"
                    DELETE FROM CatPersonal
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
        public DataTable GetStaffById(int id)
        {
            DataTable tabla = new DataTable();
            Conexion conexion = new Conexion();

            using (MySqlConnection conn = conexion.GetConnection())
            {
                string query = @"
            SELECT ID, Nombre, Cargo, created_at, updated_at
            FROM CatPersonal
            WHERE ID = @id;";

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