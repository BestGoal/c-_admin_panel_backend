using EventsManagemtns.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventsManagemtns.Models
{
    public class Sector
    {
        public int id { get; set; }
        public string name { get; set; }
        public IList<Organization> organizations { get; set; }
    }
}
