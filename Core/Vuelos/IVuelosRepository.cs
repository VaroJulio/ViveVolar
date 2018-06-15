using Common.To.Vuelos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Vuelos
{
    public interface IVuelosRepository
    {
        Task<VueloTo> ObtenerVueloPorIdAsync(int id);
        ICollection<VueloTo> ObtenerVuelosPorFiltro(FiltroVuelosTo filtro);
        void GuardarNuevoVuelo(VueloTo vuelo);
        void GuardarNuevosVuelos(List<VueloTo> vuelos);
        void ActualizarVuelo(VueloTo vuelo);
        void ActualizarVuelos(List<VueloTo> vuelos);
    }
}
