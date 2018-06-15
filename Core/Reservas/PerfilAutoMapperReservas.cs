using AutoMapper;
using Common.To.Reservas;
using Domain.Entidades;

namespace Core.Reservas
{
    public class PerfilAutoMapperReservas : Profile
    {
        public PerfilAutoMapperReservas()
        {
            CreateMap<Reserva, ReservaTo>()
               .ForMember(dest => dest.IdReserva, options => options.MapFrom(source => source.IdReserva))
               .ForMember(dest => dest.CodigoConsultaReserva, options => options.MapFrom(source => source.CodigoConsultaReserva))
               .ForMember(dest => dest.FechaReserva, options => options.MapFrom(source => source.FechaReserva))
               .ForMember(dest => dest.Correo, options => options.MapFrom(source => source.Correo))
               .ForMember(dest => dest.Itinerarios, options => options.MapFrom(source => source.Itinerarios)).ReverseMap()
               .ForAllOtherMembers(options => options.Ignore());

            CreateMap<Itinerario, ItinerarioTo>()
              .ForMember(dest => dest.Id, options => options.MapFrom(source => source.Id))
              .ForMember(dest => dest.IdReserva, options => options.MapFrom(source => source.IdReserva))
              .ForMember(dest => dest.IdVuelo, options => options.MapFrom(source => source.IdVuelo))
              .ForMember(dest => dest.IdentificacionPasajero, options => options.MapFrom(source => source.IdentificacionPasajero))
              .ForMember(dest => dest.ValorFinalTicket, options => options.MapFrom(source => source.ValorFinalTicket))
              .ForMember(dest => dest.Pasajero, options => options.MapFrom(source => source.Pasajero))
              .ForMember(dest => dest.Reserva, options => options.MapFrom(source => source.Reserva))
              .ForMember(dest => dest.Vuelo, options => options.MapFrom(source => source.Vuelo)).ReverseMap()
              .ForAllOtherMembers(options => options.Ignore());

            CreateMap<Pasajero, PasajeroTo>()
             .ForMember(dest => dest.Identificacion, options => options.MapFrom(source => source.Identificacion))
             .ForMember(dest => dest.NombreCompleto, options => options.MapFrom(source => source.NombreCompleto))
             .ForMember(dest => dest.FechaNacimiento, options => options.MapFrom(source => source.FechaNacimiento))
             .ForMember(dest => dest.Correo, options => options.MapFrom(source => source.Correo))
             .ForMember(dest => dest.Telefono, options => options.MapFrom(source => source.Telefono))
             .ForMember(dest => dest.Itinerarios, options => options.MapFrom(source => source.Itinerarios)).ReverseMap()
             .ForAllOtherMembers(options => options.Ignore());
        }
    }
}
