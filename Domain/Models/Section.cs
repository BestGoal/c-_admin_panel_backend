using EventsManagemtns.Controllers;
using System.Collections.Generic;

namespace EventsManagemtns.Models
{
    public class Section
    {

        public int id { get; set; }

        public string name { get; set; }

        public IList<Employee> employees { get; set; }

        public IList<Tasks> tasks { get; set; }
    }
}