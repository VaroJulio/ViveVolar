using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entidades
{
    public class Usuario
    {
        public long Identificacion { get; set; }
        public string NombreCompleto { get; set; }
        public string Correo { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int IdRol { get; set; }
    }
}
