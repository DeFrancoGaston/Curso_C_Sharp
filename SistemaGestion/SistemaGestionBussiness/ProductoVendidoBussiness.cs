using SistemaGestionData;
using SistemaGestionEntities;

namespace SistemaGestionBussiness
{
    public static class ProductoVendidoBussiness
    {
        public static List<ProductoVendido> ListarProductoVendidos()
        {
            try
            {
                return ProductoVendidoData.ListarProductosVendidos();
            }
            catch (Exception e) { throw; }
        }

        public static long CrearProductoVendido(ProductoVendido productoVendido)
        {
            try
            {
                return ProductoVendidoData.CrearProductoVendido(productoVendido);
            }
            catch (Exception e) { throw; }
        }

        public static bool EliminarProductoVendido(long id)
        {
            try
            {
                return ProductoVendidoData.EliminarProductoVendido(id);
            }
            catch (Exception e) { throw; }
        }

        public static bool ModificarProductoVendido(ProductoVendido productoVendido)
        {
            try
            {
                return ProductoVendidoData.ModificarProductoVendido(productoVendido);
            }
            catch (Exception e) { throw; }
        }

        public static ProductoVendido ObtenerProductoVendido(long id)
        {
            try
            {
                return ProductoVendidoData.ObtenerProductoVendido(id);
            }
            catch (Exception e) { throw; }
        }

    }
}
