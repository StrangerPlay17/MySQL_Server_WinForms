using empresa_inventario;
using MySql.Data.MySqlClient; // Importa la biblioteca oficial de conectividad de MySQL para .NET
using System;                 // Importa funciones básicas del sistema
using System.Data;            // Importa el espacio de nombres de .NET para el manejo de datos en memoria



// Define el espacio de nombres del proyecto como "empresa_inventario"
namespace empresa_inventario
{
    // Clase para manejar las consultas SQL de la tabla CatProducto
    public class ProductsDAO
    {
        // ---------------------------------------------------------------------------------------------------
        // GETALL
        public DataTable GetProducts()             // Método para consultar todos los productos
                                                   // donde obtiene todos los registros de CatProducto
        {
            DataTable tabla = new DataTable();     // Se crea una nueva instancia de tipo DataTable

            Conexion conexion = new Conexion();   // Se crea el objeto de la clase "Conexion" para la conexión a MySQL

            using (MySqlConnection conn =          // Se obtienen los datos de conexión a MySQL desde el método GetConnection
                   conexion.GetConnection())      // donde "using" hace la liberación de recursos de forma automática
            {
                conn.Open();                      // Se abre la conexión con la base de datos

                // Selecciona todos los registros de CatProducto ordenados por ID
                // donde AS renombra los encabezados de las fechas para mejor interpretación del usuario
                string query = @"
                    SELECT
                        ID,
                        Descripcion,
                        created_at AS 'Fecha de Creación',
                        updated_at AS 'Última Modificación'
                    FROM CatProducto
                    ORDER BY ID;";

                using (MySqlDataAdapter adapter =  // Ejecuta la consulta a MySQL para recuperar los datos
                       new MySqlDataAdapter(query, conn))
                {
                    adapter.Fill(tabla);          // Recupera las filas y columnas resultantes de la consulta
                                                  // y las inserta en el objeto de tipo DataTable
                }
            }

            return tabla;                          // Se devuelven los registros obtenidos en "tabla"
        }

