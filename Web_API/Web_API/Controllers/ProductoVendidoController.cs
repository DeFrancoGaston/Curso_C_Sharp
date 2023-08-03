//using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web_API.Models;
using Web_API.DataServices;
using Microsoft.IdentityModel.Tokens;

namespace Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoVendidoController : ControllerBase
    {
        [HttpGet]
        public ActionResult<ProductoVendido> GetProductoVendido(int id)
        {
            if (id == 0) { return BadRequest(); }

            ProductoVendidoDS productovendidoDS = new ProductoVendidoDS();
            var productovendido = productovendidoDS.ObtenerProductoVendidoPorId(id);

            if (productovendido == null) { return NotFound(); }

            return Ok(productovendido);
        }

        [HttpGet("prod_venta")]
        public ActionResult<ProductoVendido> GetProductoVendidoListado(int id)
        {
            ProductoVendidoDS productovendidoDS = new ProductoVendidoDS();
            List<ProductoVendido> productovendido = productovendidoDS.ObtenerProductosPorIdVenta(id);

            if (productovendido.Count() == 0) { return NotFound(); }

            return Ok(productovendido);
        }

        [HttpPost]
        public ActionResult<ProductoVendido> PostProductoVendido([FromBody] ProductoVendido productovendido)
        {
            var productovendidoDS = new ProductoVendidoDS();
            var prod_resp = productovendidoDS.CrearProductoVendido(productovendido);
            return Ok(prod_resp);
        }

        [HttpPut]
        public IActionResult PutProductoVendido([FromBody] ProductoVendido productovendido)
        {
            if (productovendido.Id == 0 || productovendido == null) { return BadRequest(); }

            var productovendidoDS = new ProductoVendidoDS();
            var prod_resp = productovendidoDS.ModificarProductoVendido(productovendido);

            if (!prod_resp)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return Ok();
        }

        [HttpDelete]
        public ActionResult<string> DeleteProdcutoVendido(long id)
        {
            if (id == 0) { return BadRequest(); }

            var productovendidoDS = new ProductoVendidoDS();
            var prod_resp = productovendidoDS.EliminarProductoVendido(id);

            if (!prod_resp)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return Ok();
        }
    }
}
