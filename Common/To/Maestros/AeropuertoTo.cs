using System.Collections.Generic;

namespace Common.To.Maestros
{
    public class AeropuertoTo
    {
        public int Id { get; set; }
        public string CodigoMundial { get; set; }
        public string Nombre { get; set; }
        public int IdCiudad { get; set; }
        public string Habilitado { get; set; }
        public CiudadTo Ciudad { get; set; }
        public List<OrigenDestinoTo> OrigenDestinos { get; set; }
    }
}
