using System.Collections.Generic;

namespace Common.To.Maestros
{
    public class PaisTo
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Habilitado { get; set; }
        public List<EstadoTo> Estados { get; set; }
    }
}
