using DVDLibraryDBWEB.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVDLibraryDBWEB.Data.Interfaces
{
    public interface IDVDRepository
    {
        List<DVD> GetAllDVDs();

        DVD GetDVDById(int DVDId);
        List<DVD> GetDVDByTitle(string Title);
        List<DVD> GetDVDByYear(string Year);
        List<DVD> GetDVDByDirector(string Director);
        List<DVD> GetDVDByRating(string Rating);

        void DVDCreate(DVD dvd);
        void DVDUpdate(DVD dvd);
        void DVDDelete(int DVDId);
    }
}
