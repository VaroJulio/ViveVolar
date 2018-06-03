using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain;

namespace DomainTest
{
    [TestClass]
    public class AccesoDatosTest
    {
        [TestMethod]
        public void InicializarBd()
        {
            try
            {
                using (ViveVolarDbContext contexto = ViveVolarDbContext.GetDbContext())
                {
                    Assert.IsTrue(contexto.Database.Exists());
                }
            }
            catch (Exception ex)
            {
                Assert.Fail("No existe la base de datos");
                Console.WriteLine("Se presentó el siguiente error: " + ex.Message);
            }
        }
    }
}
