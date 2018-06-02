using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entidades
{
    public class Aeropuerto
    {
        int Id { get; set;}
        string CodigoMundial { get; set; }
        string Nombre { get; set; }
        string IdCiudad { get; set; }
    }
}
