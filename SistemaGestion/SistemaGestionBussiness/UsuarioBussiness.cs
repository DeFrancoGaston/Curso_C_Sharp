using SistemaGestionEntities;
using SistemaGestionData;
using SistemaGestionEntities.Responses;

namespace SistemaGestionBussiness
{
    public static class UsuarioBussiness
    {
        public static UsuarioResponse ListarUsuarios()
        {
            return UsuarioData.ListarUsuarios();
        }

        public static UsuarioResponse CrearUsuario(Usuario usuario)
        {
            return UsuarioData.CrearUsuario(usuario);
        }

        public static UsuarioResponse EliminarUsuario(long id)
        {
            return UsuarioData.EliminarUsuario(id);
        }

        public static UsuarioResponse ModificarUsuario(Usuario usuario)
        {
            return UsuarioData.ModificarUsuario(usuario);
        }

        public static UsuarioResponse ObtenerUsuario(long id)
        {
            return UsuarioData.ObtenerUsuario(id);
        }

        public  static UsuarioResponse IniciarSesion(string nombreusr, string pass)
        {
            return UsuarioData.IniciarSesion(nombreusr, pass);
        }
    }
}