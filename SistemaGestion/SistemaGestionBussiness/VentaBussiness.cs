using SistemaGestionData;
using SistemaGestionEntities;
using SistemaGestionEntities.Responses;

namespace SistemaGestionBussiness
{
    public static class VentaBussiness
    {
        public static VentaResponse ListarVentas()
        {
            return VentaData.ListarVentas();
        }

        public static VentaResponse CrearVenta(Venta venta)
        {
            return VentaData.CrearVenta(venta);
        }

        public static VentaResponse EliminarVenta(long id)
        {
            return VentaData.EliminarVenta(id);
        }

        public static VentaResponse ModificarVenta(Venta venta)
        {
            return VentaData.ModificarVenta(venta);
        }

        public static VentaResponse ObtenerVenta(long id)
        {
            return VentaData.ObtenerVenta(id);
        }

        public static VentaResponse CargarVenta(long idusuario, List<ProductoVendido> listproductosvendidos)
        {
            Venta venta = new Venta();
            VentaResponse ventaResponse = new VentaResponse();

            try
            {
                long idVenta;
                venta.IdUsuario = idusuario;
                venta.Comentarios = "Generadas desde el API";

                ventaResponse = VentaBussiness.CrearVenta(venta);
                if (!(ventaResponse.Mensaje == "OK"))
                {
                    return ventaResponse;
                }

                idVenta = ventaResponse.Id;

                foreach(ProductoVendido prodvendido in listproductosvendidos)
                {
                    prodvendido.IdVenta = idVenta;
                    ProductoVendidoResponse productoVendidoResponse = ProductoVendidoBussiness.CrearProductoVendido(prodvendido);

                    if (!(productoVendidoResponse.Mensaje == "OK"))
                    {
                        ventaResponse.Mensaje = productoVendidoResponse.Mensaje;
                        return ventaResponse;
                    }
                }

                ventaResponse.Id = idVenta;
                return ventaResponse;
            }
            catch (Exception ex)
            {
                ventaResponse.Mensaje = ex.Message;
                return ventaResponse;
            }
        }

    }
}
