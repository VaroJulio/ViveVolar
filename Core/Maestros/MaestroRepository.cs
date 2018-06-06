using AutoMapper;
using Common.To.Maestros;
using Core.Maestros.BdRepositories;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Maestros
{
    public class MaestroRepository : IMaestrosRepository
    {
        public async Task<AeropuertoTo> ObtenerAeropuertoPorIdAsync(int id)
        {
            AeropuertoTo aeropuerto = new AeropuertoTo();
            using (var Contexto = ViveVolarDbContext.GetDbContext())
            {
                var aeropuertoRepositorio = new AeropuertoRepository(Contexto);
                var result = await aeropuertoRepositorio.ObtenerPorId(id.ToString());
                aeropuerto = Mapper.Map<AeropuertoTo>(result);
            }
            return aeropuerto;
        }

        public Task<ICollection<AeropuertoTo>> ObtenerAeropuertosPorFiltroAsync(FiltroGeograficoTo filtro)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<AeropuertoTo>> ObtenerAeropuertosPorFiltroAsync(FiltroAeropuertoTo filtro)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<CiudadTo>> ObtenerCiudadesPorFiltroAsync(FiltroGeograficoTo filtro)
        {
            throw new NotImplementedException();
        }

        public Task<CiudadTo> ObtenerCiudadPorIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<EstadoTo> ObtenerEstadoPorIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<EstadoTo>> ObtenerEstadosPorFiltroAsync(FiltroGeograficoTo filtro)
        {
            throw new NotImplementedException();
        }

        public Task<OrigenDestinoTo> ObtenerOrigenDestinoPorIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<OrigenDestinoTo>> ObtenerOrigenesDestinosPorFiltroAsync(FiltroGeograficoTo filtro)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<PaisTo>> ObtenerPaisesPorFiltroAsync(FiltroGeograficoTo filtro)
        {
            throw new NotImplementedException();
        }

        public Task<PaisTo> ObtenerPaisPorIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
