//using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaGestionEntities;
using SistemaGestionBussiness;
using SistemaGestionEntities.Responses;

namespace WEB_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentaController : ControllerBase
    {
        [HttpGet("ListarVentas")]
        public ActionResult<IEnumerable<Venta>> GetListarVentas()
        {
            VentaResponse ventaResponse = VentaBussiness.ListarVentas();

            if (!(ventaResponse.Mensaje == "OK"))
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return Ok(ventaResponse.Ventas);
        }

        [HttpGet]
        public ActionResult<Venta> GetObtenerVenta([FromHeader] long id)
        {
            VentaResponse ventaResponse = VentaBussiness.ObtenerVenta(id);

            if (!(ventaResponse.Mensaje == "OK"))
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return Ok(ventaResponse.Venta);
        }

        [HttpPost]
        public ActionResult<long> PostCrearVenta([FromBody] Venta venta)
        {
            VentaResponse ventaResponse = VentaBussiness.CrearVenta(venta);

            if (!(ventaResponse.Mensaje == "OK"))
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return Ok(ventaResponse.Id);
        }

        [HttpDelete]
        public ActionResult<bool> DeleteEliminarVenta([FromHeader] long id)
        {
            VentaResponse ventaResponse = VentaBussiness.EliminarVenta(id);

            if (!(ventaResponse.Mensaje == "OK"))
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return Ok(true);
        }

        [HttpPut]
        public ActionResult<bool> PutModificarVenta([FromBody] Venta venta)
        {
            VentaResponse ventaResponse = VentaBussiness.ModificarVenta(venta);

            if (!(ventaResponse.Mensaje == "OK"))
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return Ok(true);
        }

        [HttpPost("CargarVenta")]
        public ActionResult<long> PostCargarVenta([FromHeader] long idusuario, [FromBody] List<ProductoVendido> listprodvendido)
        {
            VentaResponse ventaResponse = VentaBussiness.CargarVenta(idusuario, listprodvendido);

            if (!(ventaResponse.Mensaje == "OK"))
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return Ok(ventaResponse.Id);
        }

    }
}
