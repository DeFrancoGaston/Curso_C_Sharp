namespace Web_API.Models
{
    public class Venta
    {
        public long Id { set; get; }
        public string Comentarios { set; get; }

        public Venta()
        {
            Id = 0;
            Comentarios = string.Empty;
        }

        public Venta(long id, string comentario)
        {
            Id = id;
            Comentarios = comentario;
        }
    }
}