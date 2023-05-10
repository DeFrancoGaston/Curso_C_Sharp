using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP01
{
    public class Producto
    {
        protected int _id, _idUsario;
        protected string _descripcion;
        protected float _costo, _precioVenta, _stock;

        public Producto()
        {
            _id = 0;
            _descripcion = string.Empty;
            _costo = 0f;
            _precioVenta = 0f;
            _stock = 0f;
        }

        public Producto(int id, string descripcion, float costo, float precioVenta, float stock, int idUsuario)
        {
            this._id = id;
            this._descripcion = descripcion;
            this._costo = costo;
            this._precioVenta = precioVenta;
            this._stock = stock;
            this._idUsario = idUsuario;
        }

        public int id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string descripcion
        {
            get
            {
                if (_descripcion == string.Empty)
                {
                    return "SIN DESCRIPCIÓN.";
                }
                else { return _descripcion; }
            }
            set { _descripcion = value; }
        }

        public float costo
        {
            get { return _costo; }
            set { _costo = value; }
        }

        public float precioVenta
        {
            get { return _precioVenta; }
            set { _precioVenta = value; }
        }

        public float stock
        {
            get { return _stock; }
            set { _stock = value; }
        }

        public int idUsuario
        {
            get { return _idUsario; }
            set { _idUsario = value; }
        }

    }
}