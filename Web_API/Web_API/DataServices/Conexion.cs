namespace Web_API.DataServices
{
    public class Conexion
    {
        private string connectionString = string.Empty;

        public Conexion() {
            var constructor = new ConfigurationBuilder().SetBasePath(
                Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

            connectionString = constructor.GetSection("ConnectionStrings:conexionBD").Value;
        }

        public string cadenaSQL()
        { return connectionString; }
    }
}
