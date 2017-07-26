using DVDLibraryDBWEB.Data.MockRepository;
using DVDLibraryDBWEB.Models.Tables;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVDLibraryDBWEB.Tests.IntegrationTests
{
    [TestFixture]
    public class DVDRepositoryMockTests
    {
        DVDRepositoryMock repo;

        [SetUp]
        public void Init()
        {
            repo = new DVDRepositoryMock();
        }

        [TearDown]
        public void resetRepo()
        {
            repo.DVDClearList();
        }
        [Test]
        public void CanLoadDVDsMock()
        {
            var dvds = repo.GetAllDVDs();

            Assert.AreEqual(2, dvds.Count());

            Assert.AreEqual("A Great Tale", dvds[1].Title);
            Assert.AreEqual(1, dvds[1].DVDId);
            Assert.AreEqual("Joe Smith", dvds[1].Director);
            Assert.AreEqual("PG-13", dvds[1].Rating);
            Assert.AreEqual("2012", dvds[1].ReleaseYear);
            Assert.AreEqual("This is a great tale stored in the mock repo", dvds[1].Notes);
        }

        [Test]
        public void CanLoadDVDByIdMock()
        {
            DVD dvd = repo.GetDVDById(1);

            Assert.AreEqual(1, dvd.DVDId);
            Assert.AreEqual("Joe Smith", dvd.Director);
            Assert.AreEqual("A Great Tale", dvd.Title);
            Assert.AreEqual("2012", dvd.ReleaseYear);
            Assert.AreEqual("PG-13", dvd.Rating);
            Assert.AreEqual("This is a great tale stored in the mock repo", dvd.Notes);
        }

        [Test]
        public void CanLoadDVDByTitleMock()
        {
            List<DVD> dvds = repo.GetDVDByTitle("A Great Tale");

            Assert.AreEqual(dvds.Count, 1);
            Assert.AreEqual(1, dvds[0].DVDId);
            Assert.AreEqual("Joe Smith", dvds[0].Director);
            Assert.AreEqual("A Great Tale", dvds[0].Title);
            Assert.AreEqual("2012", dvds[0].ReleaseYear);
            Assert.AreEqual("PG-13", dvds[0].Rating);
            Assert.AreEqual("This is a great tale stored in the mock repo", dvds[0].Notes);
        }

        [Test]
        public void CanLoadDVDByReleaseYearMock()
        {
            List<DVD> dvds = repo.GetDVDByYear("2012");

            Assert.AreEqual(dvds.Count, 1);
            Assert.AreEqual(1, dvds[0].DVDId);
            Assert.AreEqual("Joe Smith", dvds[0].Director);
            Assert.AreEqual("A Great Tale", dvds[0].Title);
            Assert.AreEqual("2012", dvds[0].ReleaseYear);
            Assert.AreEqual("PG-13", dvds[0].Rating);
            Assert.AreEqual("This is a great tale stored in the mock repo", dvds[0].Notes);
        }

        [Test]
        public void CanLoadDVDByRatingMock()
        {
            List<DVD> dvds = repo.GetDVDByRating("PG-13");

            Assert.AreEqual(dvds.Count, 1);
            Assert.AreEqual(1, dvds[0].DVDId);
            Assert.AreEqual("Joe Smith", dvds[0].Director);
            Assert.AreEqual("A Great Tale", dvds[0].Title);
            Assert.AreEqual("2012", dvds[0].ReleaseYear);
            Assert.AreEqual("PG-13", dvds[0].Rating);
            Assert.AreEqual("This is a great tale stored in the mock repo", dvds[0].Notes);
        }

        [Test]
        public void CanLoadDVDByDirectorMock()
        {
            List<DVD> dvds = repo.GetDVDByDirector("Joe Smith");

            Assert.AreEqual(dvds.Count, 1);
            Assert.AreEqual(1, dvds[0].DVDId);
            Assert.AreEqual("Joe Smith", dvds[0].Director);
            Assert.AreEqual("A Great Tale", dvds[0].Title);
            Assert.AreEqual("2012", dvds[0].ReleaseYear);
            Assert.AreEqual("PG-13", dvds[0].Rating);
            Assert.AreEqual("This is a great tale stored in the mock repo", dvds[0].Notes);
        }

        [Test]
        public void NotFoundDVDReturnsNullMock()
        {
            DVD dvd = repo.GetDVDById(2000000);

            Assert.IsNull(dvd);
        }

        [Test]
        public void CanCreateDVDMock()
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
        public void CanUpdateDVDMock()
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

            dvd.Director = "Steve Brannon";
            dvd.Notes = "This movie isn't any good.";
            dvd.Rating = "PG";
            dvd.Title = "The Nice Gardener";
            dvd.ReleaseYear = "2017";

            repo.DVDUpdate(dvd);

            var updatedDVD = repo.GetDVDById(2);

            Assert.AreEqual(2, updatedDVD.DVDId);
            Assert.AreEqual("The Nice Gardener", updatedDVD.Title);
            Assert.AreEqual("PG", updatedDVD.Rating);
            Assert.AreEqual("This movie isn't any good.", updatedDVD.Notes);
            Assert.AreEqual("2017", updatedDVD.ReleaseYear);
            Assert.AreEqual("Steve Brannon", updatedDVD.Director);

        }

        [Test]
        public void CanDeleteDVDMock()
        {
            DVD dvd = new DVD
            {
                Title = "The Terminator",
                Rating = "R",
                ReleaseYear = "1981",
                Director = "James Cameron",
                Notes = "Cyborg from the future kills people and a dog."
            };

            DVDRepositoryMock repo = new DVDRepositoryMock();

            repo.DVDCreate(dvd);

            var newDVD = repo.GetDVDById(2);

            Assert.IsNotNull(newDVD);

            repo.DVDDelete(2);

            Assert.IsNull(repo.GetDVDById(2));

        }

    }
}