        // ---------------------------------------------------------------------------------------------------
        // INSERT
        public bool Insert(string descripcion)   // Método para insertar un nuevo producto en CatProducto
        {
            Conexion conexion = new Conexion();   // Se crea el objeto de la clase "Conexion" para la conexión a MySQL

            using (MySqlConnection conn =          // Se obtienen los datos de conexión a MySQL desde el método GetConnection
                   conexion.GetConnection())      // donde "using" libera los recursos al finalizar
            {
                // Consulta para insertar un nuevo producto en la tabla CatProducto
                string query = @"
                    INSERT INTO CatProducto (Descripcion)
                    VALUES (@descripcion);";

                using (MySqlCommand cmd =         // Crea el comando SQL con la conexión a la base de datos
                       new MySqlCommand(query, conn))
                {
                    // Asigna el valor de la descripción al parámetro SQL
                    // recibido como parámetro del método
                    // donde VarChar, 40 indica que se manejará una cadena de hasta 40 caracteres
                    cmd.Parameters.Add(
                        "@descripcion", MySqlDbType.VarChar, 40
                    ).Value = descripcion;

                    conn.Open();                  // Se abre la conexión con la base de datos

                    // Ejecuta el INSERT y devuelve true si se insertó el registro
                    // o false si no se insertó ningún registro
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        // ---------------------------------------------------------------------------------------------------
        // UPDATE
        public bool Update(int id, string descripcion) // Método para actualizar un producto en CatProducto
                                                           // donde modifica la descripción del producto por su ID
        {
            Conexion conexion = new Conexion();            // Se crea el objeto de la clase "Conexion" para la conexión a MySQL

            using (MySqlConnection conn =                   // Se obtienen los datos de conexión a MySQL desde el método GetConnection
                   conexion.GetConnection())               // donde "using" libera los recursos al finalizar
            {
                // Consulta para actualizar la descripción del producto
                // únicamente del registro cuyo ID coincida con el parámetro recibido
                string query = @"
                    UPDATE CatProducto
                    SET Descripcion = @descripcion
                    WHERE ID = @id;";

                using (MySqlCommand cmd =                  // Crea el comando SQL con la conexión a la base de datos
                       new MySqlCommand(query, conn))
                {
                    // Asigna la nueva descripción del producto al parámetro SQL
                    cmd.Parameters.Add(
                        "@descripcion", MySqlDbType.VarChar, 40
                    ).Value = descripcion;

                    // Asigna el ID del producto que se desea actualizar
                    // donde Int32 indica que el parámetro es de tipo entero
                    cmd.Parameters.Add(
                        "@id", MySqlDbType.Int32
                    ).Value = id;

                    conn.Open();                           // Se abre la conexión con la base de datos

                    // Ejecuta el UPDATE y devuelve true si se modificó algún registro
                    // o false si no se modificó ningún registro
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        // ---------------------------------------------------------------------------------------------------
        // DELETE
        public bool Delete(int id)              // Método para eliminar un producto de CatProducto
                                                  // donde elimina el registro identificado por su ID
        {
            Conexion conexion = new Conexion();  // Se crea el objeto de la clase "Conexion" para la conexión a MySQL

            using (MySqlConnection conn =         // Se obtienen los datos de conexión a MySQL desde el método GetConnection
                   conexion.GetConnection())     // donde "using" libera los recursos al finalizar
            {
                // Consulta para eliminar el producto cuyo ID coincida con el parámetro recibido
                string query = @"
                    DELETE FROM CatProducto
                    WHERE ID = @id;";

                using (MySqlCommand cmd =        // Crea el comando SQL con la conexión a la base de datos
                       new MySqlCommand(query, conn))
                {
                    // Asigna el ID del producto que se desea eliminar
                    // donde Int32 indica que el parámetro es de tipo entero
                    cmd.Parameters.Add(
                        "@id", MySqlDbType.Int32
                    ).Value = id;

                    conn.Open();                 // Se abre la conexión con la base de datos

                    // Ejecuta el DELETE y devuelve true si se eliminó algún registro
                    // o false si no se eliminó ningún registro
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        // ---------------------------------------------------------------------------------------------------
        // GETBY ID
        public DataTable GetProductById(int id)   // Método para consultar un producto de CatProducto por su ID
                                                  // donde busca un registro y devuelve sus datos
        {
            DataTable tabla = new DataTable();    // Se crea una nueva instancia de tipo DataTable
                                                  // donde se almacenará el resultado de la consulta

            Conexion conexion = new Conexion();  // Se crea el objeto de la clase "Conexion" para la conexión a MySQL

            using (MySqlConnection conn =         // Se obtienen los datos de conexión a MySQL desde el método GetConnection
                   conexion.GetConnection())     // donde "using" libera los recursos al finalizar
            {
                // Consulta para buscar un producto por su ID
                // donde WHERE permite recuperar únicamente el registro solicitado
                string query = @"
                    SELECT
                        ID,
                        Descripcion,
                        created_at,
                        updated_at
                    FROM CatProducto
                    WHERE ID = @id
                    ORDER BY ID;";

                using (MySqlCommand cmd =        // Crea el comando SQL con la conexión a la base de datos
                       new MySqlCommand(query, conn))
                {
                    // Asigna el ID del producto que se desea consultar
                    // donde se utiliza un parámetro para evitar concatenar el ID directamente en el SQL
                    cmd.Parameters.Add(
                        "@id", MySqlDbType.Int32
                    ).Value = id;

                    conn.Open();                 // Se abre la conexión con la base de datos

                    // Ejecuta la consulta y utiliza un adaptador para recuperar los resultados
                    using (MySqlDataAdapter adapter =
                           new MySqlDataAdapter(cmd))
                    {
                        adapter.Fill(tabla);     // Recupera las filas y columnas resultantes de la consulta
                                                 // y las inserta en el objeto de tipo DataTable
                    }
                }
            }

            // Si existe el producto devuelve una fila con sus datos si no existe, devuelve un DataTable vacío
            return tabla;
        }
    }
}