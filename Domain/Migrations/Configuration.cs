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

        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "ViveVolarDbContext";
        }

        protected override void Seed(ViveVolarDbContext context)
        {
            //  This method will be called after migrating to the latest version.
            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data. E.g.

            //  context.People.AddOrUpdate(
            //  p ⇒ p.FullName, 
            //  new Person { FullName = "Andrew Peters" }, 
            //  new Person { FullName = "Brice Lambson" }, 
            //  new Person { FullName = "Rowan Miller" }
            //  );
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

    public partial class UpdateEstaHabilitadoOrigenDEstinoField : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Origenesdestinos", "Habilitado", c => c.Boolean(nullable: false, defaultValueSql: "true"));
        }

        public override void Down()
        {
        }
    }
}
