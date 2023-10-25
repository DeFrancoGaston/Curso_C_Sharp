using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionEntities.Responses
{
    public class ProductoResponse
    {
        public long Id { get; set; }
        public Producto Producto { get; set; }
        public List<Producto> Productos { get; set; }
        public string Mensaje { get; set; }
    }
}
