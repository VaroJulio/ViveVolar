using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entidades
{
    class Pasajero
    {        
        string Identificacion { get; set; }
        string NombreCompleto { get; set; }
        DateTime FechaNacimiento { get; set; }
        string Correo { get; set; }
        string Telefono { get; set; }
    }
}
