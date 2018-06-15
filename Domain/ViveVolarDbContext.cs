using Common.Auxiliares;
using Common.Constantes;
using Domain.Entidades;
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.Validation;
using System.Linq;

namespace Domain
{
    public class ViveVolarDbContext : DbContext
    {
        #region Constructores
        public string ConnectionString { get; set; }

        public ViveVolarDbContext() : base("ViveVolarDbConnectionString") { }

        public ViveVolarDbContext(string connectionStringName) : base("name=" + connectionStringName)
        {
            ejecutarInicializador(TipoInicializador.Ninguno);
        }
        #endregion

        #region Propiedades
        public DbSet<Pais> Paises { get; set; }
        public DbSet<Estado> Estados { get; set; }
        public DbSet<Ciudad> Ciudades { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Aeropuerto> Aeropuertos { get; set; }
        public DbSet<OrigenDestino> OrigenesDestinos { get; set; }
        public DbSet<Vuelo> Vuelos { get; set; }
        public DbSet<Pasajero> Pasajeros { get; set; }
        public DbSet<Reserva> Reservas { get; set; }
        public DbSet<Itinerario> Itinerarios { get; set; }
        #endregion

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Properties().Configure(cppc => cppc.HasColumnName(cppc.ClrPropertyInfo.Name.ToUpper()));
            modelBuilder.Entity<Vuelo>().Property(i => i.ValorInicialTicket).HasColumnType("Money");
            modelBuilder.Entity<Itinerario>().Property(i => i.ValorFinalTicket).HasColumnType("Money");
            base.OnModelCreating(modelBuilder);
        }

        private void ejecutarInicializador(TipoInicializador tipoInicializador)
        {
            switch (tipoInicializador)
            {
                case TipoInicializador.Ninguno:
                    Database.SetInitializer<ViveVolarDbContext>(null);
                    break;
                case TipoInicializador.NoExiste:
                    Database.SetInitializer(new ViveVolarNoExisteDBInitializer());
                    break;
                case TipoInicializador.ModeloCambio:
                    Database.SetInitializer(new ViveVolarModeloCambioDBInitializer());
                    break;
                case TipoInicializador.Siempre:
                    Database.SetInitializer(new ViveVolarSiempreDBInitializer());
                    break;
                case TipoInicializador.Migracion:
                    Database.SetInitializer(new ViveVolarMigracionDBInitializer());
                    break;
            }
        }

        private class ViveVolarNoExisteDBInitializer : CreateDatabaseIfNotExists<ViveVolarDbContext>
        {
            protected override void Seed(ViveVolarDbContext context)
            {
                Rol admin = new Rol();
                admin.Nombre = "Administrador";
                admin.Descripcion = "Administrador de la plataforma";
                context.Roles.Add(admin);
                //context.Roles.Add(new Rol() {Nombre = "administrador", Descripcion = "Administrador de la plataforma" });
                base.Seed(context);
            }
        }

        private class ViveVolarModeloCambioDBInitializer : DropCreateDatabaseIfModelChanges<ViveVolarDbContext>
        {
            protected override void Seed(ViveVolarDbContext context)
            {
                context.Paises.Add(new Domain.Entidades.Pais() { Nombre = "Colombia", Habilitado = "S" });
                base.Seed(context);
            }
        }

        private class ViveVolarSiempreDBInitializer : DropCreateDatabaseAlways<ViveVolarDbContext>
        {
            protected override void Seed(ViveVolarDbContext context)
            {
                Rol admin = new Rol();
                admin.Nombre = "Administrador";
                admin.Descripcion = "Administrador de la plataforma";
                context.Roles.Add(admin);
                base.Seed(context);
            }
        }

        private class ViveVolarMigracionDBInitializer : MigrateDatabaseToLatestVersion<ViveVolarDbContext, Domain.Migrations.Configuration> { }

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
            if (ex.InnerException != null)
            {
                throw MejorarExcepcion(ex.InnerException);
            }

            var mensaje = string.Concat("---> The inner exception is: ", ex.Message);

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
