namespace Segunda_Entrega.DataServices
{
    using Microsoft.Data.SqlClient;
    using Segunda_Entrega.Classes;

    public static class UsuarioData
    {
        //Guardo la cadena de conexión
        static string connectionString = "data source=DESKTOP-9M2BSDE\\MSSQLSERVER01;initial catalog=SistemaGestion;Trusted_Connection=True;TrustServerCertificate=true";

        // Método para insertar un nuevo usuario en la Base de Datos
        // Recibe un objeto Usuario con la información del usuario a crear
        // Devuelve el Id asignado al nuevo registro
        public static long CrearUsuario(Usuario usuario)
        {
            long respuesta;

            try
            {
                // Creamos una nueva conexión a la base de datos utilizando el string de conexión que se recibió en el constructor
                using (var connection = new SqlConnection(connectionString))
                {
                    // Abrimos la conexión
                    connection.Open();

                    // Definimos la consulta SQL que vamos a ejecutar
                    const string query = @"INSERT INTO Usuario (Nombre, Apellido, NombreUsuario, Contraseña, Mail) 
                                       VALUES (@Nombre, @Apellido, @NombreUsuario, @Contraseña, @Mail);
                                       SELECT Convert(bigint, @@IDENTITY);";
                    // Creamos una nueva instancia de SqlCommand con la consulta SQL y la conexión asociada
                    using (var command = new SqlCommand(query, connection))
                    {
                        // Agregamos los parámetros correspondientes a la consulta SQL utilizando el objeto Usuario recibido como parámetro
                        command.Parameters.AddWithValue("@Nombre", usuario.Nombre);
                        command.Parameters.AddWithValue("@Apellido", usuario.Apellido);
                        command.Parameters.AddWithValue("@NombreUsuario", usuario.NombreUsuario);
                        command.Parameters.AddWithValue("@Contraseña", usuario.Contraseña);
                        command.Parameters.AddWithValue("@Mail", usuario.Mail);

                        // Ejecutamos la consulta SQL utilizando ExecuteScalar() que retorna el id generado para nuevo registro insertado
                        respuesta = (long)(command.ExecuteScalar());
                    }
                    connection.Close();
                    return respuesta;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return -1;
            }
        }

        // Método para eliminar un usuario de la Base de Datos según su Id
        // Recibe el Id del usuario que se desea eliminar
        // Devuelve true si la eliminación fue exitosa, false si no
        public static bool EliminarUsuario(long id)
        {
            bool respuesta;

            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Definimos la consulta SQL que vamos a ejecutar
                    const string query = @"DELETE FROM Usuario WHERE Id = @Id";
                    // Creamos una nueva instancia de SqlCommand con la consulta SQL y la conexión asociada
                    using (var command = new SqlCommand(query, connection))
                    {
                        // Agregamos el parámetro correspondiente a la consulta SQL utilizando el Id recibido como parámetro
                        command.Parameters.AddWithValue("@Id", id);

                        // Ejecutamos la consulta SQL utilizando ExecuteNonQuery() que retorna la cantidad de filas afectadas por la consulta SQL
                        // En este caso, debería ser 1 si se eliminó el usuario correctamente, o 0 si no se encontró el usuario con el Id correspondiente
                        respuesta = command.ExecuteNonQuery() > 0;
                    }
                    connection.Close();
                    return respuesta;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }

        // Método para modificar un usuario existente en la Base de Datos
        // Recibe un objeto Usuario con la información actualizada del usuario a modificar
        // Devuelve true si la modificación fue exitosa, false si no
        public static bool ModificarUsuario(Usuario usuario)
        {
            bool respuesta;

            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Definimos la consulta SQL que vamos a ejecutar
                    const string query = @"UPDATE Usuario SET Nombre = @Nombre, Apellido = @Apellido, 
                                       NombreUsuario = @NombreUsuario, Contraseña = @Contraseña, Mail = @Mail 
                                       WHERE Id = @Id";
                    // Creamos una nueva instancia de SqlCommand con la consulta SQL y la conexión asociada
                    using (var command = new SqlCommand(query, connection))
                    {
                        // Agregamos los parámetros correspondientes a la consulta SQL utilizando el objeto Usuario recibido como parámetro
                        command.Parameters.AddWithValue("@Nombre", usuario.Nombre);
                        command.Parameters.AddWithValue("@Apellido", usuario.Apellido);
                        command.Parameters.AddWithValue("@NombreUsuario", usuario.NombreUsuario);
                        command.Parameters.AddWithValue("@Contraseña", usuario.Contraseña);
                        command.Parameters.AddWithValue("@Mail", usuario.Mail);
                        command.Parameters.AddWithValue("@Id", usuario.Id);

                        // Ejecutamos la consulta SQL utilizando ExecuteNonQuery() que retorna la cantidad de filas afectadas por la consulta SQL
                        // En este caso, debería ser 1 si se modificó el usuario correctamente, o 0 si no se encontró el usuario con el Id correspondiente
                        respuesta = command.ExecuteNonQuery() > 0;
                    }
                    connection.Close();
                    return respuesta;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }

        // Método para obtener la información de un usuario según su Id
        // Recibe el Id del usuario que se desea obtener
        // Devuelve un objeto Usuario con la información correspondiente, o null si no se encontró
        public static Usuario ObtenerUsuario(long id)
        {
            Usuario usuario = new Usuario();

            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Definimos la consulta SQL que vamos a ejecutar
                    const string query = @"SELECT Id, Nombre, Apellido, NombreUsuario, Contraseña, Mail 
                                       FROM Usuario WHERE Id = @Id";
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
                                    // Creamos un nuevo objeto Usuario con la información obtenida del objeto SqlDataReader
                                    usuario.Id = reader.GetInt64(0);
                                    usuario.Nombre = reader.GetString(1);
                                    usuario.Apellido = reader.GetString(2);
                                    usuario.NombreUsuario = reader.GetString(3);
                                    usuario.Contraseña = reader.GetString(4);
                                    usuario.Mail = reader.GetString(5);
                                }
                            }
                        }
                    }
                    connection.Close();
                    return usuario;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return null;
            }
        }
        /*******************************************************************************************/
        public static List<Usuario> ListarUsuarios()
        {
            List<Usuario> lista = new List<Usuario>();

            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Definimos la consulta SQL que vamos a ejecutar
                    const string query = @"SELECT Id, Nombre, Apellido, NombreUsuario, Contraseña, Mail 
                                       FROM Usuario";
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
                                    var usuario = new Usuario();
                                    usuario.Id = reader.GetInt64(0);
                                    usuario.Nombre = reader.GetString(1);
                                    usuario.Apellido = reader.GetString(2);
                                    usuario.NombreUsuario = reader.GetString(3);
                                    usuario.Contraseña = reader.GetString(4);
                                    usuario.Mail = reader.GetString(5);

                                    //Agregamos el objeto producto al listado
                                    lista.Add(usuario);
                                }
                            }
                        }
                    }
                    connection.Close();
                    return lista;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return null;
            }
        }
    }
}
