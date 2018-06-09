using AutoMapper;
using Common.To.Maestros;
using Common.Constantes;
using Core.Maestros.BdRepositories;
using Domain;
using Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

        public ICollection<AeropuertoTo> ObtenerAeropuertosPorFiltro(FiltroGeograficoTo filtro)
        {
            List<AeropuertoTo> aeropuertos = new List<AeropuertoTo>();
            using (var Contexto = ViveVolarDbContext.GetDbContext())
            {
                var aeropuertoRepositorio = new AeropuertoRepository(Contexto);

                var result = aeropuertoRepositorio.Filtrar(ConstruirExpresionConsultaAeropuertoPorFiltroGeografico(filtro));
                aeropuertos = Mapper.Map<List<AeropuertoTo>>(result);
            }
            return aeropuertos;
        }

        public Expression<Func<Aeropuerto, bool>> ConstruirExpresionConsultaAeropuertoPorFiltroGeografico(FiltroGeograficoTo filtro)
        {
            Expression<Func<Aeropuerto, bool>> filtroInfo = null;
            switch (filtro.JerarquiaGeografica)
            {
                case FiltroGeografico.IdCiudad:
                    filtroInfo = a => a.IdCiudad == filtro.Id;
                    break;
                case FiltroGeografico.IdEstado:
                    filtroInfo = a => a.Ciudad.IdEstado == filtro.Id;
                    break;
                case FiltroGeografico.IdPais:
                     filtroInfo = a => a.Ciudad.Estado.IdPais == filtro.Id;
                    break;
            }
            return filtroInfo;
        }

        public ICollection<AeropuertoTo> ObtenerAeropuertosPorFiltro(FiltroAeropuertoTo filtro)
        {
            List<AeropuertoTo> aeropuertos = new List<AeropuertoTo>();
            using (var Contexto = ViveVolarDbContext.GetDbContext())
            {
                var aeropuertoRepositorio = new AeropuertoRepository(Contexto);
                var expressionFilter = ConstruirExpresionConsultaAeropuertoPorFiltroAeropuerto(filtro);
                if (expressionFilter != null)
                {
                    var result = aeropuertoRepositorio.Filtrar(expressionFilter);
                    aeropuertos = Mapper.Map<List<AeropuertoTo>>(result);
                }
                else
                {
                    Expression<Func<OrigenDestino, bool>> filtroInfo = null;
                    var origenDestinoRepositorio = new OrigenDestinoRepository(Contexto);

                    if(filtro.CriterioOrigenDestino == EsOrigenODestino.EsDestino)
                        filtroInfo = o => o.Id == int.Parse(filtro.Id) && o.EsDestino == true;
                    else if (filtro.CriterioOrigenDestino == EsOrigenODestino.EsOrigen)
                        filtroInfo = o => o.Id == int.Parse(filtro.Id) && o.EsDestino == true;
                    else
                        filtroInfo = o => o.Id == int.Parse(filtro.Id);

                    var result = origenDestinoRepositorio.Filtrar(filtroInfo);
                    //var result = origenDestinoRepositorio.ObtenerPorId(filtro.Id).Result.Aeropuerto;
                    aeropuertos = Mapper.Map<List<AeropuertoTo>>(result);
                }               
            }
            return aeropuertos;
        }

        public Expression<Func<Aeropuerto, bool>> ConstruirExpresionConsultaAeropuertoPorFiltroAeropuerto(FiltroAeropuertoTo filtro)
        {
            Expression<Func<Aeropuerto, bool>> filtroInfo = null;
            switch (filtro.IdFiltroBusqueda)
            {
                case FiltroAeropuerto.IdAeropuerto:
                    filtroInfo = a => a.Id == int.Parse(filtro.Id);
                    break;
                case FiltroAeropuerto.IdMundial:
                    filtroInfo = a => a.CodigoMundial == filtro.Id;
                    break;
            }
            return filtroInfo;
        }

        public ICollection<CiudadTo> ObtenerCiudadesPorFiltro(FiltroGeograficoTo filtro)
        {
            List<CiudadTo> ciudades = new List<CiudadTo>();
            using (var Contexto = ViveVolarDbContext.GetDbContext())
            {
                var ciudadRepositorio = new CiudadRepository(Contexto);

                var result = ciudadRepositorio.Filtrar(ConstruirExpresionConsultaCiudadPorFiltroGeografico(filtro));
                ciudades = Mapper.Map<List<CiudadTo>>(result);
            }
            return ciudades;
        }

        public Expression<Func<Ciudad, bool>> ConstruirExpresionConsultaCiudadPorFiltroGeografico(FiltroGeograficoTo filtro)
        {
            Expression<Func<Ciudad, bool>> filtroInfo = null;
            switch (filtro.JerarquiaGeografica)
            {
                case FiltroGeografico.IdCiudad:
                    filtroInfo = a => a.Id == filtro.Id;
                    break;
                case FiltroGeografico.IdEstado:
                    filtroInfo = a => a.Estado.Id == filtro.Id;
                    break;
                case FiltroGeografico.IdPais:
                    filtroInfo = a => a.Estado.IdPais == filtro.Id;
                    break;
            }
            return filtroInfo;
        }

        public async Task<CiudadTo> ObtenerCiudadPorIdAsync(int id)
        {
            CiudadTo ciudad = new CiudadTo();
            using (var Contexto = ViveVolarDbContext.GetDbContext())
            {
                var ciudadRepositorio = new CiudadRepository(Contexto);
                var result = await ciudadRepositorio.ObtenerPorId(id.ToString());
                ciudad = Mapper.Map<CiudadTo>(result);
            }
            return ciudad;
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
