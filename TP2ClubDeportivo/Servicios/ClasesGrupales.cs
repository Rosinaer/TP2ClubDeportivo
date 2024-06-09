using System;
using System.Collections.Generic;
using System.Text;

namespace TP2ClubDeportivo.Servicios
{
    internal class ClasesGrupales : ServicioDeportivo
    {
        public int NumeroParticipantes { get; set; }
        public int DuracionMinutos { get; set; }

        public override decimal CalcularPrecio()
        {
            decimal precioBase = DuracionMinutos * 80;
            if (NumeroParticipantes > 10)
            {
                precioBase *= 0.8m;
            }
            decimal precioFinal = precioBase + (precioBase * 0.105m);//precioBase + la mitad del iva
            return precioFinal;
        }
    }
}
