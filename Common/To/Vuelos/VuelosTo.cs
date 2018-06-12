using Common.To.Maestros;
using Common.To.Reservas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.To.Vuelos
{
    public class VueloTo
    {
        public int Id { get; set; }
        public int IdOrigen { get; set; }
        public DateTime HoraSalida { get; set; }
        public int IdDestino { get; set; }
        public DateTime HoraLlegada { get; set; }
        public int NumPasajeros { get; set; }
        public decimal ValorInicialTicket { get; set; }
        public string Habilitado { get; set; }
        public OrigenDestinoTo Origen { get; set; }
        public OrigenDestinoTo Destino { get; set; }
        public List<ItinerarioTo> Itinerarios { get; set; }
    }
}
