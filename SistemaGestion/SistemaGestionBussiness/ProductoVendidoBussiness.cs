using SistemaGestionData;
using SistemaGestionEntities;
using SistemaGestionEntities.Responses;

namespace SistemaGestionBussiness
{
    public static class ProductoVendidoBussiness
    {
        public static ProductoVendidoResponse ListarProductoVendidos()
        {
            return ProductoVendidoData.ListarProductosVendidos();
        }

        public static ProductoVendidoResponse CrearProductoVendido(ProductoVendido productoVendido)
        {
            ProductoResponse productoResponse = new ProductoResponse();
            ProductoVendidoResponse productoVendidoResponse = new ProductoVendidoResponse();
            try
            {
                productoResponse = ProductoBussiness.ObtenerProducto(productoVendido.IdProducto);

                if (!(productoResponse.Mensaje == "OK"))
                {
                    productoVendidoResponse.Mensaje = productoVendidoResponse.Mensaje;
                    return productoVendidoResponse;
                }

                if (productoResponse.Producto.Stock < productoVendido.Stock)
                {
                    productoVendidoResponse.Mensaje = "Stock insuficiente.";
                    return productoVendidoResponse;
                }

                productoResponse.Producto.Stock -= productoVendido.Stock;

                productoResponse = ProductoBussiness.ModificarProducto(productoResponse.Producto);

                if (!(productoResponse.Mensaje == "OK"))
                {
                    productoVendidoResponse.Mensaje = productoVendidoResponse.Mensaje;
                    return productoVendidoResponse;
                }

                //productoVendidoResponse = ProductoVendidoData.CrearProductoVendido(productoVendido);
                return ProductoVendidoData.CrearProductoVendido(productoVendido);
            }
            catch (Exception ex)
            {
                productoVendidoResponse.Mensaje = ex.Message;
                return productoVendidoResponse;
            }
        }

        public static ProductoVendidoResponse EliminarProductoVendido(long id)
        {
            return ProductoVendidoData.EliminarProductoVendido(id);
        }

        public static ProductoVendidoResponse ModificarProductoVendido(ProductoVendido productoVendido)
        {
            return ProductoVendidoData.ModificarProductoVendido(productoVendido);
        }

        public static ProductoVendidoResponse ObtenerProductoVendido(long id)
        {
            return ProductoVendidoData.ObtenerProductoVendido(id);
        }

    }
}
