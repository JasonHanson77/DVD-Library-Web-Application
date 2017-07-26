namespace DVDLibraryDBWEBAPI.Migrations
{
    using DVDLibraryDBWEB.Models.Tables;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DVDContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DVDContext context)
        {
            context.DVD.AddOrUpdate(
            d => d.DVDId,
            new DVD
            {
                DVDId = 0,
                Title = "The Good Tale",
                Rating = "PG",
                ReleaseYear = "2012",
                Notes = "This is a Good Tale",
                Director = "Sam Jones"
            },

            new DVD
            {
                DVDId = 1,
                Title = "The Great Tale",
                Rating = "PG-13",
                ReleaseYear = "2015",
                Notes = "This is a Great Tale",
                Director = "Joe Smith"
            },

            new DVD
            {
                DVDId = 2,
                Title = "The Entity Tale",
                Rating = "R",
                ReleaseYear = "2013",
                Notes = "This is a tale about the Entity Framework",
                Director = "Sam Jones"
            }

        );
        }
    }
}
