//using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web_API.Models;
using Web_API.DataServices;
using Microsoft.IdentityModel.Tokens;

namespace Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        [HttpGet]
        public ActionResult<Producto> GetProducto(int id)
        {
            if (id == 0) { return BadRequest(); }

            ProductoDS productoDS = new ProductoDS();
            var producto = productoDS.ObtenerProductoPorId(id);

            if (producto == null) { return NotFound(); }

            return Ok(producto);
        }

        [HttpGet("prod_list")]
        public ActionResult<Producto> GetProductoListado()
        {
            ProductoDS productoDS = new ProductoDS();
            List<Producto> producto = productoDS.ObtenerProductoListado();

            if (producto.Count() == 0) { return NotFound(); }

            return Ok(producto);
        }

        [HttpPost]
        public ActionResult<Producto> PostProducto([FromBody] Producto producto)
        {
            var productoDS = new ProductoDS();
            var prod_resp = productoDS.CrearProducto(producto);
            return Ok(prod_resp);
        }

        [HttpPut]
        public IActionResult PutProducto([FromBody] Producto producto)
        {
            if (producto.Id == 0 || producto == null) { return BadRequest(); }

            var productoDS = new ProductoDS();
            var prod_resp = productoDS.ModificarProducto(producto);

            if (!prod_resp)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return Ok();
        }

        [HttpDelete]
        public ActionResult<string> DeleteProdcuto(long id)
        {
            if (id == 0) { return BadRequest(); }

            var productoDS = new ProductoDS();
            var prod_resp = productoDS.EliminarProducto(id);

            if (!prod_resp)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return Ok();
        }

    }
}
