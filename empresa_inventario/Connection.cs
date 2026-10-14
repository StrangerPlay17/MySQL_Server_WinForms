using MySql.Data.MySqlClient; // Importa la biblioteca oficial de conectividad de MySQL para .NET
using DotNetEnv;              // Importa la biblioteca para leer las variables del archivo .env

// Define el espacio de nombres del proyecto como "empresa_inventario"
namespace empresa_inventario
{
    public class Conexion // Clase para establecer la conexión a MySQL desde el archivo .env 
    {
        // Obtiene la ruta del archivo .env ubicado en la carpeta de ejecución del programa
        private static readonly string rutaEnv =
            Path.Combine(AppDomain.CurrentDomain.BaseDirectory, ".env");

        // Guarda la cadena de conexión creada mediante el método CrearCadenaConexion
        private static readonly string cadena = CrearCadenaConexion();

        // Método que obtiene los datos del archivo .env y crea la cadena de conexión
        private static string CrearCadenaConexion()
        {
            // Verifica que exista el archivo .env
            // Si no existe, muestra una excepción indicando su ubicación
            if (!File.Exists(rutaEnv))
            {
                throw new FileNotFoundException(
                    "No se encontró el archivo .env. Verifica su ubicación.",
                    rutaEnv
                );
            }

            // Carga las variables almacenadas en el archivo .env
            Env.Load(rutaEnv);

            // Obtiene los datos del servidor, puerto, base de datos, usuario y contraseña
            // para construir la cadena de conexión a MySQL
            var builder = new MySqlConnectionStringBuilder
            {
                Server = Environment.GetEnvironmentVariable("DB_SERVER"),
                Port = uint.Parse(
                    Environment.GetEnvironmentVariable("DB_PORT")
                ),
                Database = Environment.GetEnvironmentVariable("DB_NAME"),
                UserID = Environment.GetEnvironmentVariable("DB_USER"),
                Password = Environment.GetEnvironmentVariable("DB_PASSWORD")
            };

            // Devuelve la cadena de conexión creada con los datos del archivo .env
            return builder.ConnectionString;
        }

        // ---------------------------------------------------------------------------------------------------
        // GET CONNECTION
        public MySqlConnection GetConnection() // Método que crea y devuelve un objeto de conexión a MySQL
        {
            return new MySqlConnection(cadena);    // Crea y devuelve la conexión utilizando la cadena almacenada
                                                   // la cual puede abrirse posteriormente mediante el método Open()
        }
    }
}