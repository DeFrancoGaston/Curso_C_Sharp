using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionEntities.Responses
{
    public class VentaResponse
    {
        public long Id { get; set; }
        public Venta Venta { get; set; }
        public List<Venta> Ventas { get; set; }
        public string Mensaje { get; set; }
    }
}
