﻿using AutoMapper;
using Common.To.Maestros;
using Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Maestros
{
    public class PerfilAutoMapperMaestros : Profile
    {
        public PerfilAutoMapperMaestros()
        {
            CreateMap<Aeropuerto, AeropuertoTo>().ForAllOtherMembers(options => options.Ignore());
            CreateMap<Ciudad, CiudadTo>().ForAllOtherMembers(options => options.Ignore());
            CreateMap<Pais, PaisTo>().ForAllOtherMembers(options => options.Ignore());
            CreateMap<Estado, EstadoTo>().ForAllOtherMembers(options => options.Ignore());
            CreateMap<OrigenDestino, OrigenDestinoTo>().ForAllOtherMembers(options => options.Ignore());
        }
    }
}
