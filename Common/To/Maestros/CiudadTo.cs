using System.Collections.Generic;

namespace Common.To.Maestros
{
    public class CiudadTo
    {
        public int Id { get; set; }
        public string Nombre { get; set; } 
        public int IdEstado { get; set; }
        public EstadoTo Estado { get; set; }
        public List<AeropuertoTo> Aeropuertos { get; set; }
    }
}
