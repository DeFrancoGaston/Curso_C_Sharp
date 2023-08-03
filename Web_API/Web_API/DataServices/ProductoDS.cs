namespace Web_API.DataServices
{
    using Microsoft.Data.SqlClient;
    using Web_API.Models;

    public class ProductoDS
    {
        private readonly string connectionString;

        // Constructor que recibe el string de conexión a la Base de Datos
        public ProductoDS(/*string connectionString*/)
        {
            Conexion cn = new Conexion();
            string connectionString = cn.cadenaSQL();

            this.connectionString = connectionString;
        }

        // Método para insertar un nuevo Producto en la Base de Datos
        // Recibe un objeto Producto con la información del producto a crear
        // Devuelve el Id asignado al nuevo registro
        public Producto CrearProducto(Producto producto)
        {
            // Creamos una nueva conexión a la base de datos utilizando el string de conexión que se recibió en el constructor
            using (var connection = new SqlConnection(connectionString))
            {
                // Abrimos la conexión
                connection.Open();

                // Definimos la consulta SQL que vamos a ejecutar
                const string query = @"INSERT INTO Producto (Descripciones, Costo, PrecioVenta, Stock, IdUsuario) 
                                   VALUES (@Descipcion, @Costo, @PrecioVenta, @Stock, @IdUsuario);
                                   SELECT SCOPE_IDENTITY();";
                // Creamos una nueva instancia de SqlCommand con la consulta SQL y la conexión asociada
                using (var command = new SqlCommand(query, connection))
                {
                    // Agregamos los parámetros correspondientes a la consulta SQL utilizando el objeto producto recibido como parámetro
                    command.Parameters.AddWithValue("@Descipciones", producto.Descripciones);
                    command.Parameters.AddWithValue("@Costo", producto.Costo);
                    command.Parameters.AddWithValue("@PrecioVenta", producto.PrecioVenta);
                    command.Parameters.AddWithValue("@Stock", producto.Stock);
                    command.Parameters.AddWithValue("@IdUsuario", producto.IdUsuario);

                    // Ejecutamos la consulta SQL utilizando ExecuteScalar() que retorna el id generado para nuevo registro insertado
                    var resp = command.ExecuteScalar();

                    producto.Id = (int)(decimal)resp;

                    return producto;
                }
            }
        }

        // Método para eliminar un producto de la Base de Datos según su Id
        // Recibe el Id del producto que se desea eliminar
        // Devuelve true si la eliminación fue exitosa, false si no
        public bool EliminarProducto(long id)
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
                    return command.ExecuteNonQuery() > 0;
                }
            }
        }

        // Método para modificar un producto existente en la Base de Datos
        // Recibe un objeto Producto con la información actualizada del producto a modificar
        // Devuelve true si la modificación fue exitosa, false si no
        public bool ModificarProducto(Producto producto)
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
                    command.Parameters.AddWithValue("@Descripciones", producto.Descripciones);
                    command.Parameters.AddWithValue("@Costo", producto.Costo);
                    command.Parameters.AddWithValue("@PrecioVenta", producto.PrecioVenta);
                    command.Parameters.AddWithValue("@Stock", producto.Stock);
                    command.Parameters.AddWithValue("@IdUsuario", producto.IdUsuario);
                    command.Parameters.AddWithValue("@Id", producto.Id);

                    // Ejecutamos la consulta SQL utilizando ExecuteNonQuery() que retorna la cantidad de filas afectadas por la consulta SQL
                    // En este caso, debería ser 1 si se modificó el producto correctamente, o 0 si no se encontró el producto con el Id correspondiente
                    return command.ExecuteNonQuery() > 0;
                }
            }
        }

        // Método para obtener la información de un producto según su Id
        // Recibe el Id del producto que se desea obtener
        // Devuelve un objeto Producto con la información correspondiente, o null si no se encontró
        public Producto ObtenerProductoPorId(long id)
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
                        if (reader.Read())
                        {
                            // Creamos un nuevo objeto Producto con la información obtenida del objeto SqlDataReader
                            return new Producto
                            {
                                Id = reader.GetInt64(0),
                                Descripciones = reader.GetString(1),
                                Costo = (float)reader.GetDecimal(2),
                                PrecioVenta = (float)reader.GetDecimal(3),
                                Stock = reader.GetInt32(4),
                                IdUsuario = reader.GetInt64(5)
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

        public List<Producto> ObtenerProductoListado()
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
                        List<Producto> prod_list = new List<Producto> { };
                        /*if (reader.HasRows)
                        {*/
                        while (reader.Read())
                            {
                                // Creamos un nuevo objeto Producto con la información obtenida del objeto SqlDataReader
                                Producto aux_prod = new Producto
                                {
                                    Id = reader.GetInt64(0),
                                    Descripciones = reader.GetString(1),
                                    Costo = (float)reader.GetDecimal(2),
                                    PrecioVenta = (float)reader.GetDecimal(3),
                                    Stock = reader.GetInt32(4),
                                    IdUsuario = reader.GetInt64(5)
                                };

                                prod_list.Add(aux_prod);
                            }
                        /*}
                        else
                        {
                            // Si no se encontró ningún registro, devolvemos null
                            return null;
                        }*/
                        return prod_list;
                    }
                }
            }
        }
    }
}
