namespace SistemaGestionData
{
    using Microsoft.Data.SqlClient;
    using SistemaGestionEntities;
    using SistemaGestionEntities.Responses;

    public static class ProductoVendidoData
    {
        //Guardo la cadena de conexión
        static string connectionString = "data source=DESKTOP-9M2BSDE\\MSSQLSERVER01;initial catalog=SistemaGestion;Trusted_Connection=True;TrustServerCertificate=true";

        // Método para insertar un nuevo ProductoVendido en la Base de Datos
        public static ProductoVendidoResponse CrearProductoVendido(ProductoVendido productoVendido)
        {
            ProductoVendidoResponse productoVendidoResponse = new ProductoVendidoResponse();
            try
            {
                // Creamos una nueva conexión a la base de datos utilizando el string de conexión que se recibió en el constructor
                using (var connection = new SqlConnection(connectionString))
                {
                    // Abrimos la conexión
                    connection.Open();
                    long respuesta;

                    // Definimos la consulta SQL que vamos a ejecutar
                    const string query = @"INSERT INTO ProductoVendido (Stock,IdProducto,IdVenta) 
                                       VALUES (@Stock, @IdProducto, @IdVenta);
                                       SELECT Convert(bigint, @@IDENTITY);";
                    // Creamos una nueva instancia de SqlCommand con la consulta SQL y la conexión asociada
                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Stock", productoVendido.Stock);
                        command.Parameters.AddWithValue("@IdProducto", productoVendido.IdProducto);
                        command.Parameters.AddWithValue("@IdVenta", productoVendido.IdVenta);

                        // Ejecutamos la consulta SQL utilizando ExecuteScalar() que retorna el id generado para nuevo registro insertado
                        respuesta = (long)command.ExecuteScalar();
                    }
                    connection.Close();
                    productoVendidoResponse.Mensaje = "OK";
                    productoVendidoResponse.Id = respuesta;
                }
                return productoVendidoResponse;
            }
            catch (Exception ex)
            {
                productoVendidoResponse.Mensaje = ex.Message;
                return productoVendidoResponse;
            }
        }

        // Método para eliminar un ProductoVendido de la Base de Datos según su Id
        public static ProductoVendidoResponse EliminarProductoVendido(long id)
        {
            ProductoVendidoResponse productoVendidoResponse = new ProductoVendidoResponse();

            try
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
                        if (command.ExecuteNonQuery() > 0)
                        {
                            productoVendidoResponse.Mensaje = "OK";
                        }
                        else
                        {
                            productoVendidoResponse.Mensaje = "ERROR";
                        };
                        connection.Close();
                        return productoVendidoResponse;
                    }
                }
            }
            catch (Exception ex)
            {
                productoVendidoResponse.Mensaje = ex.Message;
                return productoVendidoResponse;
            }
        }

        // Método para modificar un ProductoVendido existente en la Base de Datos
        public static ProductoVendidoResponse ModificarProductoVendido(ProductoVendido productoVendido)
        {
            ProductoVendidoResponse productoVendidoResponse = new ProductoVendidoResponse();

            try
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
                        if (command.ExecuteNonQuery() > 0)
                        {
                            productoVendidoResponse.Mensaje = "OK";
                        }
                        else
                        {
                            productoVendidoResponse.Mensaje = "ERROR";
                        };
                        connection.Close();
                        return productoVendidoResponse;
                    }
                }
            }
            catch (Exception ex)
            {
                productoVendidoResponse.Mensaje = ex.Message;
                return productoVendidoResponse;
            }
        }

        // Método para obtener la información de un ProductoVendido según su Id
        public static ProductoVendidoResponse ObtenerProductoVendido(long id)
        {
            ProductoVendido productoVendido = new ProductoVendido();
            ProductoVendidoResponse productoVendidoResponse = new ProductoVendidoResponse();

            try
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
                                productoVendido.Id = reader.GetInt64(0);
                                productoVendido.Stock = reader.GetInt32(1);
                                productoVendido.IdProducto = reader.GetInt64(2);
                                productoVendido.IdVenta = reader.GetInt64(3);
                            }
                        }
                    }
                    connection.Close();
                    productoVendidoResponse.Mensaje = "OK";
                    productoVendidoResponse.ProductoVendido = productoVendido;
                }
                return productoVendidoResponse;
            }
            catch (Exception ex)
            {
                productoVendidoResponse.Mensaje = ex.Message;
                return productoVendidoResponse;
            }
        }

        // Método para obtener el listado de productos vendidos en una Venta.
        public static ProductoVendidoResponse ObtenerProductosVentaPorId(long idVenta)
        {
            ProductoVendidoResponse productoVendidoResponse = new ProductoVendidoResponse();
            List<ProductoVendido> lista = new List<ProductoVendido>();

            try
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
                            //Recorro el set de registros y los voy volcando a una Lista de Obetos.
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    ProductoVendido productoVendido = new ProductoVendido();
                                    productoVendido.Id = reader.GetInt64(0);
                                    productoVendido.Stock = reader.GetInt16(1);
                                    productoVendido.IdProducto = reader.GetInt64(2);
                                    productoVendido.IdVenta = reader.GetInt64(3);
                                    lista.Add(productoVendido);
                                }
                            }
                        }
                    }
                    connection.Close();
                }
                productoVendidoResponse.Mensaje = "OK";
                productoVendidoResponse.ProductosVendidos = lista;
                return productoVendidoResponse;
            }
            catch (Exception ex)
            {
                productoVendidoResponse.Mensaje = ex.Message;
                return productoVendidoResponse;
            }
        }

        // Método para obtener el listado de productos vendidos.
        public static ProductoVendidoResponse ListarProductosVendidos()
        {
            ProductoVendidoResponse productoVendidoResponse = new ProductoVendidoResponse();
            List<ProductoVendido> lista = new List<ProductoVendido>();

            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Definimos la consulta SQL que vamos a ejecutar
                    const string query = @"SELECT Id, Stock, IdProducto, IdVenta 
                                       FROM ProductoVendido";
                    // Creamos una nueva instancia de SqlCommand con la consulta SQL y la conexión asociada
                    using (var command = new SqlCommand(query, connection))
                    {
                        // Ejecutamos la consulta SQL utilizando ExecuteReader() que retorna un objeto SqlDataReader que podemos utilizar para leer los datos devueltos por la consulta SQL
                        using (var reader = command.ExecuteReader())
                        {
                            //Recorro el set de registros y los voy volcando a una Lista de Obetos.
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    ProductoVendido productoVendido = new ProductoVendido();
                                    productoVendido.Id = reader.GetInt64(0);
                                    productoVendido.Stock = reader.GetInt32(1);
                                    productoVendido.IdProducto = reader.GetInt64(2);
                                    productoVendido.IdVenta = reader.GetInt64(3);
                                    lista.Add(productoVendido);
                                }
                            }
                        }
                    }
                    connection.Close();
                }
                productoVendidoResponse.Mensaje = "OK";
                productoVendidoResponse.ProductosVendidos = lista;
                return productoVendidoResponse;
            }
            catch (Exception ex)
            {
                productoVendidoResponse.Mensaje = ex.Message;
                return productoVendidoResponse;
            }
        }
    }
}