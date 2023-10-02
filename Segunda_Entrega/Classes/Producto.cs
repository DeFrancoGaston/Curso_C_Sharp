namespace Segunda_Entrega.Classes
{
    public class Producto
    {
        public long Id { get; set; }
        public string Descripcion { get; set; }
        public decimal Costo { get; set; }
        public decimal PrecioVenta { get; set; }
        public int Stock { get; set; }
        public long IdUsuario { get; set; }

        public Producto()
        {
            this.Id = 0;
            this.Descripcion = string.Empty;
            this.Costo = 0;
            this.PrecioVenta = 0;
            this.Stock = 0;
            this.IdUsuario = 0;
        }

        public Producto(long id, string descripcion, decimal costo, decimal precioVenta, int stock, long idUsario)
        {
            this.Id = id;
            this.Descripcion = descripcion;
            this.Costo = costo;
            this.PrecioVenta = precioVenta;
            this.Stock = stock;
            this.IdUsuario = idUsario;
        }
    }
}
