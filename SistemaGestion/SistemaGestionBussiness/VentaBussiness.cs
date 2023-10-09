using SistemaGestionData;
using SistemaGestionEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionBussiness
{
    public static class VentaBussiness
    {
        public static List<Venta> ListarVentas()
        {
            try
            {
                return VentaData.ListarVentas();
            }
            catch (Exception e) { throw;}
        }

        public static long CrearVenta(Venta venta)
        {
            try
            {
                return VentaData.CrearVenta(venta);
            }
            catch (Exception e) { throw; }
        }

        public static bool EliminarVenta(long id)
        {
            try
            {
                return VentaData.EliminarVenta(id);
            }
            catch (Exception e) { throw; }
        }

        public static bool ModificarVenta(Venta venta)
        {
            try
            {
                return VentaData.ModificarVenta(venta);
            }
            catch (Exception e) { throw; }
        }

        public static Venta ObtenerVenta(long id)
        {
            try
            {
                return VentaData.ObtenerVenta(id);
            }
            catch (Exception e) { throw; }
        }
    }
}
