using SistemaGestionData;
using SistemaGestionEntities;

namespace SistemaGestionBussiness
{
    public static class ProductoBussiness
    {
        public static List<Producto> ListarProductos()
        {
            try
            {
                return ProductoData.ListarProductos();
            }
            catch (Exception e) { throw; }
        }

        public static long CrearProducto(Producto producto)
        {
            try
            {
                return ProductoData.CrearProducto(producto);
            }
            catch (Exception e) { throw; }
        }

        public static bool EliminarProducto(long id)
        {
            try
            {
                return ProductoData.EliminarProducto(id);
            }
            catch (Exception e) { throw; }
        }

        public static bool ModificarProducto(Producto producto)
        {
            try
            {
                return ProductoData.ModificarProducto(producto);
            }
            catch (Exception e) { throw; }
        }

        public static Producto ObtenerProducto(long id)
        {
            try
            {
                return ProductoData.ObtenerProducto(id);
            }
            catch (Exception e) { throw; }
        }
    }
}
