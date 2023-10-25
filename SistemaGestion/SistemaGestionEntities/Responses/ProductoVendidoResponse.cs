using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionEntities.Responses
{
    public class ProductoVendidoResponse
    {
        public long Id { get; set; }
        public ProductoVendido ProductoVendido { get; set; }
        public List<ProductoVendido> ProductosVendidos { get; set; }
        public string Mensaje { get; set; }
    }
}
