using AutoMapper.QueryableExtensions;
using KatarinaZvkovic.Net13.Intrfaces;
using KatarinaZvkovic.Net13.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace KatarinaZvkovic.Net13.Controllers
{
    public class PutniciController : ApiController
    {
        IPutnikRepository repo { get; set; }
        public PutniciController(IPutnikRepository repository)
        {
            repo = repository;
        }
        public IEnumerable<PutnikDTO> Get()
        {
            return repo.GetAll().ProjectTo<PutnikDTO>();
        }

        [ResponseType(typeof(Putnik))]
        public IHttpActionResult GetFestival(int id)
        {
            var fest = repo.GetId(id);
            if (fest == null)
            {
                return NotFound();
            }
            return Ok(fest);
        }

        [Authorize]
        public IHttpActionResult Post(Putnik putnik)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            repo.Add(putnik);
            return CreatedAtRoute("DefaultApi", new { id = putnik.Id }, putnik);
        }
        [Authorize]
        public IHttpActionResult Put(int id, Putnik putnik)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != putnik.Id)
            {
                return BadRequest();
            }
            try
            {
                repo.Update(putnik);
            }
            catch
            {
                return BadRequest();
            }
            return Ok(putnik);
        }
        [Authorize]
        public IHttpActionResult Delete(int id)
        {
            var festival = repo.GetId(id);
            if (festival == null)
            {
                return NotFound();

            }
            repo.Delete(festival);
            return Ok();
        }
        [Authorize]
        [ResponseType(typeof(IEnumerable<PutnikDTO>))]
        public IHttpActionResult GetbyAdress(string oznaka)
        {
            var fest = repo.SearchByAdress(oznaka).ProjectTo<PutnikDTO>();
            if (fest == null)
            {
                return NotFound();
            }
            return Ok(fest);
        }

        [Authorize]
        [Route("api/pretraga")]
        [ResponseType(typeof(IEnumerable<PutnikDTO>))]
        [HttpPost]
        public IHttpActionResult SearchByMedals(PretragaDTO pretraga)
        {
            IQueryable<PutnikDTO> res = repo.SearchByYear(pretraga.Start, pretraga.End).
            AsQueryable().ProjectTo<PutnikDTO>();

            if (res == null)
            {
                return NotFound();
            }
            return Ok(res);
        }
        [ResponseType(typeof(IEnumerable<PutnikDTO>))]
        [Route("api/brojnost")]
        public IHttpActionResult GetSumYear()
        {
            var res = repo.GetAllCompSum();
            if (res == null)
            {
                return NotFound();
            }
            return Ok(res);
        }

    }
}
