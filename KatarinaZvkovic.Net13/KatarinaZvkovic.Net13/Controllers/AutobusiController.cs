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
    public class AutobusiController : ApiController
    {
        IAutobusRepository repo { get; set; }
        public AutobusiController(IAutobusRepository repository)
        {
            repo = repository;
        }

        public IEnumerable<Autobus> Get()
        {
            return repo.GetAll();
        }

        [ResponseType(typeof(Autobus))]
        public IHttpActionResult GetId(int id)
        {
            var res = repo.GetId(id);
            if (res == null)
            {
                return NotFound();
            }
            return Ok(res);
        }
        [Route("api/tradicija")]
        [ResponseType(typeof(IEnumerable<Autobus>))]
        public IHttpActionResult GetAllSortYear()
        {
            var res = repo.GetAllSorted();
            if (res == null)
            {
                return NotFound();
            }
            return Ok(res);
        }

        public IEnumerable<Autobus> GetByOznaka(string oznaka)
        {
            return repo.GetAllByOznaka(oznaka);
        }

    }
}
