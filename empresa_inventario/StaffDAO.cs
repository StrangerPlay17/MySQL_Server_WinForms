using empresa_inventario;
using MySql.Data.MySqlClient; // Importa la biblioteca oficial de conectividad de MySQL para .NET
using System.Data;            // Importa el espacio de nombres de .NET para el manejo de datos en memoria


// Define el espacio de nombres del proyecto como "empresa_inventario"
namespace empresa_inventario
{
    // Clase para manejar las consultas SQL de la tabla CatPersonal
    public class StaffDAO
    {
        // ---------------------------------------------------------------------------------------------------
        // GETALL
        public DataTable GetStaff()                 // Método para consultar todos los registros de CatPersonal
        {
            DataTable tabla = new DataTable();      // Se crea una instancia de tipo DataTable para almacenar los resultados de la consulta

            Conexion conexion = new Conexion();    // Se crea una instancia de la clase Conexion para obtener la conexión a MySQL

            using (MySqlConnection conn = conexion.GetConnection()) // Se obtiene el objeto de conexión a MySQL mediante el método GetConnection
            {                                                       // el bloque using permite liberar los recursos de la conexión al finalizar
                conn.Open();                                        // Se abre la conexión con la base de datos

                // Consulta para obtener todos los registros de CatPersonal ordenados por ID
                // AS permite asignar nombres personalizados a las columnas de fecha en el resultado de la consulta
                string query = @"
                    SELECT
                        ID,
                        Nombre,
                        Cargo,
                        created_at AS 'Fecha de Creación',
                        updated_at AS 'Última Modificación'
                    FROM CatPersonal
                    ORDER BY ID;";

                using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn))
                {
                    adapter.Fill(tabla);            // Ejecuta la consulta y carga las filas y columnas obtenidas en el DataTable
                }
            }

