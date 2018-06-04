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
                    contexto.Paises.Add(new Domain.Entidades.Pais() {Nombre="Colombia"});
                    //contexto.Usuarios.Add(new Domain.Entidades.Usuario() { Correo = "ajjbdeveloper@gmail.com", Clave = "alvaro", IdRol = 1, NombreCompleto = "Alvaro Jose Julio Beltrán" });
                    contexto.SaveChanges();
                    //Assert.IsTrue(contexto.Database.Exists());
                }
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
                Console.WriteLine("Se presentó el siguiente error: " + ex.Message);
            }
        }
    }
}
