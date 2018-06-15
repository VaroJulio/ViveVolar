using Common.To.Vuelos;

namespace Common.To.Reservas
{
    public class ItinerarioTo
    {
        public int Id { get; set; }
        public int IdReserva { get; set; }
        public int IdVuelo { get; set; }
        public string IdentificacionPasajero { get; set; }
        public decimal ValorFinalTicket { get; set; }
        public ReservaTo Reserva { get; set; }
        public VueloTo Vuelo { get; set; }
        public PasajeroTo Pasajero { get; set; }
    }
}
