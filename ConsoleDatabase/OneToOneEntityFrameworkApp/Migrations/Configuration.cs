namespace OneToOneEntityFrameworkApp.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<OneToOneEntityFrameworkApp.SwabhavDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "OneToOneEntityFrameworkApp.SwabhavDBContext";
        }

        protected override void Seed(OneToOneEntityFrameworkApp.SwabhavDBContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
