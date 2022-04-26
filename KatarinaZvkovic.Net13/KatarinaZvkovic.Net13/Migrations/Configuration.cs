namespace KatarinaZvkovic.Net13.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<KatarinaZvkovic.Net13.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(KatarinaZvkovic.Net13.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            
        context.Autobusi.AddOrUpdate(x => x.Id,
                new Models.Autobus() { Id = 1, OznakaLinije = "2", GodinaProizvodnje = 2008 },
                new Models.Autobus() { Id = 2, OznakaLinije = "9A", GodinaProizvodnje = 2020 },
                new Models.Autobus() { Id = 3, OznakaLinije = "9", GodinaProizvodnje = 2008 }
                ) ;

            context.Putnici.AddOrUpdate(x => x.Id,
                new Models.Putnik() { Id = 1, ImePrezime = "Jelena Petrovic", AdresaStanovanja = "Narodnog fronta 6", GodinaRodjenja = 1987, TipKarte = "Godisnja", AutobusId = 1 },
                new Models.Putnik() { Id = 2, ImePrezime = "Janko Lukic", AdresaStanovanja = "Lasla Gala 15", GodinaRodjenja = 1997, TipKarte = "Mesecna", AutobusId = 3 },
                new Models.Putnik() { Id = 3, ImePrezime = "Nikola Aleksic", AdresaStanovanja = "Radnicka 8", GodinaRodjenja = 1986, TipKarte = "Nedeljna", AutobusId = 1 },
                new Models.Putnik() { Id = 4, ImePrezime = "Luka Markovic", AdresaStanovanja = "Temerinska 23", GodinaRodjenja = 1998, TipKarte = "Nedeljna", AutobusId = 2 },
                new Models.Putnik() { Id = 5, ImePrezime = "Asleksandra Mirkovic", AdresaStanovanja = "Marka Miljanova 38", GodinaRodjenja = 1985, TipKarte = "Godisnja", AutobusId = 3 }
                );

         context.SaveChanges();
        }
    }
        
}
