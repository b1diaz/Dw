using System;
using System.Collections.Generic;
using System.Text;

namespace DigitalWare.Models
{
    public class ClaseBase
    {
        public long Id { get; set; }
        /// <summary>
        /// Fecha de creacion
        /// </summary>
        public DateTime Creado { get; set; } = new DateTime().Date;
        /// <summary>
        /// Fecha de actualizacion
        /// </summary>
        public DateTime Actualizado { get; set; } = new DateTime().Date;
    }
}
