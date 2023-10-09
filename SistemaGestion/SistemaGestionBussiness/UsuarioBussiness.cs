using SistemaGestionEntities;
using SistemaGestionData;

namespace SistemaGestionBussiness
{
    public static class UsuarioBussiness
    {
        public static List<Usuario> ListarUsuarios()
        {
            try
            {
                return UsuarioData.ListarUsuarios();
            }
            catch (Exception e) { throw;}
}

public static long CrearUsuario(Usuario usuario)
        {
            try
            {
                return UsuarioData.CrearUsuario(usuario);
            }
            catch (Exception e) { throw; }
        }

        public static bool EliminarUsuario(long id)
        {
            try
            {
                return UsuarioData.EliminarUsuario(id);
            }
            catch (Exception e) { throw; }
        }

        public static bool ModificarUsuario(Usuario usuario)
        {
            try
            {
                return UsuarioData.ModificarUsuario(usuario);
            }
            catch (Exception e) { throw; }
        }

        public static Usuario ObtenerUsuario(long id)
        {
            try
            {
                return UsuarioData.ObtenerUsuario(id);
            }
            catch (Exception e) { throw; }
        }
    }
}