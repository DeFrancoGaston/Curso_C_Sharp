//using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web_API.Models;
using Web_API.DataServices;

namespace Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentaController : ControllerBase
    {
        [HttpGet]
        public ActionResult<Venta> GetVenta(int id)
        {
            if (id == 0) { return BadRequest(); }

            VentaDS ventaDS = new VentaDS();
            var venta = ventaDS.ObtenerVentaPorId(id);

            if (venta == null) { return NotFound(); }

            return Ok(venta);
        }

        [HttpGet("venta_list")]
        public ActionResult<Venta> GetVentaListado()
        {
            VentaDS ventaDS = new VentaDS();
            List<Venta> venta = ventaDS.ObtenerVentaListado();

            if (venta.Count() == 0) { return NotFound(); }

            return Ok(venta);
        }

        [HttpPost]
        public ActionResult<Venta> PostVenta([FromBody] Venta venta)
        {
            var ventaDS = new VentaDS();
            var venta_resp = ventaDS.CrearVenta(venta);
            return Ok(venta_resp);
        }

        [HttpPut]
        public IActionResult PutVenta([FromBody] Venta venta)
        {
            if (venta.Id == 0 || venta == null) { return BadRequest(); }

            var ventaDS = new VentaDS();
            var venta_resp = ventaDS.ModificarVenta(venta);

            if (!venta_resp)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return Ok();
        }

        [HttpDelete]
        public ActionResult<string> DeleteVenta(long id)
        {
            if (id == 0) { return BadRequest(); }

            var ventaDS = new VentaDS();
            var venta_resp = ventaDS.EliminarVenta(id);

            if (!venta_resp)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return Ok();
        }
    }
}
