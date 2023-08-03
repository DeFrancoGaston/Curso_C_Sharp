namespace Web_API.Models
{
    public class ProductoVendido
    {
        public long Id { get; set; }
        public int Stock { get; set; }
        public long IdProducto { get; set; }
        public long IdVenta { get; set; }

        public ProductoVendido()
        {
            this.Id = 0;
            this.IdProducto = 0;
            this.IdVenta = 0;
            this.Stock = 0;
        }

        public ProductoVendido(long id, long idProducto, long idVenta)
        {
            this.Id = id;
            this.IdProducto = idProducto;
            this.IdVenta = idVenta;
        }
    }
}
