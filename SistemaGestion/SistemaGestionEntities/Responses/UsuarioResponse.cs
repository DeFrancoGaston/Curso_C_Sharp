using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionEntities.Responses
{
    public class UsuarioResponse
    {
        public long Id { get; set; }
        public Usuario Usuario { get; set; }
        public List<Usuario> Usuarios { get; set; }
        public string Mensaje { get; set; }
    }
}
