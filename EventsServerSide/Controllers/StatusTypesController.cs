using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;
using Domain;
using EventsManagemtns.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EventsManagemtns.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusTypesController : ControllerBase
    {

        private readonly DbContextImpl context;

        public StatusTypesController(DbContextImpl impl) {
            context = impl;        
        }

        // GET: api/<StatusTypesController>
        [HttpGet]
        public List<StatusType> Get()
        {
            return context.statusTypes.ToList();
        }

        // GET api/<StatusTypesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<StatusTypesController>
        [HttpPost]
        public List<StatusType> Post([FromBody] List<StatusType> comingList)
        {
            comingList.ForEach(st =>
            {
                if (context.statusTypes.Find(st.id) == null)
                {
                    context.statusTypes.Add(st);
                }
            });
           
            context.SaveChanges();
            return context.statusTypes.ToList();
        }

        // PUT api/<StatusTypesController>/5
        [HttpPut]
        public void Put([FromBody] StatusType value)
        {

            StatusType statusType = context.statusTypes.Where(x => x.id == value.id).SingleOrDefault();
            //statusType.statuses = value.statuses;
            context.statusTypes.Add(statusType);
            context.SaveChanges();


        }

        // DELETE api/<StatusTypesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {

        }
    }
}
