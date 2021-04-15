using System;
using System.Collections.Generic;
using System.Text;

namespace DigitalWare.Models
{
    public class Vendedor : ClaseBase
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Cedula { get; set; }
        public List<Factura> Facturas { get; set; }
    }
}
