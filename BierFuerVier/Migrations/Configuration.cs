namespace BierFuerVier.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Drawing;
    using System.IO;
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
                new User() { Id = 4, Email = "lukas@bierfuervier.ch", Password = "1234" }
                );

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            context.Beer.AddOrUpdate(x => x.Id,
                new Beer() { Id = 1, Name = "Eichhof Lager", Image = ImageToByte(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "../Migrations/lager.png")), Description = "Sein feines Malzaroma und seine Milde machen unser Lager zum Klassiker. Es ist goldgelb und fein im Geschmack." },
                new Beer() { Id = 2, Name = "Eichhof Retro", Image = ImageToByte(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "../Migrations/retro.png")), Description = "Ein Bier von damals, unkompliziert und authentisch vom Geschmack bis hin zur Verpackung. Eine Hefe aus den 70er Jahren bringt den unbekümmerten Geschmack des Lagers zurück: Einfach, bodenständig, süffig. Kurz: Der Geschmack der guten alten Zeiten." },
                new Beer() { Id = 3, Name = "Eichhof Braugold", Image = ImageToByte(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "../Migrations/braugold.png")), Description = "Das aufwendige Brauverfahren gibt unserem Braugold seinen angenehm herben Charakter und ein rundes Aroma. Braugold ist unser Premiumbier für Freunde der herben Linie." }
                );
        }

        private byte[] ImageToByte(string path)
        {
            MemoryStream ms = new MemoryStream();
            Image image = Image.FromFile(path);
            image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            return ms.ToArray();
        }
    }
}
