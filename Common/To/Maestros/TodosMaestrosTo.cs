using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.To.Maestros
{
    public class TodosMaestrosTo
    {
        List<PaisTo> Paises { get; set; }
        List<EstadoTo> Estados { get; set; }
        List<CiudadTo> Ciudades { get; set; }
        List<AeropuertoTo> Aeropuesrtos { get; set; }
        List<OrigenDestinoTo> OrigenesDestinos { get; set; }
    }
}
