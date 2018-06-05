using Common.To.Maestros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Maestros
{
    class MaestroRepository : IMaestrosRepository
    {
        public Task GuardarAeropuertoAsync(AeropuertoTo aeropuerto)
        {
            throw new NotImplementedException();
        }

        public Task GuardarCiudadAsync(CiudadTo ciudad)
        {
            throw new NotImplementedException();
        }

        public Task GuardarEstadoAsync(EstadoTo estado)
        {
            throw new NotImplementedException();
        }

        public Task GuardarOrigenDestinoAsync(OrigenDestinoTo origenDestino)
        {
            throw new NotImplementedException();
        }

        public Task GuardarPaisAsync(PaisTo pais)
        {
            throw new NotImplementedException();
        }

        public Task<AeropuertoTo> ObtenerAeropuertoPorIdAsync(int id)
        {
            throw new NotImplementedException();
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

        public Task RemoverCiudadAsync(CiudadTo ciudad)
        {
            throw new NotImplementedException();
        }

        public Task RemoverEstadoAsync(EstadoTo estado)
        {
            throw new NotImplementedException();
        }

        public Task RemoverOrigenDestinoAsync(OrigenDestinoTo origenDestino)
        {
            throw new NotImplementedException();
        }

        public Task RemoverPaisAsync(PaisTo pais)
        {
            throw new NotImplementedException();
        }

        public Task RemovoerAeropuertoAsync(AeropuertoTo aeropuerto)
        {
            throw new NotImplementedException();
        }
    }
}
