using System;
using System.Collections.Generic;
using System.Text;

namespace TP2ClubDeportivo.Servicios
{
    internal abstract class ServicioDeportivo
    {
        public string Tipo { get; set; }
        public abstract decimal CalcularPrecio();
    }
}
