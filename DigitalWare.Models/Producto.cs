using System;
using System.Collections.Generic;
using System.Text;

namespace DigitalWare.Models
{
    public class Producto: ClaseBase
    {
        public string Nombre { get; set; }
        public int Precio { get; set; }
        public int StockMinimo { get; set; }
        public int Cantidad { get; set; }
        public List<ProductoFactura> ProductosFacturas { get; set; }

    }
}
