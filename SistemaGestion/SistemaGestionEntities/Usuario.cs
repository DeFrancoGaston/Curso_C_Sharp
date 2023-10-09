namespace SistemaGestionEntities
{
    public class Usuario
    {
        public long Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string NombreUsuario { get; set; }
        public string Contraseña {get; set;}
        public string Mail { get; set; }

        public Usuario()
        {
            this.Id = 0;
            this.Nombre = string.Empty;
            this.Apellido = string.Empty;
            this.Contraseña = string.Empty;
            this.Mail = string.Empty;
            this.NombreUsuario = string.Empty;
        }
        public Usuario(string nombreUsuario)
        {
            this.NombreUsuario = nombreUsuario;
            this.Nombre = string.Empty;
            this.Apellido = string.Empty;
            this.Contraseña = string.Empty;
            this.Mail = string.Empty;
        }
        public Usuario(int id, string nombre, string apellido, string nombreUsuario, string contraseña, string mail)
        {
            this.Id = id;
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.NombreUsuario = nombreUsuario;
            this.Contraseña = contraseña;
            this.Mail = mail;
        }
    }
}
