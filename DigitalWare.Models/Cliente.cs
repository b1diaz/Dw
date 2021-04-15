using System;
using System.Collections.Generic;
using System.Text;

namespace DigitalWare.Models
{
    public class Cliente: ClaseBase
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Edad { get; set; }
        public string Cedula { get; set; }
        public DateTime? FechaUltimaCompra { get; set; } = null;
        /// <summary>
        /// Dias promedio entre compras
        /// </summary>
        public int FrecuenciaCompra { get; set; }
        public List<Factura> Facturas { get; set; }
    }
}
