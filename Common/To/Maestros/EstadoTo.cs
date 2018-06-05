using System.Collections.Generic;

namespace Common.To.Maestros
{
    public class EstadoTo
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int IdPais { get; set; }
        public PaisTo Pais { get; set; }
        public List<CiudadTo> Ciudades { get; set; }
    }
}
