using Core.Maestros;
using Core.Maestros.BdRepositories;
using Core.Reservas;
using Core.Reservas.BdRepositories;
using Core.Vuelos;
using Core.Vuelos.BdRepositories;
using Domain;
using System;

using Unity;

namespace ViveVolar
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public static class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container =
          new Lazy<IUnityContainer>(() =>
          {
              var container = new UnityContainer();
              RegisterTypes(container);
              return container;
          });

        /// <summary>
        /// Configured Unity Container.
        /// </summary>
        public static IUnityContainer Container => container.Value;
        #endregion

        /// <summary>
        /// Registers the type mappings with the Unity container.
        /// </summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>
        /// There is no need to register concrete types such as controllers or
        /// API controllers (unless you want to change the defaults), as Unity
        /// allows resolving a concrete type even if it was not previously
        /// registered.
        /// </remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            // NOTE: To load from web.config uncomment the line below.
            // Make sure to add a Unity.Configuration to the using statements.
            // container.LoadConfiguration();

            // TODO: Register your type's mappings here.
            // container.RegisterType<IProductRepository, ProductRepository>();
            using (var Contexto = ViveVolarDbContext.GetDbContext())
            {
                container.RegisterType<PaisRepository>(new Unity.Injection.InjectionConstructor(Contexto));
                container.RegisterType<EstadoRepository>(new Unity.Injection.InjectionConstructor(Contexto));
                container.RegisterType<CiudadRepository>(new Unity.Injection.InjectionConstructor(Contexto));
                container.RegisterType<AeropuertoRepository>(new Unity.Injection.InjectionConstructor(Contexto));
                container.RegisterType<OrigenDestinoRepository>(new Unity.Injection.InjectionConstructor(Contexto));
                container.RegisterType<ReservaRepository>(new Unity.Injection.InjectionConstructor(Contexto));
                container.RegisterType<ItinerarioRepository>(new Unity.Injection.InjectionConstructor(Contexto));
                container.RegisterType<PasajeroRepository>(new Unity.Injection.InjectionConstructor(Contexto));
                container.RegisterType<VueloRepository>(new Unity.Injection.InjectionConstructor(Contexto));
            }
            container.RegisterType<IMaestrosRepository, MaestroRepository>();
            container.RegisterType<IReservasRepository, ReservasRepository>();
            container.RegisterType<IVuelosRepository, VuelosRepository>();
        }
    }
}