using SistemaGestionData;
using SistemaGestionEntities;
using SistemaGestionEntities.Responses;

namespace SistemaGestionBussiness
{
    public static class ProductoBussiness
    {
        public static ProductoResponse ListarProductos()
        {
            return ProductoData.ListarProductos();
        }

        public static ProductoResponse CrearProducto(Producto producto)
        {
            return ProductoData.CrearProducto(producto);
        }

        public static ProductoResponse EliminarProducto(long id)
        {
            return ProductoData.EliminarProducto(id);
        }

        public static ProductoResponse ModificarProducto(Producto producto)
        {
            return ProductoData.ModificarProducto(producto);
        }

        public static ProductoResponse ObtenerProducto(long id)
        {
            return ProductoData.ObtenerProducto(id);
        }
    }
}
