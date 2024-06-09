using System;
using System.Collections.Generic;
using System.Text;

namespace TP2ClubDeportivo
{
    internal class Suplementos
    {
        public string Nombre { get; set; }
        public decimal PorcentajeGanancia { get; set; }
        public decimal PrecioLista { get; set; }

        public decimal CalcularPrecioFinal()
        {
            decimal precioConGanancia = PrecioLista + (PrecioLista * PorcentajeGanancia / 100);
            decimal precioFinal = precioConGanancia + (precioConGanancia * 0.21m);
            return precioFinal;
        }
    }
}