            return tabla;                           // Devuelve el DataTable con los registros obtenidos
        }

        // ---------------------------------------------------------------------------------------------------
        // INSERT
        public bool Insertar(string nombre, string cargo) // Método para insertar un nuevo registro en CatPersonal
        {
            Conexion conexion = new Conexion();           // Se crea una instancia de la clase Conexion para obtener la conexión a MySQL

            using (MySqlConnection conn = conexion.GetConnection()) // Se obtiene el objeto de conexión a la base de datos
            {
                // Consulta SQL para insertar un nuevo registro con el nombre y el cargo recibidos
                string query = @"
                    INSERT INTO CatPersonal (Nombre, Cargo)
                    VALUES (@nombre, @cargo);";

                using (MySqlCommand cmd = new MySqlCommand(query, conn)) // Se crea el comando SQL que se ejecutará mediante la conexión
                {
                    // Se agregan los parámetros que recibirán los valores de nombre y cargo
                    // VarChar indica el tipo de dato de texto y 80 especifica el tamaño declarado para cada parámetro
                    cmd.Parameters.Add(
                        "@nombre", MySqlDbType.VarChar, 80
                    ).Value = nombre;

                    cmd.Parameters.Add(
                        "@cargo", MySqlDbType.VarChar, 80
                    ).Value = cargo;

                    conn.Open(); // Se abre la conexión con la base de datos

                    // Ejecuta el INSERT y devuelve true si se insertó algún registro
                    // o false si la operación no afectó ninguna fila
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        // ---------------------------------------------------------------------------------------------------
        // UPDATE
        public bool Actualizar(int id, string nombre, string cargo) // Método para actualizar un registro de CatPersonal mediante su ID
        {
            Conexion conexion = new Conexion();                    // Se crea una instancia de la clase Conexion para obtener la conexión a MySQL

            using (MySqlConnection conn = conexion.GetConnection()) // Se obtiene el objeto de conexión a la base de datos
            {
                // Consulta SQL para modificar el nombre y el cargo del registro cuyo ID coincida con el parámetro recibido
                string query = @"
                    UPDATE CatPersonal
                    SET Nombre = @nombre,
                        Cargo = @cargo
                    WHERE ID = @id;";

                using (MySqlCommand cmd = new MySqlCommand(query, conn)) // Se crea el comando SQL que se ejecutará mediante la conexión
                {
                    // Se agrega el parámetro que identifica al registro que se desea actualizar
                    cmd.Parameters.Add(
                        "@id", MySqlDbType.Int32
                    ).Value = id;

                    // Se asigna el nuevo nombre al parámetro correspondiente
                    cmd.Parameters.Add(
                        "@nombre", MySqlDbType.VarChar, 80
                    ).Value = nombre;

                    // Se asigna el nuevo cargo al parámetro correspondiente
                    cmd.Parameters.Add(
                        "@cargo", MySqlDbType.VarChar, 80
                    ).Value = cargo;

                    conn.Open(); // Se abre la conexión con la base de datos

                    // Ejecuta el UPDATE y devuelve true si se modificó alguna fila
                    // o false si la operación no afectó ninguna fila
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        // ---------------------------------------------------------------------------------------------------
        // DELETE
        public bool Eliminar(int id) // Método para eliminar un registro de CatPersonal mediante su ID
        {
            Conexion conexion = new Conexion(); // Se crea una instancia de la clase Conexion para obtener la conexión a MySQL

            using (MySqlConnection conn = conexion.GetConnection()) // Se obtiene el objeto de conexión a la base de datos
            {
                // Consulta SQL para eliminar el registro cuyo ID coincida con el parámetro recibido
                string query = @"
                    DELETE FROM CatPersonal
                    WHERE ID = @id;";

                using (MySqlCommand cmd = new MySqlCommand(query, conn)) // Se crea el comando SQL que se ejecutará mediante la conexión
                {
                    // Se agrega el parámetro que identifica al registro que se desea eliminar
                    // Int32 indica que el parámetro es de tipo entero
                    cmd.Parameters.Add(
                        "@id", MySqlDbType.Int32
                    ).Value = id;

                    conn.Open(); // Se abre la conexión con la base de datos

                    // Ejecuta el DELETE y devuelve true si se eliminó alguna fila
                    // o false si la operación no afectó ninguna fila
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        // ---------------------------------------------------------------------------------------------------
        // GETBY ID
        public DataTable GetStaffById(int id) // Método para consultar un registro de CatPersonal mediante su ID
        {
            DataTable tabla = new DataTable(); // Se crea una instancia de tipo DataTable para almacenar los resultados de la consulta

            Conexion conexion = new Conexion(); // Se crea una instancia de la clase Conexion para obtener la conexión a MySQL

            using (MySqlConnection conn = conexion.GetConnection()) // Se obtiene el objeto de conexión a la base de datos
            {
                // Consulta SQL para recuperar los datos del registro cuyo ID coincida con el parámetro recibido
                string query = @"
                    SELECT
                        ID,
                        Nombre,
                        Cargo,
                        created_at AS 'Fecha de Creación',
                        updated_at AS 'Última Modificación'
                    FROM CatPersonal
                    WHERE ID = @id;";

                using (MySqlCommand cmd = new MySqlCommand(query, conn)) // Se crea el comando SQL que se ejecutará mediante la conexión
                {
                    // Se agrega el parámetro @id para identificar el registro solicitado
                    // el uso de parámetros evita concatenar directamente el valor del ID en la consulta SQL
                    cmd.Parameters.Add(
                        "@id", MySqlDbType.Int32
                    ).Value = id;

                    conn.Open(); // Se abre la conexión con la base de datos

                    // Se crea un adaptador para ejecutar el comando y recuperar los resultados de la consulta
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                    {
                        adapter.Fill(tabla); // Carga las filas y columnas obtenidas en el DataTable
                    }
                }
            }

            // Si existe el registro solicitado el DataTable lo retorna, si no existe, devuelve un DataTable vacío
            return tabla;
        }
    }
}