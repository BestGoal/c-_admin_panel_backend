using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EventsManagemtns.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrganizationController : ControllerBase
    {

        private readonly DbContextImpl _ctx;
        public OrganizationController(DbContextImpl ctx)
        {
            _ctx = ctx;
        }
        // GET: api/<OrganizationController>
        [HttpGet]
        public IList<Organization> Get()
        {

           return _ctx.organizations.ToList();
        }

        // GET api/<OrganizationController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<OrganizationController>
        [HttpPost]
        public Organization Post([FromBody] Organization neworg)
        {
            _ctx.organizations.Add(neworg);
            _ctx.SaveChanges();
            return neworg;
        }

        // PUT api/<OrganizationController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<OrganizationController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
