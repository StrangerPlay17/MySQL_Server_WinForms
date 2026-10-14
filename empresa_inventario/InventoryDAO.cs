using empresa_inventario;
using MySql.Data.MySqlClient; // Importa la biblioteca oficial de conectividad de MySQL para .NET
using System.Data;            // Importa el espacio de nombres de .NET para el manejo de datos en memoria


// Define el espacio de nombres del proyecto como "empresa_inventario"
namespace empresa_inventario
{
    // Clase para manejar las consultas SQL de la tabla tblInventario
    public class InventoryDAO
    {
        // ---------------------------------------------------------------------------------------------------
        // GETALL
        public DataTable GetInventory()          // Método para consultar todos los registros del inventario
        {
            DataTable tabla = new DataTable();   // Se crea una instancia de tipo DataTable para almacenar los resultados de la consulta

            Conexion conexion = new Conexion(); // Se crea una instancia de la clase Conexion para obtener la conexión a MySQL

            using (MySqlConnection conn = conexion.GetConnection()) // Se obtiene el objeto de conexión a MySQL mediante el método GetConnection
            {                                                       // el bloque using permite liberar los recursos de la conexión al finalizar
                conn.Open();                                        // Se abre la conexión con la base de datos

                // Consulta para obtener los registros del inventario junto con la descripción del producto
                // y el nombre del personal relacionado 
                // donde INNER JOIN relaciona las tablas mediante sus ID correspondientes
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

                using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn)) // Se crea un adaptador para ejecutar la consulta y recuperar los resultados
                {
                    adapter.Fill(tabla);         // Ejecuta la consulta y carga las filas y columnas obtenidas en el DataTable
                }
            }

