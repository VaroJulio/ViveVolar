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
    }

    sealed internal class EstadoRepository : RepositorioGenerico<Estado>
    {
    }

    sealed internal class CiudadRepository : RepositorioGenerico<Ciudad>
    {
    }

    sealed internal class OrigenDestinoRepository : RepositorioGenerico<OrigenDestino>
    {
    }

    sealed internal class AeropuertoRepository : RepositorioGenerico<Aeropuerto>
    {
        public AeropuertoRepository(DbContext contexto) : base(contexto) { }
    }
}
