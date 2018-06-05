using Common.To.Vuelos;
using System.Collections.Generic;

namespace Common.To.Maestros
{
    public class OrigenDestinoTo
    {
        public int Id { get; set; }
        public int IdAeropuerto { get; set; }
        public string Nombre { get; set; }
        public bool EsOrigen { get; set; }
        public bool EsDestino { get; set; }
        public bool Habilitado { get; set; }
        public AeropuertoTo Aeropuerto { get; set; }
        public List<VueloTo> Vuelos { get; set; }
    }
}
