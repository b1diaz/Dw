using System;
using System.Collections.Generic;
using System.Text;

namespace DigitalWare.Models
{
    public class ProductoFactura
    {
        /// <summary>
        /// Fecha de creacion
        /// </summary>
        public DateTime Creado { get; set; } = new DateTime().Date;
        /// <summary>
        /// Fecha de Actualizacion
        /// </summary>
        public DateTime Actualizado { get; set; } = new DateTime().Date;
        public long ProductoId { get; set; }
        public Producto Producto { get; set; }
        public long FacturaId { get; set; }
        public Factura Factura { get; set; }
    }
}
