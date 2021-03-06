﻿using AutoMapper;
using AutoMapper.Configuration;

namespace Core
{
    public static class AutoMapperConfig
    {
        public static void RegistrarMapeosGlobales()
        {
            MapperConfigurationExpression configuracionAutoMapper = new MapperConfigurationExpression();

            configuracionAutoMapper.ShouldMapProperty = pi => pi.GetAccessors().Length > 0 ? !pi.GetAccessors()[0].IsVirtual : false;

            //EstablecerConfiguracionAutoMapper(ref configuracionAutoMapper);
            configuracionAutoMapper.AddProfiles(typeof(AutoMapperConfig).Assembly);

            Mapper.Initialize(configuracionAutoMapper);

            Mapper.AssertConfigurationIsValid();
        }

        public static void LimpiarMapeosGlobales()
        {
            Mapper.Reset();
        }
    }
}
