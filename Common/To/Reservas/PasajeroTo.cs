using System;
using System.Collections.Generic;

namespace Common.To.Reservas
{
    public class PasajeroTo
    {
        public string Identificacion { get; set; }
        public string NombreCompleto { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public List<ItinerarioTo> Itinerarios { get; set; }
    }
}
