using Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Maestros.BdRepositories
{
    sealed internal class PaisRepository : RepositorioGenerico<Pais>
    {
        public PaisRepository(DbContext contexto) : base(contexto) { }
    }

    sealed internal class EstadoRepository : RepositorioGenerico<Estado>
    {
        public EstadoRepository(DbContext contexto) : base(contexto) { }
    }

    sealed internal class CiudadRepository : RepositorioGenerico<Ciudad>
    {
        public CiudadRepository(DbContext contexto) : base(contexto) { }
    }

    sealed internal class OrigenDestinoRepository : RepositorioGenerico<OrigenDestino>
    {
        public OrigenDestinoRepository(DbContext contexto) : base(contexto) { }
    }

    sealed internal class AeropuertoRepository : RepositorioGenerico<Aeropuerto>
    {
        public AeropuertoRepository(DbContext contexto) : base(contexto) { }
    }
}
