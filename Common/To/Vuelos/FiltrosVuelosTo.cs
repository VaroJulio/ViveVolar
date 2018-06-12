using Common.Constantes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.To.Vuelos
{
    public class FiltroVuelosTo
    {
        public int IdOrigen { get; set; }
        public FiltroVueloOrigen CriterioBusquedaOrigen { get; set; }
        public DateTime? FechaOrigen { get; set; }
        public int IdDestino { get; set; }
        public FiltroVueloDestino CriterioBusquedaDestino { get; set; }
        public DateTime? FechaDestino { get; set; }
    }
}
