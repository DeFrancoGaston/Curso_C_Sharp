namespace Web_API.DataServices
{
    using Microsoft.Data.SqlClient;
    using Web_API.Models;

    public class VentaDS
    {
        private readonly string connectionString;

        // Constructor que recibe el string de conexión a la Base de Datos
        public VentaDS(/*string connectionString*/)
        {
            Conexion cn = new Conexion();
            string connectionString = cn.cadenaSQL();

            this.connectionString = connectionString;
        }

        // Método para insertar una nueva Venta en la Base de Datos
        public int CrearVenta(Venta venta)
        {
            // Creamos una nueva conexión a la base de datos utilizando el string de conexión que se recibió en el constructor
            using (var connection = new SqlConnection(connectionString))
            {
                // Abrimos la conexión
                connection.Open();

                // Definimos la consulta SQL que vamos a ejecutar
                const string query = @"INSERT INTO Venta (Comentarios) 
                                   VALUES (@Comentarios);
                                   SELECT SCOPE_IDENTITY();";
                // Creamos una nueva instancia de SqlCommand con la consulta SQL y la conexión asociada
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Comentarios", venta.Comentarios);

                    // Ejecutamos la consulta SQL utilizando ExecuteScalar() que retorna el id generado para nuevo registro insertado
                    return (int)(decimal)command.ExecuteScalar();
                }
            }
        }

        // Método para eliminar una Venta de la Base de Datos según su Id
        public bool EliminarVenta(long id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Definimos la consulta SQL que vamos a ejecutar
                const string query = @"DELETE FROM Venta WHERE Id = @Id";
                // Creamos una nueva instancia de SqlCommand con la consulta SQL y la conexión asociada
                using (var command = new SqlCommand(query, connection))
                {
                    // Agregamos el parámetro correspondiente a la consulta SQL utilizando el Id recibido como parámetro
                    command.Parameters.AddWithValue("@Id", id);

                    // Ejecutamos la consulta SQL utilizando ExecuteNonQuery() que retorna la cantidad de filas afectadas por la consulta SQL
                    // En este caso, debería ser 1 si se eliminó el usuario correctamente, o 0 si no se encontró el usuario con el Id correspondiente
                    return command.ExecuteNonQuery() > 0;
                }
            }
        }

        // Método para modificar una Venta existente en la Base de Datos
        public bool ModificarVenta(Venta venta)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Definimos la consulta SQL que vamos a ejecutar
                const string query = @"UPDATE Venta SET Comentarios = @Comentarios
                                   WHERE Id = @Id";
                // Creamos una nueva instancia de SqlCommand con la consulta SQL y la conexión asociada
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Comentarios", venta.Comentarios);
                    command.Parameters.AddWithValue("@Id", venta.Id);

                    // Ejecutamos la consulta SQL utilizando ExecuteNonQuery() que retorna la cantidad de filas afectadas por la consulta SQL
                    return command.ExecuteNonQuery() > 0;
                }
            }
        }

        // Método para obtener la información de una Venta según su Id
        public Venta ObtenerVentaPorId(long id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Definimos la consulta SQL que vamos a ejecutar
                const string query = @"SELECT Id, Comentarios
                                   FROM Venta WHERE Id = @Id";
                // Creamos una nueva instancia de SqlCommand con la consulta SQL y la conexión asociada
                using (var command = new SqlCommand(query, connection))
                {
                    // Agregamos el parámetro correspondiente a la consulta SQL utilizando el Id recibido como parámetro
                    command.Parameters.AddWithValue("@Id", id);

                    // Ejecutamos la consulta SQL utilizando ExecuteReader() que retorna un objeto SqlDataReader que podemos utilizar para leer los datos devueltos por la consulta SQL
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Creamos un nuevo objeto ProductoVendido con la información obtenida del objeto SqlDataReader
                            return new Venta
                            {
                                Id = reader.GetInt64(0),
                                Comentarios = reader.GetString(1)
                            };
                        }
                        else
                        {
                            // Si no se encontró ningún registro, devolvemos null
                            return null;
                        }
                    }
                }
            }
        }

        // Método para obtener un listado de las Ventas.
        public List<Venta> ObtenerVentaListado()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Definimos la consulta SQL que vamos a ejecutar
                const string query = @"SELECT Id, Comentarios
                                   FROM Venta";
                // Creamos una nueva instancia de SqlCommand con la consulta SQL y la conexión asociada
                using (var command = new SqlCommand(query, connection))
                {
                    // Ejecutamos la consulta SQL utilizando ExecuteReader() que retorna un objeto SqlDataReader que podemos utilizar para leer los datos devueltos por la consulta SQL
                    using (var reader = command.ExecuteReader())
                    {
                        List<Venta> venta_list = new List<Venta> { };
                        while (reader.Read())
                        {
                            // Creamos un nuevo objeto Producto con la información obtenida del objeto SqlDataReader
                            Venta aux_venta = new Venta
                            {
                                Id = reader.GetInt64(0),
                                Comentarios = reader.GetString(1)
                            };

                            venta_list.Add(aux_venta);
                        }
                        return venta_list;
                    }
                }
            }
        }
    }
}
