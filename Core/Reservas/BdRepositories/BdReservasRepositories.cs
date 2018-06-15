using Domain.Entidades;
using System.Data.Entity;

namespace Core.Reservas.BdRepositories
{
    sealed class ReservaRepository : RepositorioGenerico<Reserva>
    {
        public ReservaRepository(DbContext contexto) : base(contexto) { }
    }

    sealed class ItinerarioRepository : RepositorioGenerico<Itinerario>
    {
        public ItinerarioRepository(DbContext contexto) : base(contexto) { }
    }

    sealed class PasajeroRepository : RepositorioGenerico<Pasajero>
    {
        public PasajeroRepository(DbContext contexto) : base(contexto) { }
    }
}
