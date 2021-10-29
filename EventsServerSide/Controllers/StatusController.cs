using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventsManagemtns.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusController : ControllerBase
    {

        private readonly DbContextImpl dbContext;

        public StatusController(DbContextImpl impl)
        {
            dbContext = impl;
        }

        // GET: api/Status
        [HttpGet]
        public List<Status> Get()
        {
            return dbContext.statuses.ToList();
        }

        // GET: api/Status/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Status
        [HttpPost]
        public Status Post([FromBody] Status value)
        {
            dbContext.statuses.Add(value);
            dbContext.SaveChanges();
            return value;
        }

        // PUT: api/Status/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
