using Common.To.Maestros;
using Common.Constantes;
using Core;
using Core.Vuelos;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using Unity;
using Core.Vuelos.BdRepositories;
using Domain;
using Unity.Lifetime;
using Common.To.Vuelos;
using System;
using System.Threading.Tasks;

namespace CoreTest
{
    #region Pruebas de Integración
    //Pruebas de integración con la base de datos
    public partial class CoreTest
    {
        [TestMethod]
        public async Task ObtenerVueloPorIdAsync() {
            int idVuelo = 1;
            var result = await _vuelosRepo.ObtenerVueloPorIdAsync(idVuelo);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void ObtenerVuelosPorFiltro() {
            FiltroVuelosTo filtro = new FiltroVuelosTo();
            filtro.CriterioBusquedaOrigen = FiltroVueloOrigen.IdOrigen;
            filtro.CriterioBusquedaDestino= FiltroVueloDestino.IdDestino;
            filtro.IdOrigen = 2;
            filtro.IdDestino = 1;
            filtro.FechaOrigen = new DateTime(2018, 6, 21);
            filtro.FechaDestino = new DateTime(2018, 6, 21);
            var result = _vuelosRepo.ObtenerVuelosPorFiltro(filtro);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GuardarNuevoVuelo() {
            VueloTo vuelo = new VueloTo() { IdOrigen = 1, IdDestino = 2, HoraSalida = DateTime.UtcNow, HoraLlegada = DateTime.UtcNow.AddHours(5), Habilitado = "S", NumPasajeros = 60, ValorInicialTicket = 84300 };
            _vuelosRepo.GuardarNuevoVuelo(vuelo);
        }

        [TestMethod]
        public void GuardarNuevosVuelos() {
            List<VueloTo> vuelos = new List<VueloTo>();
            VueloTo vuelo1 = new VueloTo() { IdOrigen = 2, IdDestino = 1, HoraSalida = DateTime.UtcNow, HoraLlegada = DateTime.UtcNow.AddHours(5), Habilitado = "S", NumPasajeros = 120, ValorInicialTicket = 175000 };
            VueloTo vuelo2 = new VueloTo() { IdOrigen = 1, IdDestino = 2, HoraSalida = DateTime.UtcNow, HoraLlegada = DateTime.UtcNow.AddHours(5), Habilitado = "N", NumPasajeros = 90, ValorInicialTicket = 275920 };
            vuelos.Add(vuelo1);
            vuelos.Add(vuelo2);
            _vuelosRepo.GuardarNuevosVuelos(vuelos);
        }

        [TestMethod]
        public void ActualizarVuelo() {
            VueloTo vuelo1 = new VueloTo() { Id = 1003,  IdOrigen = 2, IdDestino = 1, HoraSalida = DateTime.UtcNow, HoraLlegada = DateTime.UtcNow.AddHours(5), Habilitado = "N", NumPasajeros = 75, ValorInicialTicket = 651000};
            _vuelosRepo.ActualizarVuelo(vuelo1);
        }

        [TestMethod]
        public void ActualizarVuelos() {
            List<VueloTo> vuelos = new List<VueloTo>();
            VueloTo vuelo1 = new VueloTo() { Id = 1003, IdOrigen = 2, IdDestino = 1, HoraSalida = DateTime.UtcNow, HoraLlegada = DateTime.UtcNow.AddHours(5), Habilitado = "S", NumPasajeros = 120, ValorInicialTicket = 175000 };
            VueloTo vuelo2 = new VueloTo() { Id = 1004, IdOrigen = 1, IdDestino = 2, HoraSalida = DateTime.UtcNow, HoraLlegada = DateTime.UtcNow.AddHours(5), Habilitado = "S", NumPasajeros = 200, ValorInicialTicket = 1213 };
            vuelos.Add(vuelo1);
            vuelos.Add(vuelo2);
            _vuelosRepo.ActualizarVuelos(vuelos);
        }
    }
    #endregion
}
