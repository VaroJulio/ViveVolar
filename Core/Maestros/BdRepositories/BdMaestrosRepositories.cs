using Domain.Entidades;
using System.Data.Entity;

namespace Core.Maestros.BdRepositories
{
    public sealed class PaisRepository : RepositorioGenerico<Pais>
    {
        public PaisRepository(DbContext contexto) : base(contexto) { }
    }

    public sealed class EstadoRepository : RepositorioGenerico<Estado>
    {
        public EstadoRepository(DbContext contexto) : base(contexto) { }
    }

    public sealed class CiudadRepository : RepositorioGenerico<Ciudad>
    {
        public CiudadRepository(DbContext contexto) : base(contexto) { }
    }

    public sealed class OrigenDestinoRepository : RepositorioGenerico<OrigenDestino>
    {
        public OrigenDestinoRepository(DbContext contexto) : base(contexto) { }
    }

    public sealed class AeropuertoRepository : RepositorioGenerico<Aeropuerto>
    {
        public AeropuertoRepository(DbContext contexto) : base(contexto) { }
    }
}
