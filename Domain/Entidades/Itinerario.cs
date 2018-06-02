using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entidades
{
    class Itinerario
    {
        int Id { get; set; }
        Guid CodigoConsultaReserva { get; set; }
        int IdVuelo { get; set; }
        string IdentificacionPasajero { get; set; }
    }
}
