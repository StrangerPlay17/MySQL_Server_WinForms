using MySql.Data.MySqlClient;

namespace empresa_inventario
{
    public class Conexion
    {
        private string cadena =
            "Server=localhost;" +
            "Port=3306;" +
            "Database=empresa_inventario;" +
            "Uid=root;" +
            "Pwd=Superdatabase123;";

        public MySqlConnection GetConnection()
        {
            return new MySqlConnection(cadena);
        }
    }
}