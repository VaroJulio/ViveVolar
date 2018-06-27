using Common.To.Maestros;
using Common.Constantes;
using Core;
using Core.Maestros;
using Core.Vuelos;
using Core.Reservas;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using Unity;
using Core.Maestros.BdRepositories;
using Core.Vuelos.BdRepositories;
using Core.Reservas.BdRepositories;
using Domain;

namespace CoreTest
{
    #region Pruebas de Integración
    //Pruebas de integración con la base de datos
    [TestClass]
    public partial class CoreTest
    {
        //Repositorio a inyectar.
        private MaestroRepository _maestroRepo;
        private VuelosRepository _vuelosRepo;
        private ReservasRepository _reservasRepo;

        [TestInitialize]
        public void Inicializar()
        {
            //Se registran los mapeos y se hace inyección de dependencias en el método donde se inicializa el Test
            AutoMapperConfig.RegistrarMapeosGlobales();
            using (var Contexto = ViveVolarDbContext.GetDbContext())
            {
                IUnityContainer contenedor = new UnityContainer();

                contenedor.RegisterType<PaisRepository>(new Unity.Injection.InjectionConstructor(Contexto));
                contenedor.RegisterType<EstadoRepository>(new Unity.Injection.InjectionConstructor(Contexto));
                contenedor.RegisterType<CiudadRepository>(new Unity.Injection.InjectionConstructor(Contexto));
                contenedor.RegisterType<AeropuertoRepository>(new Unity.Injection.InjectionConstructor(Contexto));
                contenedor.RegisterType<OrigenDestinoRepository>(new Unity.Injection.InjectionConstructor(Contexto));
                _maestroRepo = contenedor.Resolve<MaestroRepository>();

                contenedor.RegisterType<VueloRepository>(new Unity.Injection.InjectionConstructor(Contexto));
                _vuelosRepo = contenedor.Resolve<VuelosRepository>();

                contenedor.RegisterType<ReservaRepository>(new Unity.Injection.InjectionConstructor(Contexto));
                contenedor.RegisterType<PasajeroRepository>(new Unity.Injection.InjectionConstructor(Contexto));
                contenedor.RegisterType<ItinerarioRepository>(new Unity.Injection.InjectionConstructor(Contexto));
                _reservasRepo = contenedor.Resolve<ReservasRepository>();
            }
        }

        //Se limpian los mapeos.
        [TestCleanup]
        public void Limpiar()
        {
            AutoMapperConfig.LimpiarMapeosGlobales();
        }

        [TestMethod]
        public void ObtenerAeropuertoPorId()
        {
            AeropuertoTo aeropuerto = _maestroRepo.ObtenerAeropuertoPorIdAsync(1).Result;
            Assert.IsTrue(aeropuerto.Nombre != null);
        }

        [TestMethod]
        public void ObtenerAeropuertosPorFiltro()
        {
            List<AeropuertoTo> aeropuertos = _maestroRepo.ObtenerAeropuertosPorFiltro(new FiltroGeograficoTo() { Id = 1, JerarquiaGeografica = FiltroGeografico.IdPais }).ToList();
            Assert.IsTrue(aeropuertos.Count > 0);
        }

        [TestMethod]
        public void ObtenerAeropuertosPorFiltroAeropuerto()
        {
            List<AeropuertoTo> aeropuertos = _maestroRepo.ObtenerAeropuertosPorFiltro(new FiltroAeropuertoTo() { Id = "BOG", IdFiltroBusqueda = FiltroAeropuerto.CodMundial }).ToList();
            Assert.IsTrue(aeropuertos.Count > 0);
        }

        [TestMethod]
        public void ObtenerPaisPorIdAsync()
        {
            PaisTo pais = _maestroRepo.ObtenerPaisPorIdAsync(1).Result;
            Assert.IsTrue(pais.Nombre != null);
        }

        [TestMethod]
        public void ObtenerEstadoPorIdAsync()
        {
            EstadoTo estado = _maestroRepo.ObtenerEstadoPorIdAsync(1).Result;
            Assert.IsTrue(estado.Nombre != null);
        }

        [TestMethod]
        public void ObtenerCiudadPorIdAsync()
        {
            CiudadTo ciudad = _maestroRepo.ObtenerCiudadPorIdAsync(1).Result;
            Assert.IsTrue(ciudad.Nombre != null);
        }

        [TestMethod]
        public void ObtenerOrigenDestinoPorIdAsync()
        {
            OrigenDestinoTo origenDestino = _maestroRepo.ObtenerOrigenDestinoPorIdAsync(1).Result;
            Assert.IsTrue(origenDestino.Nombre != null);
        }

        [TestMethod]
        public void ObtenerPaisesPorFiltro()
        {
            List<PaisTo> paises = _maestroRepo.ObtenerPaisesPorFiltro(new FiltroGeograficoTo() { Id = 1, JerarquiaGeografica = FiltroGeografico.IdPais }).ToList();
            Assert.IsTrue(paises.Count > 0);
        }

        [TestMethod]
        public void ObtenerEstadosPorFiltro()
        {
            List<EstadoTo> estados = _maestroRepo.ObtenerEstadosPorFiltro(new FiltroGeograficoTo() { Id = 1, JerarquiaGeografica = FiltroGeografico.IdPais }).ToList();
            Assert.IsTrue(estados.Count > 0);
        }

        [TestMethod]
        public void ObtenerCiudadesPorFiltro()
        {
            List<CiudadTo> ciudades = _maestroRepo.ObtenerCiudadesPorFiltro(new FiltroGeograficoTo() { Id = 1, JerarquiaGeografica = FiltroGeografico.IdPais }).ToList();
            Assert.IsTrue(ciudades.Count > 0);
        }

        [TestMethod]
        public void ObtenerOrigenesDestinosPorFiltro()
        {
            List<OrigenDestinoTo> origenesDestinos = _maestroRepo.ObtenerOrigenesDestinosPorFiltro(new FiltroGeograficoTo() { Id = 1, JerarquiaGeografica = FiltroGeografico.IdPais }).ToList();
            Assert.IsTrue(origenesDestinos.Count > 0);
        }
    }
    #endregion
}
