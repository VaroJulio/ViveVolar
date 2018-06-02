using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entidades
{
    public class OrigenDestino
    {
        int Id { get; set; }
        int IdAeropuerto { get; set; }
        string Nombre { get; set; }
        bool EsOrigen { get; set; }
        bool EsDestino { get; set; }
    }
}
