using Domain.Entidades;
using System.Data.Entity;

namespace Core.Maestros.BdRepositories
{
    sealed class PaisRepository : RepositorioGenerico<Pais>
    {
        public PaisRepository(DbContext contexto) : base(contexto) { }
    }

    sealed  class EstadoRepository : RepositorioGenerico<Estado>
    {
        public EstadoRepository(DbContext contexto) : base(contexto) { }
    }

    sealed class CiudadRepository : RepositorioGenerico<Ciudad>
    {
        public CiudadRepository(DbContext contexto) : base(contexto) { }
    }

    sealed class OrigenDestinoRepository : RepositorioGenerico<OrigenDestino>
    {
        public OrigenDestinoRepository(DbContext contexto) : base(contexto) { }
    }

    sealed class AeropuertoRepository : RepositorioGenerico<Aeropuerto>
    {
        public AeropuertoRepository(DbContext contexto) : base(contexto) { }
    }
}
