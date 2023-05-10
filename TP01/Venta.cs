using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP01
{
    internal class Venta
    {
        int _id, _idUsuario;
        string _comentario;

        public Venta(int idUsuario)
        {
            _id = 0;
            _idUsuario = idUsuario;
            _comentario = string.Empty;
        }

        public int id { set; get; }
        public string comentario { set; get;}
        public string usuario { set; get; }
    }
}
