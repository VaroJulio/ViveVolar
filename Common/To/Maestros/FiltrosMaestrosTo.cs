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
        int Id { get; set; }
        FiltroGeografico JerarquiaGeografica { get; set; }
    }

    public class FiltroAeropuertoTo
    {
        string Id { get; set; }
        FiltroAeropuerto IdFiltroBusqueda { get; set; }
        EsOrigenODestino CriterioOrigenDestino { get; set; }
    } 
}
