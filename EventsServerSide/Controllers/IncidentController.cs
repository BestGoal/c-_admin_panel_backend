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
    public class IncidentController : ControllerBase
    {
        private readonly DbContextImpl context;
        public IncidentController(DbContextImpl impl) {
            context = impl;
        }

        // GET: api/Incident
        [HttpGet]
        public List<Incident> Get()
        {
            var queryables = context.incidents.Select(a => new
            {
                id = a.id,
                category = a.category, 
                org = a.org,
                saverity = a.saverity,
                status = a.status, 
                Urgancey = a.Urgancey,
                IpAddresses = a.IpAddresses.ToList(),
                date = a.date,
                description = a.description,
                subject = a.subject,
                time = a.time,
            });

            var lists = queryables.AsEnumerable().Select(x => new Incident
            { 
                id = x.id,
                category = x.category,
                org = x.org,
                saverity = x.saverity,
                status = x.status,
                Urgancey = x.Urgancey,
                IpAddresses = x.IpAddresses,
                date = x.date,
                description = x.description,
                subject = x.subject,
                time = x.time,
            }).ToList();

            return lists;
        }

        // GET: api/Incident/5
        [HttpGet("{id}")]
        public Incident Get(int id)
        {
            return context.incidents.Find(id);
        }

        // POST: api/Incident
        [HttpPost]
        public void Post([FromBody] Incident value)
        {

            value.saverity = context.saverities.Find(value.saverity.id);
            value.category = context.categories.Find(value.category.id);
            value.Urgancey = context.urganceys.Find(value.Urgancey.id);
            value.org = context.organizations.Find(value.org.id);
            value.status = context.statuses.ToList().ElementAt(0);

            context.incidents.Add(value);
            context.SaveChanges();
        }

        // PUT: api/Incident/5
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
