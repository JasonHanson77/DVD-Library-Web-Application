using DVDLibraryDBWEB.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVDLibraryDBWEB.Models.Tables;
using System.Data.Entity;

namespace DVDLibraryDBWEB.Data.EntityFramework
{
    public class DVDRepositoryEF : IDVDRepository
    {
        private DVDContext _dvdContext;

        public DVDRepositoryEF(DVDContext DVDContext) 
        {
            this._dvdContext = DVDContext;
        }

        static DVDRepositoryEF()
        {
            DVDContext context = new DVDContext();
            context.Database.ExecuteSqlCommand("exec DbResetEntity");
        }

        public void DVDCreate(DVD dvd)
        {
            _dvdContext.DVD.Add(dvd);

            _dvdContext.SaveChanges();
        }

        public void DVDDelete(int DVDId)
        {
            DVD dvd = _dvdContext.DVD.ToList().FirstOrDefault(d => d.DVDId == DVDId);

            _dvdContext.DVD.Remove(dvd);

            _dvdContext.SaveChanges();
        }

        public void DVDUpdate(DVD dvd)
        {
            _dvdContext.Entry(dvd).State = EntityState.Modified;

            _dvdContext.SaveChanges();


        }

        public List<DVD> GetAllDVDs()
        {
            return _dvdContext.DVD.ToList();
        }

        public List<DVD> GetDVDByDirector(string Director)
        {
            return _dvdContext.DVD.AsEnumerable().Where(d => d.Director == Director).ToList();
        }

        public DVD GetDVDById(int DVDId)
        {
            return _dvdContext.DVD.FirstOrDefault(d => d.DVDId == DVDId);
        }

        public List<DVD> GetDVDByRating(string Rating)
        {
            return _dvdContext.DVD.AsEnumerable().Where(d => d.Rating == Rating).ToList();
        }

        public List<DVD> GetDVDByTitle(string Title)
        {
            return _dvdContext.DVD.AsEnumerable().Where(d => d.Title == Title).ToList();
        }

        public List<DVD> GetDVDByYear(string Year)
        {
            return _dvdContext.DVD.AsEnumerable().Where(d => d.ReleaseYear == Year).ToList();
        }
    }
}