            return tabla;                        // Devuelve el DataTable con los registros del inventario obtenidos
        }

        // ---------------------------------------------------------------------------------------------------
        // LOAD ComboBoxProducts INFO (Vista en Inventario)
        public DataTable ObtenerProductos()      // Método para consultar los productos que se mostrarán en el ComboBoxProducts
        {
            DataTable tabla = new DataTable();   // Se crea una instancia de tipo DataTable para almacenar los productos consultados

            Conexion conexion = new Conexion(); // Se crea una instancia de la clase Conexion para obtener la conexión a MySQL

            using (MySqlConnection conn = conexion.GetConnection()) // Se obtiene el objeto de conexión a la base de datos
            {
                // Consulta para obtener el ID y la descripción de todos los productos en CatProductos
                // ORDER BY organiza los productos alfabéticamente por su descripción
                string query = @"
                    SELECT ID, Descripcion
                    FROM CatProducto
                    ORDER BY Descripcion;";

                using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn)) // Se crea un adaptador para ejecutar la consulta y recuperar los resultados
                {
                    adapter.Fill(tabla);         // Carga los productos obtenidos en el DataTable
                }
            }

            return tabla;                        // Devuelve el DataTable con los productos consultados
        }

        // ---------------------------------------------------------------------------------------------------
        // LOAD ComboBoxStaff INFO (Vista en Inventario)
        public DataTable ObtenerPersonal()       // Método para consultar el personal que se mostrará en el ComboBoxStaff
        {
            DataTable tabla = new DataTable();   // Se crea una instancia de tipo DataTable para almacenar el personal consultado

            Conexion conexion = new Conexion(); // Se crea una instancia de la clase Conexion para obtener la conexión a MySQL

            using (MySqlConnection conn = conexion.GetConnection()) // Se obtiene el objeto de conexión a la base de datos
            {
                // Consulta para obtener el ID y el nombre de todo el personal registrado
                // ORDER BY organiza los nombres del personal alfabéticamente
                string query = @"
                    SELECT ID, Nombre
                    FROM CatPersonal
                    ORDER BY Nombre;";

                using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn)) // Se crea un adaptador para ejecutar la consulta y recuperar los resultados
                {
                    adapter.Fill(tabla);         // Carga los registros del personal obtenidos en el DataTable
                }
            }

            return tabla;                        // Devuelve el DataTable con el personal consultado
        }

        // ---------------------------------------------------------------------------------------------------
        // INSERT
        public bool Insertar(int idProducto, int idPersonal, int cantidad) // Método para insertar un nuevo registro en tblInventario
        {
            Conexion conexion = new Conexion(); // Se crea una instancia de la clase Conexion para obtener la conexión a MySQL

            using (MySqlConnection conn = conexion.GetConnection()) // Se obtiene el objeto de conexión a la base de datos
            {
                // Consulta SQL para insertar un registro de inventario
                string query = @"
                    INSERT INTO tblInventario
                        (IDProducto, IDPersonal, Cantidad)
                    VALUES
                        (@idProducto, @idPersonal, @cantidad);";

                using (MySqlCommand cmd = new MySqlCommand(query, conn)) // Se crea el comando SQL que se ejecutará mediante la conexión
                {
                    // Se agrega el parámetro que identifica al producto seleccionado
                    // Int32 indica que el parámetro es de tipo entero
                    cmd.Parameters.Add(
                        "@idProducto", MySqlDbType.Int32
                    ).Value = idProducto;

                    // Se agrega el parámetro que identifica al personal relacionado con el registro
                    cmd.Parameters.Add(
                        "@idPersonal", MySqlDbType.Int32
                    ).Value = idPersonal;

                    // Se agrega el parámetro que indica la cantidad registrada en el inventario
                    cmd.Parameters.Add(
                        "@cantidad", MySqlDbType.Int32
                    ).Value = cantidad;

                    conn.Open(); // Se abre la conexión con la base de datos

                    // Ejecuta el INSERT y devuelve true si se insertó algún registro
                    // o false si la operación no afectó ninguna fila
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        // ---------------------------------------------------------------------------------------------------
        // UPDATE
        public bool Actualizar(int id, int idProducto, int idPersonal, int cantidad) // Método para actualizar un registro de inventario mediante su ID
        {
            Conexion conexion = new Conexion(); // Se crea una instancia de la clase Conexion para obtener la conexión a MySQL

            using (MySqlConnection conn = conexion.GetConnection()) // Se obtiene el objeto de conexión a la base de datos
            {
                // Consulta SQL para actualizar los datos de un registro del inventario
                // WHERE identifica el registro que se desea modificar mediante su ID
                string query = @"
                    UPDATE tblInventario
                    SET IDProducto = @idProducto,
                        IDPersonal = @idPersonal,
                        Cantidad = @cantidad
                    WHERE ID = @id;";

                using (MySqlCommand cmd = new MySqlCommand(query, conn)) // Se crea el comando SQL que se ejecutará mediante la conexión
                {
                    // Se agrega el parámetro que identifica al registro de inventario que se desea actualizar
                    cmd.Parameters.Add(
                        "@id", MySqlDbType.Int32
                    ).Value = id;

                    // Se asigna el ID del nuevo producto relacionado con el registro
                    cmd.Parameters.Add(
                        "@idProducto", MySqlDbType.Int32
                    ).Value = idProducto;

                    // Se asigna el ID del personal relacionado con el registro
                    cmd.Parameters.Add(
                        "@idPersonal", MySqlDbType.Int32
                    ).Value = idPersonal;

                    // Se asigna la nueva cantidad del registro de inventario
                    cmd.Parameters.Add(
                        "@cantidad", MySqlDbType.Int32
                    ).Value = cantidad;

                    conn.Open(); // Se abre la conexión con la base de datos

                    // Ejecuta el UPDATE y devuelve true si la operación afectó alguna fila
                    // o false si no se modificó ninguna fila
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        // ---------------------------------------------------------------------------------------------------
        // DELETE
        public bool Eliminar(int id) // Método para eliminar un registro del inventario mediante su ID
        {
            Conexion conexion = new Conexion(); // Se crea una instancia de la clase Conexion para obtener la conexión a MySQL

            using (MySqlConnection conn = conexion.GetConnection()) // Se obtiene el objeto de conexión a la base de datos
            {
                // Consulta SQL para eliminar el registro de inventario donde el ID coincida con el parámetro recibido
                string query = @"
                    DELETE FROM tblInventario
                    WHERE ID = @id;";

                using (MySqlCommand cmd = new MySqlCommand(query, conn)) // Se crea el comando SQL que se ejecutará mediante la conexión
                {
                    // Se agrega el parámetro que identifica al registro de inventario que se desea eliminar
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
        public DataTable GetInventoryById(int id) // Método para consultar un registro de inventario mediante su ID
        {
            DataTable tabla = new DataTable();    // Se crea una instancia de tipo DataTable para almacenar los resultados de la consulta

            Conexion conexion = new Conexion();  // Se crea una instancia de la clase Conexion para obtener la conexión a MySQL

            using (MySqlConnection conn = conexion.GetConnection()) // Se obtiene el objeto de conexión a la base de datos
            {
                // Consulta SQL para buscar un registro de inventario por su ID
                // INNER JOIN permite obtener la descripción del producto y el nombre del personal relacionado
                // y WHERE filtrar por ID 
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

                using (MySqlCommand cmd = new MySqlCommand(query, conn)) // Se crea el comando SQL que se ejecutará mediante la conexión
                {
                    // Se agrega el parámetro @id para identificar el registro de inventario solicitado
                    // el uso de parámetros evita concatenar directamente el valor del ID en la consulta SQL
                    cmd.Parameters.Add(
                        "@id", MySqlDbType.Int32
                    ).Value = id;

                    conn.Open(); // Se abre la conexión con la base de datos

                    // Se crea un adaptador para ejecutar el comando SQL y recuperar los resultados de la consulta
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                    {
                        adapter.Fill(tabla); // Carga las filas y columnas obtenidas en el DataTable
                    }
                }
            }

            // Si existe el registro lo retorna; sino, devuelve un DataTable vacío
            return tabla;
        }
    }
}