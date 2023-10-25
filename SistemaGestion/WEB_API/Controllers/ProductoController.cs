using Microsoft.AspNetCore.Mvc;
using SistemaGestionBussiness;
using SistemaGestionEntities;
using SistemaGestionEntities.Responses;

namespace WEB_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        [HttpGet("ListarProductos")]
        public ActionResult<IEnumerable<Producto>> GetListarProductos()
        {
            ProductoResponse productoResponse = ProductoBussiness.ListarProductos();

            if (!(productoResponse.Mensaje == "OK"))
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return Ok(productoResponse.Productos);
        }

        [HttpGet]
        public ActionResult<Producto> GetObtenerProducto([FromHeader] long id)
        {
            ProductoResponse productoResponse = ProductoBussiness.ObtenerProducto(id);

            if (!(productoResponse.Mensaje == "OK"))
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return Ok(productoResponse.Producto);
        }

        [HttpPost]
        public ActionResult<long> PostCrearProducto([FromBody] Producto producto)
        {
            ProductoResponse productoResponse = ProductoBussiness.CrearProducto(producto);

            if (!(productoResponse.Mensaje == "OK"))
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return Ok(productoResponse.Id);
        }

        [HttpDelete]
        public ActionResult<bool> DeleteEliminarProducto([FromHeader] long id)
        {
            ProductoResponse productoResponse = ProductoBussiness.EliminarProducto(id);

            if (!(productoResponse.Mensaje == "OK"))
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return Ok(true);
        }

        [HttpPut]
        public ActionResult<bool> PutModificarProducto([FromBody] Producto producto)
        {
            ProductoResponse productoResponse = ProductoBussiness.ModificarProducto(producto);

            if (!(productoResponse.Mensaje == "OK"))
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return Ok(true);
        }
    }
}
