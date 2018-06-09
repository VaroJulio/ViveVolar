using Common.Constantes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.To.Maestros
{
    public class FiltroGeograficoTo
    {
        public int Id { get; set; }
        public FiltroGeografico JerarquiaGeografica { get; set; }
    }

    public class FiltroAeropuertoTo
    {
        public string Id { get; set; }
        public FiltroAeropuerto IdFiltroBusqueda { get; set; }
        public EsOrigenODestino CriterioOrigenDestino { get; set; }
    } 
}
