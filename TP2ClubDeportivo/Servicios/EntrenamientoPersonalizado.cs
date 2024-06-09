using System;
using System.Collections.Generic;
using System.Text;

namespace TP2ClubDeportivo.Servicios
{
    internal class EntrenamientoPersonalizado : ServicioDeportivo
    { 
        public int DuracionHoras { get; set; }

        public override decimal CalcularPrecio()
        {
            decimal precioBase = DuracionHoras * 2000;
            decimal precioFinal = precioBase + (precioBase * 0.105m);//precioBase + la mitad del iva
            return precioFinal;
        }
    }
}
