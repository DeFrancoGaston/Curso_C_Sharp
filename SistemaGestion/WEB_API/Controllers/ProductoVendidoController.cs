using Microsoft.AspNetCore.Mvc;
using SistemaGestionBussiness;
using SistemaGestionEntities;
using SistemaGestionEntities.Responses;

namespace WEB_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoVendidoController : ControllerBase
    {
        [HttpGet("ListarProductoVendidos")]
        public ActionResult<IEnumerable<ProductoVendido>> GetListarProductoVendidos()
        {
            ProductoVendidoResponse productoVendidoResponse = ProductoVendidoBussiness.ListarProductoVendidos();

            if (!(productoVendidoResponse.Mensaje == "OK"))
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return Ok(productoVendidoResponse.ProductosVendidos);
        }

        [HttpGet]
        public ActionResult<ProductoVendido> GetObtenerProductoVendido([FromHeader] long id)
        {
            ProductoVendidoResponse productoVendidoResponse = ProductoVendidoBussiness.ObtenerProductoVendido(id);

            if (!(productoVendidoResponse.Mensaje == "OK"))
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return Ok(productoVendidoResponse.ProductoVendido);
        }

        [HttpPost]
        public ActionResult<long> PostCrearProductoVendido([FromBody] ProductoVendido productovendido)
        {
            ProductoVendidoResponse productoVendidoResponse = ProductoVendidoBussiness.CrearProductoVendido(productovendido);

            if (!(productoVendidoResponse.Mensaje == "OK"))
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return Ok(productoVendidoResponse.Id);
        }

        [HttpDelete]
        public ActionResult<bool> DeleteEliminarProductoVendido([FromHeader] long id)
        {
            ProductoVendidoResponse productoVendidoResponse = ProductoVendidoBussiness.EliminarProductoVendido(id);

            if (!(productoVendidoResponse.Mensaje == "OK"))
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return Ok(true);
        }

        [HttpPut]
        public ActionResult<bool> PutModificarProductoVendido([FromBody] ProductoVendido productovendido)
        {
            ProductoVendidoResponse productoVendidoResponse = ProductoVendidoBussiness.ModificarProductoVendido(productovendido);

            if (!(productoVendidoResponse.Mensaje == "OK"))
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return Ok(true);
        }
    }
}