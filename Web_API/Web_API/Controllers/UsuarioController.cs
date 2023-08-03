using Microsoft.AspNetCore.Mvc;
using Web_API.Models;
using Web_API.DataServices;
using Microsoft.IdentityModel.Tokens;

namespace Web_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController :ControllerBase
    {
        [HttpGet]
        public ActionResult<Usuario> GetUsuario(int id)
        {
            if(id == 0) { return BadRequest(); }

            UsuarioDS usuarioDS = new UsuarioDS();
            var usuario = usuarioDS.ObtenerUsuarioPorId(id);
            
            if(usuario == null) { return NotFound(); }

            return Ok(usuario);
        }

        [HttpGet("client_name")]
        public ActionResult<string> GetNombreUsuario(long id)
        {
            if (id == 0) { return BadRequest(); }

            UsuarioDS usuarioDS = new UsuarioDS();
            var usuario = usuarioDS.ObtenerUsuarioPorId(id);

            if (usuario == null) { return NotFound(); }

            return Ok(usuario.Nombre);
        }

        [HttpGet("begin_session")]
        public ActionResult<Usuario> BeginSession(string nombre_usuario, string pass)
        {
            if (nombre_usuario.IsNullOrEmpty() || pass.IsNullOrEmpty()) { return BadRequest(); }

            UsuarioDS usuarioDS = new UsuarioDS();
            var usuario = usuarioDS.IniciarSesion(nombre_usuario, pass);

            if (usuario == null) { return NotFound(); }

            return Ok(usuario);
        }

            [HttpPost]
            public ActionResult<Usuario> PostUsuario([FromBody] Usuario usuario)
            {
                var usuarioDS = new UsuarioDS();
                var usu_resp = usuarioDS.CrearUsuario(usuario);
                return Ok(usu_resp);
            }

            [HttpPut]
            public IActionResult PutUsuario([FromBody] Usuario usuario)
            {
                if(usuario.Id == 0 || usuario == null) { return BadRequest(); }
            
                var usuarioDS = new UsuarioDS();
                var usu_resp = usuarioDS.ModificarUsuario(usuario);
            
                if (!usu_resp)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }
                return Ok();
            }

        [HttpDelete]
        public ActionResult<string> DeleteUsuario(long id)
        {
            if (id == 0) { return BadRequest(); }

            UsuarioDS usuarioDS = new UsuarioDS();
            var usu_resp = usuarioDS.EliminarUsuario(id);

            if (!usu_resp)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return Ok();
        }
    }
}
