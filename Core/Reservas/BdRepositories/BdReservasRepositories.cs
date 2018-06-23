using Domain.Entidades;
using System.Data.Entity;

namespace Core.Reservas.BdRepositories
{
    public sealed class ReservaRepository : RepositorioGenerico<Reserva>
    {
        public ReservaRepository(DbContext contexto) : base(contexto) { }
    }

    public sealed class ItinerarioRepository : RepositorioGenerico<Itinerario>
    {
        public ItinerarioRepository(DbContext contexto) : base(contexto) { }
    }

    public sealed class PasajeroRepository : RepositorioGenerico<Pasajero>
    {
        public PasajeroRepository(DbContext contexto) : base(contexto) { }
    }
}
