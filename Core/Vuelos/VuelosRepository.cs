using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Common.To.Vuelos;
using Common.Constantes;
using Core.Vuelos.BdRepositories;
using Domain;
using Domain.Entidades;
using Common.Auxiliares;

namespace Core.Vuelos
{
    public class VuelosRepository : IVuelosRepository
    {
        public void ActualizarVuelo(VueloTo vuelo)
        {
            throw new NotImplementedException();
        }

        public void ActualizarVuelos(List<VueloTo> vuelos)
        {
            throw new NotImplementedException();
        }

        public void GuardarNuevosVuelos(List<VueloTo> vuelos)
        {
            throw new NotImplementedException();
        }

        public void GuardarNuevoVuelo(VueloTo vuelo)
        {
            throw new NotImplementedException();
        }

        public async Task<VueloTo> ObtenerVueloPorIdAsync(int id)
        {
            VueloTo vuelo = new VueloTo();
            using (var Contexto = ViveVolarDbContext.GetDbContext())
            {
                var vueloRepositorio = new VueloRepository(Contexto);
                var result = await vueloRepositorio.ObtenerPorId(id.ToString());
                vuelo = Mapper.Map<VueloTo>(result);
            }
            return vuelo;
        }

        public ICollection<VueloTo> ObtenerVuelosPorFiltro(FiltroVuelosTo filtro)
        {
            List<VueloTo> vuelos = new List<VueloTo>();
            using (var Contexto = ViveVolarDbContext.GetDbContext())
            {
                var vueloRepositorio = new VueloRepository(Contexto);

                var result = vueloRepositorio.Filtrar(ConstruirExpresionConsultaVuelosPorFiltroVuelos(filtro)).ToList();
                vuelos = Mapper.Map<List<VueloTo>>(result);
            }
            return vuelos;
        }

        public Expression<Func<Vuelo, bool>> ConstruirExpresionConsultaVuelosPorFiltroVuelos(FiltroVuelosTo filtro)
        {
            Expression<Func<Vuelo, bool>> filtroInfo = null;
            Expression<Func<Vuelo, bool>> predicateAuxiliar = null;
            
            switch (filtro.CriterioBusquedaOrigen)
            {
                case FiltroVueloOrigen.IdOrigen:
                    filtroInfo = v => v.IdOrigen == filtro.IdOrigen;
                    break;
                case FiltroVueloOrigen.IdCiudadOrigen:
                    filtroInfo = v => v.Origen.Aeropuerto.IdCiudad == filtro.IdOrigen;
                    break;
                case FiltroVueloOrigen.IdPaisOrigen:
                    filtroInfo = v => v.Origen.Aeropuerto.Ciudad.Estado.IdPais == filtro.IdOrigen;
                    break;
            }

            if (filtro.FechaOrigen != null)
                predicateAuxiliar = v => v.HoraSalida == filtro.FechaOrigen;
                
            else
                predicateAuxiliar = v => v.HoraSalida >= DateTime.UtcNow;

            filtroInfo = filtroInfo.And(predicateAuxiliar);

            switch (filtro.CriterioBusquedaDestino)
            {
                case FiltroVueloDestino.IdDestino:
                    predicateAuxiliar = v => v.IdDestino == filtro.IdDestino;
                    break;
                case FiltroVueloDestino.IdCiudadDestino:
                    predicateAuxiliar = v => v.Destino.Aeropuerto.IdCiudad == filtro.IdDestino;
                    break;
                case FiltroVueloDestino.IdPaisDestino:
                    predicateAuxiliar = v => v.Destino.Aeropuerto.Ciudad.Estado.IdPais == filtro.IdDestino;
                    break;
            }

            filtroInfo = filtroInfo.And(predicateAuxiliar);

            if (filtro.FechaDestino != null)
                predicateAuxiliar = v => v.HoraLlegada == filtro.FechaDestino;
            else
                predicateAuxiliar = v => v.HoraLlegada <= DateTime.UtcNow.AddDays(30);

            filtroInfo = filtroInfo.And(predicateAuxiliar);

            return filtroInfo;
        }
    }
}
