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

namespace CoreTest
{
    #region Pruebas de Integración
    //Pruebas de integración con la base de datos
    public partial class CoreTest
    {
        [TestMethod]
        public void ObtenerVueloPorIdAsync() { }

        [TestMethod]
        public void ObtenerVuelosPorFiltro() { }

        [TestMethod]
        public void GuardarNuevoVuelo() { }

        [TestMethod]
        public void GuardarNuevosVuelos() { }

        [TestMethod]
        public void ActualizarVuelo() { }

        [TestMethod]
        public void ActualizarVuelos() { }
    }
    #endregion
}
