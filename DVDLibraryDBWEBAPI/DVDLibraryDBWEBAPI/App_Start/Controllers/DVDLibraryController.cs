using DVDLibraryDBWEB.Data.Interfaces;
using DVDLibraryDBWEB.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web.Http;
using System.Web.Http.Cors;

namespace DVDLibraryDBWEBAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class DVDLibraryController : ApiController
    {
        IDVDRepository _repository;

        public DVDLibraryController(IDVDRepository repository)
        {
            _repository = repository;
        }

        [Route("dvds")]
        [AcceptVerbs("GET")]
        public IEnumerable<DVD> GetAllDVDs()
        {
            return _repository.GetAllDVDs();
        }

        [Route("dvd/{dvdId}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult Get(int DVDId)
        {
            var dvd = _repository.GetDVDById(DVDId);
            if (dvd == null)
            {
                return NotFound();
            }
            return Ok(dvd);
        }

        [Route("dvds/title/{title}")]
        [AcceptVerbs("GET")]
    public IHttpActionResult GetDVDByTitle(string Title)
    {
        var dvds = _repository.GetDVDByTitle(Title);
        if (dvds.Count() == 0)
        {
            return NotFound();
        }
        return Ok(dvds);
    }

        [Route("dvds/year/{year}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetDVDByYear(string Year)
        {
            var dvds = _repository.GetDVDByYear(Year);
            if (dvds.Count() == 0)
            {
                return NotFound();
            }
            return Ok(dvds);
        }

        [Route("dvds/rating/{rating}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetDVDByRating(string Rating)
        {
            var dvds = _repository.GetDVDByRating(Rating);
            if (dvds.Count() == 0)
            {
                return NotFound();
            }
            return Ok(dvds);
        }

        [Route("dvds/director/{director}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetDVDByDirector(string Director)
        {
            var dvds = _repository.GetDVDByDirector(Director);
            if (dvds.Count() == 0)
            {
                return NotFound();
            }
            return Ok(dvds);
        }


        [Route("dvd/{dvdId}")]
        [AcceptVerbs("PUT")]
        public IHttpActionResult Update(DVD dvd)
        {
             _repository.DVDUpdate(dvd);

            return Ok(dvd);
        }

        [Route("dvd/{dvdId}")]
        [AcceptVerbs("DELETE")]
        public IHttpActionResult Delete(int DVDId)
        {
            _repository.DVDDelete(DVDId);

            DVD dvd = _repository.GetDVDById(DVDId);

            if (dvd == null)
            {
                return Ok();
            }

            return InternalServerError();
        }

        [Route("dvd")]
        [AcceptVerbs("POST")]
        public IHttpActionResult Add(DVD dvd)
        {
            _repository.DVDCreate(dvd);

            return Ok(dvd);
        }

    }
}
