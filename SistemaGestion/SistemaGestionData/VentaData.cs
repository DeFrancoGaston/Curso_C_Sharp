namespace SistemaGestionData
{
    using Microsoft.Data.SqlClient;
    using SistemaGestionEntities;
    using SistemaGestionEntities.Responses;

    public static class VentaData
    {
        //Guardo la cadena de conexión
        static string connectionString = "data source=DESKTOP-9M2BSDE\\MSSQLSERVER01;initial catalog=SistemaGestion;Trusted_Connection=True;TrustServerCertificate=true";

        // Método para insertar una nueva Venta en la Base de Datos
        public static VentaResponse CrearVenta(Venta venta)
        {
            VentaResponse ventaResponse = new VentaResponse();

            try
            {
                // Creamos una nueva conexión a la base de datos utilizando el string de conexión que se recibió en el constructor
                using (var connection = new SqlConnection(connectionString))
                {
                    // Abrimos la conexión
                    connection.Open();
                    long respuesta;

                    // Definimos la consulta SQL que vamos a ejecutar
                    const string query = @"INSERT INTO Venta (Comentarios, IdUsuario) 
                                       VALUES (@Comentarios, @IdUsuario);
                                       SELECT Convert(bigint, @@IDENTITY);";
                    // Creamos una nueva instancia de SqlCommand con la consulta SQL y la conexión asociada
                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Comentarios", venta.Comentarios);
                        command.Parameters.AddWithValue("@IdUsuario", venta.IdUsuario);

                        // Ejecutamos la consulta SQL utilizando ExecuteScalar() que retorna el id generado para nuevo registro insertado
                        respuesta = (long)command.ExecuteScalar();
                    }
                    connection.Close();
                    ventaResponse.Mensaje = "OK";
                    ventaResponse.Id = respuesta;
                }
                return ventaResponse;
            }
            catch (Exception ex)
            {
                ventaResponse.Mensaje = ex.Message;
                return ventaResponse;
            }
        }

        // Método para eliminar una Venta de la Base de Datos según su Id
        public static VentaResponse EliminarVenta(long id)
        {
            VentaResponse ventaResponse = new VentaResponse();

            try
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
                        if (command.ExecuteNonQuery() > 0)
                        {
                            ventaResponse.Mensaje = "OK";
                        }
                        else
                        {
                            ventaResponse.Mensaje = "ERROR";
                        };
                        connection.Close();
                        return ventaResponse;
                    }
                }
            }
            catch (Exception ex)
            {
                ventaResponse.Mensaje = ex.Message;
                return ventaResponse;
            }
        }

        // Método para modificar un ProductoVendido existente en la Base de Datos
        public static VentaResponse ModificarVenta(Venta venta)
        {
            VentaResponse ventaResponse = new VentaResponse();

            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Definimos la consulta SQL que vamos a ejecutar
                    const string query = @"UPDATE Venta SET Comentarios = @Comentarios, IdUsuario = @IdUsuario 
                                       WHERE Id = @Id";
                    // Creamos una nueva instancia de SqlCommand con la consulta SQL y la conexión asociada
                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Comentarios", venta.Comentarios);
                        command.Parameters.AddWithValue("@IdUsuario", venta.IdUsuario);
                        command.Parameters.AddWithValue("@Id", venta.Id);

                        // Ejecutamos la consulta SQL utilizando ExecuteNonQuery() que retorna la cantidad de filas afectadas por la consulta SQL
                        if (command.ExecuteNonQuery() > 0)
                        {
                            ventaResponse.Mensaje = "OK";
                        }
                        else
                        {
                            ventaResponse.Mensaje = "ERROR";
                        };
                        connection.Close();
                        return ventaResponse;
                    }
                }
            }
            catch (Exception ex)
            {
                ventaResponse.Mensaje = ex.Message;
                return ventaResponse;
            }
        }

        // Método para obtener la información de un ProductoVendido según su Id
        public static VentaResponse ObtenerVenta(long id)
        {
            VentaResponse ventaResponse = new VentaResponse();
            Venta respuesta = new Venta();

            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Definimos la consulta SQL que vamos a ejecutar
                    const string query = @"SELECT Id, Comentarios, IdUsuario 
                                       FROM Venta WHERE Id = @Id";
                    // Creamos una nueva instancia de SqlCommand con la consulta SQL y la conexión asociada
                    using (var command = new SqlCommand(query, connection))
                    {
                        // Agregamos el parámetro correspondiente a la consulta SQL utilizando el Id recibido como parámetro
                        command.Parameters.AddWithValue("@Id", id);

                        // Ejecutamos la consulta SQL utilizando ExecuteReader() que retorna un objeto SqlDataReader que podemos utilizar para leer los datos devueltos por la consulta SQL
                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                if (reader.Read())
                                {
                                    // Creamos un nuevo objeto ProductoVendido con la información obtenida del objeto SqlDataReader
                                    respuesta.Id = reader.GetInt64(0);
                                    respuesta.Comentarios = reader.GetString(1);
                                    respuesta.IdUsuario = reader.GetInt64(2);
                                }
                            }
                        }
                    }
                    connection.Close();
                    ventaResponse.Mensaje = "OK";
                    ventaResponse.Venta = respuesta;
                }
                return ventaResponse;
            }
            catch (Exception ex)
            {
                ventaResponse.Mensaje = ex.Message;
                return ventaResponse;
            }
        }

        public static VentaResponse ListarVentas()
        {
            VentaResponse ventaResponse = new VentaResponse();
            List<Venta> lista = new List<Venta>();

            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Definimos la consulta SQL que vamos a ejecutar
                    const string query = @"SELECT Id, Comentarios, IdUsuario 
                                       FROM Venta";
                    // Creamos una nueva instancia de SqlCommand con la consulta SQL y la conexión asociada
                    using (var command = new SqlCommand(query, connection))
                    {
                        // Ejecutamos la consulta SQL utilizando ExecuteReader() que retorna un objeto SqlDataReader que podemos utilizar para leer los datos devueltos por la consulta SQL
                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    // Creamos un nuevo objeto Producto con la información obtenida del objeto SqlDataReader
                                    var venta = new Venta();
                                    venta.Id = reader.GetInt64(0);
                                    venta.Comentarios = reader.GetString(1);
                                    venta.IdUsuario = reader.GetInt64(2);

                                    //Agregamos el objeto producto al listado
                                    lista.Add(venta);
                                }
                            }
                        }
                    }
                    connection.Close();
                }
                ventaResponse.Mensaje = "OK";
                ventaResponse.Ventas = lista;
                return ventaResponse;
            }
            catch (Exception ex)
            {
                ventaResponse.Mensaje = ex.Message;
                return ventaResponse;
            }
        }
    }
}
