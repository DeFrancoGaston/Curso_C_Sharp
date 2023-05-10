using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP01
{
    class Usuario
    {
        int _id;
        string _nombre, _apellido, _nombreUsuario, _contrasenia, _mail;

        public Usuario(string nombreUsuario)
        {
            this._nombreUsuario = nombreUsuario;
            this._nombre = string.Empty;
            this._apellido = string.Empty;
            this._contrasenia = string.Empty;
            this._mail = string.Empty;
        }

        public string nombre { get; set; }
        public string apellido { get; set; }
        public string contrasenia
        {
            set
            {
                _contrasenia = value;
            }
        }

        public string email { get; set; }
    }

}
