namespace Web_API.DataServices
{
    using Microsoft.Data.SqlClient;
    using Web_API.Models;

    public class ProductoVendidoDS
    {
        private readonly string connectionString;

        // Constructor que recibe el string de conexión a la Base de Datos
        public ProductoVendidoDS(/*string connectionString*/)
        {
            Conexion cn = new Conexion();
            string connectionString = cn.cadenaSQL();

            this.connectionString = connectionString;
        }

        // Método para insertar un nuevo ProductoVendido en la Base de Datos
        public ProductoVendido CrearProductoVendido(ProductoVendido productovendido)
        {
            // Creamos una nueva conexión a la base de datos utilizando el string de conexión que se recibió en el constructor
            using (var connection = new SqlConnection(connectionString))
            {
                // Abrimos la conexión
                connection.Open();

                // Definimos la consulta SQL que vamos a ejecutar
                const string query = @"INSERT INTO ProductoVendido (Stock,IdProducto,IdVenta) 
                                   VALUES (@Stock, @IdProducto, @IdVenta);
                                   SELECT SCOPE_IDENTITY();";
                // Creamos una nueva instancia de SqlCommand con la consulta SQL y la conexión asociada
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Stock", productovendido.Stock);
                    command.Parameters.AddWithValue("@IdProducto", productovendido.IdProducto);
                    command.Parameters.AddWithValue("@IdVenta", productovendido.IdVenta);

                    // Ejecutamos la consulta SQL utilizando ExecuteScalar() que retorna el id generado para nuevo registro insertado
                    var resp = command.ExecuteScalar();

                    productovendido.Id = (int)(decimal)resp;

                    return productovendido;
                }
            }
        }

        // Método para eliminar un ProductoVendido de la Base de Datos según su Id
        public bool EliminarProductoVendido(long id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Definimos la consulta SQL que vamos a ejecutar
                const string query = @"DELETE FROM ProductoVendido WHERE Id = @Id";
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

        // Método para modificar un ProductoVendido existente en la Base de Datos
        public bool ModificarProductoVendido(ProductoVendido productoVendido)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Definimos la consulta SQL que vamos a ejecutar
                const string query = @"UPDATE ProductoVendido SET Stock = @Stock, IdProducto = @IdProducto, 
                                   IdVenta = @IdVenta 
                                   WHERE Id = @Id";
                // Creamos una nueva instancia de SqlCommand con la consulta SQL y la conexión asociada
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Stock", productoVendido.Stock);
                    command.Parameters.AddWithValue("@IdProducto", productoVendido.IdProducto);
                    command.Parameters.AddWithValue("@IdVenta", productoVendido.IdVenta);
                    command.Parameters.AddWithValue("@Id", productoVendido.Id);

                    // Ejecutamos la consulta SQL utilizando ExecuteNonQuery() que retorna la cantidad de filas afectadas por la consulta SQL
                    // En este caso, debería ser 1 si se modificó el usuario correctamente, o 0 si no se encontró el usuario con el Id correspondiente
                    return command.ExecuteNonQuery() > 0;
                }
            }
        }

        // Método para obtener la información de un ProductoVendido según su Id
        public ProductoVendido ObtenerProductoVendidoPorId(long id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Definimos la consulta SQL que vamos a ejecutar
                const string query = @"SELECT Id, Stock, IdProducto, IdVenta 
                                   FROM ProductoVendido WHERE Id = @Id";
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
                            return new ProductoVendido
                            {
                                Id = reader.GetInt64(0),
                                Stock = reader.GetInt32(1),
                                IdProducto = reader.GetInt64(2),
                                IdVenta = reader.GetInt64(3)
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
        // Método para obtener el listado de productos vendidos en una Venta.
        public List<ProductoVendido> ObtenerProductosPorIdVenta(long idVenta)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Definimos la consulta SQL que vamos a ejecutar
                const string query = @"SELECT Id, Stock, IdProducto, IdVenta 
                                   FROM ProductoVendido WHERE IdVenta = @IdVenta";
                // Creamos una nueva instancia de SqlCommand con la consulta SQL y la conexión asociada
                using (var command = new SqlCommand(query, connection))
                {
                    // Agregamos el parámetro correspondiente a la consulta SQL utilizando el IdVenta recibido como parámetro
                    command.Parameters.AddWithValue("@IdVenta", idVenta);

                    // Ejecutamos la consulta SQL utilizando ExecuteReader() que retorna un objeto SqlDataReader que podemos utilizar para leer los datos devueltos por la consulta SQL
                    using (var reader = command.ExecuteReader())
                    {

                        List<ProductoVendido> listado = new List<ProductoVendido>();
                        //Recorro el set de registros y los voy volcando a una Lista de Obetos.
                        while (reader.Read())
                        {
                            ProductoVendido productoVendido = new ProductoVendido();
                            productoVendido.Id = reader.GetInt64(0);
                            productoVendido.Stock = reader.GetInt32(1);
                            productoVendido.IdProducto = reader.GetInt64(2);
                            productoVendido.IdVenta = reader.GetInt64(3);
                            listado.Add(productoVendido);
                        }

                        if (listado.Count >= 0)
                        {
                            return listado;
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
    }
}
