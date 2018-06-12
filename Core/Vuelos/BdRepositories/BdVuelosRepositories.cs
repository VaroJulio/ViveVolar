using Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Vuelos.BdRepositories
{
    sealed internal class VueloRepository : RepositorioGenerico<Vuelo>
    {
        public VueloRepository(DbContext contexto) : base(contexto) { }
    }
}
