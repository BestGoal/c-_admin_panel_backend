using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using EventsManagemtns.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EventsManagemtns.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SectorController : ControllerBase
    {


        private readonly DbContextImpl _ctx;
        public SectorController(DbContextImpl ctx)
        {
            _ctx = ctx;
        }

        // GET: api/<SectorController>
        [HttpGet]
        public IList<Sector> Get()
        {
            return _ctx.sectors.ToList();
        }

        // GET api/<SectorController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<SectorController>
        [HttpPost]
        public List<Sector> Post([FromBody] List<Sector> newSectors)
        {
            newSectors.ForEach(st =>
            {
                if (_ctx.sectors.Find(st.id) == null)
                {
                    _ctx.sectors.Add(st);
                }
            });
            _ctx.SaveChanges();
            return _ctx.sectors.ToList();
        }

        // PUT api/<SectorController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SectorController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
