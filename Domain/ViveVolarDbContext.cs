using Common.Auxiliares;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class ViveVolarDbContext : DbContext
    {
        public string ConnectionString { get; set; }
        public ViveVolarDbContext(string connectionStringName) : base("name=" + connectionStringName)
        {
            // Permite desactivar las migraciones a la base de datos
            Database.SetInitializer<ViveVolarDbContext>(null);
        }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{

        //}

        public override int SaveChanges()
        {
            try
            {
                return base.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                throw MejorarExcepcion(ex);
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    throw MejorarExcepcion(ex);
                }
                else
                {
                    throw;
                }
            }
        }

        public static ViveVolarDbContext GetDbContext()
        {
            var dbContext = (ViveVolarDbContext)null;
            var connectionStringName = AuxiliarViveVolar.ObtenerAtributoDeConfiguracion("NombreCadenaConexion", true);

            if (!string.IsNullOrEmpty(connectionStringName))
            {
                dbContext = new ViveVolarDbContext(connectionStringName);
            }

            return dbContext;
        }

        private static Exception MejorarExcepcion(Exception ex)
        {
            var mensaje = string.Concat(
                ex.Message, "---> The inner exception is: ", ex.InnerException.Message
            );

            var excepcion = new Exception(mensaje, ex);

            return excepcion;
        }

        private static DbEntityValidationException MejorarExcepcion(
            DbEntityValidationException ex)
        {
            var listaMensajes = ex.EntityValidationErrors
                    .SelectMany(x => x.ValidationErrors)
                    .Select(x => x.ErrorMessage);

            var mensaje = string.Concat(
                ex.Message, "---> The validation errors are: ",
                string.Join("; ", listaMensajes)
            );

            var excepcion = new DbEntityValidationException(
                mensaje, ex.EntityValidationErrors
            );

            return excepcion;
        }
    }
}
