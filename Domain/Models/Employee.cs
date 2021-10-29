using EventsManagemtns.Models;
using System.Collections;
using System.Collections.Generic;
using System.Security.AccessControl;
using System.Threading.Tasks;

namespace EventsManagemtns.Controllers
{
    public class Employee
    {
        public int id { get; set; }
        public string name { get; set; }
        public int SectionID { get; set; }
        public int eid { get; set; }
        public IList<Role> roles { get; set; }
        public IList<Tasks> tasks { get; set; }
    }
}