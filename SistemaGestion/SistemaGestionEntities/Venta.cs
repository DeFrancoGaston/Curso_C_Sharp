namespace SistemaGestionEntities
{
    public class Venta
    {
        public long Id { get; set; }
        public String Comentarios { get; set; }
        public long IdUsuario { get; set; }

        public Venta()
        {
            this.Id = 0;
            this.Comentarios = string.Empty;
            this.IdUsuario = 0;
        }
        public Venta(long id, string comentarios, long idUsuario)
        {
            this.Id = id;
            this.Comentarios = comentarios;
            this.IdUsuario = idUsuario;
        }
    }
}