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

                var result = aeropuertoRepositorio.Filtrar(ConstruirExpresionConsultaAeropuertoPorFiltroGeografico(filtro)).ToList();
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
                    var result = aeropuertoRepositorio.Filtrar(expressionFilter).ToList();
                    aeropuertos = Mapper.Map<List<AeropuertoTo>>(result);
                }
                else
                {
                    Expression<Func<OrigenDestino, bool>> filtroInfo = null;
                    var origenDestinoRepositorio = new OrigenDestinoRepository(Contexto);

                    if (filtro.CriterioOrigenDestino == EsOrigenODestino.EsDestino)
                        filtroInfo = o => o.Id == int.Parse(filtro.Id) && o.EsDestino == "S";
                    else if (filtro.CriterioOrigenDestino == EsOrigenODestino.EsOrigen)
                        filtroInfo = o => o.Id == int.Parse(filtro.Id) && o.EsDestino == "S";
                    else
                        filtroInfo = o => o.Id == int.Parse(filtro.Id);

                    var result = origenDestinoRepositorio.Filtrar(filtroInfo).Select(a => a.Aeropuerto).ToList();
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
                case FiltroAeropuerto.CodMundial:
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

                var result = ciudadRepositorio.Filtrar(ConstruirExpresionConsultaCiudadPorFiltroGeografico(filtro)).ToList();
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

        public async Task<EstadoTo> ObtenerEstadoPorIdAsync(int id)
        {
            EstadoTo estado = new EstadoTo();
            using (var Contexto = ViveVolarDbContext.GetDbContext())
            {
                var estadoRepositorio = new EstadoRepository(Contexto);
                var result = await estadoRepositorio.ObtenerPorId(id.ToString());
                estado = Mapper.Map<EstadoTo>(result);
            }
            return estado;
        }

        public ICollection<EstadoTo> ObtenerEstadosPorFiltro(FiltroGeograficoTo filtro)
        {
            List<EstadoTo> estados = new List<EstadoTo>();
            using (var Contexto = ViveVolarDbContext.GetDbContext())
            {
                var estadoRepositorio = new EstadoRepository(Contexto);
                var expressionFilter = ConstruirExpresionConsultaEstadoPorFiltroGeografico(filtro);
                if (expressionFilter != null)
                {
                    var result = estadoRepositorio.Filtrar(expressionFilter).ToList();
                    estados = Mapper.Map<List<EstadoTo>>(result);
                }
                else
                {
                    Expression<Func<Ciudad, bool>> filtroInfo = null;
                    var ciudadRepositorio = new CiudadRepository(Contexto);

                    if (filtro.JerarquiaGeografica == FiltroGeografico.IdCiudad)
                        filtroInfo = c => c.Id == filtro.Id;

                    var result = ciudadRepositorio.Filtrar(filtroInfo).Select(c => c.Estado).ToList();
                    estados = Mapper.Map<List<EstadoTo>>(result);
                }
            }
            return estados;
        }

        public Expression<Func<Estado, bool>> ConstruirExpresionConsultaEstadoPorFiltroGeografico(FiltroGeograficoTo filtro)
        {
            Expression<Func<Estado, bool>> filtroInfo = null;
            switch (filtro.JerarquiaGeografica)
            {
                case FiltroGeografico.IdEstado:
                    filtroInfo = a => a.Id == filtro.Id;
                    break;
                case FiltroGeografico.IdPais:
                    filtroInfo = a => a.Pais.Id == filtro.Id;
                    break;
            }
            return filtroInfo;
        }

        public async Task<OrigenDestinoTo> ObtenerOrigenDestinoPorIdAsync(int id)
        {
            OrigenDestinoTo origenDestino = new OrigenDestinoTo();
            using (var Contexto = ViveVolarDbContext.GetDbContext())
            {
                var origenDestinoRepositorio = new OrigenDestinoRepository(Contexto);
                var result = await origenDestinoRepositorio.ObtenerPorId(id.ToString());
                origenDestino = Mapper.Map<OrigenDestinoTo>(result);
            }
            return origenDestino;
        }

        public ICollection<OrigenDestinoTo> ObtenerOrigenesDestinosPorFiltro(FiltroGeograficoTo filtro)
        {
            List<OrigenDestinoTo> origenesDestinos = new List<OrigenDestinoTo>();
            using (var Contexto = ViveVolarDbContext.GetDbContext())
            {
                List<AeropuertoTo> aeropuertos = new List<AeropuertoTo>();
                aeropuertos = ObtenerAeropuertosPorFiltro(filtro).ToList();
                foreach (var a in aeropuertos)
                {
                    origenesDestinos.AddRange(a.OrigenDestinos);
                }
            }
            return origenesDestinos;
        }

        public ICollection<PaisTo> ObtenerPaisesPorFiltro(FiltroGeograficoTo filtro)
        {
            List<PaisTo> paises = new List<PaisTo>();
            if (filtro.JerarquiaGeografica != FiltroGeografico.IdPais)
                paises.Add(ObtenerEstadosPorFiltro(filtro).FirstOrDefault().Pais);
            else
                paises.Add(ObtenerPaisPorIdAsync(filtro.Id).Result);
            return paises;
        }

        public async Task<PaisTo> ObtenerPaisPorIdAsync(int id)
        {
            PaisTo pais = new PaisTo();
            using (var Contexto = ViveVolarDbContext.GetDbContext())
            {
                var paisRepositorio = new PaisRepository(Contexto);
                var result = await paisRepositorio.ObtenerPorId(id.ToString());
                pais = Mapper.Map<PaisTo>(result);
            }
            return pais;
        }
    }
}
