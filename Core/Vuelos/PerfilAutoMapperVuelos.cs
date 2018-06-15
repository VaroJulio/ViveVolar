using AutoMapper;
using Common.To.Vuelos;
using Domain.Entidades;

namespace Core.Vuelos
{
    public class PerfilAutoMapperVuelos : Profile
    {
        public PerfilAutoMapperVuelos()
        {
            CreateMap<Vuelo, VueloTo>()
               .ForMember(dest => dest.Id, options => options.MapFrom(source => source.Id))
               .ForMember(dest => dest.IdOrigen, options => options.MapFrom(source => source.IdOrigen))
               .ForMember(dest => dest.HoraSalida, options => options.MapFrom(source => source.HoraSalida))
               .ForMember(dest => dest.IdDestino, options => options.MapFrom(source => source.IdDestino))
               .ForMember(dest => dest.HoraLlegada, options => options.MapFrom(source => source.HoraLlegada))
               .ForMember(dest => dest.NumPasajeros, options => options.MapFrom(source => source.NumPasajeros))
               .ForMember(dest => dest.ValorInicialTicket, options => options.MapFrom(source => source.ValorInicialTicket))
               .ForMember(dest => dest.Habilitado, options => options.MapFrom(source => source.Habilitado))
               .ForMember(dest => dest.Origen, options => options.MapFrom(source => source.Origen))
               .ForMember(dest => dest.Destino, options => options.MapFrom(source => source.Destino))
               .ForMember(dest => dest.Itinerarios, options => options.MapFrom(source => source.Itinerarios)).ReverseMap()
               .ForAllOtherMembers(options => options.Ignore());
        }
    }
}
