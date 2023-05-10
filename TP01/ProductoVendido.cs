using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP01
{
    internal class ProductoVendido
    {
        int _id, _idProducto, _idVenta;
        float _stock;

        public ProductoVendido(int id, int idProducto, int idVenta)
        {
            this._id = id;
            this._idProducto = idProducto;
            this._idVenta = idVenta;
        }

        public float id { get; }
        public float idProducto { get; }
        public float idVenta { get; }
        public float stock { get; set; }
    }
}
