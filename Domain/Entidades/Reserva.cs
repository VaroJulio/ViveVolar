using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entidades
{
    class Reserva
    {
        int IdReserva { get; set; }
        Guid CodigoConsultaReserva { get; set; }
        DateTime FechaReserva { get; set; }
        string Correo { get; set; }
    }
}
