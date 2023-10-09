namespace SistemaGestionData
{
    using Microsoft.Data.SqlClient;
    using SistemaGestionEntities;

    public static class ProductoData
    {
        //Guardo la cadena de conexión
        static string connectionString = "data source=DESKTOP-9M2BSDE\\MSSQLSERVER01;initial catalog=SistemaGestion;Trusted_Connection=True;TrustServerCertificate=true";

        // Método para insertar un nuevo Producto en la Base de Datos
        // Recibe un objeto Producto con la información del producto a crear
        // Devuelve el Id asignado al nuevo registro
        public static long CrearProducto(Producto producto)
        {
            try
            {
                // Creamos una nueva conexión a la base de datos utilizando el string de conexión que se recibió en el constructor
                using (var connection = new SqlConnection(connectionString))
                {
                    // Abrimos la conexión
                    connection.Open();
                    long respuesta;

                    // Definimos la consulta SQL que vamos a ejecutar
                    const string query = @"INSERT INTO Producto (Descripciones, Costo, PrecioVenta, Stock, IdUsuario) 
                                   VALUES (@Descipcion, @Costo, @PrecioVenta, @Stock, @IdUsuario);
                                   SELECT Convert(bigint, @@IDENTITY);";
                    // Creamos una nueva instancia de SqlCommand con la consulta SQL y la conexión asociada
                    using (var command = new SqlCommand(query, connection))
                    {
                        // Agregamos los parámetros correspondientes a la consulta SQL utilizando el objeto producto recibido como parámetro
                        command.Parameters.AddWithValue("@Descipcion", producto.Descripcion);
                        command.Parameters.AddWithValue("@Costo", producto.Costo);
                        command.Parameters.AddWithValue("@PrecioVenta", producto.PrecioVenta);
                        command.Parameters.AddWithValue("@Stock", producto.Stock);
                        command.Parameters.AddWithValue("@IdUsuario", producto.IdUsuario);
                        respuesta = (long)command.ExecuteScalar();
                    }
                    // Ejecutamos la consulta SQL utilizando ExecuteScalar() que retorna el id generado para nuevo registro insertado
                    connection.Close();
                    return respuesta;
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.ToString());
                //return -1;
                throw;
            }
        }

        // Método para eliminar un producto de la Base de Datos según su Id
        // Recibe el Id del producto que se desea eliminar
        // Devuelve true si la eliminación fue exitosa, false si no
        public static bool EliminarProducto(long id)
        {
            bool respuesta;
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Definimos la consulta SQL que vamos a ejecutar
                    const string query = @"DELETE FROM Producto WHERE Id = @Id";
                    // Creamos una nueva instancia de SqlCommand con la consulta SQL y la conexión asociada
                    using (var command = new SqlCommand(query, connection))
                    {
                        // Agregamos el parámetro correspondiente a la consulta SQL utilizando el Id recibido como parámetro
                        command.Parameters.AddWithValue("@Id", id);

                        // Ejecutamos la consulta SQL utilizando ExecuteNonQuery() que retorna la cantidad de filas afectadas por la consulta SQL
                        // En este caso, debería ser 1 si se eliminó el producto correctamente, o 0 si no se encontró el producto con el Id correspondiente
                        respuesta = command.ExecuteNonQuery() > 0;
                        connection.Close();
                        return respuesta;
                    }

                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.ToString());
                //return false;
                throw;
            }
        }

        // Método para modificar un producto existente en la Base de Datos
        // Recibe un objeto Producto con la información actualizada del producto a modificar
        // Devuelve true si la modificación fue exitosa, false si no
        public static bool ModificarProducto(Producto producto)
        {
            bool respuesta;
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Definimos la consulta SQL que vamos a ejecutar
                    const string query = @"UPDATE Producto SET Descripciones = @Descripciones, Costo = @Costo, 
                                       PrecioVenta = @PrecioVenta, Stock = @Stock, IdUsuario = @IdUsuario 
                                       WHERE Id = @Id";
                    // Creamos una nueva instancia de SqlCommand con la consulta SQL y la conexión asociada
                    using (var command = new SqlCommand(query, connection))
                    {
                        // Agregamos los parámetros correspondientes a la consulta SQL utilizando el objeto Producto recibido como parámetro
                        command.Parameters.AddWithValue("@Descripciones", producto.Descripcion);
                        command.Parameters.AddWithValue("@Costo", producto.Costo);
                        command.Parameters.AddWithValue("@PrecioVenta", producto.PrecioVenta);
                        command.Parameters.AddWithValue("@Stock", producto.Stock);
                        command.Parameters.AddWithValue("@IdUsuario", producto.IdUsuario);
                        command.Parameters.AddWithValue("@Id", producto.Id);

                        // Ejecutamos la consulta SQL utilizando ExecuteNonQuery() que retorna la cantidad de filas afectadas por la consulta SQL
                        // En este caso, debería ser 1 si se modificó el producto correctamente, o 0 si no se encontró el producto con el Id correspondiente
                        respuesta = command.ExecuteNonQuery() > 0;
                        connection.Close();
                        return respuesta;
                    }
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.ToString());
                //return false;
                throw;

            }
        }

        // Método para obtener la información de un producto según su Id
        // Recibe el Id del producto que se desea obtener
        // Devuelve un objeto Producto con la información correspondiente, o null si no se encontró
        public static Producto ObtenerProducto(long id)
        {
            Producto producto = new Producto();

            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Definimos la consulta SQL que vamos a ejecutar
                    const string query = @"SELECT Id, Descripciones, Costo, PrecioVenta, Stock, IdUsuario 
                                       FROM Producto WHERE Id = @Id";
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
                                    // Creamos un nuevo objeto Producto con la información obtenida del objeto SqlDataReader
                                    producto.Id = reader.GetInt64(0);
                                    producto.Descripcion = reader.GetString(1);
                                    producto.Costo = reader.GetDecimal(2);
                                    producto.PrecioVenta = reader.GetDecimal(3);
                                    producto.Stock = reader.GetInt32(4);
                                    producto.IdUsuario = reader.GetInt64(5);
                                }
                            }
                        }
                    }
                    connection.Close();
                }
                return producto;
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.ToString());
                //return null;
                throw;

            }
        }

        public static List<Producto> ListarProductos()
        {
            List<Producto> lista = new List<Producto>();

            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Definimos la consulta SQL que vamos a ejecutar
                    const string query = @"SELECT Id, Descripciones, Costo, PrecioVenta, Stock, IdUsuario 
                                       FROM Producto";
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
                                    var producto = new Producto();
                                    producto.Id = reader.GetInt64(0);
                                    producto.Descripcion = reader.GetString(1);
                                    producto.Costo = reader.GetDecimal(2);
                                    producto.PrecioVenta = reader.GetDecimal(3);
                                    producto.Stock = reader.GetInt32(4);
                                    producto.IdUsuario = reader.GetInt64(5);
                                    
                                    //Agregamos el objeto producto al listado
                                    lista.Add(producto);
                                }
                            }
                        }
                    }
                    connection.Close();
                }
                return lista;
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.ToString());
                //return null;
                throw;
            }
        }
    }
}
