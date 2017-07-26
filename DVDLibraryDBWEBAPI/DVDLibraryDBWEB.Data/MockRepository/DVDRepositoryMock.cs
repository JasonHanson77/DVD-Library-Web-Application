using DVDLibraryDBWEB.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVDLibraryDBWEB.Models.Tables;

namespace DVDLibraryDBWEB.Data.MockRepository
{
    public class DVDRepositoryMock : IDVDRepository
    {
        private static List<DVD> _dvds = new List<DVD>();

        private static DVD MockDVDOne = new DVD
        {
            DVDId = 0,
            Title = "A Good Tale",
            Director = "Sam Jones",
            Rating = "PG",
            ReleaseYear = "2015",
            Notes = "This is a good tale stored in the mock repo"
        };

        private static DVD MockDVDTwo = new DVD
        {
            DVDId = 1,
            Title = "A Great Tale",
            Director = "Joe Smith",
            Rating = "PG-13",
            ReleaseYear = "2012",
            Notes = "This is a great tale stored in the mock repo"
        };

        public DVDRepositoryMock()
        {
            if(_dvds.Count() == 0)
            {
                _dvds.Add(MockDVDOne);
                _dvds.Add(MockDVDTwo);
            }
        }

        public void DVDClearList()
        {
            _dvds.Clear();
        }

        public void DVDCreate(DVD dvd)
        {
            dvd.DVDId = _dvds.Max(d => d.DVDId) + 1;

            _dvds.Add(dvd);
        }

        public void DVDDelete(int DVDId)
        {
            DVD dvd = _dvds.FirstOrDefault(d => d.DVDId == DVDId);

            _dvds.Remove(dvd);
        }

        public void DVDUpdate(DVD dvd)
        {
            int index = _dvds.FindIndex(d => d.DVDId == dvd.DVDId);

            _dvds.RemoveAt(index);

            _dvds.Insert(index, dvd);

        }

        public List<DVD> GetAllDVDs()
        {
            return _dvds;
        }

        public List<DVD> GetDVDByDirector(string Director)
        {
            return _dvds.Where(d => d.Director == Director).ToList(); ;
        }

        public DVD GetDVDById(int DVDId)
        {
            return _dvds.FirstOrDefault(d => d.DVDId == DVDId);
        }

        public List<DVD> GetDVDByRating(string Rating)
        {
            return _dvds.Where(d => d.Rating == Rating).ToList(); ;
        }

        public List<DVD> GetDVDByTitle(string Title)
        {
            return _dvds.Where(d => d.Title == Title).ToList(); 
        }

        public List<DVD> GetDVDByYear(string Year)
        {
            return _dvds.Where(d => d.ReleaseYear == Year).ToList(); 
        }
    }

}
