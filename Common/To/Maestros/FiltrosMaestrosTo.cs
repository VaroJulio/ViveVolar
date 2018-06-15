using Common.Constantes;

namespace Common.To.Maestros
{
    public class FiltroGeograficoTo
    {
        public int Id { get; set; }
        public FiltroGeografico JerarquiaGeografica { get; set; }
    }

    public class FiltroAeropuertoTo
    {
        public string Id { get; set; }
        public FiltroAeropuerto IdFiltroBusqueda { get; set; }
        public EsOrigenODestino CriterioOrigenDestino { get; set; }
    } 
}
