using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using Microsoft.VisualBasic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EventsManagemtns.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AptsController : ControllerBase
    {

        private readonly DbContextImpl context;
        public AptsController(DbContextImpl impl) {
            context = impl;
        }
        // GET: api/<AptsController>
        [HttpGet]
        public List<APT> Get() {
            List<APT> lists
               = context.Apts.Include(x => x.TargetedCountries)
                .Include(x => x.OriginCountries)
                .Include(x => x.ThreatSignatures)
                .Include(x => x.AlternativeNames)
                .Include(x => x.CompanyNames)
                .Include(x => x.ToolsNames)
                .Include(x => x.TargetSectorNames)
                .Include(x => x.Contents)
                .Include(x => x.Attachments)
                .ToList();


            return lists;

    }

        // GET api/<AptsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<AptsController>
        [HttpPost]
        public void Post([FromBody] APT apt)
        {
            List<Country> targetedCountries = new List<Country>();
            List<Country> originCountry = new List<Country>();


            foreach (Country c in apt.TargetedCountries)
            {
                targetedCountries.Add(context.Countries.Find(c.Id));
            }
            foreach (Country c in apt.OriginCountries)
            {
                originCountry.Add(context.Countries.Find(c.Id));
            }
            apt.OriginCountries = originCountry;
            apt.TargetedCountries = targetedCountries;

            context.Apts.Add(apt);
            context.SaveChanges();
        }

        // PUT api/<AptsController>/5
        [HttpPut]
        public void Put([FromBody] APT newAPT)
        {

            // define un-known type thats pointing to apt
            var queryables = context.Apts.Where(x => x.id == newAPT.id).Select(a => new
            {
                id = a.id,
                AlternativeNames = a.AlternativeNames.ToList(),
                ThreatSignatures = a.ThreatSignatures.ToList(),
                Name = a.Name,
                date = a.Date,
                Contents = a.Contents.ToList(),
                OriginCountries = a.OriginCountries.ToList(),
                TargetedCountries = a.TargetedCountries.ToList(),
                CompanyNames = a.CompanyNames.ToList(),
                toolsNames = a.ToolsNames.ToList(),
                targetSectorNames = a.TargetSectorNames.ToList(),

            });

            // convert the unkonwn type to APT
            var lists = queryables.AsEnumerable().Select(x => new APT
            {
                AlternativeNames = x.AlternativeNames,
                CompanyNames = x.CompanyNames,
                ToolsNames = x.toolsNames,
                TargetSectorNames = x.targetSectorNames,
                id = x.id,
                Name = x.Name,
                Date = x.date,
                Contents = x.Contents,
                OriginCountries = x.OriginCountries,
                ThreatSignatures = x.ThreatSignatures,
                TargetedCountries = x.TargetedCountries
            }).ToList();


            
            APT aPT = lists.ElementAt(0);

            List<Country> targetedCountries = new List<Country>();
            List<Country> originCountry = new List<Country>();


            foreach (Country c in newAPT.TargetedCountries)
            {
                targetedCountries.Add(context.Countries.Find(c.Id));
            }

            foreach (Country c in newAPT.OriginCountries)
            {
                originCountry.Add(context.Countries.Find(c.Id));
            }

            context.Entry(aPT).CurrentValues.SetValues(newAPT);
            context.SaveChanges();
        }

        // DELETE api/<AptsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
