using DVDLibraryDBWEB.Data.EntityFramework;
using DVDLibraryDBWEB.Models.Tables;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVDLibraryDBWEB.Tests.IntegrationTests
{
    [TestFixture]
    public class DVDLibraryDBWEBEFTests
    {
        private DVDRepositoryEF repo;

        private DVDContext context = new DVDContext();

        [SetUp]
        public void Init()
        {
            repo = new DVDRepositoryEF(context);
        }

        [TearDown]
        public void ResetDB()
        {
            context.Database.ExecuteSqlCommand("exec DbResetEntity");
        }

        [Test]
        public void CanLoadDVDsEF()
        {
            var dvds = repo.GetAllDVDs();

            Assert.AreEqual(3, dvds.Count());

            Assert.AreEqual("The Great Tale", dvds[1].Title);
            Assert.AreEqual(1, dvds[1].DVDId);
            Assert.AreEqual("Joe Smith", dvds[1].Director);
            Assert.AreEqual("PG-13", dvds[1].Rating);
            Assert.AreEqual("2015", dvds[1].ReleaseYear);
            Assert.AreEqual("This is a Great Tale", dvds[1].Notes);
        }

        [Test]
        public void CanLoadDVDByIdEF()
        {
            DVD dvd = repo.GetDVDById(1);

            Assert.AreEqual("The Great Tale", dvd.Title);
            Assert.AreEqual(1, dvd.DVDId);
            Assert.AreEqual("Joe Smith", dvd.Director);
            Assert.AreEqual("PG-13", dvd.Rating);
            Assert.AreEqual("2015", dvd.ReleaseYear);
            Assert.AreEqual("This is a Great Tale", dvd.Notes);
        }

        [Test]
        public void CanLoadDVDByTitleEF()
        {
            List<DVD> dvds = repo.GetDVDByTitle("The Great Tale");

            Assert.AreEqual(dvds.Count, 1);
            Assert.AreEqual("The Great Tale", dvds[0].Title);
            Assert.AreEqual(1, dvds[0].DVDId);
            Assert.AreEqual("Joe Smith", dvds[0].Director);
            Assert.AreEqual("PG-13", dvds[0].Rating);
            Assert.AreEqual("2015", dvds[0].ReleaseYear);
            Assert.AreEqual("This is a Great Tale", dvds[0].Notes);
        }

        [Test]
        public void CanLoadDVDByRatingEF()
        {
            List<DVD> dvds = repo.GetDVDByRating("PG-13");

            Assert.AreEqual(dvds.Count, 1);
            Assert.AreEqual("The Great Tale", dvds[0].Title);
            Assert.AreEqual(1, dvds[0].DVDId);
            Assert.AreEqual("Joe Smith", dvds[0].Director);
            Assert.AreEqual("PG-13", dvds[0].Rating);
            Assert.AreEqual("2015", dvds[0].ReleaseYear);
            Assert.AreEqual("This is a Great Tale", dvds[0].Notes);
        }

        [Test]
        public void CanLoadDVDByReleaseYearEF()
        {
            List<DVD> dvds = repo.GetDVDByYear("2015");

            Assert.AreEqual(dvds.Count, 1);
            Assert.AreEqual("The Great Tale", dvds[0].Title);
            Assert.AreEqual(1, dvds[0].DVDId);
            Assert.AreEqual("Joe Smith", dvds[0].Director);
            Assert.AreEqual("PG-13", dvds[0].Rating);
            Assert.AreEqual("2015", dvds[0].ReleaseYear);
            Assert.AreEqual("This is a Great Tale", dvds[0].Notes);
        }

        [Test]
        public void CanLoadDVDByDirectorEF()
        {
            List<DVD> dvds = repo.GetDVDByDirector("Joe Smith");

            Assert.AreEqual(dvds.Count, 1);
            Assert.AreEqual(1, dvds[0].DVDId);
            Assert.AreEqual("Joe Smith", dvds[0].Director);
            Assert.AreEqual("The Great Tale", dvds[0].Title);
            Assert.AreEqual("2015", dvds[0].ReleaseYear);
            Assert.AreEqual("PG-13", dvds[0].Rating);
            Assert.AreEqual("This is a Great Tale", dvds[0].Notes);
        }

        [Test]
        public void NotFoundDVDReturnsNullEF()
        {
            DVD dvd = repo.GetDVDById(2000000);

            Assert.IsNull(dvd);
        }

        [Test]
        public void CanCreateDVDEF()
        {
            DVD dvd = new DVD
            {
                Title = "The Terminator",
                Rating = "R",
                ReleaseYear = "1981",
                Director = "James Cameron",
                Notes = "Cyborg from the future kills people and a dog."
            };

            repo.DVDCreate(dvd);

            Assert.AreEqual(2, dvd.DVDId);
            Assert.AreEqual("The Terminator", dvd.Title);
            Assert.AreEqual("R", dvd.Rating);
            Assert.AreEqual("Cyborg from the future kills people and a dog.", dvd.Notes);
            Assert.AreEqual("1981", dvd.ReleaseYear);
            Assert.AreEqual("James Cameron", dvd.Director);

        }

        [Test]
        public void CanUpdateDVDEF()
        {
            DVD dvd = new DVD
            {
                Title = "The Terminator",
                Rating = "R",
                ReleaseYear = "1981",
                Director = "James Cameron",
                Notes = "Cyborg from the future kills people and a dog."
            };

            DVDContext context = new DVDContext();

            DVDRepositoryEF repo = new DVDRepositoryEF(context);

            repo.DVDCreate(dvd);

            dvd.Director = "Steve Brannon";
            dvd.Notes = "This movie isn't any good.";
            dvd.Rating = "PG";
            dvd.Title = "The Nice Gardener";
            dvd.ReleaseYear = "2017";

            repo.DVDUpdate(dvd);

            var updatedDVD = repo.GetDVDById(3);

            Assert.AreEqual(repo.GetAllDVDs().Count, 4);
            Assert.AreEqual(3, updatedDVD.DVDId);
            Assert.AreEqual("The Nice Gardener", updatedDVD.Title);
            Assert.AreEqual("PG", updatedDVD.Rating);
            Assert.AreEqual("This movie isn't any good.", updatedDVD.Notes);
            Assert.AreEqual("2017", updatedDVD.ReleaseYear);
            Assert.AreEqual("Steve Brannon", updatedDVD.Director);

        }

        [Test]
        public void CanDeleteDVDEF()
        {
            DVD dvd = new DVD
            {
                Title = "The Terminator",
                Rating = "R",
                ReleaseYear = "1981",
                Director = "James Cameron",
                Notes = "Cyborg from the future kills people and a dog."
            };

            repo.DVDCreate(dvd);

            var newDVD = repo.GetDVDById(2);

            Assert.IsNotNull(newDVD);

            repo.DVDDelete(2);

            Assert.IsNull(repo.GetDVDById(2));

        }

    }
}
