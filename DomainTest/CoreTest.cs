using Common.To.Maestros;
using Common.Constantes;
using Core;
using Core.Maestros;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreTest
{
    [TestClass]
    public class CoreTest
    {
        [TestMethod]
        public void ObtenerAeropuertoPorId()
        {
            AutoMapperConfig.RegistrarMapeosGlobales();
            int id = 1;
            IMaestrosRepository repositorio = new MaestroRepository();
            AeropuertoTo aeropuerto = repositorio.ObtenerAeropuertoPorIdAsync(id).Result;
            Assert.IsTrue(aeropuerto.Nombre != null);
        }

        [TestMethod]
        public void ObtenerAeropuertosPorFiltro()
        {
            AutoMapperConfig.RegistrarMapeosGlobales();
            IMaestrosRepository repositorio = new MaestroRepository();
            List<AeropuertoTo> aeropuertos = repositorio.ObtenerAeropuertosPorFiltro(new FiltroGeograficoTo() {Id = 1, JerarquiaGeografica = FiltroGeografico.IdPais }).ToList();
            Assert.IsTrue(aeropuertos.Count > 0);
        }

        [TestMethod]
        public void ObtenerAeropuertosPorFiltroAeropuerto()
        {
            AutoMapperConfig.RegistrarMapeosGlobales();
            IMaestrosRepository repositorio = new MaestroRepository();
            List<AeropuertoTo> aeropuertos = repositorio.ObtenerAeropuertosPorFiltro(new FiltroAeropuertoTo() { Id = "BOG", IdFiltroBusqueda = FiltroAeropuerto.CodMundial}).ToList();
            Assert.IsTrue(aeropuertos.Count > 0);
        }

        [TestMethod]
        public void ObtenerPaisPorIdAsync()
        {
            AutoMapperConfig.RegistrarMapeosGlobales();
            int id = 1;
            IMaestrosRepository repositorio = new MaestroRepository();
            PaisTo pais = repositorio.ObtenerPaisPorIdAsync(id).Result;
            Assert.IsTrue(pais.Nombre != null);
        }

        [TestMethod]
        public void ObtenerEstadoPorIdAsync()
        {
            AutoMapperConfig.RegistrarMapeosGlobales();
            int id = 1;
            IMaestrosRepository repositorio = new MaestroRepository();
            EstadoTo estado = repositorio.ObtenerEstadoPorIdAsync(id).Result;
            Assert.IsTrue(estado.Nombre != null);
        }

        [TestMethod]
        public void ObtenerCiudadPorIdAsync()
        {
            AutoMapperConfig.RegistrarMapeosGlobales();
            int id = 1;
            IMaestrosRepository repositorio = new MaestroRepository();
            CiudadTo ciudad = repositorio.ObtenerCiudadPorIdAsync(id).Result;
            Assert.IsTrue(ciudad.Nombre != null);
        }

        [TestMethod]
        public void ObtenerOrigenDestinoPorIdAsync()
        {
            AutoMapperConfig.RegistrarMapeosGlobales();
            int id = 1;
            IMaestrosRepository repositorio = new MaestroRepository();
            OrigenDestinoTo origenDestino = repositorio.ObtenerOrigenDestinoPorIdAsync(id).Result;
            Assert.IsTrue(origenDestino.Nombre != null);
        }

        [TestMethod]
        public void ObtenerPaisesPorFiltro()
        {
            AutoMapperConfig.RegistrarMapeosGlobales();
            int id = 1;
            IMaestrosRepository repositorio = new MaestroRepository();
            List<PaisTo> paises = repositorio.ObtenerPaisesPorFiltro(new FiltroGeograficoTo() { Id = id, JerarquiaGeografica = FiltroGeografico.IdPais }).ToList();
            Assert.IsTrue(paises.Count > 0);
        }

        [TestMethod]
        public void ObtenerEstadosPorFiltro()
        {
            AutoMapperConfig.RegistrarMapeosGlobales();
            int id = 1;
            IMaestrosRepository repositorio = new MaestroRepository();
            List<EstadoTo> estados = repositorio.ObtenerEstadosPorFiltro(new FiltroGeograficoTo() { Id = id, JerarquiaGeografica = FiltroGeografico.IdPais }).ToList();
            Assert.IsTrue(estados.Count > 0);
        }

        [TestMethod]
        public void ObtenerCiudadesPorFiltro()
        {
            AutoMapperConfig.RegistrarMapeosGlobales();
            int id = 1;
            IMaestrosRepository repositorio = new MaestroRepository();
            List<CiudadTo> ciudades = repositorio.ObtenerCiudadesPorFiltro(new FiltroGeograficoTo() { Id = id, JerarquiaGeografica = FiltroGeografico.IdPais }).ToList();
            Assert.IsTrue(ciudades.Count > 0);
        }

        [TestMethod]
        public void ObtenerOrigenesDestinosPorFiltro()
        {
            AutoMapperConfig.RegistrarMapeosGlobales();
            int id = 1;
            IMaestrosRepository repositorio = new MaestroRepository();
            List<OrigenDestinoTo> origenesDestinos = repositorio.ObtenerOrigenesDestinosPorFiltro(new FiltroGeograficoTo() { Id = id, JerarquiaGeografica = FiltroGeografico.IdPais }).ToList();
            Assert.IsTrue(origenesDestinos.Count > 0);
        }



    }
}
