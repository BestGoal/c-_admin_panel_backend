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
    public class CountriesController : ControllerBase
    {
        private readonly DbContextImpl context;
        public CountriesController(DbContextImpl contextImpl) {
            context = contextImpl;
        }
        // GET: api/<CountriesController>
        [HttpGet]
        public IEnumerable<object> Get()
        {
            var enumerable = context.Countries.ToList().Select(x=> new 
            { 
                x.CountryName,
                x.Contenant,
                x.Id
            });

            return enumerable;
        }

        // GET api/<CountriesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CountriesController>
        [HttpPost]
        public void Post([FromBody] List<Country> countries)
        {
            context.Countries.AddRange(countries);
            context.SaveChanges();

        }

        // PUT api/<CountriesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CountriesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
