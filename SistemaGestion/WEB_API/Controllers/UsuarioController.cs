using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaGestionBussiness;
using SistemaGestionEntities;
using SistemaGestionEntities.Responses;

namespace WEB_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        [HttpGet("ListarUsuarios")]
        public ActionResult<IEnumerable<Usuario>> GetListarUsuarios()
        {
            UsuarioResponse usuarioResponse = UsuarioBussiness.ListarUsuarios();

            if (!(usuarioResponse.Mensaje == "OK"))
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return Ok(usuarioResponse.Usuarios);
        }

        [HttpGet]
        public ActionResult<Usuario> GetObtenerUsuario([FromHeader] long id)
        {
            UsuarioResponse usuarioResponse = UsuarioBussiness.ObtenerUsuario(id);

            if (!(usuarioResponse.Mensaje == "OK"))
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return Ok(usuarioResponse.Usuario);
        }

        [HttpPost]
        public ActionResult<long> PostCrearUsuario([FromBody] Usuario usuario)
        {
            UsuarioResponse usuarioResponse = UsuarioBussiness.CrearUsuario(usuario);

            if (!(usuarioResponse.Mensaje == "OK"))
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return Ok(usuarioResponse.Id);
        }

        [HttpDelete]
        public ActionResult<bool> DeleteEliminarUsuario([FromHeader] long id)
        {
            UsuarioResponse usuarioResponse = UsuarioBussiness.EliminarUsuario(id);

            if (!(usuarioResponse.Mensaje == "OK"))
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return Ok(true);
        }

        [HttpPut]
        public ActionResult<bool> PutModificarUsuario([FromBody] Usuario usuario)
        {
            UsuarioResponse usuarioResponse = UsuarioBussiness.ModificarUsuario(usuario);

            if (!(usuarioResponse.Mensaje == "OK"))
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return Ok(true);
        }

        [HttpGet("IniciarSesion")]
        public ActionResult<Usuario> GetIniciarSesion([FromHeader] string nombreusr, [FromHeader] string pass)
        {
            UsuarioResponse usuarioResponse = UsuarioBussiness.IniciarSesion(nombreusr, pass);

            if (!(usuarioResponse.Mensaje == "OK"))
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return Ok(usuarioResponse.Usuario);
        }
    }
}
