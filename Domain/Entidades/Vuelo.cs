using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entidades
{
    class Vuelo
    {
        int Id { get; set; }
        int IdOrigen { get; set; }
        DateTime HoraSalida { get; set; }
        int IdDestino { get; set; }
        DateTime HoraLlegada { get; set; }
        int NumPasajeros { get; set; }
    }
}
