using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<ViveVolarDbContext>
    {
        private readonly bool _pendingMigrations;

        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "ViveVolarDbContext";
            //var migrator = new DbMigrator(this);
            //DbMigration primera = new UpdateFechaTimeStampReservaField();
            //primera.Up();
            //_pendingMigrations = migrator.GetPendingMigrations().Any();
            //if (_pendingMigrations)
            //{
            //    migrator.Update();
            //    Seed(ViveVolarDbContext.GetDbContext());
            //}

            //DbMigration primera = new UpdateEstaHabilitadoField();
            //primera.Up();
            //DbMigration segunda = new UpdateFechaTimeStampReservaField();
            //segunda.Up();
            //TargetDatabase = new System.Data.Entity.Infrastructure.DbConnectionInfo("ViveVolarDbConnectionString");
        }

        protected override void Seed(ViveVolarDbContext context)
        {
            //context.SaveChanges();
            base.Seed(context);
        }
    }

    public partial class UpdateFechaTimeStampReservaField : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Reservas", "FechaReserva", c => c.DateTime(nullable: false, defaultValueSql: "GETUTCDATE()"));
        }

        public override void Down()
        {
        }
    }

    public partial class UpdateEstaHabilitadoField : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Paises", "Habilitado", c => c.Boolean(nullable: false, defaultValueSql: "true"));
            AlterColumn("dbo.Estados", "Habilitado", c => c.Boolean(nullable: false, defaultValueSql: "true"));
            AlterColumn("dbo.Ciudades", "Habilitado", c => c.Boolean(nullable: false, defaultValueSql: "true"));
            AlterColumn("dbo.Origenesdestinos", "Habilitado", c => c.Boolean(nullable: false, defaultValueSql: "true"));
            AlterColumn("dbo.Aeropuertos", "Habilitado", c => c.Boolean(nullable: false, defaultValueSql: "true"));
            AlterColumn("dbo.Vuelos", "Habilitado", c => c.Boolean(nullable: false, defaultValueSql: "true"));
        }

        public override void Down()
        {
        }
    }
}
