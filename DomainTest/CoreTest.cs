using Common.To.Maestros;
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
        }
    }
}
