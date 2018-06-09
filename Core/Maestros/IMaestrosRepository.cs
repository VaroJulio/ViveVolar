using Common.To.Maestros;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Maestros
{
    public interface IMaestrosRepository
    {
        //Consultas
        //Task<ICollection<TodosMaestrosTo>> ObtenerTodosMaestrosAsync();
        //Task<ICollection<PaisTo>> ObtenerTodosPaisesAsync();
        //Task<ICollection<EstadoTo>> ObtenerTodosEstadosAsync();
        //Task<ICollection<CiudadTo>> ObtenerTodosCiudadesAsync();
        //Task<ICollection<OrigenDestinoTo>> ObtenerTodosOrigenesDestinosAsync();
        //Task<ICollection<AeropuertoTo>> ObtenerTodosAeropuertosAsync();
        Task<PaisTo> ObtenerPaisPorIdAsync(int id);
        Task<EstadoTo> ObtenerEstadoPorIdAsync(int id);
        Task<CiudadTo> ObtenerCiudadPorIdAsync(int id);
        Task<OrigenDestinoTo> ObtenerOrigenDestinoPorIdAsync(int id);
        Task<AeropuertoTo> ObtenerAeropuertoPorIdAsync(int id);
        Task<ICollection<PaisTo>> ObtenerPaisesPorFiltroAsync(FiltroGeograficoTo filtro);
        Task<ICollection<EstadoTo>> ObtenerEstadosPorFiltroAsync(FiltroGeograficoTo filtro);
        ICollection<CiudadTo> ObtenerCiudadesPorFiltro(FiltroGeograficoTo filtro);
        Task<ICollection<OrigenDestinoTo>> ObtenerOrigenesDestinosPorFiltroAsync(FiltroGeograficoTo filtro);
        ICollection<AeropuertoTo> ObtenerAeropuertosPorFiltro(FiltroGeograficoTo filtro);
        ICollection<AeropuertoTo> ObtenerAeropuertosPorFiltro(FiltroAeropuertoTo filtro);

        //Guardar - Editar
        //Task GuardarPaisAsync(PaisTo pais);
        //Task GuardarEstadoAsync(EstadoTo estado);
        //Task GuardarCiudadAsync(CiudadTo ciudad);
        //Task GuardarOrigenDestinoAsync(OrigenDestinoTo origenDestino);
        //Task GuardarAeropuertoAsync(AeropuertoTo aeropuerto);
        //Task GuardarPaisesAsync(List<PaisTo> paises);
        //Task GuardarEstadosAsync(List<EstadoTo> estados);
        //Task GuardarCiudadesAsync(List<CiudadTo> ciudades);
        //Task GuardarOrigenesDestinosAsync(List<OrigenDestinoTo> origenesDestinos);
        //Task GuardarAeropuertosAsync(List<AeropuertoTo> aeropuertos);

        //Remover - Deshabilitar
        //Task RemoverPaisAsync(PaisTo pais);
        //Task RemoverEstadoAsync(EstadoTo estado);
        //Task RemoverCiudadAsync(CiudadTo ciudad);
        //Task RemoverOrigenDestinoAsync(OrigenDestinoTo origenDestino);
        //Task RemovoerAeropuertoAsync(AeropuertoTo aeropuerto);
        //Task RemoverPaisesAsync(List<PaisTo> paises);
        //Task RemoverEstadosAsync(List<EstadoTo> estados);
        //Task RemoverCiudadesAsync(List<CiudadTo> ciudades);
        //Task RemoverOrigenesDestinosAsync(List<OrigenDestinoTo> origenesDestinos);
        //Task RemoverAeropuertosAsync(List<AeropuertoTo> aeropuertos);
    }
}
