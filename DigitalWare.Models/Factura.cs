using System;
using System.Collections.Generic;
using System.Text;

namespace DigitalWare.Models
{
    public class Factura : ClaseBase
    {
        public int Total { get; set; }
        public long VendedorId { get; set; }
        public Vendedor Vendedor { get; set; }
        public List<ProductoFactura> ProductosFacturas { get; set; }
        public long ClienteId { get; set; }
        public Cliente Cliente { get; set; }
    }
}
