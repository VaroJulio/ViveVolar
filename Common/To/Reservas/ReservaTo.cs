using System;
using System.Collections.Generic;

namespace Common.To.Reservas
{
    public class ReservaTo
    {
        public int IdReserva { get; set; }
        public Guid CodigoConsultaReserva { get; set; }
        public DateTime FechaReserva { get; set; }
        public string Correo { get; set; }
        public List<ItinerarioTo> Itinerarios { get; set; }
    }
}
