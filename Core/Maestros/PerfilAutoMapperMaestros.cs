using AutoMapper;
using Common.To.Maestros;
using Domain.Entidades;

namespace Core.Maestros
{
    public class PerfilAutoMapperMaestros : Profile
    {
        public PerfilAutoMapperMaestros()
        {
            CreateMap<Aeropuerto, AeropuertoTo>()
                .ForMember(dest => dest.Id, options => options.MapFrom(source => source.Id))
                .ForMember(dest => dest.CodigoMundial, options => options.MapFrom(source => source.CodigoMundial))
                .ForMember(dest => dest.Nombre, options => options.MapFrom(source => source.Nombre))
                .ForMember(dest => dest.IdCiudad, options => options.MapFrom(source => source.IdCiudad))
                .ForMember(dest => dest.Habilitado, options => options.MapFrom(source => source.Habilitado))
                .ForMember(dest => dest.Ciudad, options => options.MapFrom(source => source.Ciudad))
                .ForMember(dest => dest.OrigenDestinos, options => options.MapFrom(source => source.OrigenDestinos))
                .ForAllOtherMembers(options => options.Ignore());
            CreateMap<Ciudad, CiudadTo>()
                .ForMember(dest => dest.Id, options => options.MapFrom(source => source.Id))
                .ForMember(dest => dest.Nombre, options => options.MapFrom(source => source.Nombre))
                .ForMember(dest => dest.IdEstado, options => options.MapFrom(source => source.IdEstado)) 
                .ForMember(dest => dest.Habilitado, options => options.MapFrom(source => source.Habilitado))
                .ForMember(dest => dest.Estado, options => options.MapFrom(source => source.Estado))
                .ForMember(dest => dest.Aeropuertos, options => options.MapFrom(source => source.Aeropuertos))
                .ForAllOtherMembers(options => options.Ignore());
            CreateMap<Pais, PaisTo>()
                .ForMember(dest => dest.Id, options => options.MapFrom(source => source.Id))
                .ForMember(dest => dest.Nombre, options => options.MapFrom(source => source.Nombre))
                .ForMember(dest => dest.Habilitado, options => options.MapFrom(source => source.Habilitado))
                .ForMember(dest => dest.Estados, options => options.MapFrom(source => source.Estados))
                .ForAllOtherMembers(options => options.Ignore());
            CreateMap<Estado, EstadoTo>()
                .ForMember(dest => dest.Id, options => options.MapFrom(source => source.Id))
                .ForMember(dest => dest.Nombre, options => options.MapFrom(source => source.Nombre))
                .ForMember(dest => dest.IdPais, options => options.MapFrom(source => source.IdPais))
                .ForMember(dest => dest.Habilitado, options => options.MapFrom(source => source.Habilitado))              
                .ForMember(dest => dest.Pais, options => options.MapFrom(source => source.Pais))
                .ForMember(dest => dest.Ciudades, options => options.MapFrom(source => source.Ciudades))
                .ForAllOtherMembers(options => options.Ignore());
            CreateMap<OrigenDestino, OrigenDestinoTo>()
                .ForMember(dest => dest.Id, options => options.MapFrom(source => source.Id))
                .ForMember(dest => dest.IdAeropuerto, options => options.MapFrom(source => source.IdAeropuerto))
                .ForMember(dest => dest.Nombre, options => options.MapFrom(source => source.Nombre))
                .ForMember(dest => dest.EsOrigen, options => options.MapFrom(source => source.EsOrigen))
                .ForMember(dest => dest.EsDestino, options => options.MapFrom(source => source.EsDestino))
                .ForMember(dest => dest.Habilitado, options => options.MapFrom(source => source.Habilitado))
                .ForMember(dest => dest.Aeropuerto, options => options.MapFrom(source => source.Aeropuerto))
                .ForMember(dest => dest.Vuelos, options => options.MapFrom(source => source.Vuelos))
                .ForAllOtherMembers(options => options.Ignore());
        }
    }
}
