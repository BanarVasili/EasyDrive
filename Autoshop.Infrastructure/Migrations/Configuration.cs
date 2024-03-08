using System.Data.Entity.Migrations;

namespace Autoshop.Infrastructure.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<Autoshop.Infrastructure.JewelryStoreContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Autoshop.Infrastructure.JewelryStoreContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
