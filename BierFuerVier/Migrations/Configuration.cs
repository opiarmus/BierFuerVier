namespace BierFuerVier.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BierFuerVier.Models.DbAccess>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(BierFuerVier.Models.DbAccess context)
        {
            context.User.AddOrUpdate(x => x.Id,
                new User() { Id = 1, Email = "chef@bierfuervier.ch", Password = "1234" },
                new User() { Id = 2, Email = "patrick@bierfuervier.ch", Password = "1234" },
                new User() { Id = 3, Email = "luca@bierfuervier.ch", Password = "1234" },
                new User() { Id = 3, Email = "lukas@bierfuervier.ch", Password = "1234" }
                );

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
