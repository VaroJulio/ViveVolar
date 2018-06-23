using Domain.Entidades;
using System.Data.Entity;

namespace Core.Vuelos.BdRepositories
{
    public sealed class VueloRepository : RepositorioGenerico<Vuelo>
    {
        public VueloRepository(DbContext contexto) : base(contexto) { }
    }
}
