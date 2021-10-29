using System;
using System.Collections.Generic;
using System.Linq;
using Domain;
using EventsManagemtns.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EventsManagemtns.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SectionsController : ControllerBase
    {

        private readonly DbContextImpl _ctx;
        public SectionsController(DbContextImpl ctx)
        {
            _ctx = ctx;
        }

        // GET: api/<SectionsController>
        [HttpGet]
        public List<Section> Get()
        {
            return _ctx.sections.ToList();
        }

        // GET api/<SectionsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<SectionsController>
        [HttpPost]
        public List<Section> Post([FromBody] List<Section> sections)
        {
            sections.ForEach(st =>
            {
                if (_ctx.sections.Find(st.id) == null)
                {
                    _ctx.sections.Add(st);
                }
            });
            _ctx.SaveChanges();
            return _ctx.sections.ToList();
            
        }

        // PUT api/<SectionsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SectionsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
