using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain;
using Domain.Migrations;
using System.Data.Entity.Migrations;

namespace DomainTest
{
    [TestClass]
    public class DomainTest
    {
        [TestMethod]
        public void InicializarBd()
        {
            try
            {
                using (ViveVolarDbContext contexto = ViveVolarDbContext.GetDbContext())
                {
                    var ciudad = contexto.Ciudades.FindAsync(1);
                    //contexto.Paises.Add(new Domain.Entidades.Pais() {Nombre="COLOMBIA", Habilitado= "S"});
                    //contexto.Usuarios.Add(new Domain.Entidades.Usuario() { Correo = "ajjbdeveloper@gmail.com", Clave = "alvaro", IdRol = 1, NombreCompleto = "Alvaro Jose Julio Beltrán" });
                    //contexto.SaveChanges();
                    Assert.IsTrue(contexto.Database.Exists());
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
